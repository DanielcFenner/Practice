#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    if (argc != 2)
        printf("Usage: ./recover filename\n");

    char *infile = argv[1];
    printf("%s", infile);
}