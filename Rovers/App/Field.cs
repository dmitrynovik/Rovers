using System;

namespace Rovers.App
{
    internal class Field : IRoverValidator
    {
        public int Length { get; private set; }
        public int Height  { get; private set; }

        public Field(int length, int height)
        {
            Length = length;
            Height = height;
        }

        public void Validate(Rover r)
        {
            if ((r.Y > Height) || (r.X > Length) || (r.Y < 0) || (r.X < 0))
                throw new RoverException(string.Format("Rover coordnates [{0},{1}] out of field's bounds [{2},{3}]",
                                                          r.X, r.Y, Length, Height));
        }
    }
}
