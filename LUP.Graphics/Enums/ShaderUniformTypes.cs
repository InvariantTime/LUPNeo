using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Enums
{
    public enum ShaderUniformTypes
    {
        None = -1,

        //Scalar
        Int = 0,

        Float = 1,

        Double = 2,

        Uint = 3,

        Bool = 4,

        //Vector 2
        Vec2 = 5,

        IVec2 = 6,

        UVec2 = 7,

        DVec2 = 8,

        //Vector3
        Vec3 = 9,

        IVec3 = 10, 

        UVec3 = 11,

        DVec3 = 12,

        //Vector4
        Vec4 = 13,

        IVec4 = 14,

        UVec4 = 15,

        DVec4 = 16,

        //Other
        Mat4 = 17,
    }
}
