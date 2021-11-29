import csv
import sys


def main():
    people = []
    if len(sys.argv) != 3:
        sys.exit("Incorrect usage, try: python3 dna.py database.csv sequences.txt")

    fcsv = open(sys.argv[1], "r")
    reader = csv.DictReader(fcsv)
    for row in reader:
        people.append(row)

    # Take 1 row of the people list, remove the 1st element and keep just the DNA keys
    dna_iterable = people[0].keys()
    dna_list = list(dna_iterable)
    dna_list.pop(0)
    # STRs that we will check for now stored in a list


main()
