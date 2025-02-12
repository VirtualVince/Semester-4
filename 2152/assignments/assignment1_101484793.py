"""
Author: Vincente Sequeira
Assignment: #1
"""

# Variable Declarations
gym_member = "Alex Alliton"  # String
preferred_weight_kg = 20.5  # Float
highest_reps = 25  # Integer
membership_active = True  # Boolean

# Dictionary storing friends' workout statistics
workout_stats = {
    "Vince": (30, 45, 20),
    "Shalev": (25, 50, 15),
    "Felipe": (40, 30, 25)
}

# Calculate total workout minutes for each friend
for friend, minutes in workout_stats.items():
    total_minutes = sum(minutes)
    workout_stats[f"{friend}_Total"] = total_minutes

# Creating a 2D list of workout minutes
workout_list = [list(minutes) for friend, minutes in workout_stats.items() if "Total" not in friend]  # Nested list

# Slicing workout_list
yoga_running = [row[:2] for row in workout_list]  # Extracting yoga and running
weightlifting_last_two = [row[2] for row in workout_list[-2:]]  # Extracting weightlifting for last two friends

print("Yoga & Running minutes for all friends:", yoga_running)
print("Weightlifting minutes for last two friends:", weightlifting_last_two)

# Checking if any friend's total workout is >= 120
for friend, total in workout_stats.items():
    if "Total" in friend and total >= 120:
        print(f"Great job staying active, {friend.replace('_Total', '')}!")

# Allow user input to check a friend's workout minutes
friend_name = input("Enter a friend's name: ")
if friend_name in workout_stats:
    print(f"{friend_name}'s workout minutes: Yoga: {workout_stats[friend_name][0]}, Running: {workout_stats[friend_name][1]}, Weightlifting: {workout_stats[friend_name][2]}")
    print(f"Total workout minutes: {workout_stats[f'{friend_name}_Total']}")
else:
    print(f"Friend {friend_name} not found in the records.")

# Finding the friend with highest and lowest workout minutes
friend_totals = {friend: total for friend, total in workout_stats.items() if "Total" in friend}
highest_friend = max(friend_totals, key=friend_totals.get).replace("_Total", "")
lowest_friend = min(friend_totals, key=friend_totals.get).replace("_Total", "")

print(f"Friend with highest total workout minutes: {highest_friend}")
print(f"Friend with lowest total workout minutes: {lowest_friend}")
