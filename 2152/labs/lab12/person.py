from mammal import Mammal

class Person(Mammal):
    def __init__(self, name, age, height):
        super().__init__(age)
        self.name = name
        self.height = height
    
    def speak(self):
        print("Hello")
    
    def __str__(self):
        return f"Person: {self.name}, {self.heart}"
        