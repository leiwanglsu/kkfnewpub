#include "stdafx.h"
#include "EMKalmanClass.h"


NRMatrixDotNet^ MatrixInverse(NRMatrixDotNet^ inMatrix) {
	//make a copy of the input matrix to double(,) matrix
	int nrows, ncols, i, j;
	nrows = inMatrix->NRows;
	ncols = inMatrix->NCols;
	array<double, 2>^ copyMatrix = gcnew array<double, 2>(nrows, ncols);


	for (i = 0; i < nrows; i++) {
		for (j = 0; j < ncols; j++) {
			copyMatrix[i, j] = inMatrix->GetValue(i, j);
		}
	}

	array<double, 2>^ copyMatrix1 = Accord::Math::Matrix::Inverse(copyMatrix);
	NRMatrixDotNet^ outMatrix = gcnew NRMatrixDotNet(nrows, ncols);
	for (i = 0; i < nrows; i++) {
		for (j = 0; j < ncols; j++) {
			outMatrix->SetValue(i, j, copyMatrix1[i, j]);

		}
	}
	return outMatrix;

}
double MatrixDeterminant(NRMatrixDotNet^ inMatrix) {
	//make a copy of the input matrix to double(,) matrix
	int nrows, ncols, i, j;
	nrows = inMatrix->NRows;
	ncols = inMatrix->NCols;
	array<double, 2>^ copyMatrix = gcnew array<double, 2>(nrows, ncols);


	for (i = 0; i < nrows; i++) {
		for (j = 0; j < ncols; j++) {
			copyMatrix[i, j] = inMatrix->GetValue(i, j);
		}
	}
	double dt = Accord::Math::Matrix::Determinant(copyMatrix);
	return dt;

}

void EMKalmanClassNew::Initialize(double u0, double phi, double e)
//the EM algorithm is initialized and ready to iterate
{
		int i;
		for (i = 0; i < p; i++) { //u is the initial system status of the kalman filter
			u->SetValue(i, 0, u0);
		}
		NRMatrixDotNet^ E = gcnew NRMatrixDotNet(p, p);

		E->SetIdentity();
		E = E * (e * e);
		Xn[0] = u; //initial value of the estimated x (s,t)
		Pn[0] = E; //initial value of the errors and uncertainty 


		Phi->SetIdentity();
		Phi = Phi * phi;

		Q_->SetIdentity(); //Q is the error matrix to be estimated 
		//Q_ = Q_ * (0 * 0); //set Q as the square of error' start from 0?
			
}
//following Shumway and Stoffer 
double EMKalmanClassNew::Iterate(array<NRMatrixDotNet ^> ^M, array<NRMatrixDotNet^>^ y, ArrayList^ R2)
/*M is the kriging function for each time t, R is the  Error at the n observation sites
discussion: since there is missing data problem, the observation error cannot be always be calculated for each location
can we assume all sites have the same amount of observation error for time t, so R(t) will be a time dependent diagnal 
matrix series. At each time, RT[t] will represent the mean observation error at time t
intially, RT can be set to a default error value 
*/

