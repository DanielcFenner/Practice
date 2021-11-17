#include "helpers.h"
#include <math.h>

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
    return;
}

// Convert image to sepia
void sepia(int height, int width, RGBTRIPLE image[height][width])
{
    BYTE sepiaRed, sepiaGreen, sepiaBlue;
    float originalRed, originalGreen, originalBlue;
    for (int i = 0; i < height - 1; i++)
    {
        for (int j = 0; j < height - 1; j++)
        {
            originalRed = image[i][j].rgbtRed;
            originalGreen = image[i][j].rgbtGreen;
            originalBlue = image[i][j].rgbtBlue;
            sepiaRed = round((.393 * originalRed) + (.349 * originalGreen) + (.189 * originalBlue));
            if (sepiaRed > 255) sepiaRed = 255;
            sepiaGreen = round((.349 * originalRed) + (.686 * originalGreen) + (.168 * originalBlue));
            if (sepiaGreen > 255) sepiaGreen = 255;
            sepiaBlue = round((.272 * originalRed) + (.534 * originalGreen) + (.131 * originalBlue));
            if (sepiaBlue > 255) sepiaBlue = 255;
            image[i][j].rgbtRed = sepiaRed, image[i][j].rgbtGreen = sepiaGreen, image[i][j].rgbtBlue = sepiaBlue;
        }        
    }  
    return;
}

// Reflect image horizontally
void reflect(int height, int width, RGBTRIPLE image[height][width])
{
    RGBTRIPLE imageCopy[height][width];
    for (int i = 0; i < height - 1; i++)
    {
        for (int j = 0; j < width - 1; j++)
        {
            image[i][j] = imageCopy[i][width - 1 - j];
        }       
    }
    return;
}

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width])
{
    return;
}
