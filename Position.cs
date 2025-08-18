namespace Marsbot;
// Represents a position on the grid
public readonly struct Position
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Returns position as "X Y" string
    public override string ToString() => $"{X} {Y}";
}

