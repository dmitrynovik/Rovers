namespace Rovers.App.RoverCommands
{
    internal class ActionRotateLeft : IRoverCommand
    {
        public void Execute(Rover r, Field plateau)
        {
            RotateImpl.Rotate(r, false);
        }
    }
}
