namespace Rovers.App
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public override string ToString()
        {
            return string.Join(" ", X, Y, Direction.ToString().Substring(0, 1));
        }
    }
}
