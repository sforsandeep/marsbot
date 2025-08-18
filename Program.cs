using Marsbot;

// Entry point for the Marsbot simulation
class Program
{
    // Main method: handles input, output, and error reporting
    static void Main(string[] args)
    {
        try
        {
            // Read input (from console or file)
            string input = GetInput();
            // Process robot instructions and get results
            string output = ProcessRobots(input);
            // Print only the final output (positions and LOST status)
            Console.WriteLine(output); // required final output only
        }
        catch (Exception ex)
        {
            // Print error message and exit with error code
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }


    // Reads input from the user or falls back to file
    private static string GetInput()
    {

        if (!Console.IsInputRedirected) // Check if input is redirected (e.g. from a file)
            Console.Error.WriteLine("Paste input. Press ENTER on a blank line to use instructions.txt."); //using Console.Error to avoid mixing with output

        var lines = new List<string>();
        string? line;

        // Read lines until a blank line or end of input
        while ((line = Console.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) break;
            lines.Add(line);
        }

        // If user provided input, use it
        if (lines.Count > 0)
            return string.Join("\n", lines);

        // Otherwise, load instructions from file
        return GetFileInput();
    }

    // Loads input from instructions.txt in the executable directory
    private static string GetFileInput()
    {
        var baseDir = AppContext.BaseDirectory;
        var samplePath = Path.Combine(baseDir, "instructions.txt");

        if (!File.Exists(samplePath))
            throw new FileNotFoundException("No input provided and instructions.txt not found.", samplePath);

        var text = File.ReadAllText(samplePath).Trim();
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("instructions.txt is empty.");

        return text;
    }

    // Parses input and simulates all robots, returning their final states
    private static string ProcessRobots(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty");

        // Split input into lines, ignoring empty lines
        string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 1)
            throw new ArgumentException("Input must contain grid dimensions");

        // Parse grid size from the first line
        Grid grid = ParseGrid(lines[0]);

        var results = new List<string>();
        // Each robot is described by two lines: position and instructions
        for (int i = 1; i < lines.Length; i += 2)
        {
            if (i + 1 >= lines.Length)
                throw new ArgumentException($"Missing instructions for robot at line {i + 1}");

            // Parse robot's starting position and direction
            Robot robot = ParseRobot(lines[i]);
            // Get movement instructions for this robot
            string instructions = lines[i + 1].Trim();

            // Simulate robot's movement on the grid
            robot.Execute(instructions, grid);
            // Add robot's final state to results (e.g. "1 1 E" or "3 3 N LOST")
            results.Add(robot.ToString());
        }

        // Return all robot results, one per line
        return string.Join(Environment.NewLine, results);
    }

    // Parses grid dimensions from input line
    private static Grid ParseGrid(string gridLine)
    {
        string[] coords = gridLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (coords.Length != 2)
            throw new ArgumentException("Grid line must contain exactly 2 coordinates");

        if (!int.TryParse(coords[0], out int maxX) || !int.TryParse(coords[1], out int maxY))
            throw new ArgumentException("Grid coordinates must be integers");

        return new Grid(maxX, maxY);
    }

    // Parses robot's initial position and direction from input line
    private static Robot ParseRobot(string robotLine)
    {
        string[] parts = robotLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3)
            throw new ArgumentException("Robot line must contain x, y, and direction");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Robot coordinates must be integers");

        // Validate robot coordinates are within allowed range
        if (x < 0 || y < 0 || x > 50 || y > 50)
            throw new ArgumentException("Robot coordinates must be between 0 and 50");

        if (parts[2].Length != 1)
            throw new ArgumentException("Direction must be a single character");

        // Convert direction character to Direction enum
        Direction direction = DirectionExtensions.FromChar(parts[2][0]);
        Position position = new Position(x, y);

        // Create and return new Robot instance
        return new Robot(position, direction);
    }
}
