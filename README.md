# Marsbot

C# console application that simulates robot movement on the surface of Mars according to instructions provided from Earth.

## Problem Description

The surface of Mars is modeled by a rectangular grid where robots can move according to instructions. Each robot has a position (x, y coordinates) and an orientation (North, South, East, West). Robots can turn left, turn right, or move forward one grid point.

When a robot moves off the edge of the grid, it becomes "lost" but leaves a "scent" that prevents future robots from falling off at the same location.
