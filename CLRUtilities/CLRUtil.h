#pragma once

#include "ResizeImage.h"
#include "atlbase.h"

public ref class CLRUtil
{
private:
	CResizeImage* resizeHelper; 

public:
	value struct ImageData
	{
		cli::array<unsigned short>^ pixelData;
		int width;
		int height;
	};

public:
	CLRUtil() {
		resizeHelper = new CResizeImage();
	}

	~CLRUtil() {

	}

	bool ResizeImage(ImageData inputImage, float scale, ImageData% outputImage);
};

