namespace LUP.SceneGraph
{
    public class SceneProcessor : IApplicationStage
    {
        private readonly ISceneProvider provider;

        public SceneProcessor(ISceneProvider provider)
        {
            this.provider = provider;
        }

        public void Handle(LoopContext context)
        {
            throw new NotImplementedException();
        }
    }
}
