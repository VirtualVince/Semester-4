class Heart:
    def __init__(self, bpm=72):
        self.bpm = bpm
    
    def beat(self):
        print("Lub-dub")
        self.bpm += 1  # Optionally changing bpm
    
    def __str__(self):
        return f"Heart rate: {self.bpm} bpm"