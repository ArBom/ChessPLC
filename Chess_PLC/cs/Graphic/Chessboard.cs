using System;
using System.Collections.Generic;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    class Chessboard
    {
        private static List<Texture> textures;
        private static VBO<Vector3> chessboardSquares;
        //private static VBO<Vector3> whiteSBColor;
        //private static VBO<Vector3> blackSBColor;
        private static VBO<uint> whiteSBQuads;
        private static VBO<uint> blackSBQuads;
        private static VBO<Vector2> chessboardUV;

        public void Draw(ShaderProgram program)
        {
            Gl.BindTexture(textures[1]);
            Gl.BindBufferToShaderAttribute(chessboardSquares, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(chessboardUV, program, "vertexUV");
            Gl.BindBuffer(whiteSBQuads);

            // draw the cube
            Gl.DrawElements(BeginMode.Quads, whiteSBQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Gl.BindTexture(textures[0]);
            Gl.BindBuffer(blackSBQuads);
            Gl.DrawElements(BeginMode.Quads, blackSBQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public Chessboard()
        {
            chessboardSquares = new VBO<Vector3>(new Vector3[] {
                new Vector3(-1, 1, 0), new Vector3(-.75, 1, 0), new Vector3(-.5, 1, 0), new Vector3(-.25, 1, 0), new Vector3(0, 1, 0), new Vector3(.25, 1, 0), new Vector3(.5, 1, 0), new Vector3(.75, 1, 0), new Vector3(1, 1, 0),
                new Vector3(-1, .75, 0), new Vector3(-.75, .75, 0), new Vector3(-.5, .75, 0), new Vector3(-.25, .75, 0), new Vector3(0, .75, 0), new Vector3(.25, .75, 0), new Vector3(.5, .75, 0), new Vector3(.75, .75, 0), new Vector3(1, .75, 0),
                new Vector3(-1, .5, 0), new Vector3(-.75, .5, 0), new Vector3(-.5, .5, 0), new Vector3(-.25, .5, 0), new Vector3(0, .5, 0), new Vector3(.25, .5, 0), new Vector3(.5, .5, 0), new Vector3(.75, .5, 0), new Vector3(1, .5, 0),
                new Vector3(-1, .25, 0), new Vector3(-.75, .25, 0), new Vector3(-.5, .25, 0), new Vector3(-.25, .25, 0), new Vector3(0, .25, 0), new Vector3(.25, .25, 0), new Vector3(.5, .25, 0), new Vector3(.75, .25, 0), new Vector3(1, .25, 0),
                new Vector3(-1, 0, 0), new Vector3(-.75, 0, 0), new Vector3(-.5, 0, 0), new Vector3(-.25, 0, 0), new Vector3(0, 0, 0), new Vector3(.25, 0, 0), new Vector3(.5, 0, 0), new Vector3(.75, 0, 0), new Vector3(1, 0, 0),
                new Vector3(-1, -.25, 0), new Vector3(-.75, -.25, 0), new Vector3(-.5, -.25, 0), new Vector3(-.25, -.25, 0), new Vector3(0, -.25, 0), new Vector3(.25, -.25, 0), new Vector3(.5, -.25, 0), new Vector3(.75, -.25, 0), new Vector3(1, -.25, 0),
                new Vector3(-1, -.5, 0), new Vector3(-.75, -.5, 0), new Vector3(-.5, -.5, 0), new Vector3(-.25, -.5, 0), new Vector3(0, -.5, 0), new Vector3(.25, -.5, 0), new Vector3(.5, -.5, 0), new Vector3(.75, -.5, 0), new Vector3(1, -.5, 0),
                new Vector3(-1, -.75, 0), new Vector3(-.75, -.75, 0), new Vector3(-.5, -.75, 0), new Vector3(-.25, -.75, 0), new Vector3(0, -.75, 0), new Vector3(.25, -.75, 0), new Vector3(.5, -.75, 0), new Vector3(.75, -.75, 0), new Vector3(1, -.75, 0),
                new Vector3(-1, -1, 0), new Vector3(-.75, -1, 0), new Vector3(-.5, -1, 0), new Vector3(-.25, -1, 0), new Vector3(0, -1, 0), new Vector3(.25, -1, 0), new Vector3(.5, -1, 0), new Vector3(.75, -1, 0), new Vector3(1, -1, 0),

                new Vector3(-1, 1, -.1), new Vector3(-.75, 1, -.1), new Vector3(-.5, 1, -.1), new Vector3(-.25, 1, -.1), new Vector3(0, 1, -.1), new Vector3(.25, 1, -.1), new Vector3(.5, 1, -.1), new Vector3(.75, 1, -.1), new Vector3(1, 1, -.1), //81-90
                new Vector3(1, .75, -.1), new Vector3(1, .5, -.1), new Vector3(1, .25, -.1), new Vector3(1, 0, -.1), new Vector3(1, -.25, -.1), new Vector3(1, -.5, -.1), new Vector3(1, -.75, -.1), //91-97
                new Vector3(1, -1, -.1), new Vector3(.75, -1, -.1), new Vector3(.5, -1, -.1), new Vector3(.25, -1, -.1), new Vector3(0, -1, -.1), new Vector3(-.25, -1, -.1), new Vector3(-.5, -1, -.1), new Vector3(-.75, -1, -.1), new Vector3(-1, -1, -.1), //98-106
                new Vector3(-1, -.75, -.1), new Vector3(-1, -.5, -.1), new Vector3(-1, -.25, -.1), new Vector3(-1, 0, -.1),  new Vector3(-1, .25, -.1), new Vector3(-1, .5, -.1), new Vector3(-1, .75, -.1) //107-113
            });

            blackSBQuads = new VBO<uint>(new uint[] {0,1,10,9, 2,3,12,11, 4,5,14,13, 6,7,16,15,
                                                     10,11,20,19, 12,13,22,21, 14,15,24,23, 16,17,26,25,
                                                     18,19,28,27, 20,21,30,29, 22,23,32,31, 24,25,34,33,
                                                     28,29,38,37, 30,31,40,39, 32,33,42,41, 34,35,44,43,
                                                     36,37,46,45, 38,39,48,47, 40,41,50,49, 42,43,52,51,
                                                     46,47,56,55, 48,49,58,57, 50,51,60,59, 52,53,62,61,
                                                     54,55,64,63, 56,57,66,65, 58,59,68,67, 60,61,70,69,
                                                     64,65,74,73, 66,67,76,75, 68,69,78,77, 70,71,80,79,

                                                     1,0,81,82, 3,2,83,84, 5,4,85,86, 7,6,87,88,
                                                     90,91,26,17, 92,93,44,35, 94,95,62,53, 96,97,80,71,
                                                     97,98,79,80, 99,100,77,78, 101,102,75,76, 103,104,73,74,
                                                     54,63,106,107, 36,45,108,109, 18,27,110,111, 0,9,112,81
            }, BufferTarget.ElementArrayBuffer);

            whiteSBQuads = new VBO<uint>(new uint[] {1,2,11,10, 3,4,13,12, 5,6,15,14, 7,8,17,16,
                                                     11,12,21,20, 13,14,23,22, 15,16,25,24, 9,10,19,18,
                                                     19,20,29,28, 21,22,31,30, 23,24,33,32, 25,26,35,34,
                                                     29,30,39,38, 31,32,41,40, 33,34,43,42, 27,28,37,36,
                                                     37,38,47,46, 39,40,49,48, 41,42,51,50, 43,44,53,52,
                                                     47,48,57,56, 49,50,59,58, 51,52,61,60, 45,46,55,54,
                                                     55,56,65,64, 57,58,67,66, 59,60,69,68, 61,62,71,70,
                                                     65,66,75,74, 67,68,77,76, 69,70,79,78, 63,64,73,72,

                                                     2,1,82,83, 4,3,84,85, 6,5,86,87, 8,7,88,89,
                                                     8,17,90,89, 35,26,91,92, 53,44,93,94, 71,62,95,96,
                                                     78,79,98,99, 76,77,100,101, 74,75,102,103, 72,73,104,105,
                                                     105,106,63,72, 107,108,45,54, 109,110,27,36, 111,112,9,18
            }, BufferTarget.ElementArrayBuffer);

            chessboardUV = new VBO<Vector2>(new Vector2[] {
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),

               new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 0),
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(1 ,1), new Vector2(0 ,1),

            });

            Texture tempT;
            textures = new List<Texture>();
            tempT = new Texture("..//..//textures//woodL.jpg");
            textures.Add(tempT);
            tempT = new Texture("..//..//textures//woodD.jpg");
            textures.Add(tempT);
        }

        ~Chessboard()
        {
            foreach (var t in textures)
                t.Dispose();

            chessboardSquares.Dispose();
            whiteSBQuads.Dispose();
            blackSBQuads.Dispose();
            chessboardUV.Dispose();
        }
    }
}
