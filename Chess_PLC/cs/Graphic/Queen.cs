using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    class Queen : Chessman
    {
        Texture tempT = new Texture("..//..//textures//tkanina.jpg");

        private static VBO<Vector3> triangle = new VBO<Vector3>(new Vector3[] {
            new Vector3(0, 0, .46),
            new Vector3(0, .023333, .4), new Vector3(0.009567, 0.021316, .4), new Vector3(0.01734, 0.016133, .4), new Vector3(0.022193, 0.00721, .4),  new Vector3(0.023201, -0.001572, .4),
            new Vector3(0.023206, -0.011667, .4), new Vector3(0.013717, -0.018877, .4),  new Vector3(0.00485, -0.022827, .4),
            new Vector3(-0.00485, -0.022823, .4), new Vector3(-0.013717, -0.018877, .4), new Vector3(-0.020207, -0.011667, .4), new Vector3(-0.023207, -0.002438, .4),
            new Vector3(-0.022193, 0.00721, .4), new Vector3(-0.01734, 0.015613, .4), new Vector3(-0.009563, 0.021317, .4), new Vector3(0, 0.023333, .4),

            new Vector3(0, 0, .435),
            new Vector3(0, .07, .4), new Vector3(0.01455, 0.068467, .42), new Vector3(0.02847, 0.06395, .43), new Vector3(0.04115, 0.05663, .42), new Vector3(0.05202, 0.0484, .4), new Vector3(0.06062, 0.035, .37), new Vector3(0.06658, 0.02163, .4), new Vector3(0.06962, 0.004715, .42), new Vector3(0.06962, -0.004715, .43),
            new Vector3(0.06658, -0.02163, .42), new Vector3(0.06062, -0.035, .4), new Vector3(0.05202, -0.04684, .37), new Vector3(0.04115, -0.05663, .4), new Vector3(0.02847, -0.06545, .42), new Vector3(0.01455, -0.06848, .43), new Vector3(0, -0.07, .42),
            new Vector3(-0.01455, -0.06847, .4), new Vector3(-0.02843, -0.06395, .37), new Vector3(-0.04115, -0.05663, .4), new Vector3(-0.05202, -0.04684, .42), new Vector3(-0.06062, -0.035, .43), new Vector3(-0.06658, -0.02163, .42), new Vector3(-0.06962, -0.007315, .4), new Vector3(-0.06962, 0.007315, .37),
            new Vector3(-0.06658, 0.02163, .4), new Vector3(-0.06062, 0.035, .42), new Vector3(-0.05202, 0.04684, .43), new Vector3(-0.04115, 0.05663, .42), new Vector3(-0.02869, 0.06395, .4), new Vector3(-0.01019, 0.06847, .37), new Vector3(0, 0.07, .4),
            new Vector3(0, 0, .25),
        });

        private static VBO<uint> triangleElements = new VBO<uint>(new uint[] {
            0,1,2, 0,2,3, 0,3,4, 0,4,3, 0,5,4, 0,6,5, 0,7,6, 0,8,7, 0,9,8, 0,10,9, 0,11,10, 0,12,11, 0,13,12, 0,14,13, 0,15,14, 0,16,15, 0,1,16,
            17,18,48, 17,19,18, 17,20,19, 17,21,20, 17,22,21, 17,23,22, 17,24,23, 17,25,24, 17,26,25, 17,27,26, 17,28,27, 17,29,28, 17,30,29, 17,31,30, 17,32,31, 17,33,32, 17,34,33, 17,35,34, 17,36,35, 17,37,36, 17,38,37, 17,39,38, 17,40,39, 17,41,40, 17,42,41, 17,43,42, 17,44,43, 17,45,44, 17,46,45, 17,47,46, 17,48,47,
            18,48,49, 19,18,49, 20,19,49, 21,20,49, 22,21,49, 23,22,49, 24,23,49, 25,24,49, 26,25,49, 27,26,49, 28,27,49, 29,28,49, 30,29,49, 31,30,49, 32,31,49, 33,32,49, 34,33,49, 35,34,49, 36,35,49, 37,36,49, 38,37,49, 39,38,49, 40,39,49, 41,40,49, 42,41,49, 43,42,49, 44,43,49, 45,44,49, 46,45,49, 47,46,49, 48,47,49, 
        }, BufferTarget.ElementArrayBuffer);

        public override void Draw(ShaderProgram program)
        {

            DrawCoping(program);
            DrawBase(program, .1f, .4f);
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

        public Queen()
        {
            chessman_T = Chessman_type.King;
            //coping =;
        }

        ~Queen()
        {
            triangleElements.Dispose();
            triangle.Dispose();
        }
    }
}
