// NRMatrixNet.h

#pragma once
#include "nr3.h"
#include "LUdcmp.h"
#include "eigen_sym.h"
#include "svd.h"
#include "gaussj.h"
#include "fitmrq.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Runtime::Serialization;
using namespace System::IO;

namespace NRMatrixNet {
	[Serializable]
	
	public ref class NRMatrixDotNet : public ISerializable
	{
		NRmatrix<double> *data_;
		//System::Collections::SortedList^ badRows_; //mark the rows for missing data
		
	
	public:

		NRMatrixDotNet(void);
		~NRMatrixDotNet(void);
		!NRMatrixDotNet();//finalizer
		NRMatrixDotNet( int nrows, int ncols);
		NRMatrixDotNet(System::Array^ pArray); //make a copy of the array from the input data
		void CreateFromArray(System::Array^ pArray);
	public:
		
		virtual void GetObjectData(SerializationInfo^ info, StreamingContext context);
		NRMatrixDotNet(SerializationInfo^ info, StreamingContext context);
		String^  ToString() override
		{
			 int numberElements = 100;
			 int count = 0;
			 String^ s = "";
			 int i, j;
			 int nrows = (*data_).nrows();
			 int ncols = (*data_).ncols();
			 for (i = 0; i < nrows; i++){
				 for (j = 0; j < ncols; j++) {
					 s += String::Format("{0},", (*data_)[i][j]);
					 if (count++ > numberElements) {
						 return s;
					 }
					 
				 }
				 s += "\n";
			 }
			 return s;

		}
		NRMatrixDotNet^ Clone() //make a copy of the matrix
		{
			int i,j, nrows, ncols;
			ncols = data_->ncols();
			nrows = data_->nrows();
			NRMatrixDotNet^ newMatrix = gcnew NRMatrixDotNet(nrows,ncols);
		
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*newMatrix->data_)[i][j] = (*data_)[i][j];
				
				}
			}
			return newMatrix;

		};
		

		void Resize(int nrows, int ncols)
		{
			data_->resize (nrows, ncols);
		}
	 	
	
		property int NRows{
			int get(){if(data_) return data_->nrows(); else return 0;}
		}
		property int NCols{
			int get(){if(data_) return data_->ncols(); else return 0;}
		}
		void SetIdentity()
		{
			int nrows, ncols;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(nrows != ncols){
				throw gcnew System::Exception("Cannot set identity for non-square matrix");
			}

			int i, j;
			for(i = 0; i < nrows; i ++){
				for(j = 0; j < ncols; j++){
					if(i != j){
						(*data_)[i][j] = 0;
					}
					else{
						(*data_)[i][j] = 1;
					}
				}
			}
		}
		System::Array ^ GetArray()
		{
			System::Array ^pArray;
			int nrows, ncols;
			ncols = data_->ncols();
			nrows = data_->nrows();
			pArray = Array::CreateInstance(double::typeid, ncols, nrows);
			int i, j;
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					pArray->SetValue((*data_)[i][j],j,i);
				}
			}
			return pArray;

		}
		double GetValue(int row, int col)
		{
			return (*data_)[row][col];
		}

		void SetValue(int row, int col, double value)
		{
			/*
			int nrows, ncols;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(row < 0 || row >= nrows || col < 0 || col >= ncols) return;*/
			(*data_)[row][col] = value;

		}
		void Reset()
		{
			int nrows, ncols;
			ncols = data_->ncols();
			nrows = data_->nrows();
			data_->assign(nrows, ncols, 0);


		}
		void EigenValues(NRMatrixDotNet^ v, NRMatrixDotNet^ a){
			/*
			Jacobi jac(*this->data_);
			*v->data_ = jac.v;
			int i;
			for(i = 0; i < data_->ncols(); i++){
				(*a->data_)[0][i] = jac.d[i];
			}
			*/
			//try svd 
			SVD svd(*this->data_);
			int rank = svd.rank(-1);
			int nullity = svd.nullity(-1);

			*v->data_ = svd.u;
			int i;
			for(i = 0; i < data_->ncols(); i++){
				(*a->data_)[0][i] = svd.w[i];
			}

		}

		static NRMatrixDotNet ^operator +(NRMatrixDotNet ^A,NRMatrixDotNet ^B) //Addition 
		{
			int nrows, ncols;
			ncols = A->data_->ncols();
			nrows = A->data_->nrows();
			if(nrows != B->data_->nrows() || ncols != B->data_->ncols()){
				throw gcnew Exception("Matrix Addition: rows and columns are not equal");
			}
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			int i, j;
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*B->data_)[i][j] + (*A->data_)[i][j];
				
				}
			}
			return C;
		}

		static NRMatrixDotNet ^operator +=(NRMatrixDotNet ^A, NRMatrixDotNet ^B) //Addition 
		{
			int nrows, ncols;
			ncols = A->data_->ncols();
			nrows = A->data_->nrows();

			int i, j;
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*A->data_)[i][j] += (*B->data_)[i][j];
				}
			}
			return A;
		}

		static NRMatrixDotNet ^operator -(NRMatrixDotNet ^A, NRMatrixDotNet ^B) //minus
		{
			int nrows, ncols;
			ncols = A->data_->ncols();
			nrows = A->data_->nrows();
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			int i, j;
			for(i = 0; i < nrows; i++){
				
				for(j = 0; j < ncols; j++){
					
						(*C->data_)[i][j] = (*A->data_)[i][j] - (*B->data_)[i][j];
					
				}
			}
			return C;

		}
		static NRMatrixDotNet ^operator *(NRMatrixDotNet ^A, double f) //multiplication by a constant
		{
			int nrows, ncols;
			ncols = A->data_->ncols();
			nrows = A->data_->nrows();
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			int i, j;
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*A->data_)[i][j] * f;
				}
			}
			return C;
		}

		static NRMatrixDotNet ^operator /(NRMatrixDotNet ^A, double f) //divided by a constant
		{
			int nrows, ncols;
			ncols = A->data_->ncols();
			nrows = A->data_->nrows();
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			int i, j;
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*A->data_)[i][j] / f;
				}
			}
			return C;
		}

		static 	NRMatrixDotNet ^operator *(NRMatrixDotNet ^A, NRMatrixDotNet ^B) //multiplication 
		{
			int nrowsA, ncolsA, ncolsB, nrowsB;
			ncolsA = A->data_->ncols();
			nrowsA = A->data_->nrows();
			ncolsB = B->data_->ncols();
			nrowsB = B->data_->nrows();
			if(ncolsA != nrowsB){
				throw gcnew Exception("Matrix multiplcation: A cols != B rows");
			}

			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrowsA, ncolsB);
			int i, j, n;
			for(i = 0; i < nrowsA; i++){
				for(j = 0; j < ncolsB; j++){
					(*C->data_)[i][j] = 0;
					for( n = 0; n < ncolsA; n++){ //ncolsA == nrowsB
						(*C->data_)[i][j] += (*A->data_)[i][n] * (*B->data_)[n][j];
					}
				}
			}
			return C;
		}

		NRMatrixDotNet ^T() //get transpose of the matrix
		{
			int nrows, ncols;
			int i, j;
			ncols = data_->ncols();
			nrows = data_->nrows();
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(ncols, nrows);
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[j][i] = (*data_)[i][j];
				}
			}
			return C;
		}
		NRMatrixDotNet ^Inverse()//get  inverse of the matrix
		{
			//inversion by the LU decomposition
			int nrows, ncols;
			int i, j;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(ncols != nrows){
				throw gcnew Exception("Matrix trace: cols != rows");
			}
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			NRMatrixDotNet^ D = gcnew NRMatrixDotNet(nrows, ncols);
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*data_)[i][j];
				}
			}
			LUdcmp luc(*C->data_);
			luc.inverse( *D->data_ );
			return D;
		}
		double rms() //calculate the root mean square 
		{
			int nrows, ncols;
			int i;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(ncols != nrows){
				throw gcnew Exception("Matrix trace: cols != rows");
			}
			double trace = 0;
			for(i = 0; i < nrows; i++){
				trace += (*data_)[i][i] * (*data_)[i][i];
			}

			return sqrt(trace / nrows);

		}
		double Trace()//get the trace of the matrix
		{
			int nrows, ncols;
			int i;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(ncols != nrows){
				throw gcnew Exception("Matrix trace: cols != rows");
			}
			double trace = 0;
			for(i = 0; i < nrows; i++){
				trace += (*data_)[i][i];
			}

			return trace;
		}
		double Determinant_logrithm()
		{
			int nrows, ncols;
			int i, j;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(ncols != nrows){
				throw gcnew Exception("Matrix trace: cols != rows");
			}
			if(nrows == 1) return (*data_)[0][0];
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*data_)[i][j];
				}
			}
			LUdcmp luc(*C->data_ );
			return luc.det_log();
		}
		double Determinant()//get the determinate of the matrix from the LU decomposition
		{
			int nrows, ncols;
			int i, j;
			ncols = data_->ncols();
			nrows = data_->nrows();
			if(ncols != nrows){
				throw gcnew Exception("Matrix trace: cols != rows");
			}
			if(nrows == 1) return (*data_)[0][0];
			NRMatrixDotNet^ C = gcnew NRMatrixDotNet(nrows, ncols);
			for(i = 0; i < nrows; i++){
				for(j = 0; j < ncols; j++){
					(*C->data_)[i][j] = (*data_)[i][j];
				}
			}
			LUdcmp luc(*C->data_ );
			return luc.det();

		}

		void GetVectorByColumn(VecDoub& v, int col){
			int nrows = data_->nrows();
			int i;
			for(i = 0; i < nrows; i++){
				v[i] = (*data_)[i][col];
			}
		}
		/*
		void MarkBadRows(double bad_value) //only applicable to 1-d vectors
		{
			int ncols = data_->ncols();
			if(ncols > 1){
				throw gcnew System::Exception("bad data only applicable to 1-d vectors");
			}
			int nrows = data_->nrows();
			int i;
			for(i = 0; i < nrows; i++){
				if((*data_)[i][0] == bad_value){
					(*data_)[i][0] = 0;
					badRows_->Add(i,nullptr);
				}
			}
			
		}
		*/
		
	};


	


