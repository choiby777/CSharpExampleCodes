// CLRExample.h

#pragma once

#include "ImageHelper.h"
#include "atlbase.h"

using namespace System;

namespace CLRExample {

	public ref class CLRUtil
	{
	private:
		CImageHelper* resizeHelper;

	public:
		value struct Sample {
			int test;
			cli::array<byte>^ InputArr;
			System::String^ stringValue;
		};

		value struct ImageData
		{
			cli::array<unsigned short>^ pixelData;
			int width;
			int height;
		};

	public:
		CLRUtil();
		bool ResizeImage(ImageData inputImage, float scale, ImageData% outputImage);
		bool FunctionTest(
			System::String^% stringValue,
			int% intValue,
			DOUBLE% doubleValue,
			cli::array<byte>^ inputArr,
			cli::array<byte>^% outputArr,
			Sample^ structTest);
	};
}
