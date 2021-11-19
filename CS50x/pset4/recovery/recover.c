#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdbool.h>

int main(int argc, char *argv[])
{
    if (argc != 2)
    {
        printf("Usage: ./recover filename\n");
        return 0;
    }

    // open and check if the input file exists
    FILE *infile = fopen(argv[1], "r");
    if (infile == NULL)
    {
        printf("Could not open file.\n");
        return 1;
    }

    // create pointer to outfile
    FILE *outfile;
    // 512 byte buffer
    uint8_t buffer[512];
    int jpgCounter = 0;
    char filename[8];

    // loop until we reach end of file
    while (fread(&buffer, sizeof(uint8_t), 512, infile))
    {
        // if the 4 bytes at the start of file match a jpg header
        if (buffer[0] == 0xff && buffer[1] == 0xd8 && buffer[2] == 0xff && (buffer[3] & 0xf0) == 0xe0)
        {
            // create a new file with string format xxx.jpg
            sprintf(filename, "%03i.jpg", jpgCounter);
            outfile = fopen(filename, "w");

            //write to the file and incrase jpg counter for next file name
            fwrite(&buffer, sizeof(uint8_t), 512, outfile);
            jpgCounter++;
        }
        else if (outfile)
        {
            // continue to write to the file if new jpg isn't found
            fwrite(&buffer, sizeof(uint8_t), 512, outfile);
        }
    }
    //close files
    fclose(infile);
    fclose(outfile);
}