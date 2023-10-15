using LUP.Math;

namespace LUP.Client.Input
{
    public interface IMouse
    {
        event EventHandler<MouseEventArgs>? ButtonDown;

        event EventHandler<MouseEventArgs>? ButtonRelease;

        event EventHandler<CursorArgs>? MouseMoved;

        ICursor Cursor { get; }

        bool IsButtonPressed(MouseButtons button);

        Vector2 GetPosition();

        void SetPosition(Vector2 position);
    }

    public interface ICursor
    {
        CursorStates State { get; set; }   
    }

    public enum CursorStates
    {
        Enable = 0,

        Hide = 1,

        Disable = 2
    }
}
