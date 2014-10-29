namespace Rovers.App.RoverCommands
{
    internal class CommandMove : IRoverAction
    {
        public void Perform(Rover r, IRoverValidator validator)
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
