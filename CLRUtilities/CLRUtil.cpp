#include "stdafx.h"
#include "CLRUtil.h"


bool CLRUtil::ResizeImage(ImageData inputImage, float scale, ImageData% outputImage)
{
	pin_ptr<unsigned short> p = &inputImage.pixelData[0];
	unsigned short* np = p;

	CResizeImage::image_t *src = new CResizeImage::image_t();
	CResizeImage::image_t *dst = new CResizeImage::image_t();

	src->pixels = np;
	src->w = inputImage.width;
	src->h = inputImage.height;

	resizeHelper->ResizingImage(src, dst, scale, scale);

	outputImage.width = inputImage.width * scale;
	outputImage.height = inputImage.height * scale;

	outputImage.pixelData = nullptr;
	int bufferSize = outputImage.width * outputImage.height;
	outputImage.pixelData = gcnew array<USHORT>(bufferSize);

	pin_ptr<USHORT> data_array_start = &outputImage.pixelData[0];
	memcpy(data_array_start, dst->pixels, bufferSize * sizeof(WORD));

	return true;
}