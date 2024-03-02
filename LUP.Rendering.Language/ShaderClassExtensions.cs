using LUP.Rendering.Language.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language
{
    public static class ShaderClassExtensions
    {
        public static IEnumerable<ShaderMethod> GetMethods(this ShaderClass @class)
        {
            return SelectFrom<ShaderMethod>(@class.Members);
        }


        public static void GetClassParamters(this ShaderClass @class)
        {

        }


        public static void GetAttributes(this ShaderClass @class)
        {

        }



        private static IEnumerable<T> SelectFrom<T>(IEnumerable<IShaderMember> members)
            where T : class, IShaderMember
        {
            return from o in members where o is T 
                   select o as T;
        }
    }
}
