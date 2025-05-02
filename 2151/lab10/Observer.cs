using System;
using System.Collections.Generic;

namespace Patterns
{
    interface ISubject
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void Notify();
    }

    interface IObserver
    {
        void Update();
    }

    public class Subject : ISubject
    {
        private List<Observer> observers = new List<Observer>();
        private int _int;

        public int Inventory
        {
            get => _int;
            set
            {
                if (value > _int)
                    Notify();
                _int = value;
            }
        }

        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            observers.ForEach(o => o.Update());
        }
    }

    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }

        public Observer(string name)
        {
            ObserverName = name;
        }

        public void Update()
        {
            Console.WriteLine($"{ObserverName}: A new product has arrived at the store.");
        }
    }
}
