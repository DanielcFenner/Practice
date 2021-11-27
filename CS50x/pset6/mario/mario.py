# probably should've done this with for loops... but...
def main():
    height = get_positive_int()
    # Loop for the rows
    for i in range(height):
        # Just using math on each element of the row to generate the pyramid
        print(" " * (height - i - 1), end="")
        print("#" * (i + 1), end="")
        print("  ", end="")
        print("#" * (i + 1), end="")
        print("")

# Get a positive int between 1 and 8 from the user, anything else will re-prompt the user to enter a legitimate value


def get_positive_int():
    while True:
        try:
            height = int(input("Enter the height of your pyramid:"))
        except ValueError:
            print("You entered an invalid character, please enter a number")
            continue

        if height < 1 or height > 8:
            print("Please enter a number between 1 and 8")
            continue
        else:
            return height


if __name__ == "__main__":
    main()
