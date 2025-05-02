using System;
using Patterns;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of Observers to create: ");
        int numObservers = int.Parse(Console.ReadLine());

        MyAggregate observerList = new MyAggregate();
        Subject store = new Subject();

        for (int i = 0; i < numObservers; i++)
        {
            Observer observer = new Observer($"Observer No: {i + 1}");
            store.Subscribe(observer);
            observerList[i] = observer.ObserverName;
        }

        Console.WriteLine("\nRegistered Observers:");
        IIterator iter = observerList.GetIterator();

        for (string name = iter.FirstItem; !iter.IsDone; name = iter.NextItem)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nUpdating Inventory...");
        store.Inventory += 1; 

        Console.ReadLine(); 
    }
}
