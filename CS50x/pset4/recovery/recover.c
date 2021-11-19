#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>

int main(int argc, char *argv[])
{
    if (argc != 2)
    {
        printf("Usage: ./recover filename\n");
        return 0;
    }

    FILE *infile = fopen(argv[1], "r");
    FILE *outfile;
    uint8_t buffer[512];
    int jpgCounter = 0;
    char *filename = malloc(8 * sizeof(char));
    while (fread(&buffer, sizeof(buffer), 512, infile))
    {
        if (buffer[0] == 0xff && buffer[1] == 0xd8 && buffer[2] == 0xff && (buffer[3] & 0xf0) == 0xe0)
        {
            sprintf(filename, "%03i.jpg", jpgCounter);
            outfile = fopen(filename, "w");
            fwrite(&buffer, sizeof(buffer), 512, outfile);
            jpgCounter++;
        }
        else
        {
            fwrite(&buffer, sizeof(buffer), 512, outfile);
        }
    }
    free(filename);
    fclose(infile);
    fclose(outfile);
}