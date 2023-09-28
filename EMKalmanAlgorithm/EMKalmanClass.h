#pragma once
using namespace System;
using namespace NRMatrixNet;
using namespace System::Collections;

public ref class EMKalmanClassNew
{
	int nT, p;//p is the number of common fields p
	NRMatrixDotNet^ Q_; //p * p matrix
	NRMatrixDotNet^ Phi;//p * p matrix
	NRMatrixDotNet^ u; // p * 1 matrix
	array<NRMatrixDotNet^>^ Pn; //Pt|n //t + 1 * p * p
	array<NRMatrixDotNet^>^ Xn; //Xt|n  //t + 1 * p * p
	

public:
	EMKalmanClassNew(int nTimes, int nFields)
		: nT(nTimes), p(nFields)
	{
		u = gcnew NRMatrixDotNet(p, 1);
		Phi = gcnew NRMatrixDotNet(p, p);
		
		Q_ = gcnew NRMatrixDotNet(p, p);
		Pn = gcnew array<NRMatrixDotNet^>(nT + 1); ; //Pt|n
		Xn = gcnew array<NRMatrixDotNet^>(nT + 1); ; //Xt|n
		
	}
	void Initialize(double u0, double phi, double e); //initial mean value, transit matrix in time, and initial error
	double Iterate(array<NRMatrixDotNet^>^ M, array<NRMatrixDotNet^>^ y, ArrayList^ R2);
	property array<NRMatrixDotNet^>^ AST {
		array<NRMatrixDotNet^>^ get() { return Xn; }
	};
	property NRMatrixDotNet^ Q {
		NRMatrixDotNet^ get() { return Q_; }

	}
	property array<NRMatrixDotNet^>^ P {
		array<NRMatrixDotNet^>^ get() { return Pn; }
	}
	property NRMatrixDotNet^ PHI {
		NRMatrixDotNet^ get() { return Phi; }
	}
};
