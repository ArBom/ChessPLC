using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    class Rock : Chessman
    {
        Texture tempT = new Texture("..//..//textures//tkanina.jpg");

        private static VBO<Vector3> triangle = new VBO<Vector3>(new Vector3[] {
            new Vector3(0, 0, .35),
            new Vector3(0, .023333, .35), new Vector3(0.009567, 0.021316, .35), new Vector3(0.01734, 0.016133, .35), new Vector3(0.022193, 0.00721, .35),  new Vector3(0.023201, -0.001572, .35),
            new Vector3(0.023206, -0.011667, .35), new Vector3(0.013717, -0.018877, .35),  new Vector3(0.00485, -0.022827, .35),
            new Vector3(-0.00485, -0.022823, .35), new Vector3(-0.013717, -0.018877, .35), new Vector3(-0.020207, -0.011667, .35), new Vector3(-0.023207, -0.002438, .35),
            new Vector3(-0.022193, 0.00721, .35), new Vector3(-0.01734, 0.015613, .35), new Vector3(-0.009563, 0.021317, .35), new Vector3(0, 0.023333, .35),

            new Vector3(0, .023333, .4), new Vector3(0.009567, 0.021316, .4), new Vector3(0.01734, 0.016133, .4), new Vector3(0.022193, 0.00721, .4),  new Vector3(0.023201, -0.001572, .4),
            new Vector3(0.023206, -0.011667, .4), new Vector3(0.013717, -0.018877, .4),  new Vector3(0.00485, -0.022827, .4),
            new Vector3(-0.00485, -0.022823, .4), new Vector3(-0.013717, -0.018877, .4), new Vector3(-0.020207, -0.011667, .4), new Vector3(-0.023207, -0.002438, .4),
            new Vector3(-0.022193, 0.00721, .4), new Vector3(-0.01734, 0.015613, .4), new Vector3(-0.009563, 0.021317, .4), new Vector3(0, 0.023333, .4),

            new Vector3(0, .07, .4), new Vector3(0.01455, 0.068467, .4), new Vector3(0.02847, 0.06395, .4), new Vector3(0.04115, 0.05663, .4), new Vector3(0.05202, 0.0484, .4), new Vector3(0.06062, 0.035, .4), new Vector3(0.06658, 0.02163, .4), new Vector3(0.06962, 0.004715, .4), new Vector3(0.06962, -0.004715, .4),
            new Vector3(0.06658, -0.02163, .4), new Vector3(0.06062, -0.035, .4), new Vector3(0.05202, -0.04684, .4), new Vector3(0.04115, -0.05663, .4), new Vector3(0.02847, -0.06545, .4), new Vector3(0.01455, -0.06848, .4), new Vector3(0, -0.07, .4),
            new Vector3(-0.01455, -0.06847, .4), new Vector3(-0.02843, -0.06395, .4), new Vector3(-0.04115, -0.05663, .4), new Vector3(-0.05202, -0.04684, .4), new Vector3(-0.06062, -0.035, .4), new Vector3(-0.06658, -0.02163, .4), new Vector3(-0.06962, -0.007315, .4), new Vector3(-0.06962, 0.007315, .4),
            new Vector3(-0.06658, 0.02163, .4), new Vector3(-0.06062, 0.035, .4), new Vector3(-0.05202, 0.04684, .4), new Vector3(-0.04115, 0.05663, .4), new Vector3(-0.02869, 0.06395, .4), new Vector3(-0.01019, 0.06847, .4), new Vector3(0, 0.07, .4),

        });

        private static VBO<uint> triangleElements = new VBO<uint>(new uint[] {
            0,1,2, 0,2,3, 0,3,4, 0,4,3, 0,5,4, 0,6,5, 0,7,6, 0,8,7, 0,9,8, 0,10,9, 0,11,10, 0,12,11, 0,13,12, 0,14,13, 0,15,14, 0,16,15, 0,1,16,
            1,17,18, 1,2,18,  3,4,19, 4,19,20,  5,6,22, 5,22,21,  8,7,24, 7,24,23,  9,10,25, 10,25,26,  11,12,27, 12,27,28,  13,14,29, 14,29,30,

        }, BufferTarget.ElementArrayBuffer);

        public override void Draw(ShaderProgram program)
        {
            
            DrawCoping(program);
            DrawBase(program, .1f, 2.0f);
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

        public Rock()
        {
            chessman_T = Chessman_type.Rock;
            //coping =;
        }

        ~Rock()
        {
            triangleElements.Dispose();
            triangle.Dispose();
        }

    }
}
