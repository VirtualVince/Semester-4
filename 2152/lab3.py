import random

# Setup
diceOptions = list(range(1, 7)) 
weapons = ['Fist', 'Knife', 'Club', 'Gun', 'Bomb', 'Nuclear Bomb']

# Display available weapons
print("Available Weapons:")
for i, weapon in enumerate(weapons, 1):
    print(f"{i}. {weapon}")

# Player input validation for combat strength
while True:
    try:
        combatStrength = int(input("Enter your combat strength (1-6): "))
        if 1 <= combatStrength <= 6:
            break
        else:
            print("Invalid input. Please enter an integer between 1 and 6.")
    except ValueError:
        print("Invalid input. Please enter a valid integer.")

while True:
    try:
        mCombatStrength = int(input("Enter monster's combat strength (1-6): "))
        if 1 <= mCombatStrength <= 6:
            break
        else:
            print("Invalid input. Please enter an integer between 1 and 6.")
    except ValueError:
        print("Invalid input. Please enter a valid integer.")

# Battle simulation
for j in range(1, 21, 2):
    # Roll dice for hero and monster
    heroRoll = random.choice(diceOptions)
    monsterRoll = random.choice(diceOptions)

    # Calculate total strengths
    heroTotal = combatStrength + heroRoll
    monsterTotal = mCombatStrength + monsterRoll

    # Display round details
    print(f"\nRound {j}:")
    print(f"Hero rolled {heroRoll}, Monster rolled {monsterRoll}.")
    print(f"Hero selected: {weapons[heroRoll - 1]}, Monster selected: {weapons[monsterRoll - 1]}.")
    print(f"Hero Total Strength: {heroTotal}, Monster Total Strength: {monsterTotal}.")

    # Determine round winner
    if heroTotal > monsterTotal:
        print("Hero wins the round!")
    elif heroTotal < monsterTotal:
        print("Monster wins the round!")
    else:
        print("It's a tie!")

    # Break condition
    if j == 11:
        print("\nBattle Truce declared in Round 11. Game Over!")
        break
