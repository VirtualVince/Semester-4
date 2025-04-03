from Person import Person

class Student(Person):
    def __init__(self, name, age, height, major):
        super().__init__(name, age, height)  # Call parent constructor
        self.major = major  # Public attribute
        print("This time it's a Student object")


# Testing the Student class
if __name__ == "__main__":
    student = Student("Maria", 22, 6, "Computer Science")
    print(student.name)  # Accessing inherited property
    print(student.major)  # Accessing new property
