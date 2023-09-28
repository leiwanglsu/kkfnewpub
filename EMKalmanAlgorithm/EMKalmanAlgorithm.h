// EMKalmanAlgorithm.h

#pragma once

using namespace System;
using namespace NRMatrixNet;
using namespace System::Collections;

namespace EMKalmanAlgorithm {
	public delegate void PrintMatrix(NRMatrixDotNet^);
	public delegate void PrintMessage(String^);
	public delegate bool Stop();
	
	NRMatrixDotNet ^MatrixInverse(NRMatrixDotNet^ inMatrix){
		//make a copy of the input matrix to double(,) matrix
		int nrows, ncols, i, j;
		nrows = inMatrix->NRows;
		ncols = inMatrix->NCols;
		array<double, 2>^ copyMatrix = gcnew array<double, 2>(nrows, ncols);
	

		for (i = 0; i < nrows; i++){
			for (j = 0; j < ncols; j++){
				copyMatrix[i, j] = inMatrix->GetValue(i, j);
			}
		}
		
		array<double, 2>^ copyMatrix1 = Accord::Math::Matrix::Inverse(copyMatrix);
		NRMatrixDotNet^ outMatrix = gcnew NRMatrixDotNet(nrows, ncols);
		for (i = 0; i < nrows; i++){
			for (j = 0; j < ncols; j++){
				outMatrix->SetValue(i, j, copyMatrix1[i, j]);

			}
		}
		return outMatrix;

	}
	double MatrixDeterminant(NRMatrixDotNet^ inMatrix){
		//make a copy of the input matrix to double(,) matrix
		int nrows, ncols, i, j;
		nrows = inMatrix->NRows;
		ncols = inMatrix->NCols;
		array<double, 2>^ copyMatrix = gcnew array<double, 2>(nrows, ncols);


		for (i = 0; i < nrows; i++){
			for (j = 0; j < ncols; j++){
				copyMatrix[i, j] = inMatrix->GetValue(i, j);
			}
		}
		double dt = Accord::Math::Matrix::Determinant(copyMatrix);
		return dt;
		
	}
	public ref class EMKalmanClass
	{
		//parameters

		NRMatrixDotNet ^Q; 
		bool initialized_;
		double sigma_, sigma_out_;
		array<NRMatrixDotNet ^> ^M;
		//array<NRMatrixDotNet ^> ^r;
		NRMatrixDotNet ^Phi;
		double no_data_;
		NRMatrixDotNet ^u;
		bool stop_;
		int error_code_;
		//time series
		array<NRMatrixDotNet^> ^y; //observation data
		array<NRMatrixDotNet^> ^Pn; //Pt|n
		array<NRMatrixDotNet^> ^Xn; //Xt|n

		int nT, p;//p is the number of common fields p, m is the number of normative sites of the space-time field
		NRMatrixDotNet^ a_s_t;
	public:
		//controls
		property int ErrorCode{
			int get(){ return error_code_; }
		}
		bool FixedObservationError;
		//double Convergence_Error;
		ArrayList^ Likelihood;
		event PrintMatrix^ PrintMatrixEvent;
		event PrintMessage^ PrintMessageEvent1;
		event PrintMessage^ PrintMessageEvent2;
		event Stop ^ StopSign;
		property int nTimes{
			int get(){return nT;}
		}
	
		property bool IsInitialized{
			bool get(){ return initialized_; }
		}
		property int nFields{
			int get(){return p;}
		}
		property array<NRMatrixDotNet^>^ ObservationData{
			void set(array<NRMatrixDotNet^>^ xst){y = xst;}
		}
		property NRMatrixDotNet^ Alpha_s_t{ //this is the mean value u to be estimated
			NRMatrixDotNet^ get(){return a_s_t;}
		}
		property array<NRMatrixDotNet ^> ^H{ //m rows by p columns matrix, m is the number of observation
			void set(array<NRMatrixDotNet ^> ^h){M = h;}
			
		}

		property NRMatrixDotNet^ PHI{
			//void set(NRMatrixDotNet^ p){Phi = p;}
			NRMatrixDotNet^ get(){return Phi;}
		}
		property double R_SigmaE{ //R is the observation error
			void set(double e){ sigma_ = e; }
			double get(){ return sigma_out_; }
		}
		property NRMatrixDotNet ^ Q_SigmaN{ //Q is the model error
			//void set(NRMatrixDotNet ^n){ Q = n;}
			NRMatrixDotNet^ get(){return Q;}
		}
		property double BadData{
			void set(double d){no_data_ = d;}
		}
		EMKalmanClass() {
			initialized_ = false;
		}
		EMKalmanClass(int nTimes, int nPrincipals)
			: nT(nTimes), p(nPrincipals), initialized_(false)
		{
			u = gcnew NRMatrixDotNet(p, 1);
			Phi = gcnew NRMatrixDotNet(p, p);
			
			//R = gcnew NRMatrixDotNet(m, m);
			
			Q = gcnew NRMatrixDotNet(p, p);
			
			Pn = gcnew array<NRMatrixDotNet^>(nT + 1); ; //Pt|n
						
			Xn = gcnew array<NRMatrixDotNet^>(nT + 1); ; //Xt|n
			a_s_t = gcnew NRMatrixDotNet(nT, p); //a copy of alpha(s,t)
		}
		void Initialize(EMKalmanClass^ pOtherKKF){
			if (pOtherKKF == nullptr){
				throw "nullptr";
				return;
			}
			

			Phi = pOtherKKF->Phi * 1;
			Q = pOtherKKF->Q * 1;
			sigma_ = pOtherKKF->sigma_;
			Xn[0] = pOtherKKF->Xn[0] * 1;
			Pn[0] = pOtherKKF->Pn[0] * 1;
			initialized_ = true;
		}
	
		void Initialize(double u0, double p0, double phi, double r)
		{
			//Convergence_Error = error;
			
			int i;
			for(i = 0; i < p; i++){ //u is the initial system status of the kalman filter
				u->SetValue(i,0,u0);
			}
			NRMatrixDotNet ^E = gcnew NRMatrixDotNet(p,p);
			
			E->SetIdentity();
			E = E * p0;
			Xn[0] = u; //initial value of the estimated x (s,t)
			Pn[0] = E; //initial value of the error 
			
			 
			Phi->SetIdentity();
			Phi = Phi * phi;

			Q->SetIdentity(); //Q is the error matrix to be estimated 
			Q = Q * (r * r); //set Q the same as the initial value of R
			sigma_ = r; //R will be generated when it is necessary from sigma_
			initialized_ = true;
						
		}

		double KalmanSmoother();
		int EMKalman(double error);
		void EMKalmanFixSteps(int nStep);
		NRMatrixDotNet^ EMKalmanClass::Predict(NRMatrixDotNet ^hj);
	
	};


	
}
