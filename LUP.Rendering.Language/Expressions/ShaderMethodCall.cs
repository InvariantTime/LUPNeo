using LUP.Rendering.Language.Members;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderMethodCall : IShaderMemberCall
    {
        public ShaderMethod Method { get; }

        public string? ParentParameter { get; }

        public ShaderMethodCall(ShaderMethod method, string? parent = null)
        {
            Method = method;
            ParentParameter = parent;
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T info)
        {
            visitor.Visit(this, info);
        }
    }
}
