using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Effects
{
    public interface IEffectAcessor
    {
        //Scalars
        void Set(string name, float value);

        void Set(string name, int value);

        void Set(string name, bool value);

        void Set(string name, double value);

        void Set(string name, uint value);

        //Vector 2
        void Set(string name, Vec2<float> value);

        void Set(string name, Vec2<int> value);

        void Set(string name, Vec2<double> value);

        void Set(string name, Vec2<uint> value);

        //Vector 3
        void Set(string name, Vec3<float> value);

        void Set(string name, Vec3<int> value);

        void Set(string name, Vec3<double> value);

        void Set(string name, Vec3<uint> value);

        //Vector 4
        void Set(string name, Vec4<float> value);

        void Set(string name, Vec4<int> value);

        void Set(string name, Vec4<double> value);

        void Set(string name, Vec4<uint> value);

        //Other
        void Set(string name, Matrix4 value);

        void Set(string name, Matrix4[] value);
    }
}
