namespace Rovers.App.RoverCommands
{
    internal class ActionRotateRight : IRoverCommand
    {
        public void Execute(Rover r, IRoverValidator validator)
        {
            RotateImpl.Rotate(r, true);
        }
    }
}
