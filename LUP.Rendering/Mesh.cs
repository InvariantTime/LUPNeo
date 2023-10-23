namespace LUP.Rendering
{
    //TODO: box
    public class Mesh
    {
        public int MaterialIndex { get; set; } = -1;

        public MeshDraw Draw { get; }

        public Mesh(MeshDraw draw)
        {
            Draw = draw;
        }
    }
}
