using ClassLibrary1;

Position FailurePosition = new(-1, -1);

Position result = FailurePosition;

try
{
    // Read the first line (header)
    var line = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(line))
    {
        return;
    }

    var (tableWidth, tableHeight, startPosition) = Parsers.ParseHeader(line);
    ITable table = new RectangularTable(tableWidth, tableHeight);

    if (!table.IsValidPosition(startPosition))
    {
        throw new InvalidPositionException($"Invalid start position: {startPosition}");
    }

    List<Command> commands = new();

    // Read the next line which are the commands...
    line = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(line))
    {
        commands.AddRange(Parsers.ParseCommands(line));
    }

    // perform the actual simulation
    result = Simulator.Simulate(table, startPosition, commands.ToArray());
}
catch (InvalidPositionException)
{
    // Intentionally left blank, default value of "result" ([-1, -1]) will be printed at end of program
}
catch (Exception ex)
{
    Console.Error.WriteLine($"ERROR: {ex.Message}");
    return;
}

Console.WriteLine(result.ToString());
