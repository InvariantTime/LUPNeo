namespace LUP.SceneGraph.Modules
{
    public abstract class SceneModule : DisposableObject
    {
        public int UpdatePerSecond { get; protected set; } = 0;


        //TODO: scehduling
        public virtual void Update()
        {

        }
    }
}
