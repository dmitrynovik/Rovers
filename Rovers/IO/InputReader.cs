using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Rovers.App;
using Rovers.App.RoverCommands;

namespace Rovers.IO
{
    // Contains all the parsing rules of the solution.
    internal class InputReader : IDisposable
    {
        private const char Delimiter = ' ';
        private TextReader reader;

        public InputReader(TextReader inputReader)
        {
            if (inputReader == null)
                throw new ArgumentNullException("inputReader");

            reader = inputReader;
        }

        private static int ParseNumber(string number)
        {
            return int.Parse(number, CultureInfo.InvariantCulture);
        }

        public bool EndOfFile
        {
            get { return IsEndOfFile(reader.Peek()); }
        }

        private bool IsEndOfLine()
        {
            return IsEndOfLine(reader.Peek());
        }

        private static bool IsEndOfLine(int ch)
        {
            return IsEndOfFile(ch) || (ch == 10) || (ch == 13);
        }

        private static bool IsEndOfFile(int ch)
        {
            return ch == -1;
        }

        public Field ReadField()
        {
            var dimensions = ReadLineTokens(2);
            return new Field(ParseNumber(dimensions[0]), ParseNumber(dimensions[1]));
        }

        private string[] ReadLineTokens(int expectedLength)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
                throw new RoverException("Input read error: unexpected empty string.");

            var dimensions = line.Split(new char[] {Delimiter}, StringSplitOptions.RemoveEmptyEntries);
            if (dimensions.Length != expectedLength)
                throw new RoverException(string.Format("Input read error: Expected {0} arguments in the line separated by '{1}', read: {2}",
                        expectedLength, Delimiter, dimensions.Length));

            return dimensions;
        }

        public Rover ReadRover(Field plateau)
        {
            var args = ReadLineTokens(3);
            return new Rover() {X = ParseNumber(args[0]), Y = ParseNumber(args[1]), Direction = StringToDirection(args[2])};
        }

        private static Direction StringToDirection(string s)
        {
            switch (s.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "W":
                    return Direction.West;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                default:
                    throw new RoverException(string.Format("Unexpected direction: '{0}'", s));
            }
        }

        internal IEnumerable<IRoverCommand> ReadRoverCommands()
        {
            while (!IsEndOfLine())
            {
                var ch = ReadChar();
                switch (ch)
                {
                    case 'L':
                        yield return new ActionRotateLeft();
                        break;
                    case 'R':
                        yield return new ActionRotateRight();
                        break;
                    case 'M':
                        yield return new CommandMove();
                        break;
                    default:
                        if (char.IsLetterOrDigit(ch))
                            throw new RoverException(string.Format("Unexpected character '{0}' in rover's action sequence", ch));
                        break;
                }
            }
            MoveToNextLine();
        }

        private char ReadChar()
        {
            return (char)reader.Read();
        }

        private void MoveToNextLine()
        {
            while ((!EndOfFile) && IsEndOfLine())
                ReadChar();
        }

        public void Dispose()
        {
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
        }
    }
}
