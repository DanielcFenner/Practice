#include <stdio.h>
#include <cs50.h>

bool CcChecksum(long ccNumber);
int CcLength(long ccNumber);
int TwoStartingDigits(long ccNumber, int ccLength);

int main(void)
{
    long ccNumber = get_long("Please enter your credit card number: ");
    long ccNumberClone = ccNumber;
    int ccLength = 0;

    ccLength = CcLength(ccNumber);
    int twoStartingDigits = TwoStartingDigits(ccNumber, ccLength);
    int oneStartingDigit = twoStartingDigits / 10;

    if (CcChecksum(ccNumber)) // if credit checksum is legit
    {
        if (ccLength == 15 && (twoStartingDigits == 34 || twoStartingDigits == 37)) printf("AMEX\n"); // Check and print conditions for AMEX
        else if (ccLength == 16 && (twoStartingDigits <= 55 && twoStartingDigits >= 51)) printf("MASTERCARD\n"); // Check and print conditions for MasterCard
        else if ((ccLength == 13 || ccLength == 16) && oneStartingDigit == 4) printf("VISA\n"); // Check and print conditions for VISA
        else printf("INVALID\n");
    }
    else printf("INVALID\n"); // print INVALID if checksum fails
}

bool CcChecksum(long ccNumber) // Takes credit card number and returns whether the checksum is legit or not
{
    long ccNumberClone = ccNumber;
    int ccDigit = 0;

    do
    {
    // Adding every other digit from last digit to ccDigit
    long ccEveryOtherDigit = ccNumberClone%10;
    ccDigit += ccEveryOtherDigit;
    ccNumberClone /= 10;

    // Find every other digit from 2nd last, multiply by 2 then add the digits of those numbers together
    long ccEveryOtherDigitSecond = ccNumberClone%10;
    ccEveryOtherDigitSecond *= 2;
    ccDigit += ccEveryOtherDigitSecond %10;
    ccEveryOtherDigitSecond /= 10;
    ccDigit += ccEveryOtherDigitSecond %10;
    } while (ccNumberClone /= 10);

    return ccDigit % 10 == 0;
}

int CcLength(long ccNumber) // iterate through every digit to find the credit card length
{
    int ccLength = 0;
    long ccNumberClone = ccNumber;
    do
    {
        ccLength++;
    } while (ccNumberClone /= 10);
    return ccLength;
}

int TwoStartingDigits(long ccNumber, int ccLength) // return the first 2 starting digits of a credit card number, if you know the length
{
    long startingDigitsTwo = ccNumber;
    for (int i = 0; i < ccLength - 2; i++)
    {
        startingDigitsTwo /= 10;
    }
    return startingDigitsTwo;
}