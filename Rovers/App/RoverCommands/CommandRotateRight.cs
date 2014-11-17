namespace Rovers.App.RoverCommands
{
    internal class ActionRotateRight : IRoverCommand
    {
        public void Execute(Rover r, Field plateau)
        {
            RotateImpl.Rotate(r, true);
        }
    }
}
