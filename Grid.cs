namespace Marsbot;

public class Grid
{
    private readonly Position _upperRight;
    private readonly HashSet<Position> _scents;

    public Grid(int maxX, int maxY)
    {
        if (maxX < 0 || maxY < 0 || maxX > 50 || maxY > 50)
            throw new ArgumentException("Grid coordinates must be between 0 and 50");

        _upperRight = new Position(maxX, maxY);
        _scents = new HashSet<Position>();
    }

    /// <summary>
    /// Checks if a position is within the grid boundaries
    /// </summary>
    public bool IsWithinBounds(Position position)
    {
        return position.X >= 0 && position.X <= _upperRight.X &&
               position.Y >= 0 && position.Y <= _upperRight.Y;
    }

    /// <summary>
    /// Marks a position as having robot scent (where a robot was lost)
    /// </summary>
    public void AddScent(Position position)
    {
        _scents.Add(position);
    }

    /// <summary>
    /// Checks if a position has robot scent (prevents robots from falling off)
    /// </summary>
    public bool HasScent(Position position)
    {
        return _scents.Contains(position);
    }
}
