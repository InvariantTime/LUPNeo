using LUP.Mathematics;
using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    //TODO: math of transform
    public sealed partial class TransformComponent : ComponentBase, IObjectProvider
    {
        private bool needUpdateMatrices;

        private Matrix4 local;
        private Matrix4 inverse;

        public Vector3 Position { get; set; }

        public Quaternion Rotation { get; set; }

        public Vector3 Scale { get; set; }

        
        public Matrix4 GetLocalMatrix()
        {
            if (needUpdateMatrices == true)
            {
                UpdateMatrices();
                needUpdateMatrices = false;
            }

            return local;
        }


        private void UpdateMatrices()
        {
            
        }
    }
}
