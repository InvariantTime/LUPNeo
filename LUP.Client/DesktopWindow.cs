using LUP.Logging;
using Silk.NET.SDL;

namespace LUP.Client
{
    public unsafe class DesktopWindow : IInput, IWindow, IDisposable
    {
        private readonly Sdl sdl;
        private readonly Window* handle;
        private readonly Renderer* renderer;
        private readonly ILogger<DesktopWindow> logger;

        public string Title
        {
            get => sdl.GetWindowTitleS(handle);

            set => sdl.SetWindowTitle(handle, value);
        }

        public DesktopWindow(ILogger<DesktopWindow> logger, IOption<DesktopSettings> settings)
        {
            this.logger = logger;
            sdl = Sdl.GetApi();

            var s = settings.Accessor;
            handle = sdl.CreateWindow(s.Title, Sdl.WindowposUndefined, 
                Sdl.WindowposUndefined, s.Width, s.Height, BuildFlags(s));

            if (handle == null)
                logger.Error("Unable to create window", sdl.GetErrorAsException());

            renderer = sdl.CreateRenderer(handle, -1, (uint)(RendererFlags.Accelerated | RendererFlags.Presentvsync));

            if (renderer == null)
                logger.Error("Unable to create renderer", sdl.GetErrorAsException());
        }


        public void HandleEvents()
        {
            Event e = new();
            while(sdl.PollEvent(ref e) == 1)
            {

            }
        }

        
        public void Render()
        {

        }


        public void Dispose()
        {
            sdl.DestroyWindow(handle);
            sdl.DestroyRenderer(renderer);
            sdl.Dispose();
        }


        private static uint BuildFlags(DesktopSettings settings)
        {
            return (uint)(WindowFlags.Shown);
        }
    }
}
