using LUP.Math;
using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    //TODO: math of transform
    public sealed partial class TransformComponent : ComponentBase, IObjectProvider
    {
        private Matrix4 localMatrix = Matrix4.Identity;
        private Matrix4 globalMatrix = Matrix4.Identity;

        private bool needUpdateMatrices;

        private Vector3 position;
        private Quaternion rotation = Quaternion.Identity;
        private Vector3 scale = new Vector3(1, 1, 1);

        public Vector3 Position
        {
            get => position;

            set
            {
                position = value;
                needUpdateMatrices = true;
            }
        }

        public Quaternion Rotation
        {
            get => rotation;

            set
            {
                rotation = value;
                needUpdateMatrices = true;
            }
        }

        public Vector3 Scale
        {
            get => scale;

            set
            {
                scale = value;
                needUpdateMatrices = true;
            }
        }


        public Matrix4 GetLocalMatrix()
        {
            if (needUpdateMatrices == true)
            {
                UpdateMatrices();
                needUpdateMatrices = false;
            }

            return localMatrix;
        }


        public Matrix4 GetGlobalMatrix()
        {
            if (needUpdateMatrices == true)
            {
                UpdateMatrices();
                needUpdateMatrices = false;
            }

            return globalMatrix;
        }


        private void UpdateMatrices()
        {
            localMatrix = Matrix4.CreateTranslation(position) * rotation.GetMatrix()
                * Matrix4.CreateScaling(scale);

            //TODO: global matrix
            globalMatrix = localMatrix;

            needUpdateMatrices = false;
        }
    }
}
