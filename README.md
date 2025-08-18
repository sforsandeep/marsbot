# Marsbot Challenge

This project is an implementation of the classic **Martian Robots coding challenge**. Robots move on a rectangular grid, following sequences of instructions. If a robot leaves the grid, it is marked as _LOST_ and leaves a scent that prevents later robots from repeating the same mistake.

## Tech Choices

- **Language:** C# was chosen for its strong typing, performance, and suitability for console applications.
- **Structure:** The solution is split into clear classes for grid, robot, position, and direction to keep logic organized and maintainable.
- **Extension Methods:** Used for direction logic to keep code modular and readable.
- **No UI:** The program is a console app, focused only on the requirements for simplicity and clarity.

## Problem Approach

- The grid is modeled as a class that tracks boundaries and scent positions where robots are lost.
- Robots are simulated step-by-step, following instructions and updating their position and orientation.
- Scent logic prevents robots from getting lost at the same spot as previous robots.
- Input is parsed from the console or file, supporting flexible usage and easy testing.

## Project Structure

- **Program.cs** — Entry point, handles input, validation, and simulation loop.
- **Robot.cs** — Robot logic (turning, moving, lost state).
- **Grid.cs** — Grid boundaries and scent tracking.
- **Position.cs** — Struct representing coordinates.
- **Direction.cs** — Enum and extensions for turning/moving directions.

## Requirements

- .NET 7 SDK or later installed.
- A text file with input instructions (e.g. `instructions.txt`).

## Input Format

The input consists of:

1. Upper-right coordinates of the grid.
2. Pairs of lines for each robot:

   - Starting position and orientation.
   - Instruction string.

Example:

```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

## Output Format

One line per robot with its final coordinates and orientation. Append `LOST` if the robot fell off the grid.

Example output:

```
1 1 E
3 3 N LOST
2 3 S
```

## Running the Program

### Option 1: Using instructions.txt

- Place an `instructions.txt` file in the build output directory (next to the executable).
- Run the program without arguments:

```bash
dotnet run
```

- The program will:

  - Wait for input from the console. If you press **Enter** on a blank line, it will load `instructions.txt` automatically.

### Option 2: Redirecting input (recommended for testing)

You can feed a file directly via stdin redirection:

```bash
dotnet run < input.txt
```

### Option 3: Manual input

Run the program and paste input directly, then press **Enter** on a blank line to process it.

## Testing

1. Create an `input.txt` file with the test case.
2. Run:

   ```bash
   dotnet run < input.txt > actual.txt
   ```

3. Compare `actual.txt` against your expected output.

## Releases (Prebuilt Binary)

If you prefer not to build from source, download the latest prebuilt binary from the repository’s **Releases** page and run it directly.

**How to use the release:**

1. Download the archive from **Releases**.
2. Unzip.
3. Prepare an `input.txt` with your test case (see _Input Format_ above), or place an `instructions.txt` next to the executable for fallback. There is a default instructionx.txt already there which you can modify for updating the instructions. Or can manually enter the instructions when prompted.
4. Run:

   ```cmd
   marsbot.exe < input.txt
   ```

   or

   ```cmd
   marsbot.exe < input.txt >output.txt
   ```

or

```cmd
marsbot.exe
```

which will prompts for input or fallback into instructions.txt if no input
