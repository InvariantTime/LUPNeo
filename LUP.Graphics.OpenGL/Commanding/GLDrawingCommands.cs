using LUP.Graphics.Commanding;
using LUP.Graphics.Enums;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GLDrawingCommands : DrawingCommands
    {
        public override void Clear(ClearMask mask)
        {
            GL.Clear(OpenGLConverter.Convert(mask));
        }


        public override void Draw(DrawData data)
        {
            var primitive = OpenGLConverter.Convert(data.Primitive);

            if (data.IsIndixed == true)
            {
                GL.DrawElements(primitive, data.Count, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(primitive, data.First, data.Count);
            }
        }


        public override void DrawInstance(DrawInstanceData data)
        {
            var primitive = OpenGLConverter.Convert(data.Data.Primitive);

            if (data.Data.IsIndixed == true)
            {
                GL.DrawElementsInstanced(primitive, data.Data.Count, DrawElementsType.UnsignedInt, 0, data.Count);
            }
            else
            {
                GL.DrawArraysInstanced(primitive, data.Data.First, data.Data.Count, data.Count);
            }
        }


        public override void BindVertexFormat(VertexFormat format)
        {
            foreach (var attrib in format.Attributes)
            {
                GL.EnableVertexAttribArray(attrib.Index);
                GL.VertexAttribPointer(attrib.Index, attrib.Size,
                    OpenGLConverter.Convert(attrib.Type), false, attrib.Stride, attrib.Offset);
            }
        }


        public override void UnbindVertexFormat(VertexFormat format)
        {
            foreach (var attrib in format.Attributes)
                GL.DisableVertexAttribArray(attrib.Index);
        }
    }
}
