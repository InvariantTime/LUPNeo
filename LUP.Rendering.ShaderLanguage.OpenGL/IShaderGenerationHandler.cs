using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation
{
    public interface IShaderGenerationHandler
    {
        void HandleMainCode(ShaderCodeDescriptor descriptor, StringBuilder source);

        string HandleFinishCode(ShaderCodeDescriptor descriptor, string source);
    }

    public class EmptyGenerationHandler : IShaderGenerationHandler
    {
        public static readonly EmptyGenerationHandler Instance = new();

        private EmptyGenerationHandler()
        { }


        public string HandleFinishCode(ShaderCodeDescriptor descriptor, string source)
        {
            return source;
        }


        public void HandleMainCode(ShaderCodeDescriptor descriptor, StringBuilder source)
        {
        }
    }
}
