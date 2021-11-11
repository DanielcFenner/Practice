#include <ctype.h>
#include <cs50.h>
#include <stdio.h>
#include <string.h>
#include <math.h>

int FindLetters(string paragraph);
int FindSentences(string paragraph);
int FindWords(string paragraph);

int main(void)
{
    // Get story text from user
    string story = get_string("Text: ");

    // Calculate words sentences and letters
    int sentences = FindSentences(story);
    int words = FindWords(story);
    int letters = FindLetters(story);

    // Perform grade calculation
    double wordsPerHundredMulti = (double)100 / (double)words;
    double L = letters * wordsPerHundredMulti;
    double S = sentences * wordsPerHundredMulti;
    double indexDouble = 0.0588 * L - 0.296 * S - 15.8;
    int index = round(indexDouble);

    // Output the correct grade to the screen
    if (index >= 16) printf("Grade 16+\n");
    else if (index >= 2 && index <= 15) printf("Grade %i\n", index);
    else printf("Before Grade 1\n");


}

// Loop to find all sentences
int FindSentences(string paragraph)
{
    int sentences = 0;
    for (int i = strlen(paragraph); i >= 0; i--)
    {
        if (paragraph[i] == 46 || paragraph[i] == 33 || paragraph[i] == 63) sentences++;
    }
    return sentences;
}

// Function to find how many letters
int FindLetters(string paragraph)
{
    int letters = 0;
    for (int i = strlen(paragraph); i >= 0; i--)
    {
        if (toupper(paragraph[i]) >= 65 && toupper(paragraph[i]) <= 90) letters++;
    }
    return letters;
}

// Find how many words there are
int FindWords(string paragraph)
{
    int words = 0;
    for (int i = strlen(paragraph); i >= 0; i--)
    {
        if (paragraph[i] == 32) words++;
    }
    return words + 1; // Need +1 because we calculate the amount of words by spaces and the first word doesn't have a space
}
