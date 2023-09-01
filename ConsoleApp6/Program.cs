using ClassLibrary1;

namespace ConsoleApp6
{
    internal class Program
    {
        private static readonly Position FailurePosition = new(-1, -1);

        static void Main(string[] args)
        {
            // Read the first line (header)
            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            var (tableWidth, tableHeight, startPosition) = Parsers.ParseHeader(line);

            List<Command> commands = new();

            // Read the remaining  line(s) which are the commands...
            line = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(line))
            {
                commands.AddRange(Parsers.ParseCommands(line));
                line = Console.ReadLine();
            }

            Position? result;

            try
            {
                result = Simulator.Simulate(new RectangularTable(tableWidth, tableHeight), startPosition, commands.ToArray());
            }
            catch (InvalidPositionException)
            {
                result = FailurePosition;
            }

            Console.WriteLine(result.ToString());
        }
    }
}