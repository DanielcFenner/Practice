#include "bmp.h"

// Convert image to grayscale
void grayscale(int height, int width, RGBTRIPLE image[height][width])
{
    int avg;
    for (int i = 0; i < height - 1; i++)
    {
        for (int k = 0; k < width - 1; k++)
        {
            avg = round((float)(image[i][k].rgbtBlue + image[i][k].rgbtRed + image[i][k].rgbtGreen) / 3);
            image[i][k].rgbtBlue = avg, image[i][k].rgbtGreen = avg, image[i][k].rgbtRed = avg;
        }
        
    }
}

// Convert image to sepia
void sepia(int height, int width, RGBTRIPLE image[height][width]);

// Reflect image horizontally
void reflect(int height, int width, RGBTRIPLE image[height][width]);

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width]);
