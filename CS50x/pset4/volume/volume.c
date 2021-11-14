// Modifies the volume of an audio file

#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>

// Number of bytes in .wav header
const int HEADER_SIZE = 44;

int main(int argc, char *argv[])
{
    // Check command-line arguments
    if (argc != 4)
    {
        printf("Usage: ./volume input.wav output.wav factor\n");
        return 1;
    }

    // Open files and determine scaling factor
    FILE *input = fopen(argv[1], "r");
    if (input == NULL)
    {
        printf("Could not open file.\n");
        return 1;
    }

    FILE *output = fopen(argv[2], "w");
    if (output == NULL)
    {
        printf("Could not open file.\n");
        return 1;
    }

    float factor = atof(argv[3]);

    // TODO: Copy header from input file to output file
    uint8_t header[HEADER_SIZE];
    fread(header, 1, 44, input);
    fwrite(&header[0], 1, 44, output);
    fclose(output);

    // TODO: Read samples from input file and write updated data to output file
    FILE *outputAppend = fopen(argv[2], "a");
    if (outputAppend == NULL)
    {
        printf("Could not open file.\n");
        return 1;
    }

    fseek(input, 0L, SEEK_END);
    long int size = ftell(input);
    fseek(input, 0, SEEK_SET);
    int16_t soundBytes[size];
    int16_t soundBytesWithoutHeader[size - HEADER_SIZE];
    fread(soundBytes, 2, size, input);

    for (int i = 0; i < size; i++)
    {
         if (i < 44) continue;
         soundBytesWithoutHeader[i - HEADER_SIZE] = soundBytes[i] * factor;
    }
    fwrite(&soundBytesWithoutHeader[0], 2, size - HEADER_SIZE, outputAppend);


    
    

    // Close files
    fclose(input);
    fclose(outputAppend);
}
