namespace Marsbot;
// Enum for robot direction
public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

// Helper methods for working with directions: turning, moving, and converting
public static class DirectionExtensions
{
    // Turn left (counterclockwise)
    public static Direction TurnLeft(this Direction direction)
    {
        return (Direction)(((int)direction + 3) % 4);
    }

    // Turn right (clockwise)
    public static Direction TurnRight(this Direction direction)
    {
        return (Direction)(((int)direction + 1) % 4);
    }

    // Get the next position if moving forward in the current direction
    public static Position GetForwardPosition(this Direction direction, Position current)
    {
        return direction switch
        {
            Direction.North => new Position(current.X, current.Y + 1),
            Direction.East => new Position(current.X + 1, current.Y),
            Direction.South => new Position(current.X, current.Y - 1),
            Direction.West => new Position(current.X - 1, current.Y),
            _ => throw new ArgumentException($"Invalid direction: {direction}")
        };
    }

    // Convert direction to its character representation
    public static char ToChar(this Direction direction)
    {
        return direction switch
        {
            Direction.North => 'N',
            Direction.East => 'E',
            Direction.South => 'S',
            Direction.West => 'W',
            _ => throw new ArgumentException($"Invalid direction: {direction}")
        };
    }

    // Convert a character to a Direction enum value
    public static Direction FromChar(char c)
    {
        return c switch
        {
            'N' => Direction.North,
            'E' => Direction.East,
            'S' => Direction.South,
            'W' => Direction.West,
            _ => throw new ArgumentException($"Invalid direction character: {c}")
        };
    }
}

