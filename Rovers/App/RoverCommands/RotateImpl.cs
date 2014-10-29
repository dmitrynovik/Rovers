namespace Rovers.App.RoverCommands
{
    internal static class RotateImpl
    {
        public static void Rotate(Rover r, bool clockwise)
        {
            var dir = (int) r.Direction;
            if (clockwise)
            {
                dir = (dir + 1) % 4; // N -> E -> S -> W
            }
            else
            {
                dir = (dir == 0) ? 3 : dir - 1; // N -> W -> S -> E
            }
            r.Direction = (Direction) dir;
        }
    }
}
