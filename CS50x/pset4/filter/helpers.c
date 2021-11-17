#include "helpers.h"
#include <math.h>

// Convert image to grayscale
void grayscale(int height, int width, RGBTRIPLE image[height][width])
{
    BYTE avg;
    // loop through every pixel in each column (height) and row (width)
    for (int i = 0; i < height; i++)
    {
        for (int k = 0; k < width; k++)
        {
            // find the average color of each pixel added together then set that to every color so they're even (grayscale)
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
            // Use the sepia algorithm to find the new color for each color, if its bigger than 255 then set it to 255
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
    RGBTRIPLE pixelTemp;
    for (int i = 0; i < height; i++)
    {
        // swap the pixels from each side to reflect it. Using a temp variable for the swap. Still not sure why i needed j+1? but it works...
        for (int j = 0; j < (width/2); j++)
        {
            pixelTemp = image[i][j];

            image[i][j] = image[i][width - (j + 1)];
            image[i][width - (j + 1)] = pixelTemp;
        }
    }
    return;
}

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width])
{
    // Copy the image to a new array so we can compare original pixels
    RGBTRIPLE imageCopy[height][width];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            imageCopy[i][j] = image[i][j];
        }

    }


    int avgRed = 0;
    int avgBlue = 0;
    int avgGreen = 0;
    int avgCounter= 0;
    // check every single pixel around the current pixel to see if its within the array, if it is, then add it to the average and increase the avg counter for dividing later on
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                avgRed += imageCopy[i - 1][j - 1].rgbtRed;
                avgBlue += imageCopy[i - 1][j - 1].rgbtBlue;
                avgGreen += imageCopy[i - 1][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i - 1 >= 0 && j >= 0)
            {
                avgRed += imageCopy[i - 1][j].rgbtRed;
                avgBlue += imageCopy[i - 1][j].rgbtBlue;
                avgGreen += imageCopy[i - 1][j].rgbtGreen;
                avgCounter++;
            }
            if (i - 1 >= 0 && j + 1 < width)
            {
                avgRed += imageCopy[i - 1][j + 1].rgbtRed;
                avgBlue += imageCopy[i - 1][j + 1].rgbtBlue;
                avgGreen += imageCopy[i - 1][j + 1].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j - 1 >= 0)
            {
                avgRed += imageCopy[i][j - 1].rgbtRed;
                avgBlue += imageCopy[i][j - 1].rgbtBlue;
                avgGreen += imageCopy[i][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j >= 0)
            {
                avgRed += imageCopy[i][j].rgbtRed;
                avgBlue += imageCopy[i][j].rgbtBlue;
                avgGreen += imageCopy[i][j].rgbtGreen;
                avgCounter++;
            }
            if (i >= 0 && j + 1 < width)
            {
                avgRed += imageCopy[i][j + 1].rgbtRed;
                avgBlue += imageCopy[i][j + 1].rgbtBlue;
                avgGreen += imageCopy[i][j + 1].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 < height && j - 1 >= 0)
            {
                avgRed += imageCopy[i + 1][j - 1].rgbtRed;
                avgBlue += imageCopy[i + 1][j - 1].rgbtBlue;
                avgGreen += imageCopy[i + 1][j - 1].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 < height && j >= 0)
            {
                avgRed += imageCopy[i + 1][j].rgbtRed;
                avgBlue += imageCopy[i + 1][j].rgbtBlue;
                avgGreen += imageCopy[i + 1][j].rgbtGreen;
                avgCounter++;
            }
            if (i + 1 < height && j + 1 < width)
            {
                avgRed += imageCopy[i + 1][j + 1].rgbtRed;
                avgBlue += imageCopy[i + 1][j + 1].rgbtBlue;
                avgGreen += imageCopy[i + 1][j + 1].rgbtGreen;
                avgCounter++;
            }
            // set the current pixel to the average of all the pixels around it
            image[i][j].rgbtRed = round((float)avgRed / avgCounter);
            image[i][j].rgbtBlue = round((float)avgBlue / avgCounter);
            image[i][j].rgbtGreen = round((float)avgGreen / avgCounter);
            // reset the counters
            avgRed = 0, avgBlue = 0, avgGreen = 0, avgCounter = 0;
        }

    }

    return;
}
