using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    public class Pawn : Chessman
    {

        Texture tempT = new Texture("..//..//textures//tkanina.jpg");

        private static VBO<Vector3> triangle = new VBO<Vector3>(new Vector3[] {
            new Vector3(0, 0, .46),
            new Vector3(0, .023333, .4), new Vector3(0.009567, 0.021316, .4), new Vector3(0.01734, 0.016133, .4), new Vector3(0.022193, 0.00721, .4),  new Vector3(0.023201, -0.001572, .4),
            new Vector3(0.023206, -0.011667, .4), new Vector3(0.013717, -0.018877, .4),  new Vector3(0.00485, -0.022827, .4),
            new Vector3(-0.00485, -0.022823, .4), new Vector3(-0.013717, -0.018877, .4), new Vector3(-0.020207, -0.011667, .4), new Vector3(-0.023207, -0.002438, .4),
            new Vector3(-0.022193, 0.00721, .4), new Vector3(-0.01734, 0.015613, .4), new Vector3(-0.009563, 0.021317, .4), new Vector3(0, 0.023333, .4),
        });

        private static VBO<uint> triangleElements = new VBO<uint>(new uint[] {
            0,1,2, 0,2,3, 0,3,4, 0,4,3, 0,5,4, 0,6,5, 0,7,6, 0,8,7, 0,9,8, 0,10,9, 0,11,10, 0,12,11, 0,13,12, 0,14,13, 0,15,14, 0,16,15, 0,1,16,
        }, BufferTarget.ElementArrayBuffer);

        public override void Draw(ShaderProgram program)
        {
            DrawCoping(program);
            DrawBase(program, 0.1f, .25f);

        }

        protected override void DrawCoping(ShaderProgram program)
        {
            uint vertexPositionIndex = (uint)Gl.GetAttribLocation(program.ProgramID, "vertexPosition");
            Gl.EnableVertexAttribArray(vertexPositionIndex);

            Gl.BindTexture(tempT);
            Gl.BindBuffer(triangle);
            Gl.VertexAttribPointer(vertexPositionIndex, triangle.Size, triangle.PointerType, true, 12, IntPtr.Zero);

            Gl.BindBuffer(triangleElements);

            // draw the triangle
            Gl.DrawElements(BeginMode.Triangles, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public Pawn()
        {
            chessman_T = Chessman_type.Pawn;
            //coping =;
        }
    }
}
