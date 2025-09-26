using MyMonkeyApp;

Console.WriteLine("=== 🐒 Welcome to Monkey Explorer! 🐒 ===");
Console.WriteLine();

bool keepRunning = true;

while (keepRunning)
{
    try
    {
        DisplayMenu();
        var choice = GetUserChoice();
        
        Console.WriteLine();
        
        switch (choice)
        {
            case 1:
                ListAllMonkeys();
                break;
            case 2:
                GetMonkeyByName();
                break;
            case 3:
                GetRandomMonkey();
                break;
            case 4:
                Console.WriteLine("Thanks for exploring monkeys! 🐒👋");
                keepRunning = false;
                break;
            default:
                Console.WriteLine("❌ Invalid choice. Please select 1-4.");
                break;
        }
        
        if (keepRunning)
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ An error occurred: {ex.Message}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

static void DisplayMenu()
{
    Console.WriteLine("🍌 What would you like to do?");
    Console.WriteLine("1. 📋 List all monkeys");
    Console.WriteLine("2. 🔍 Get details for a specific monkey by name");
    Console.WriteLine("3. 🎲 Get a random monkey");
    Console.WriteLine("4. 🚪 Exit app");
    Console.WriteLine();
    Console.Write("Enter your choice (1-4): ");
}

static int GetUserChoice()
{
    var input = Console.ReadLine();
    if (int.TryParse(input, out var choice))
    {
        return choice;
    }
    return 0;
}

static void ListAllMonkeys()
{
    Console.WriteLine("🐒 All Available Monkeys:");
    Console.WriteLine(new string('=', 50));
    
    var monkeys = MonkeyHelper.GetAllMonkeys();
    
    if (monkeys.Count == 0)
    {
        Console.WriteLine("No monkeys found!");
        return;
    }
    
    foreach (var monkey in monkeys)
    {
        Console.WriteLine($"• {monkey}");
        if (!string.IsNullOrEmpty(monkey.Details))
        {
            Console.WriteLine($"  Details: {monkey.Details}");
        }
        var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
        if (accessCount > 0)
        {
            Console.WriteLine($"  Random selections: {accessCount}");
        }
        Console.WriteLine();
    }
    
    Console.WriteLine($"Total monkeys: {monkeys.Count}");
}

static void GetMonkeyByName()
{
    Console.Write("🔍 Enter monkey name: ");
    var name = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ Please enter a valid monkey name.");
        return;
    }
    
    var monkey = MonkeyHelper.FindMonkeyByName(name);
    
    if (monkey == null)
    {
        Console.WriteLine($"❌ No monkey found with name '{name}'.");
        Console.WriteLine("💡 Try one of these names:");
        
        var allMonkeys = MonkeyHelper.GetAllMonkeys();
        foreach (var m in allMonkeys.Take(3))
        {
            Console.WriteLine($"   • {m.Name}");
        }
        return;
    }
    
    Console.WriteLine("🐒 Monkey Found!");
    Console.WriteLine(new string('=', 30));
    Console.WriteLine($"Name: {monkey.Name}");
    Console.WriteLine($"Location: {monkey.Location}");
    Console.WriteLine($"Population: {monkey.Population:n0}");
    
    if (!string.IsNullOrEmpty(monkey.Details))
    {
        Console.WriteLine($"Details: {monkey.Details}");
    }
    
    Console.WriteLine($"Coordinates: {monkey.Latitude:F2}, {monkey.Longitude:F2}");
    
    var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
    if (accessCount > 0)
    {
        Console.WriteLine($"Times randomly selected: {accessCount}");
    }
}

static void GetRandomMonkey()
{
    try
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        
        Console.WriteLine("🎲 Random Monkey Selected!");
        Console.WriteLine(monkey.GetAsciiArt());
        Console.WriteLine(new string('=', 30));
        Console.WriteLine($"Name: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population:n0}");
        
        if (!string.IsNullOrEmpty(monkey.Details))
        {
            Console.WriteLine($"Details: {monkey.Details}");
        }
        
        var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
        Console.WriteLine($"Times selected: {accessCount}");
        
        Console.WriteLine("\n🎉 Lucky monkey of the day!");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}
