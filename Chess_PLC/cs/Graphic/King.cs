using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    class King : Chessman
    {
        Texture tempT = new Texture("..//..//textures//tkanina.jpg");

        private static VBO<Vector3> triangle = new VBO<Vector3>(new Vector3[] {
            new Vector3(-0.023, -0.023, .54), new Vector3(-0.023, 0.023, .54), new Vector3(0.023, 0.023, .54), new Vector3(0.023, -0.023, .54),
            new Vector3(-0.0165, -0.0165, .485), new Vector3(-0.0165, 0.0165, .485), new Vector3(0.0165, 0.0165, .485), new Vector3(0.0165, -0.0165, .485),
            new Vector3(-0.023, -0.063, .5), new Vector3(-0.023, 0.063, .5), new Vector3(0.023, -0.063, .5), new Vector3(0.023, 0.063, .5), new Vector3(-0.023, -0.063, .45), new Vector3(-0.023, 0.063, .45), new Vector3(0.023, -0.063, .45), new Vector3(0.023, 0.063, .45),
            new Vector3(-0.0165, -0.0165, .465), new Vector3(-0.0165, 0.0165, .465), new Vector3(0.0165, 0.0165, .465), new Vector3(0.0165, -0.0165, .465),
            new Vector3(-0.023, -0.023, .38), new Vector3(-0.023, 0.023, .38), new Vector3(0.023, 0.023, .38), new Vector3(0.023, -0.023, .38),

            new Vector3(0, 0, .435),
            new Vector3(0, .07, .4), new Vector3(0.01455, 0.068467, .4), new Vector3(0.02847, 0.06395, .4), new Vector3(0.04115, 0.05663, .4), new Vector3(0.05202, 0.0484, .4), new Vector3(0.06062, 0.035, .4), new Vector3(0.06658, 0.02163, .4), new Vector3(0.06962, 0.004715, .4), new Vector3(0.06962, -0.004715, .4),
            new Vector3(0.06658, -0.02163, .4), new Vector3(0.06062, -0.035, .4), new Vector3(0.05202, -0.04684, .4), new Vector3(0.04115, -0.05663, .4), new Vector3(0.02847, -0.06545, .4), new Vector3(0.01455, -0.06848, .4), new Vector3(0, -0.07, .4),
            new Vector3(-0.01455, -0.06847, .4), new Vector3(-0.02843, -0.06395, .4), new Vector3(-0.04115, -0.05663, .4), new Vector3(-0.05202, -0.04684, .4), new Vector3(-0.06062, -0.035, .4), new Vector3(-0.06658, -0.02163, .4), new Vector3(-0.06962, -0.007315, .4), new Vector3(-0.06962, 0.007315, .4),
            new Vector3(-0.06658, 0.02163, .4), new Vector3(-0.06062, 0.035, .4), new Vector3(-0.05202, 0.04684, .4), new Vector3(-0.04115, 0.05663, .4), new Vector3(-0.02869, 0.06395, .4), new Vector3(-0.01019, 0.06847, .4), new Vector3(0, 0.07, .4),
            new Vector3(0, 0, .25),
        });

        private static VBO<uint> triangleElements = new VBO<uint>(new uint[] {
            0,1,3, 1,3,2,
            0,1,4, 1,4,5, 1,2,5, 2,5,6, 2,3,6, 3,6,7, 3,7,4, 3,4,0,
            4,7,8, 6,5,9, 7,8,10, 9,6,11, 8,10,12, 10,12,14, 7,10,14, 14,7,19, 14,19,12, 19,12,16, 16,12,8, 16,4,8,
            9,13,15, 9,15,11, 6,11,15, 6,15,18, 17,9,13, 17,9,5,
            17,15,13, 
            17,18,15, 16,17,4, 4,17,5, 19,15,6, 7,19,6, 
            16,17,20, 17,20,21,
            18,19,22, 19,22,23, 18,22,21, 18,17,21, 20,23,19, 19,20,16,
            24,25,54, 24,26,25, 24,27,26, 24,28,27, 24,29,28, 24,30,29, 24,31,30, 24,32,31, 24,33,32, 24,34,33, 24,35,34, 24,36,35, 24,37,36, 24,38,37, 24,39,38, 24,40,39, 24,41,40, 24,42,41, 24,43,42, 24,44,43, 24,45,44, 24,46,45, 24,47,46, 24,48,47, 24,49,48, 24,50,49, 24,51,50, 24,52,51, 24,53,52, 24,53,52, 24,54,53,
            25,54,56, 26,25,56, 27,26,56, 28,27,56, 29,28,56, 30,29,56, 31,30,56, 32,31,56, 33,32,56, 34,33,56, 35,34,56, 36,35,56, 37,36,56, 38,37,56, 39,38,56, 40,39,56, 41,40,56, 42,41,56, 43,42,56, 44,43,56, 45,44,56, 46,45,56, 47,46,56, 48,47,56, 49,48,56, 50,49,56, 51,50,56, 52,51,56, 52,51,56, 53,52,56, 54,53,56, 55,54,56
        }, BufferTarget.ElementArrayBuffer);

        public override void Draw(ShaderProgram program)
        {
            DrawCoping(program);
            DrawBase(program, .1f, .37f, true);
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

        public King()
        {
            chessman_T = Chessman_type.King;
            //coping =;
        }

        ~King()
        {
            triangleElements.Dispose();
            triangle.Dispose();
        }
    }
}
