#include "bmp.h"

// Convert image to grayscale
void grayscale(int height, int width, RGBTRIPLE image[height][width])
{
    for (int i = 0; i < height - 1; i++)
    {
        for (int k = 0; k < width - 1; k++)
        {
            image[i][k].rgbtBlue = (image[i][k].rgbtBlue + image[i][k].rgbtRed + image[i][k].rgbtGreen) / 3;
            image[i][k].rgbtGreen = (image[i][k].rgbtBlue + image[i][k].rgbtRed + image[i][k].rgbtGreen) / 3;
            image[i][k].rgbtRed = (image[i][k].rgbtBlue + image[i][k].rgbtRed + image[i][k].rgbtGreen) / 3;
        }
        
    }
    
}

// Convert image to sepia
void sepia(int height, int width, RGBTRIPLE image[height][width]);

// Reflect image horizontally
void reflect(int height, int width, RGBTRIPLE image[height][width]);

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width]);
