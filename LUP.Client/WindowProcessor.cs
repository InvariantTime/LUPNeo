namespace LUP.Client
{
    class WindowProcessor : IWindowProcessor
    {
        public IWindow Window { get; }

        public WindowProcessor(IWindow window)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }


        public void Handle(LoopContext context)
        {
            Window.Renderer?.Render();
            Window.Update();
        }
    }
}
