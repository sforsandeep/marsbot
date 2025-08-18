
namespace Marsbot;
// Robot handles movement and state
public class Robot
{
    public Position Position { get; private set; }
    public Direction Direction { get; private set; }
    public bool IsLost { get; private set; }

    public Robot(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
        IsLost = false;
    }

    /// <summary>
    /// Executes a sequence of instructions
    /// </summary>
    public void Execute(string instructions, Grid grid)
    {
        if (string.IsNullOrEmpty(instructions))
            return;

        foreach (char instruction in instructions)
        {
            if (IsLost) break;

            switch (instruction)
            {
                case 'L':
                    Direction = Direction.TurnLeft();
                    break;
                case 'R':
                    Direction = Direction.TurnRight();
                    break;
                case 'F':
                    MoveForward(grid);
                    break;
                default:
                    throw new ArgumentException($"Invalid instruction: {instruction}");
            }
        }
    }

    private void MoveForward(Grid grid)
    {
        Position nextPosition = Direction.GetForwardPosition(Position);

        // If next position is out of bounds
        if (!grid.IsWithinBounds(nextPosition))
        {
            // Check if current position has scent - if so, ignore the move
            if (grid.HasScent(Position))
            {
                return; // Ignore the instruction
            }

            // Otherwise, robot is lost
            grid.AddScent(Position); // Leave scent at last valid position
            IsLost = true;
            return;
        }

        // Move to next position
        Position = nextPosition;
    }

    public override string ToString()
    {
        string result = $"{Position} {Direction.ToChar()}";
        return IsLost ? $"{result} LOST" : result;
    }
}

