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
            new Vector3(0, 0, .37),

            new Vector3(0, 0.065, 0.37), new Vector3(0.0325, 0.05629, 0.37), new Vector3(0.05629, 0.0325, 0.37), new Vector3(0.065, 0, 0.37), new Vector3(0.05629, -0.0325, 0.37), new Vector3(0.0325, -0.05629, 0.37), new Vector3(0, -0.065, 0.37), new Vector3(-0.0325, -0.05629, 0.37), new Vector3(-0.05629, -0.0325, 0.37), new Vector3(-0.065, 0, 0.37), new Vector3(-0.05629, 0.0325, 0.37), new Vector3(-0.0325, 0.05629, 0.37),
            new Vector3(0, 0.065, 0.45), new Vector3(0.0325, 0.05629, 0.45), new Vector3(0.05629, 0.0325, 0.45), new Vector3(0.065, 0, 0.45), new Vector3(0.05629, -0.0325, 0.45), new Vector3(0.0325, -0.05629, 0.45), new Vector3(0, -0.065, 0.45), new Vector3(-0.0325, -0.05629, 0.45), new Vector3(-0.05629, -0.0325, 0.45), new Vector3(-0.065, 0, 0.45), new Vector3(-0.05629, 0.0325, 0.45), new Vector3(-0.0325, 0.05629, 0.45),
            new Vector3(0, 0.085, 0.45), new Vector3(0.0425, 0.07361, 0.45), new Vector3(0.07361, 0.0425, 0.45), new Vector3(0.085, 0, 0.45), new Vector3(0.07361, -0.0425, 0.45), new Vector3(0.0425, -0.07361, 0.45), new Vector3(0, -0.085, 0.45), new Vector3(-0.0425, -0.07361, 0.45), new Vector3(-0.07361, -0.0425, 0.45), new Vector3(-0.085, 0, 0.45), new Vector3(-0.07361, 0.0425, 0.45), new Vector3(-0.0425, 0.07361, 0.45),
            new Vector3(0, 0.075, 0.33), new Vector3(0.0375, 0.06495, 0.33), new Vector3(0.06495, 0.0375, 0.33), new Vector3(0.075, 0, 0.33), new Vector3(0.06495, -0.0375, 0.33), new Vector3(0.0375, -0.06495, 0.33), new Vector3(0, -0.075, 0.33), new Vector3(-0.0375, -0.06495, 0.33), new Vector3(-0.06495, -0.0375, 0.33), new Vector3(-0.075, 0, 0.33), new Vector3(-0.06495, 0.0375, 0.33), new Vector3(-0.0375, 0.06495, 0.33),

            new Vector3(0, 0, .2),
        });


        private static VBO<uint> quadsElements = new VBO<uint>(new uint[] {
            0,1,2,3, 0,3,4,5, 0,5,6,7, 0,7,8,9, 0,9,10,11, 0,11,12,1,
            1,2,14,13, 2,3,15,14, 4,5,17,16, 5,6,18,17, 7,8,20,19, 8,9,21,20, 10,11,23,22, 11,12,24,23,
            14,13,25,26, 15,14,26,27, 17,16,28,29, 18,17,29,30, 20,19,31,32, 21,20,32,33, 23,22,34,35, 24,23,35,36,
            3,4,40,39, 6,7,43,42, 9,10,46,45, 12,1,37,48,
            1,13,25,37, 3,15,27,39, 4,16,28,40, 6,18,30,42, 7,19,31,43, 9,21,33,45, 10,22,34,46, 12,24,36,48,
            37,38,26,25, 38,39,27,26, 40,41,29,28, 41,42,30,29, 43,44,32,31, 44,45,33,32, 46,47,35,34, 47,48,36,35,
            49,48,47,46, 49,46,45,44, 49,44,43,42, 49,42,41,40, 49,40,39,38, 49,38,37,48,
        }, BufferTarget.ElementArrayBuffer);

        public override void Draw(ShaderProgram program)
        {
            
            DrawCoping(program);
            DrawBase(program, .098f, .3f);
        }
        protected override void DrawCoping(ShaderProgram program)
        {
            uint vertexPositionIndex = (uint)Gl.GetAttribLocation(program.ProgramID, "vertexPosition");
            Gl.EnableVertexAttribArray(vertexPositionIndex);

            Gl.BindTexture(tempT);
            Gl.BindBuffer(triangle);
            Gl.VertexAttribPointer(vertexPositionIndex, triangle.Size, triangle.PointerType, true, 12, IntPtr.Zero);

            Gl.BindBuffer(quadsElements);

            // draw the triangle
            Gl.DrawElements(BeginMode.Quads, quadsElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public Rock()
        {
            chessman_T = Chessman_type.Rock;
            //coping =;
        }

        ~Rock()
        {
            quadsElements.Dispose();
            triangle.Dispose();
        }

    }
}
