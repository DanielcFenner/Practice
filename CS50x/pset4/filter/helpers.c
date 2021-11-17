#include "helpers.h"
#include <math.h>

// Convert image to grayscale
void grayscale(int height, int width, RGBTRIPLE image[height][width])
{
    BYTE avg;
    for (int i = 0; i < height; i++)
    {
        for (int k = 0; k < width; k++)
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
    float sepiaRed, sepiaGreen, sepiaBlue;
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            sepiaRed = (.393 * image[i][j].rgbtRed) + (.769 * image[i][j].rgbtGreen) + (.189 * image[i][j].rgbtBlue);
            if (sepiaRed > 255) sepiaRed = 255;
            sepiaGreen = (.349 * image[i][j].rgbtRed) + (.686 * image[i][j].rgbtGreen) + (.168 * image[i][j].rgbtBlue);
            if (sepiaGreen > 255) sepiaGreen = 255;
            sepiaBlue = (.272 * image[i][j].rgbtRed) + (.534 * image[i][j].rgbtGreen) + (.131 * image[i][j].rgbtBlue);
            if (sepiaBlue > 255) sepiaBlue = 255;
            image[i][j].rgbtBlue = round(sepiaBlue);
            image[i][j].rgbtGreen = round(sepiaGreen);
            image[i][j].rgbtRed = round(sepiaRed);
        }        
    }  
    return;
}

// Reflect image horizontally
void reflect(int height, int width, RGBTRIPLE image[height][width])
{
    RGBTRIPLE imageCopy[height][width];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            imageCopy[i][j] = image[i][j];
        }       
    }
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            image[i][j] = imageCopy[i][width - j];
        }       
    }   
    return;
}

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width])
{   
    int avgRed;
    int avgBlue;
    int avgGreen;
    int avgCounter;
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                avgRed += image[i - 1][j - 1].rgbtRed;
                avgBlue += image[i - 1][j - 1].rgbtBlue;
                avgGreen += image[i - 1][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i - 1 >= 0 && j >= 0)
            {
                avgRed += image[i - 1][j].rgbtRed;
                avgBlue += image[i - 1][j].rgbtBlue;
                avgGreen += image[i - 1][j].rgbtGreen;
                avgCounter++;
            }
            if (i - 1 >= 0 && j + 1 <= width)
            {
                avgRed += image[i - 1][j + 1].rgbtRed;
                avgBlue += image[i - 1][j + 1].rgbtBlue;
                avgGreen += image[i - 1][j + 1].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j - 1 >= 0)
            {
                avgRed += image[i][j - 1].rgbtRed;
                avgBlue += image[i][j - 1].rgbtBlue;
                avgGreen += image[i][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j >= 0)
            {
                avgRed += image[i][j].rgbtRed;
                avgBlue += image[i][j].rgbtBlue;
                avgGreen += image[i][j].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j + 1 <= width)
            {
                avgRed += image[i][j + 1].rgbtRed;
                avgBlue += image[i][j + 1].rgbtBlue;
                avgGreen += image[i][j + 1].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 <= height && j - 1 >= 0)
            {
                avgRed += image[i + 1][j - 1].rgbtRed;
                avgBlue += image[i + 1][j - 1].rgbtBlue;
                avgGreen += image[i + 1][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 <= height && j >= 0)
            {
                avgRed += image[i + 1][j].rgbtRed;
                avgBlue += image[i + 1][j].rgbtBlue;
                avgGreen += image[i + 1][j].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 <= height && j + 1 <= width)
            {
                avgRed += image[i + 1][j + 1].rgbtRed;
                avgBlue += image[i + 1][j + 1].rgbtBlue;
                avgGreen += image[i + 1][j + 1].rgbtGreen;
                avgCounter++;
            }
            image[i][j].rgbtRed = round((float)avgRed / avgCounter);
            image[i][j].rgbtBlue = round((float)avgBlue / avgCounter);
            image[i][j].rgbtGreen = round((float)avgGreen / avgCounter);
            avgRed = 0, avgBlue = 0, avgGreen = 0, avgCounter = 0;            
        }
        
    }
    
    return;
}
