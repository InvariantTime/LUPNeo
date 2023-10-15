namespace LUP.Client.Input
{
    class InputProcessor : IInputProcessor
    {
        public IInputHandler Input { get; }

        public InputProcessor(IInputHandler input)
        {
            Input = input;
        }


        public void Handle(LoopContext context)
        {
            Input.Update();
        }
    }
}
