#pragma once

#include <windows.h>

class CImageHelper
{
public:
	typedef struct {
		unsigned short *pixels;
		unsigned int w;
		unsigned int h;
	} image_t;

private:

	unsigned short getpixel(image_t *image, unsigned int x, unsigned int y);
	float lerp(float s, float e, float t);
	float blerp(float c00, float c10, float c01, float c11, float tx, float ty);
	void putpixel(image_t *image, unsigned int x, unsigned int y, unsigned short greyscale);
public:
	CImageHelper();
	~CImageHelper();

	void ResizeImage(image_t *src, image_t *dst, float scalex, float scaley);
	void Test(byte* imageData, int length);
};

