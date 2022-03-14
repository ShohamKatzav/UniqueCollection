
using ImplementingICollection;
class Program
{
    public static void Main()
    {
        string userInput;
        bool endProgram = false;
        UniqueCollection<string> MyUniqueCollection = new UniqueCollection<string>();
        MyUniqueCollection.ExistItemAdded += Program.ExistItemAdded;
        MyUniqueCollection.NotExistItemAdded += Program.NotExistItemAdded;
        MyUniqueCollection.ExistItemRemoved += Program.ExistItemRemoved;
        MyUniqueCollection.NotExistItemRemoved += Program.NotExistItemRemoved;
        MyUniqueCollection.Add("Hello");
        MyUniqueCollection.Add("World");
        MyUniqueCollection.Add("Unique");
        MyUniqueCollection.Add("Collection");
        Console.Clear();
        foreach (var item in MyUniqueCollection)
            Console.WriteLine(item);

        while (!endProgram)
        {
            Console.WriteLine(@"
            Choose an action to perform:
            A - Add
            R - Remove
            E - Enumerate
            C - Contains
            D - Clear
            Q - Quit");
            userInput = Console.ReadLine().ToLower().Trim();
            switch(userInput)
            {
                case "a":
                    Console.WriteLine("Enter item to add:");
                    MyUniqueCollection.Add(Console.ReadLine());
                    break;
                case "r":
                    Console.WriteLine("Enter item to remove:");
                    MyUniqueCollection.Remove(Console.ReadLine());
                    break;
                case "e":
                    Console.WriteLine("Enumerating:");
                    foreach (var item in MyUniqueCollection)
                        Console.WriteLine(item);
                    break;
                case "c":
                    Console.WriteLine("Enter item to search:");
                    Console.WriteLine($"Contains: {MyUniqueCollection.Contains(Console.ReadLine())}");
                    break;
                case "d":
                    MyUniqueCollection.Clear();
                    break;
                case "q":
                    endProgram = true;
                    break;
            }
        }
    }

    public static void ExistItemAdded(object sender)
    {
        Console.WriteLine($"Cannot add [{sender}], the item already exist.");
    }
    public static void NotExistItemAdded(object sender)
    {
        Console.WriteLine($"[{sender}] added successfully.");
    }

    public static void ExistItemRemoved(object sender)
    {
        Console.WriteLine($"[{sender}] Removed successfully.");
    }
    public static void NotExistItemRemoved(object sender)
    {
        Console.WriteLine($"Cannot Remove [{sender}], the item isn't exist.");
    }
}