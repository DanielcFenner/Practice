def main():
    # ask user for their cc number (rly secure)
    cc_number = get_int()
    # convert cc number to string for easy processing of some digits
    cc_number_as_string = str(cc_number)
    # pythons len function finds the length of a string
    cc_length = len(cc_number_as_string)
    # pythons string splice function cuts out the first x of a list, so i splice the first 2 numbers out of the string and cast them as an int for the 2 starting digits
    cc_two_starting_digits = int(cc_number_as_string[:2])
    # divide the 2 starting digits by 10 to get 1 starting digit, making sure to use the floor operator since pythong will auto cast to a decimal
    cc_starting_digit = cc_two_starting_digits // 10

    # if the cc checksum is true
    if (cc_checksum(cc_number) == True):
        # if statements to check the parameters for each card and print the correct card if a match is found, else print invalid
        if (cc_length == 15 and (cc_two_starting_digits == 34 or cc_two_starting_digits == 37)):
            print("AMEX")
        elif (cc_length == 16 and (cc_two_starting_digits <= 55 and cc_two_starting_digits >= 51)):
            print("MASTERCARD")
        elif ((cc_length == 13 or cc_length == 16) and cc_starting_digit == 4):
            print("VISA")
        else:
            print("INVALID")
    else:
        print("INVALID")

# bool checksum to find with a card is legit or not


def cc_checksum(cc_number):
    cc_clone = cc_number
    cc_digit = 0

    # i used the same function as my c code, there was probably a more readable way to do this in python
    # but this is efficient and works, so why not?
    while True:
        # go through every digit by mod 10ing them and add them to cc digit
        every_other_digit = cc_clone % 10
        cc_digit += every_other_digit
        # chop the last digit off the card, to move onto the next one. again making sure to use // instead of / so we don't get a decimal
        cc_clone //= 10

        # follow through with the rest of the checksum algorithm
        every_other_digit_second = cc_clone % 10
        every_other_digit_second *= 2
        cc_digit += every_other_digit_second % 10
        every_other_digit_second //= 10
        cc_digit += every_other_digit_second % 10
        cc_clone //= 10
        # if there are digits left, repeat the loop
        if (cc_clone) > 0:
            continue
        # otherwise return a boolean of whether the checksum passed or not
        else:
            return cc_digit % 10 == 0

# get int with simple try exception block to avoid invalid characters


def get_int():
    while True:
        try:
            cc_number = (int(input("Please enter your credit card number: ")))
        except ValueError:
            print("You entered invalid characters, please try again")
            continue
        finally:
            return cc_number


if __name__ == "__main__":
    main()
