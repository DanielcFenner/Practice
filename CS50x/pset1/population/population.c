#include <cs50.h>
#include <stdio.h>

int main(void)
{
    // Let the user know what the tool is
    printf("Welcome to the Llama population calculator, please follow the prompts to find how many years it will take to reach the desired Llama population\n");

    // Ask for the population starting size
    int startSize = get_int("What is the starting population? ");
    while (startSize < 9)
    {
        startSize = get_int("Starting population must be atleast 9, please type in a new starting size: ");
    }

    // Ask for the ending population size
    int endSize = get_int("What is the ending population? ");
    while (endSize < startSize)
    {
        endSize = get_int("Ending population must be bigger than the starting population, we want the llamas to grow! Please type in a new ending size: ");
    }

    // Calculate the number of years to reach the desired population of Llamas
    int currentPopulation = startSize;
    int years = 0;
    while (currentPopulation < endSize)
    {
        currentPopulation += (currentPopulation / 3) - (currentPopulation / 4);
        years++;
    }

    // Print number of years
    printf("Years: %i\n", years);
}