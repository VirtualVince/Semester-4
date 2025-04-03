from mammal import Mammal
from person import Person
from puma import Puma
from tick import Tick

if __name__ == "__main__":
    # Create a generic mammal
    mammal = Mammal(5)
    mammal.speak()
    print(mammal)

    # Create a person
    person = Person("Alice", 30, 170)
    person.heart.beat()
    print(person)
    
    # Create a tick
    tick = Tick()
    tick.suck_blood()
    
    # Create a puma with a tick
    puma = Puma(4, tick)
    puma.tick.suck_blood()
    print(puma)
