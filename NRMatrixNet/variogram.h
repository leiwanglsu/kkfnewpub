#pragma once

#include "NRMatrixNet.h"
using namespace System;
using namespace System::Runtime::InteropServices;
namespace NRMatrixNet {
	public enum class VariogramType{
		Gaussion = 1, Exponential = 2, Spherical = 3, Linear = 4

	};


	public class VariogramFunctions
	{

	public:
		static double a_, c0_, c_;
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
				y = a[1];
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

	public ref class Variogram
	{
		System::Collections::ArrayList ^ para_;

		void (*f) (const Doub x, VecDoub_I &a, Doub &y, VecDoub_O &dyda);

	public:
		double a_, c0_, c_;
		VariogramType Type;
		property System::Collections::ArrayList ^ Parameters{
			System::Collections::ArrayList ^ get(){return  para_;}

		}
		void SetParameters(array<double>^ pList)
		{
			int np;
			para_ = gcnew System::Collections::ArrayList;
			np = pList->GetUpperBound(0) + 1;

			for(int i = 0; i < np; i++){
				para_->Add(pList[i]);
			}

		}
		double GetSemiVariance(double x){
			double y;
			int nPara = para_->Count;
			VecDoub a(nPara), dyda(nPara);
			for(int i = 0; i < nPara; i++) a[i] = Convert::ToDouble (para_[i]);

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
			VariogramFunctions::c_ = c_;
			VariogramFunctions::a_ = a_;
			VariogramFunctions::c0_ = c0_;
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
			aa[0] = c0_;
			aa[1] = c_;
			aa[2] = a_;

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

			VariogramFunctions::a_ = a_;
			VariogramFunctions::c0_ = c0_;
			VariogramFunctions::c_ = c_;

			Fitmrq fit(xx, yy, ssig, aa, f, tol);

			fit.fit();

			para_ = gcnew System::Collections::ArrayList;
			int size = aa.size();
			for(int i = 0; i < size; i++){
				para_->Add(fit.a[i]);
			}
			c0_ = fit.a[0];
			c_ = fit.a[1];
			a_ = fit.a[2];

		}

	};
}

