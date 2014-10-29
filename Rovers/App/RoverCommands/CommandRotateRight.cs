namespace Rovers.App.RoverCommands
{
    internal class ActionRotateRight : IRoverAction
    {
        public void Perform(Rover r, IRoverValidator validator)
        {
            RotateImpl.Rotate(r, true);
        }
    }
}
