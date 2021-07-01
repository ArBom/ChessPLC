using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    class Knight : Chessman
    {
        Texture tempT = new Texture("..//..//textures//tkanina.jpg");

        private static VBO<Vector3> triangle = new VBO<Vector3>(new Vector3[] {
            new Vector3(-0.015, -0.07, .40), new Vector3(-0.015, .07, .40), new Vector3(0, -0.07, .35), new Vector3(0, .07, .35),
            new Vector3(0.04, -.059, .45), new Vector3(0.04, .059, .45), new Vector3(0, -.025, .4), new Vector3(0, .025, .4),
            new Vector3(0.1, -.059, .30), new Vector3(0.1, .059, .30), new Vector3(0.1, -.059, .25), new Vector3(0.1, .059, .25),
            new Vector3(0, -.059, .25), new Vector3(0, .059, .25),
            new Vector3(0.09, -.059, .15), new Vector3(0.09, .059, .15),
            new Vector3(0.085, -.044, .12), new Vector3(0.085, .044, .12), new Vector3(-0.05, -.054, .12), new Vector3(-0.05, .054, .12),
            //przod głowy powyżej
            new Vector3(-0.065, 0.034, .39), new Vector3(-0.065, -0.034, .39), new Vector3(-0.089, 0.02, .36), new Vector3(-0.089, -0.02, .36), new Vector3(-0.105, 0.024, .3), new Vector3(-0.105, -0.024, .3), new Vector3(-0.1, 0, .12),
            //grzbiet i uszy powyżej
            new Vector3(-0.085, 0.028, .12), new Vector3(-0.085, -0.028, .12),
        });

        // create a triangle
        private static VBO<Vector3> Color = new VBO<Vector3>(new Vector3[] { new Vector3(0.5f, 0.5f, 1), new Vector3(0.5f, 0.5f, 1), new Vector3(0.5f, 0.5f, 1), new Vector3(0.5f, 0.5f, 1) });
        private static VBO<uint>  triangleElements = new VBO<uint>(new uint[] { 
                    6,7,2, 2,3,7, 2,4,6, 3,5,7, 0,4,2, 1,5,3,
                    2,3,8, 3,8,9, 8,9,10, 9,11,10, 2,12,10, 2,11,10, 3,13,9, 11,13,9, 13,14,15, 12,14,13, 
                    14,15,16, 15,16,17, 15,17,19,  14,16,18, 13,15,19,  12,14,18,
                    //przód głowy powyżej
                    6,7,20, 6,20,21, 5,20,1, 7,20,5, 21,4,0, 21,6,4, 20,21,22, 21,22,23, 22,23,24, 23,24,25, 24,25,26,
                    //grzbiet i uszy powyżej
                    3,1,13,  0,2,12, 13,1,20, 0,12,21, 13,20,19, 12,21,18, 25,26,28, 24,26,27, 18,25,28,
                    19,24,27, 24,19,20, 25,21,18, 20,22,24, 21,23,25

        }, BufferTarget.ElementArrayBuffer);

        private static VBO<Vector3> Triangles = new VBO<Vector3>(new Vector3[] {
                new Vector3(5, 0, 10), new Vector3(0, 0, .8), new Vector3(10, 10, -.8),
        });

        private static VBO<uint> Quads = new VBO<uint>(new uint[] {
        0,1,2 });

        public override void Draw(ShaderProgram program)
        {
            //DrawBase(program, 1.0f, 2.0f);
            DrawCoping(program);

        }

        protected override void DrawCoping(ShaderProgram program)
        {
            uint vertexPositionIndex = (uint)Gl.GetAttribLocation(program.ProgramID, "vertexPosition");
            Gl.EnableVertexAttribArray(vertexPositionIndex);

            Gl.BindTexture(tempT);
            Gl.BindBuffer(triangle);
            Gl.VertexAttribPointer(vertexPositionIndex, triangle.Size, triangle.PointerType, true, 12, IntPtr.Zero);
            Gl.BindBufferToShaderAttribute(Color, program, "vertexColor");
            Gl.BindBuffer(triangleElements);

            // draw the triangle
            Gl.DrawElements(BeginMode.Triangles, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public Knight()
        {
            chessman_T = Chessman_type.Knight;
            //coping =;
        }

        ~Knight()
        {
            Triangles.Dispose();
            Color.Dispose();
            Quads.Dispose();
        }
    }
}
