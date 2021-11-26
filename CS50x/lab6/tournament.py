# Simulate a sports tournament

import csv
import sys
import random

# Number of simluations to run
N = 1000


def main():

    # Ensure correct usage
    if len(sys.argv) != 2:
        sys.exit("Usage: python tournament.py FILENAME")

    teams = []
    # TODO: Read teams into memory from file
    # Open the file in read only
    f = open(sys.argv[1], "r")
    # Create a reader object
    reader = csv.reader(f)
    # Skip the first line in the CSV
    next(reader)
    # For every row in the CSV, add a new team to a dictionary, then append that dictionary to the teams array
    for row in reader:
        teams.append({"team": row[0], "rating": int(row[1])})

    counts = {}
    # TODO: Simulate N tournaments and keep track of win counts
    # Populate the counts dictionary with teams and 0 wins
    for i in range(16):
        teamToAdd = teams[i]["team"]
        counts[teamToAdd] = 0
    # Simulate the tournament N times and add 1 to the count for the winner
    for i in (range(N)):
        counts[simulate_tournament(teams)] += 1

    # Print each team's chances of winning, according to simulation
    for team in sorted(counts, key=lambda team: counts[team], reverse=True):
        print(f"{team}: {counts[team] * 100 / N:.1f}% chance of winning")


def simulate_game(team1, team2):
    """Simulate a game. Return True if team1 wins, False otherwise."""
    rating1 = team1["rating"]
    rating2 = team2["rating"]
    probability = 1 / (1 + 10 ** ((rating2 - rating1) / 600))
    return random.random() < probability


def simulate_round(teams):
    """Simulate a round. Return a list of winning teams."""
    winners = []

    # Simulate games for all pairs of teams
    for i in range(0, len(teams), 2):
        if simulate_game(teams[i], teams[i + 1]):
            winners.append(teams[i])
        else:
            winners.append(teams[i + 1])

    return winners


def simulate_tournament(teams):
    """Simulate a tournament. Return name of winning team."""
    # TODO
    while True:
        # simulate a round withe the teams array, this will half the teams array with the winners everytime it happens
        teams = simulate_round(teams)
        # if only 1 team is left (the winner) then break out of the loop
        if len(teams) == 1:
            break
    # return the winner as just a string
    return teams[0]["team"]


if __name__ == "__main__":
    main()
