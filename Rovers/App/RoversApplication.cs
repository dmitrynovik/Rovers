using System.IO;
using Rovers.IO;

namespace Rovers.App
{
    // The main class of the solution. IO-agnostic and command-agnostic.
    public class RoversApplication
    {
        private InputReader  reader;
        private OutputWriter writer;
        private readonly bool mustDispose = false;

        public RoversApplication(string inputFile, string outputFile)
        {
            Init(new StreamReader(inputFile), new StreamWriter(outputFile));
            mustDispose = true;
        }

        public RoversApplication(StreamReader input, TextWriter output)
        {
            Init(input, output);
        }

        private void Init(StreamReader input, TextWriter output)
        {
            reader = new InputReader(input);
            writer = new OutputWriter(output);
        }

        // The main method of the solution.
        // The method processes rover by rover, and reads the commands one by one, so it uses O(1) (constant) memory and scalable.
        public void CalculateFinalRoversDeployment()
        {
            Field plateau = reader.ReadField();
            while (!reader.EndOfFile)
            {
                // Create rover:
                Rover rover = reader.ReadRover(plateau);

                // Get and perform the sequence of rover's actions (read & do one by one and returned via iterator).
                // Since the logic of command is encapsulated in a command itself (strategy pattern), the solution is extensible:
                foreach (var command in reader.ReadRoverCommands())
                    command.Perform(rover, plateau);

                // Write final coordinates:
                writer.WriterRoverCoordinates(rover);
            }

            if (mustDispose)
            {
                reader.Dispose();
                writer.Dispose();
            }
        }
    }
}
