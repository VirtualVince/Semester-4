# Defining Variables
array_variable = [1, 4, 7, 9]

# Order of Operations
a = 1
b = 2
c = 3
d = 4

e = (a * c) - (b / d) 

# Fully-bracketed version of e = a - b ** c // d + a % c
e = ((a - (b ** c)) // d) + (a % c)

# Formatting
temperature = 32.6
print("The temperature today is: {:.3f} degrees Celsius".format(temperature))

# Common Functions
userAge = int(input("Enter your age: ")) + 22
print("Now showing the shop items filtered by age:", userAge)
