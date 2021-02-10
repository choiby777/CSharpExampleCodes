#include "stdafx.h"
#include "ResizeImage.h"


CResizeImage::CResizeImage()
{

}


CResizeImage::~CResizeImage()
{

}


void CResizeImage::ResizingImage(image_t *src, image_t *dst, float scalex, float scaley) {
	int newWidth = (int)src->w*scalex;
	int newHeight = (int)src->h*scaley;

	dst->pixels = new unsigned short[newWidth * newHeight];
	dst->w = newWidth;
	dst->h = newHeight;

	int x, y;
	for (y = 0; y < newHeight; y++) {
		for (x = 0; x < newWidth; x++) {
			float gx = x / (float)(newWidth) * (src->w - 1);
			float gy = y / (float)(newHeight) * (src->h - 1);
			int gxi = (int)gx;
			int gyi = (int)gy;
			unsigned short result = 0;
			unsigned short c00 = getpixel(src, gxi, gyi);
			unsigned short c10 = getpixel(src, gxi + 1, gyi);
			unsigned short c01 = getpixel(src, gxi, gyi + 1);
			unsigned short c11 = getpixel(src, gxi + 1, gyi + 1);

			result |= (unsigned short)blerp(c00, c10, c01, c11, gx - gxi, gy - gyi);

			putpixel(dst, x, y, result);
		}
	}
}

unsigned short CResizeImage::getpixel(image_t *image, unsigned int x, unsigned int y) 
{
	return image->pixels[(y*image->w) + x];
}

float CResizeImage::lerp(float s, float e, float t) 
{ 
	return s + (e - s)*t; 
}

float CResizeImage::blerp(float c00, float c10, float c01, float c11, float tx, float ty) 
{
	return lerp(lerp(c00, c10, tx), lerp(c01, c11, tx), ty);
}

void CResizeImage::putpixel(image_t *image, unsigned int x, unsigned int y, unsigned short greyscale) 
{
	image->pixels[(y*image->w) + x] = greyscale;
}