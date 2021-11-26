def main():
    height = get_positive_int()
    for i in range(height):
        print(" ", end="")
        print("#", end="")
        print("")


def get_positive_int():
    height = int(input("Enter the height of your pyramid:"))
    while height < 1 or height > 8:
        height = int(input("Height must be between 1 & 8, try again: "))
    return height


if __name__ == "__main__":
    main()
