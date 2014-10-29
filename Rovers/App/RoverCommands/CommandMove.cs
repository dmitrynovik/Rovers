namespace Rovers.App.RoverCommands
{
    internal class CommandMove : IRoverCommand
    {
        public void Execute(Rover r, IRoverValidator validator)
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

            if (validator != null)
                validator.Validate(r);
        }
    }
}
