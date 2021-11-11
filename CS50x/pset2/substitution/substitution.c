#include <stdio.h>
#include <cs50.h>
#include <string.h>
#include <ctype.h>

int main(int argc, string argv[])
{


    if (argc == 2)
    {
        // Move command line key into 2 arrays, 1 which is uppercase and 1 which is lower
        // Also create a key sum which is the total of the alphabet added together
        // We'll use this to check if the key is legitimate or not
        char keyLower[26];
        char keyUpper[26];
        int keySum = 0;
        for (int i = 0; i < 26; i++)
        {
            keyUpper[i] = toupper(argv[1][i]);
            keyLower[i] = tolower(argv[1][i]);
            keySum += keyUpper[i];
        }

        // If the key is legitimate
        if (keySum == 2015)
        {
            string plainText = get_string("plaintext: ");

            // Exchange each character in string with the key character
            for (int i = 0; i < strlen(plainText); i++)
            {
                // Check if the char is lower or upcase and use the corresponding array
                if (plainText[i] >= 65 && plainText[i] <= 90) plainText[i] = keyUpper[plainText[i] - 65];
                else if (plainText[i] >= 97 && plainText[i] <= 122) plainText[i] = keyLower[plainText[i] - 97];
            }

            printf("ciphertext: %s\n", plainText);
        }
        // return 1 and usage if key isn't legit
        else
        {
            printf("Usage: ./substitution key\n");
            return 1;
        }
    }
    // return and usage if there aren't enough CL arguments
    else
    {
        printf("Usage: ./substitution key\n");
        return 1;
    }
}