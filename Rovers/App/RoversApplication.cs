using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rovers.IO;

namespace Rovers.App
{
    // The main class of the solution. IO-agnostic and command-agnostic.
    public class RoversApplication
    {
        private InputReader  _reader;
        private ICollection<Rover> _rovers = new List<Rover>();

        public RoversApplication(string input)
        {
            _reader = new InputReader(new StringReader(input));
            MoveAll();
        }

        // The main method of the solution.
        // The method processes rover by rover, and reads the commands one by one, so it uses O(1) (constant) memory and scalable.
        private void MoveAll()
        {
            var plateau = _reader.ReadField();
            while (!_reader.EndOfFile)
            {
                // Create rover:
                var rover = _reader.ReadRover(plateau);
                _rovers.Add(rover);

                // Get and perform the sequence of rover's actions (read & do one by one and returned via iterator).
                // Since the logic of command is encapsulated in a command itself (strategy pattern), the solution is extensible:
                foreach (var command in _reader.ReadRoverCommands())
                    command.Execute(rover, plateau);
            }
        }

        public override string ToString()
        {
            return string.Join("\r\n", _rovers.Select(r => r.ToString())) + "\r\n==========";
        }
    }
}
