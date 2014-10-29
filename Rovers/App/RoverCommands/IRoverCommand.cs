namespace Rovers.App.RoverCommands
{
    internal interface IRoverCommand
    {
        void Execute(Rover r, IRoverValidator validator);
    }
}
