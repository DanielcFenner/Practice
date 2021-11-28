def main():
    paragraph = input("Text: ")
    sentences = find_sentences(paragraph)
    words = find_words(paragraph)
    letters = find_letters(paragraph)

    # find the average words per 100
    words_per_hundred_multi = 100 / words
    # algorithim to find the grade index
    l = letters * words_per_hundred_multi
    s = sentences * words_per_hundred_multi
    index = round(0.0588 * l - 0.296 * s - 15.8)

    # cut off for grade 16+ and lower than grade 1
    if index >= 16:
        print("Grade 16+")
    elif index >= 2 and index <= 15:
        print(f"Grade {index}")
    else:
        print("Before Grade 1\n")

# loop through the paragraph and look for ., ? and !


def find_sentences(paragraph):
    sentences = 0
    for char in paragraph:
        if ord(char) == 46 or ord(char) == 33 or ord(char) == 63:
            sentences += 1
    return sentences

# loop through the paragraph and look for spaces, we add 1 extra word at the
# start because the first word doesn't have a space


def find_words(paragraph):
    words = 1
    for char in paragraph:
        if ord(char) == 32:
            words += 1
    return words

# loop through the paragraph and look any letter in the alphabet using ascii
# ord() returns the ascii number and we upp the letter so that weonly search
# the uppercase alphabet


def find_letters(paragraph):
    letters = 0
    for char in paragraph:
        if ord(char.upper()) >= 65 and ord(char.upper()) <= 90:
            letters += 1
    return letters


main()
