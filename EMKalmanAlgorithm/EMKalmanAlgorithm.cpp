// This is the main DLL file.

#include "stdafx.h"

#include "EMKalmanAlgorithm.h"
#include <cmath>
using namespace System::Collections;
namespace EMKalmanAlgorithm {
	String^ DebugMatrix(NRMatrixDotNet ^m)
	{
		String^ output = gcnew String("");
		int nrows, ncols;
		nrows = m->NRows;
		ncols = m->NCols;
		for(int i = 0; i < nrows; i++){
			for(int j = 0; j < ncols; j++){
				output += String::Format("{0}, ",m->GetValue(i,j));
			}
			output += "\n";
		}
		return output;
	}
	double EMKalmanClass::KalmanSmoother() //return no if the algorithm needs to stop
	{
		//note: 11/24/2014 by  Lei Wang: if there is one day with no observation, it is only going to be prediction. 
		//following Shumway and Stoffer Page 258

		int t;

		double LogL = 0; //Log likelihood
		double term1, term2;

		//	y[t]->MarkBadRows(no_data_); //mark bad data to avoid calculation
		//
		//xtt[0] and p2[0] has been initilized 
		//forward kalman filter
		//make a copy of the initial values
		NRMatrixDotNet ^X0 = Xn[0] * 1;
		NRMatrixDotNet ^P0 = Pn[0] * 1;
		
		//copy the calibrated error term to the output R value
		sigma_out_ = sigma_;
		

		array<NRMatrixDotNet^> ^X2 = gcnew array<NRMatrixDotNet^>(nT + 1); //Xt|t  
		array<NRMatrixDotNet^> ^X1 = gcnew array<NRMatrixDotNet^>(nT + 1);//and Xt|t-1
		array<NRMatrixDotNet^> ^P1 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|t-1
		array<NRMatrixDotNet^> ^P2 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|t
		array<NRMatrixDotNet^> ^Pn1 = gcnew array<NRMatrixDotNet^>(nT + 1);; //Pt|n|n-1

		X2[0] = Xn[0] * 1;//create a new matrix
		P2[0] = Pn[0] * 1;

		NRMatrixDotNet ^PhiT = Phi->T();
		array<NRMatrixDotNet ^> ^Kt = gcnew array<NRMatrixDotNet^>(nT + 1);//Kalman gain, allowed to change over time
		//NRMatrixDotNet ^K;

		//calculate LogL 


		//following a3 to a7 in page 263 
		for (t = 1; t <= nT; t++){
			X1[t] = Phi * X2[t - 1]; //A3, prediction
			P1[t] = Phi * P2[t - 1] * PhiT + Q; //A4
			int nObs = y[t - 1]->NRows;//assuming all y(t) has the same number of observation points
			if (nObs > 0){
				NRMatrixDotNet ^I_obs = gcnew NRMatrixDotNet(nObs, nObs);
				I_obs->SetIdentity();
				NRMatrixDotNet ^R = I_obs * sigma_ *sigma_; //R is a diagnal matrix and the elements are 1/m of the variances sigma_
				NRMatrixDotNet ^R_inv = I_obs * (1.0 / sigma_ / sigma_);


				//A5 inverse of large matrix is approximated with Woodbury matrix identity
				NRMatrixDotNet ^MT = M[t - 1]->T();//M is zero based array
				NRMatrixDotNet ^MM = M[t - 1]; //matrix of M
				NRMatrixDotNet ^diff = y[t - 1] - MM * X1[t];
				/*woodbury formula:
				(A + UCV)^(-1) = A^(-1) + A^(-1) * U * (C^(-1) + V * A^(-1) * U)^(-1) * V * A^(-1)
				to replace (R + M1[t] * P1[t] * MT)->Inverse()*/
				//NRMatrixDotNet ^woodbury = R_inv - R_inv * MM * ((P1[t]->Inverse() + MT * R_inv * MM)->Inverse()) * MT * R_inv;
				NRMatrixDotNet ^woodbury = MatrixInverse(MM * P1[t] * MT + R);
				//LogL Equation 18
				term1 = Math::Log(MatrixDeterminant(MM * P1[t] * MT + R)); //18

				term2 = (diff->T() * woodbury * diff)->GetValue(0, 0);
				LogL += (term1 + term2) / (-2.0);

				//Kalman correction
				Kt[t] = P1[t] * MT * woodbury; //A5
				//Kt[t] = K;

				X2[t] = X1[t] + Kt[t] * diff; //A6
				P2[t] = P1[t] - Kt[t] * MM * P1[t]; //A7
				//String^ debugString = DebugMatrix(M1[t] * P1[t] * M1[t]->T() + R);
				//debugString = DebugMatrix(M1[t]);


			}
			else{
				X2[t] = X1[t]; //A6, no correction because there is no observation
				P2[t] = P1[t]; //A7, same

			}


		}
		if (LogL != LogL){//bad logL happened
			//no need to proceed
			return LogL;

		}
		else{
			//copy the calibrated values to alpha(s,t) before changing it
			for (t = 1; t <= nT; t++){
				if (Xn[t] == nullptr){
					continue;
				}
				for (int np = 0; np < p; np++){
					a_s_t->SetValue(t - 1, np, Xn[t]->GetValue(np, 0));
				}

			}
		}
	
		
		//the last time with observation is nT0
		int nT0 = nT;
		///for(nT0 = nT; nT0 > 0; nT0--) {if (y[nT0-1]->NRows > 0) break;}


		Xn[nT0] = X2[nT0] * 1; //Xt|n is Xt|t when t = n
		Pn[nT0] = P2[nT0] * 1;
						
		//calculate x (t|n) and Pt|n using the backward recursions
		
		NRMatrixDotNet ^I = gcnew NRMatrixDotNet(p, p);
		I->SetIdentity();
		if(y[nT0-1]->NRows == 0) {
			Pn1[nT0] = Phi * P2[nT0-1]; //A12
		}
		else{
			Pn1[nT0] = (I - Kt[nT0] * M[nT0 - 1]) * Phi * P2[nT0 - 1]; //A12
		}
	
		
	    NRMatrixDotNet ^J_1, ^J_2; //= gcnew array<NRMatrixDotNet^>(nT0 + 1); ; 

		for(t = nT0; t >= 1; t--){
			J_2 = P2[t-1] * PhiT * (P1[t]->Inverse()); //A8; note j[t-1] is here j[t], so j[t-2] will be from j[t-1]
			Xn[t-1] = X2[t-1] + J_2 * (Xn[t] - Phi * X2[t-1]); //A9
			Pn[t-1] = P2[t-1] + J_2 * (Pn[t] - P1[t]) * (J_2->T()); //A10
			if(t < nT0){ //skip t = n
				Pn1[t] = P2[t] * (J_2->T()) + J_1 * (Pn1[t+1] - Phi * P2[t]) * (J_2->T());//A11
			}
			J_1 = J_2;//time move down
		}
				
		
		double var = 0;
		var = 0;
		for(t = 1; t <= nT; t++){
			int nObs = y[t-1]->NRows; // get the number of observations
			if (nObs == 0) continue;
			NRMatrixDotNet^ term1 = y[t - 1] - M[t - 1] * Xn[t];
			NRMatrixDotNet^error = term1 * (term1->T()) + M[t - 1] * Pn[t] * (M[t - 1]->T()); //eq (14)
			var += error->Trace() / nObs;
			//var += MatrixDeterminant(error) / nObs;
		}
	

		sigma_ = Math::Sqrt(var / nT); //root mean square error

		//use equations 12, 13, 14 to update Phi, Q, R and estimate u = Xtn[0]
		
		NRMatrixDotNet ^B, ^A, ^C;
		t = 1;
		A = gcnew NRMatrixDotNet(p,p);
		A->Reset();
		B = gcnew NRMatrixDotNet(p,p);
		B->Reset();
		C = gcnew NRMatrixDotNet(p,p);
		C->Reset();
		
		
		for(t = 1; t <= nT; t++){
			A += Pn[t-1] + Xn[t-1] * (Xn[t-1]->T()); //(9)
			B += Pn1[t] + Xn[t] * (Xn[t-1]->T()); //(10)
			C += Pn[t] + Xn[t] * (Xn[t]->T());     //(11)
		
		}
		
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
		
		

		Phi = B * MatrixInverse(A);
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
		Q = (C - Phi * (B->T())) / nT;
		//note on July 2018: Does Phi have to be a diagnal matrix? If not, the prediction of one normative site is a function of 
		//all the sites? Does it make sense? 
		//this part will make Phi a diagnal matrix



		//E = Ptn[0];
		
		

		System::GC::Collect();
		System::GC::WaitForPendingFinalizers();
	
		return LogL;

	}
	void EMKalmanClass::EMKalmanFixSteps(int nStep)
	{
		Likelihood = gcnew ArrayList;
		double LogL, LogL1;
		LogL = -99999;
		double rate;
		int count = 0;
		for (count = 0; count < nStep; count++){
			LogL1 = LogL;
			DateTime t1 = DateTime::Now;
			LogL = KalmanSmoother();
			if (double::IsInfinity(LogL) || double::IsNaN(LogL) || double::IsNegativeInfinity(LogL))
			{
				break;
			}
			DateTime t2 = DateTime::Now;
			TimeSpan compTime = t2 - t1;
			Likelihood->Add(LogL);
		
			rate = (LogL - LogL1) / Math::Abs(LogL1);
			PrintMessageEvent1(String::Format("Iteration {0}, LogL = {1}, Convergence rate = {2}, error {3}, time {4} \n",
				count++, LogL, rate, sigma_, compTime));
		}
		PrintMessageEvent1(String::Format("EM algorithm done! Iteration {0}, LogL = {1}, Convergence rate = {2}, error {3}", count++, LogL, rate, sigma_));

	}
	
