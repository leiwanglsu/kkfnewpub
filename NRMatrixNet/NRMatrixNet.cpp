// This is the main DLL file.

#include "stdafx.h"

#include "NRMatrixNet.h"
#include "math.h"
namespace NRMatrixNet {
	NRMatrixDotNet::NRMatrixDotNet(void)
	{
		data_ = new NRmatrix<double>(1,1); //default matrix with 1 element
			
	}
	NRMatrixDotNet::~NRMatrixDotNet(void)
	{
		this->!NRMatrixDotNet();
	}
	NRMatrixDotNet::!NRMatrixDotNet(void)
	{
		if(data_ != 0){
			delete data_;
		}
	}
	NRMatrixDotNet::NRMatrixDotNet(int nrows, int ncols)
	{

		data_ = new NRmatrix<double>(nrows, ncols);
//		badRows_ = gcnew System::Collections::SortedList;
		
	}



	NRMatrixDotNet::NRMatrixDotNet(System::Array^ pArray) //the array will be copied to the matrix
	{
//		badRows_ = gcnew System::Collections::SortedList;
		
		int ncols, nrows;
		ncols = pArray->GetUpperBound(0) + 1; //rotated, assume columns change faster than rows
		nrows = pArray->GetUpperBound(1) + 1;
		data_ = new NRmatrix<double>(nrows, ncols);
		int i,j;
		for(i = 0; i < nrows; i ++){
			for(j = 0; j < ncols; j++){
				(*data_)[i][j] = Convert::ToDouble(pArray->GetValue(j,i));
			}
		}
	}

	void NRMatrixDotNet::CreateFromArray(System::Array^ pArray)
	{
		int ncols, nrows;
		ncols = pArray->GetUpperBound(0) + 1; //rotated, assume columns change faster than rows
		nrows = pArray->GetUpperBound(1) + 1;
		if (data_ != 0) {
			delete data_;
		}
		data_ = new NRmatrix<double>(nrows, ncols);
		int i, j;
		for (i = 0; i < nrows; i++) {
			for (j = 0; j < ncols; j++) {
				(*data_)[i][j] = Convert::ToDouble(pArray->GetValue(j, i));
			}
		}
	}

	

	void NRMatrixDotNet::GetObjectData(SerializationInfo^ info, StreamingContext context)
	{
		
		Array^ pArray = this->GetArray();
		int rows, cols;
		cols = pArray->GetLength(0);
		rows = pArray->GetLength(1);
		info->AddValue("rows", rows, rows.GetType());
		info->AddValue("cols", cols, rows.GetType());
		info->AddValue("data", pArray, pArray->GetType());
		/*for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++) {
				double value = Convert::ToDouble(pArray->GetValue(i, j));
				info->AddValue("value", value, value.GetType());
			}
		}*/
			
	}

	NRMatrixDotNet::NRMatrixDotNet(SerializationInfo^ info, StreamingContext context)
	{
		int nrows, ncols;
		nrows = info->GetInt32("rows");
		ncols = info->GetInt32("cols");
		
		Object^ pObj = info->GetValue("data", Array::typeid);
		Array^ pArray = dynamic_cast<Array^>(pObj);

		if (data_ != 0) {
			delete data_;
		}
		data_ = new NRmatrix<double>(nrows, ncols);
		int i, j;
		for (i = 0; i < nrows; i++) {
			for (j = 0; j < ncols; j++) {
				(*data_)[i][j] = Convert::ToDouble(pArray->GetValue(j, i));
			}
		}

	}
	
	//double VariogramFunctions::a_ = 0;
	//double VariogramFunctions::c0_ = 0;
	//double VariogramFunctions::c_ = 0;
	//double VariogramFunctions::a_ = 0;
	

}