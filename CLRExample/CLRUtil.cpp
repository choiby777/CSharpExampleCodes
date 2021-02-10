// This is the main DLL file.

#include "stdafx.h"

#include "CLRUtil.h"

namespace CLRExample {
	
	CLRUtil::CLRUtil()
	{

	}

	bool CLRUtil::ResizeImage(ImageData inputImage, float scale, ImageData% outputImage)
	{
		pin_ptr<unsigned short> p = &inputImage.pixelData[0];
		unsigned short* np = p;

		CImageHelper::image_t *src = new CImageHelper::image_t();
		CImageHelper::image_t *dst = new CImageHelper::image_t();

		src->pixels = np;
		src->w = inputImage.width;
		src->h = inputImage.height;

		resizeHelper->ResizeImage(src, dst, scale, scale);

		outputImage.width = inputImage.width * scale;
		outputImage.height = inputImage.height * scale;

		outputImage.pixelData = nullptr;
		int bufferSize = outputImage.width * outputImage.height;
		outputImage.pixelData = gcnew array<USHORT>(bufferSize);

		pin_ptr<USHORT> data_array_start = &outputImage.pixelData[0];
		memcpy(data_array_start, dst->pixels, bufferSize * sizeof(WORD));

		return true;
	}

	bool CLRUtil::FunctionTest(
		System::String^% stringValue,
		int% intValue,
		DOUBLE% doubleValue,
		cli::array<byte>^ inputArr,
		cli::array<byte>^% outputArr,
		Sample^ structTest)
	{
		stringValue = "abcde";
		intValue = 10;
		doubleValue = 5.5;

		if (outputArr == nullptr)
		{
			outputArr = gcnew array<byte>(inputArr->Length);
		}

		for (int i = 0; i < outputArr->Length; i++)
		{
			outputArr[0] = 2 * i;
		}

		pin_ptr<byte> pinnedPtr = &inputArr[0];

		resizeHelper->Test((byte*)pinnedPtr, inputArr->Length);

		pinnedPtr = nullptr;

		return true;
	}

}