{
	int t;
	double LogL = 0; //Log likelihood
	double term1, term2;
	
	//make a copy of the initial values
	NRMatrixDotNet^ X0 = Xn[0] * 1;
	NRMatrixDotNet^ P0 = Pn[0] * 1;
	array<NRMatrixDotNet^>^ X2 = gcnew array<NRMatrixDotNet^>(nT + 1); //Xt|t  
	array<NRMatrixDotNet^>^ X1 = gcnew array<NRMatrixDotNet^>(nT + 1);//and Xt|t-1
	array<NRMatrixDotNet^>^ P1 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|t-1
	array<NRMatrixDotNet^>^ P2 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|t
	array<NRMatrixDotNet^>^ Pn1 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|n|n-1

	X2[0] = Xn[0] * 1;//create a new matrix by using the initial values of Xn, Pn
	P2[0] = Pn[0] * 1;

	NRMatrixDotNet^ PhiT = Phi->T();
	array<NRMatrixDotNet^>^ Kt = gcnew array<NRMatrixDotNet^>(nT + 1);//Kalman gain, allowed to change over time
	//calculate LogL 
	//forward kalman filter
	//following a3 to a7 in page 263 
	for (t = 1; t <= nT; t++) {
		X1[t] = Phi * X2[t - 1]; //A3, prediction
		P1[t] = Phi * P2[t - 1] * PhiT + Q_; //A4
		int nObs = y[t - 1]->NRows;
		if (nObs > 0) {
			
			NRMatrixDotNet^ I_obs = gcnew NRMatrixDotNet(nObs, nObs);
			I_obs->SetIdentity();
			NRMatrixDotNet^ R = I_obs * Convert::ToDouble(R2[R2->Count - 1]);
			NRMatrixDotNet^ R_inv = I_obs / Convert::ToDouble(R2[R2->Count - 1]);

			NRMatrixDotNet^ MT = M[t - 1]->T();//M is zero based array
			NRMatrixDotNet^ MM = M[t - 1]; //matrix of M
			NRMatrixDotNet^ diff = y[t - 1] - MM * X1[t];

			//equation A5
			
			//A5 inverse of large matrix is approximated with Woodbury matrix identity

			//woodbury formula:
			//(A + UCV)^(-1) = A^(-1) - A^(-1) * U * (C^(-1) + V * A^(-1) * U)^(-1) * V * A^(-1)
			//to replace (R + M1[t] * P1[t] * MT)->Inverse()
			//NRMatrixDotNet ^woodbury = R_inv - R_inv * MM * ((P1[t]->Inverse() + MT * R_inv * MM)->Inverse()) * MT * R_inv;
			NRMatrixDotNet^ woodbury1 = ((MM * P1[t] * MT + R))->Inverse();
			NRMatrixDotNet^ woodbury2 = MatrixInverse(MM * P1[t] * MT + R);
			//LogL Equation 18
			term1 = System::Math::Log(System::Math::Abs(woodbury2->Determinant())); //18

			term2 = (diff->T() * woodbury2 * diff)->GetValue(0, 0);
			LogL += (term1 + term2) / (-2.0);

			//Kalman correction
			Kt[t] = P1[t] * MT * woodbury2; //A5

			X2[t] = X1[t] + Kt[t] * diff; //A6

			P2[t] = P1[t] - Kt[t] * MM * P1[t]; //A7
			
		}
		else {

			X2[t] = X1[t]; //A6, no correction because there is no observation
			P2[t] = P1[t]; //A7, same
		}
	}

	
	//calculate x (t|n) and Pt|n using the backward recursions
	

	Xn[nT] = X2[nT] * 1; //Xt|n is Xt|t when t = n
	Pn[nT] = P2[nT] * 1;
	NRMatrixDotNet^ I = gcnew NRMatrixDotNet(p, p);
	I->SetIdentity();


	if (y[nT - 1]->NRows == 0) { //if there is no observation frorm the last time frame, there won't be a Kt
		Pn1[nT] = Phi * P2[nT - 1]; //A12
	}
	else {
		Pn1[nT] = (I - Kt[nT] * M[nT - 1]) * Phi * P2[nT - 1]; //A12
	}
	array<NRMatrixDotNet^>^ J =  gcnew array<NRMatrixDotNet^>(nT + 1);
	
	for (t = nT; t >= 1; t--) {
		J[t-1] = P2[t - 1] * PhiT * (P1[t]->Inverse()); //A8; note j[t-1] is here j[t], so j[t-2] will be from j[t-1]
		Xn[t - 1] = X2[t - 1] + J[t-1] * (Xn[t] - Phi * X2[t - 1]); //A9
		Pn[t - 1] = P2[t - 1] + J[t-1] * (Pn[t] - P1[t]) * (J[t-1]->T()); //A10
		
				
	}
	for (t = nT; t > 1; t--) {
		
		Pn1[t - 1] = P2[t - 1] * (J[t-2]->T()) + J[t-1] * (Pn1[t] - Phi * P2[t - 1]) * (J[t-2]->T());//A11

	}
//use equations 12, 13, 14 to update Phi, Q, R and estimate u = Xtn[0]
	double var = 0;
	
	double sigma_ = 0;
	int nNonZeroTimes = 0;
	for (t = 1; t <= nT; t++) {
		int nObs = y[t - 1]->NRows; // get the number of observations
		
		if (nObs > 0) {
				NRMatrixDotNet^ error1 = y[t-1] - M[t-1] * Xn[t];//
				double t1 = (error1->T() * error1)->Trace() / nObs;
				NRMatrixDotNet ^error3 = M[t-1] * Pn[t] * (M[t-1]->T());//Ptn[t] * M1[t]->T() * M1[t];////
				double t3 = error3->Trace() / nObs;
				
				sigma_ += t1 + t3;
				nNonZeroTimes++;
		}
	}
	R2->Add(sigma_ / nNonZeroTimes);

	NRMatrixDotNet^ B, ^ A, ^ C;
	t = 1;
	A = gcnew NRMatrixDotNet(p, p);
	A->Reset();
	B = gcnew NRMatrixDotNet(p, p);
	B->Reset();
	C = gcnew NRMatrixDotNet(p, p);
	C->Reset();


	for (t = 1; t <= nT; t++) {
		A += Pn[t - 1] + Xn[t - 1] * (Xn[t - 1]->T()); //(9)
		B += Pn1[t] + Xn[t] * (Xn[t - 1]->T()); //(10)
		C += Pn[t] + Xn[t] * (Xn[t]->T());     //(11)

	}
	Phi = B *( A->Inverse());
	Q_ = (C - Phi * (B->T())) / nT;
	System::GC::Collect();
	System::GC::WaitForPendingFinalizers();
	return LogL;
	//etimation of error R
	//Because there are bad data, one canot use the same number of observations
	//current assumption is to assume all observations having the same amount of error
	//one value sigma is calculated to create the 
	//assuming all observations have the same error to be estimated
	//if(FixedObservationError == false) //estimate the observation error R
	//{
	//	//R1 = R; //keep a copy of the last R
	//	
	//	sigma_ = 0;
	//	double var = 0;
	//	int nNonZero = 0;
	//	
	//	for(t = 1; t <= nT; t++){
	//		//sigma2 += var * missingList[t]->Count / m; //if there are missing values, the variance were not fully captured. 
	//		//We use the variance from the last step
	//		//to fill the missing part.
	//		int nObs = y[t-1]->NRows;
	//		if(nObs > 0){
	//			NRMatrixDotNet^ error1 = y[t-1] - M[t-1] * Xn[t];//
	//			double t1 = (error1->T() * error1)->Trace();
	//			NRMatrixDotNet ^error3 = M[t-1] * Pn[t] * (M[t-1]->T());//Ptn[t] * M1[t]->T() * M1[t];////
	//			double t3 = error3->Trace();
	//			var = t1 + t3;
	//			sigma_ += var / nObs / nT;
	//			++nNonZero;
	//		}
	//	}
	//		}

	//use the averaged sigma as the observation error term



	
	/*
	int i, j;
	for (i = 0; i <= Phi->NRows - 1; i++)
	{
		for (j = 0; j <= Phi->NCols - 1; j++)
		{
			if (i != j){
				Phi->SetValue(i, j, 0);
			}
		}

	}
	*/
	
	//note on July 2018: Does Phi have to be a diagnal matrix? If not, the prediction of one normative site is a function of 
	//all the sites? Does it make sense? 
	//this part will make Phi a diagnal matrix



	//E = Ptn[0];





	
}
