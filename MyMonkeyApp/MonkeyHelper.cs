namespace MyMonkeyApp;

/// <summary>
/// Static helper class for managing monkey data and operations
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys = new();
    private static readonly Dictionary<string, int> _accessCount = new();
    private static readonly Random _random = new();

    static MonkeyHelper()
    {
        InitializeMonkeyData();
    }

    /// <summary>
    /// Initialize monkey data with sample monkeys from various locations
    /// </summary>
    private static void InitializeMonkeyData()
    {
        _monkeys.AddRange(new[]
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Arabia",
                Details = "Baboons are some of the largest monkeys in the world",
                Population = 100000,
                Latitude = -8.783195,
                Longitude = 34.508523,
                Image = "baboon.jpg"
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "These monkeys are known for their intelligence and tool use",
                Population = 23000,
                Latitude = 10.500000,
                Longitude = -84.000000,
                Image = "capuchin.jpg"
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "Despite their name, blue monkeys are not actually blue",
                Population = 200000,
                Latitude = -4.038333,
                Longitude = 21.758664,
                Image = "bluemonkey.jpg"
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "Squirrel monkeys are small and very social",
                Population = 300000,
                Latitude = -2.000000,
                Longitude = -60.000000,
                Image = "squirrelmonkey.jpg"
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "These monkeys are known for their distinctive golden mane",
                Population = 3000,
                Latitude = -22.9083,
                Longitude = -42.0608,
                Image = "goldenlion.jpg"
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "Central & South America",
                Details = "These are the loudest monkeys and can be heard for miles",
                Population = 150000,
                Latitude = 9.000000,
                Longitude = -79.000000,
                Image = "howler.jpg"
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "Also known as snow monkeys, they enjoy hot springs",
                Population = 120000,
                Latitude = 36.204824,
                Longitude = 138.252924,
                Image = "macaque.jpg"
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Equatorial Africa",
                Details = "Mandrills are the largest monkeys in the world",
                Population = 25000,
                Latitude = -0.803689,
                Longitude = 11.609444,
                Image = "mandrill.jpg"
            }
        });
    }

    /// <summary>
    /// Get all available monkeys
    /// </summary>
    /// <returns>Collection of all monkeys</returns>
    public static IReadOnlyList<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Find a monkey by name (case-insensitive)
    /// </summary>
    /// <param name="name">Name of the monkey to find</param>
    /// <returns>Monkey if found, null otherwise</returns>
    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Get a random monkey and track access count
    /// </summary>
    /// <returns>A randomly selected monkey</returns>
    public static Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
            throw new InvalidOperationException("No monkeys available");

        var randomMonkey = _monkeys[_random.Next(_monkeys.Count)];
        
        // Track access count
        if (!_accessCount.ContainsKey(randomMonkey.Name))
            _accessCount[randomMonkey.Name] = 0;
        
        _accessCount[randomMonkey.Name]++;
        
        return randomMonkey;
    }

    /// <summary>
    /// Get access count for a specific monkey
    /// </summary>
    /// <param name="monkeyName">Name of the monkey</param>
    /// <returns>Number of times this monkey was randomly selected</returns>
    public static int GetAccessCount(string monkeyName)
    {
        return _accessCount.TryGetValue(monkeyName, out var count) ? count : 0;
    }

    /// <summary>
    /// Get all access counts
    /// </summary>
    /// <returns>Dictionary of monkey names and their access counts</returns>
    public static IReadOnlyDictionary<string, int> GetAllAccessCounts()
    {
        return _accessCount.AsReadOnly();
    }
}