#include <cs50.h>
#include <stdio.h>

int get_positive_int(void);

int main(void)
{

    int height = get_positive_int();


    // Main loop starts each row based on the height int
    for (int i = 0; i < height; i++)
    {
        // Spaces needed before block is simple for loop with i + 1 to stop an extra space at the beginning
        for (int x = i + 1; x < height; x++)
        {
            printf(" ");
        }
        // Calculate blocks needed for the row by subtacting main loop from the height
        for (int y = height - i; y <= height; y++)
        {
            printf("#");
        }
        // Print 2 spaces for the end of the pyramid
        printf("  ");
        // Basically copy paste of first # block loop to create blocks on other side
        for (int x = height - i; x <= height; x++)
        {
            printf("#");
        }
        // Create a new line between each row
        printf("\n");
    }

}

int get_positive_int(void)
{
    int height = get_int("Enter the height of your pyramid: ");
    while (height < 1 || height > 8)
    {
        height = get_int("Height must be between 1 & 8, try again: ");
    }
    return height;
}