public enum class VariogramType{
		Gaussion = 1, Exponential = 2, Spherical = 3, Linear = 4

	};


	public class VariogramFunctions
	{

	public:
		//static double a_, c0_, c_;
		void static Exponential (const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda) 
		{

			//c0 + c(1 - exp(-x/ a))
			Doub ex,arg;
			arg = -x/a[2];
			ex = 1 - Math::Exp(arg); //1 - exp(-h / a0)
			y = a[0] + a[1] * ex; //C0 + c * ( 1 - exp( - h / a0))
			dyda[0] = 1;

			dyda[1] = ex; 
			dyda[2] = -a[1] * Math::Exp(arg) * x / a[2] / a[2]; //-signma2 * exp(-h/a0) * (h / a0 / a0)
			if(a[0] < 0) 
			{
				dyda[0] = 0;
				y = 0;
			}
		};
		void static Linear(const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda)
		{
			//y = c0 + (c - c0) / a * x;
			//y = c;
			if( x > a[2]) {
				y = a[1];
				dyda[0] = 0;
				dyda[1] = 1;
				dyda[2] = 0;

			}
			else{
				y = a[0] + (a[1] - a[0]) / a[2] * x;

				dyda[0] = 1 - x / a[2];
				dyda[1] = x  / a[2];
				dyda[2] = -(a[1] - a[0]) * x / a[2] / a[2];
			}
			if(a[0] < 0) 
			{
				dyda[0] = 0;
				y = 0;
			}

		}
		void static Gaussian(const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda) {
			double ex, arg;
			arg = (x * x) / (a[2] * a[2]);
			ex = 1 - Math::Exp(-arg);
			y = a[0] + a[1] * ex;
			dyda[0] = 1;
			dyda[1] = ex;
			dyda[2] = -2 * a[1] * (x * x) * (1 - ex) / ( a[2] * a[2] * a[2]) ;
			if(a[0] < 0) 
			{
				dyda[0] = 0;
				y = 0;
			}

		};

		void static Spherical (const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda) 
		{
			//y = c0 + c[3x/(2a) - x*x*x / (2a*a*a)]
			if(x > a[2]){
				y = a[1] + a[0];
				dyda[0] = 1;
				dyda[1] = 1;
			}
			else{
				y = a[0] + a[1] * ( 3 * x / (2.0 * a[2]) - x * x * x / ( 2.0 * a[2] * a[2] * a[2]));
				dyda[0] = 1;
				dyda[1] = 3 * x / (2.0 * a[2]) - x * x * x / ( 2.0 * a[2] * a[2] * a[2]);
				dyda[2] = a[1] * ( -3.0 * x / 2.0 / a[2] / a[2] + x * x * x / 2.0 / a[2] / a[2] / a[2] / a[2]);
				// dyda[1] = 
			}
			if(a[0] < 0) 
			{
				dyda[0] = 0;
				y = 0;
			}

		}

	};
	[Serializable]
	public ref class Variogram
	{
		

		void (*f) (const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda);

	public:
		double a_, c0_, c_, kai2_;
		double a_min, a_max, c0_min, c0_max, c_min, c_max;//user provided range of the parameters, for random pertubation
		VariogramType Type;
		//property System::Collections::ArrayList ^ Parameters{
		//	System::Collections::ArrayList ^ get(){return  para_;}
//
		//}
		
		double GetVariance(double x){
			return c_ + c0_ - GetSemiVariance(x);
		}
		double GetSemiVariance(double x){
			double y;
			//int nPara = para_->Count;
			VecDoub a(3), dyda(3);
			a[0] = c0_;
			a[1] = c_;
			a[2] = a_;
			//for(int i = 0; i < nPara; i++) a[i] = Convert::ToDouble (para_[i]);

			switch(Type){
			case VariogramType::Gaussion:
				f = &VariogramFunctions::Gaussian;

				break;
			case VariogramType::Linear:
				f = &VariogramFunctions::Linear;

				break;	
			case VariogramType::Exponential:
				f = &VariogramFunctions::Exponential;

				break;
			case VariogramType::Spherical:
				f = &VariogramFunctions::Spherical;
				break;
			}
			//VariogramFunctions::c_ = c_;
			//VariogramFunctions::a_ = a_;
			//VariogramFunctions::c0_ = c0_;
			f(x, a, y, dyda);

			return y;


		}

		void Fit(NRMatrixDotNet^ x, NRMatrixDotNet^ y, double tol)
		{

			VecDoub xx, yy, ssig, aa; 
			int nrows = x->NRows;
			if(nrows != y->NRows) throw gcnew System::Exception("Invalid vector size for variogram fitting");
			xx.resize(nrows);
			yy.resize(nrows);

			ssig.assign(nrows,1);//set to 1 vector
			x->GetVectorByColumn(xx,0);
			y->GetVectorByColumn(yy,0);
			aa.resize(3);


			switch(Type){
			case VariogramType::Gaussion:
				f = &VariogramFunctions::Gaussian;

				break;
			case VariogramType::Linear:
				f = &VariogramFunctions::Linear;
				aa[0] = c0_;
				aa[1] = c_ / a_;
				break;	
			case VariogramType::Exponential:
				f = &VariogramFunctions::Exponential;

				break;
			case VariogramType::Spherical:
				f = &VariogramFunctions::Spherical ;

				break;
			}

			//VariogramFunctions::a_ = a_;
			//VariogramFunctions::c0_ = c0_;
			//VariogramFunctions::c_ = c_;
			//use random pertubation to find the optimized fit
			int nTest = 1000;
			int i;
			Random^ rand1 = gcnew Random();
			Random^ rand2 = gcnew Random();
			Random^ rand3 = gcnew Random();
			kai2_ = 1.79769E+308;

			for(i = 0; i < nTest; i++){
				
				aa[0] = rand1->NextDouble() * (c0_max - c0_min) * 10 + c0_min;
				aa[1] = rand2->NextDouble() * (c_max - c_min) * 10 + c_min;
				aa[2] = rand3->NextDouble() * (a_max - a_min) * 10 + a_min;
				Fitmrq fit(xx, yy, ssig, aa, f, tol);
				try{
					
					fit.fit();
				}
				catch(System::Exception^ e){
				}
				if(kai2_ > fit.chisq){
					kai2_ = fit.chisq;
					c0_ = fit.a[0];
					c_ = fit.a[1];
					a_ = fit.a[2];

				}
			}

			//para_ = gcnew System::Collections::ArrayList;
			//int size = aa.size();
			
		}

	};
}
