namespace Rovers.App.RoverCommands
{
    internal class ActionRotateLeft : IRoverCommand
    {
        public void Execute(Rover r, IRoverValidator validator)
        {
            RotateImpl.Rotate(r, false);
        }
    }
}
