
namespace LUP.Graphics.Commanding
{
    public interface IGraphicsCommandList
    {
        public ShaderCommands ShaderCommands { get; }

        public DrawingCommands DrawingCommands { get; }

        public TexturingCommands TexturingCommands { get; }

        public BufferCommands BufferCommands { get; }

        public StateCommands StateCommands { get; }

        public IGraphicsCommandProvider? PlatformCommands => null;
    }
}
