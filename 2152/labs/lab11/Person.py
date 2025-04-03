class Person:
    def __init__(self, name, age, height):
        print("Constructing the Person object")
        self.__name = name  # Private attribute
        self.__age = age  # Private attribute
        self.__height = height  # Private attribute
        self.public_prop = "I'm public"  # Public attribute

    # Getter and Setter without magic methods (comment these out later)
    def get_name(self):
        return self.__name

    def set_name(self, new_name):
        self.__name = new_name

    # Magic Getter and Setter
    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, new_name):
        self.__name = new_name

    def __del__(self):
        print("The garbage collector is automatically destroying the Person object")


# Testing the Person class
if __name__ == "__main__":
    person = Person("Mark", 20, 6)
    print(person.public_prop)  # This should work
    try:
        print(person.__name)  # This should fail (AttributeError)
    except AttributeError as e:
        print(e)

    # Using getter and setter methods
    print(person.get_name())  # Should print "Mark"
    person.set_name("Anna")
    print(person.get_name())  # Should print "Anna"

    # Using magic getter and setter
    print(person.name)  # Should print "Anna"
    person.name = "John"
    print(person.name)  # Should print "John"
