using System;
using System.IO;
using Rovers.App;

namespace Rovers.IO
{
    internal class OutputWriter : IDisposable
    {
        private TextWriter writer;

        public OutputWriter(TextWriter outputWriter)
        {
            if (outputWriter == null)
                throw new ArgumentNullException("outputWriter");

            writer = outputWriter;
        }

        public void Dispose()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

        internal void WriterRoverCoordinates(Rover r)
        {
            const string delimiter = " ";
            writer.WriteLine(string.Join(delimiter, r.X, r.Y, r.Direction.ToString().Substring(0, 1)));
        }
    }
}
