namespace Rovers.App.RoverCommands
{
    internal interface IRoverAction
    {
        void Perform(Rover r, IRoverValidator validator);
    }
}
