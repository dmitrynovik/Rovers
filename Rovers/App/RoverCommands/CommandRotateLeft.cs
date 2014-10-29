namespace Rovers.App.RoverCommands
{
    internal class ActionRotateLeft : IRoverAction
    {
        public void Perform(Rover r, IRoverValidator validator)
        {
            RotateImpl.Rotate(r, false);
        }
    }
}
