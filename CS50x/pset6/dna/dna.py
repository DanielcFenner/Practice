import csv
from os import fdopen, name
import sys


def main():
    # array of dictionarys where we'll store everyone from the csv
    people = []

    # check if there are enough arguments, if not tell em how to use it
    if len(sys.argv) != 3:
        sys.exit("Incorrect usage, try: python3 dna.py database.csv sequences.txt")

    # open the csv with a dictionary reader and append each dictionary
    # to the peoples array
    fcsv = open(sys.argv[1], "r")
    reader = csv.DictReader(fcsv)
    for row in reader:
        people.append(row)
    fcsv.close()

    # Take 1 row of the people list,
    # remove the 1st element and keep just the DNA keys
    # This will be a list of STR we can use in our sequence finder
    dna_iterable = people[0].keys()
    dna_list = list(dna_iterable)
    dna_list.pop(0)

    # Copy the entire DNA sequence into a string
    fsequence = open(sys.argv[2], "r")
    dna_sequence = fsequence.read()
    fsequence.close()

    # create match dictionary, where the key is the str and the value
    # is the amount of consecutive times we found a match
    # using sequence_finder
    dna_match_dictionary = {}
    for dna_str in dna_list:
        dna_match_dictionary[dna_str] = sequence_finder(dna_str, dna_sequence)

    # default match to no match, then we don't need to change anything
    # if there is no match - it's just updated when we do find a match
    match = "No Match"
    # for everyone persin or dictionary list
    for person in people:
        # initiliaze number of matches, this is match between the persons
        # known consecutive STR counts matched with the dna_match_dictionary
        # which has the files amount. Everytime we match 1 STR, it increases
        # the count. Then if the count is equal to the length of the
        # dna_list, we know they match for every STR and we can update
        # match to represent this
        person_number_of_matches = 0
        for dna_str in dna_match_dictionary:
            if int(person[dna_str]) == dna_match_dictionary[dna_str]:
                person_number_of_matches += 1
            if person_number_of_matches == len(dna_list):
                match = person["name"]
    print(match)


def sequence_finder(dna_str, dna_sequence):
    # takes an STR and dna_sequence then returns the maximum amount of times it repeats
    consecutive_matches = 0
    i = 0

    # we go through every element in the sequence minus the length of the STR
    # so we don't go paste the end of the array
    while i < (len(dna_sequence) - len(dna_str)):
        # slice a temp string based on the current index and the length of the
        # current STR
        temp_string = dna_sequence[i:i+len(dna_str)]
        # if the temp string matches the dna_str we're looking for
        if temp_string == dna_str:
            # increase the temp consecutive matches
            temp_consecutive_matches += 1
            # and if the temp matches is great than the overall matches
            # then set the overall matches to the temp
            if temp_consecutive_matches > consecutive_matches:
                consecutive_matches = temp_consecutive_matches
            # now we need to skip the length of the dna_str so
            # we don't overlap
            i += len(dna_str)
        else:
            # if no match is found, then reset temmporary matches
            # and increment to the next element until we find a match
            temp_consecutive_matches = 0
            i += 1

    return consecutive_matches


main()
