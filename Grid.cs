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

    // Returns true if the position is inside the grid
    public bool IsWithinBounds(Position position)
    {
        return position.X >= 0 && position.X <= _upperRight.X &&
               position.Y >= 0 && position.Y <= _upperRight.Y;
    }

    // Adds a scent at the given position (where a robot was lost)
    public void AddScent(Position position)
    {
        _scents.Add(position);
    }

    // Returns true if the position has a scent
    public bool HasScent(Position position)
    {
        return _scents.Contains(position);
    }
}
