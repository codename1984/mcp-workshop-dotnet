namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey with its characteristics and location information
/// </summary>
public class Monkey
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public string? Details { get; set; }
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Image { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Location} (Population: {Population:n0})";
    }

    public string GetAsciiArt()
    {
        var asciiArts = new[]
        {
            @"
      .-""-.
     /      \
    |  o   o  |
    |    >    |
     \  ___  /
      '-..-'
      MONKEY!
",
            @"
    .-""""""-.
   /        \
  |  ^    ^  |
  |     <    |
   \   ___  /
    '-.....-'
    Monkey Time!
",
            @"
   ,-.___,-.
   |  6   6  |
   \    ^    /
    |  ___  |
    '-.___.-'
   Wild Monkey!
"
        };

        var random = new Random();
        return asciiArts[random.Next(asciiArts.Length)];
    }
}