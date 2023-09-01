using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Parsers
    {
        /// <summary>
        /// Parse a string representing a header.
        /// A header string consists of four integers seperaded by space or commas: width, height, X-position, Y-position
        /// </summary>
        /// <param name="line">String that will be parsed as a header</param>
        /// <returns>Tuple: (tableWidth, tableHeight, position)</returns>
        /// <exception cref="Exception">Throws Exception on invalid header</exception>
        public static (int tableWidth, int tableHeight, Position position) ParseHeader(string line)
        {
            var tokens = line.Split(new char[] { ' ', '\t', ',' });

            if (tokens.Length != 4)
            {
                throw new Exception("Invalid header, expected 4 integers");
            }

            var intValues = tokens.Select(token =>
            {
                if (int.TryParse(token, out int result))
                {
                    return result;
                }
                else
                {
                    throw new Exception($"Invalid token, expected integer but got: \"{token}\"");
                }
            }).ToArray();

            return (tableWidth: intValues[0], tableHeight: intValues[1], position: new Position(intValues[2], intValues[3]));
        }

        /// <summary>
        /// Parse a string containing commands to be executed.
        /// </summary>
        /// <param name="line">String to be parsed as commands, a command is an integer, the commands are separated by space or commas</param>
        /// <returns>Array of commands</returns>
        /// <exception cref="Exception">Throws Exception on invalid commands</exception>
        public static Command[] ParseCommands(string line)
        {
            var tokens = line.Split(new char[] { ' ', '\t', ',' });

            var commands = tokens.Select(token =>
            {
                if (int.TryParse(token, out int result))
                {
                    if (!IsValidCommand(result))
                    {
                        throw new Exception($"Invalid instruction: {result}");
                    }

                    return (Command)result;
                }
                else
                {
                    throw new Exception($"Invalid command: {token}");
                }
            }).ToArray();

            return commands;
        }

        private static bool IsValidCommand(int value)
        {
            return Enum.IsDefined(typeof(Command), value);
        }
    }
}
