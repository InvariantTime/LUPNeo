namespace LUP.Client.Input
{
    public interface IInputProcessor : IApplicationStage
    {
        IInputHandler Input { get; }
    }
}