	int EMKalmanClass:: EMKalman(double error) //EM algorithm from kalman filter
	{
			
		Likelihood = gcnew ArrayList;
		double LogL;
		LogL = -99999;
		
		int count = 0;
		error_code_  = 0;
		//check the error only
		ArrayList ^errorList = gcnew ArrayList;
		ArrayList ^LogLList = gcnew ArrayList;
		error_code_ = 0;
		double std_LogL = 0;
		try
		{
			do{
				DateTime t1 = DateTime::Now;
				LogL = KalmanSmoother();
				if (count > 0)
				{
					double last_logl = Convert::ToDouble(LogLList[count - 1]);
					std_LogL += LogL - last_logl;
					//check the LogL value if LogL is going down or go to infinity, then something has been wrong
					//if (LogL < last_logl )
					//{
					//	error_code_ = -2;
					//	break;
					//}
					if ( LogL != LogL)
					{
						error_code_ = -1;
						break;
					}
					if (Math::Abs((LogL - last_logl) / std_LogL) < 0.0001){//stop condition is met
						error_code_ = 0;
						 
						break;
					}
					if (sigma_ < error)
					{
						error_code_ = 1;
						break;
					}

					/*	if (sigma_ > Convert::ToDouble(errorList[count - 1]) && count > 5)
						{
						//something is going wrong. return the false sign
						Successful_ = false;
						break;
						}
						if (Math::Abs(Convert::ToDouble(errorList[count - 1]) - sigma_) < error / 100
						&& Math::Abs(Convert::ToDouble(LogLList[count-1]) - LogL) < 0.1){//change rate is low, convergence occurs
						Successful_ = true;
						break;

						}*/
				}
				errorList->Add(sigma_);
				LogLList->Add(LogL);
				
				DateTime t2 = DateTime::Now;
				TimeSpan compTime = t2 - t1;
				PrintMessageEvent1(String::Format("Iteration {0},  error {1:0.####}, LogL {2:0.####}, time {3} \n",
					count++, sigma_, LogL, compTime));
			} while (1);
			if (error_code_ == 0)
			{
				//copy the newest calibration to the output
				//copy the calibrated values to alpha(s,t)
				int t;
				for (t = 1; t <= nT; t++){
					if (Xn[t] == nullptr){
						continue;
					}
					for (int np = 0; np < p; np++){
						Alpha_s_t->SetValue(t - 1, np, Xn[t]->GetValue(np, 0));
					}

				}
				//copy the calibrated error term to the output R value
				sigma_out_ = sigma_;
			}

			return count;
		}
		
		catch (Exception ^e){
			PrintMessageEvent1(e->Message );
			error_code_ = -4;
			return count;
		}
	}
	NRMatrixDotNet^ EMKalmanClass::Predict(NRMatrixDotNet ^hj)
	{
		//use the given hj to derive precition value
		int ndays = Xn->GetUpperBound(0);
		NRMatrixDotNet^ pPrediction = gcnew NRMatrixDotNet(ndays,1);
		for(int t = 1; t <= ndays; t++){
			pPrediction->SetValue(t - 1,0, (hj * Xn[t])->Determinant());
		}
		return pPrediction;
		
	}
}