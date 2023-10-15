namespace LUP.Client.Input
{
    public interface IInputHandler
    {
        IMouse Mouse { get; }

        IKeyboard Keyboard { get; }

        void Update();
    }
}
