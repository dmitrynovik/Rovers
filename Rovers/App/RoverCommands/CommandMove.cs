namespace Rovers.App.RoverCommands
{
    internal class CommandMove : IRoverCommand
    {
        public void Execute(Rover r, Field field)
        {
            switch (r.Direction)
            {
                case Direction.East:
                    r.X++;
                    break;
                case Direction.West:
                    r.X--;
                    break;
                case Direction.North:
                    r.Y++;
                    break;
                case Direction.South:
                    r.Y--;
                    break;
            }

            if (field != null)
                field.ValidateBounds(r);
        }
    }
}
