using Assimp;
using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Export
{
    public static class AssimpMathConverter
    {
        public static Vector3 Convert(this Vector3D vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}
