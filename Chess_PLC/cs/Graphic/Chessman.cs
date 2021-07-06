using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    public enum Chessman_type { Pawn, Rock, Knight, King};
    //Dictionary<Chessman_type, string> Chessman_L = 

    public abstract class Chessman
    {
        bool color;
        float[] position;
        protected Chessman_type chessman_T;
        public Chessman_type Chessman_T { get { return Chessman_T; } }

        Texture tempT2 = new Texture("..//..//textures//tkanina.jpg");

        protected static VBO<Vector3> Base1 = new VBO<Vector3>(new Vector3[] {
            new Vector3(0, 0, 0),

            new Vector3(0, 1, 0), new Vector3(0.2079, 0.9781, 0), new Vector3(0.4067, 0.9135, 0), new Vector3(0.5878, 0.809, 0), new Vector3(0.7431, 0.6691, 0), new Vector3(0.866, 0.5, 0), new Vector3(0.9511, 0.309, 0), new Vector3(0.9945, 0.1045, 0), new Vector3(0.9945, -0.1045, 0),
            new Vector3(0.9511, -0.309, 0), new Vector3(0.866, -0.5, 0), new Vector3(0.7431, -0.6691, 0), new Vector3(0.5878, -0.809, 0), new Vector3(0.4067, -0.9135, 0), new Vector3(0.2079, -0.9781, 0), new Vector3(0, -1, 0),
            new Vector3(-0.2079, -0.9781, 0), new Vector3(-0.4067, -0.9135, 0), new Vector3(-0.5878, -0.809, 0), new Vector3(-0.7431, -0.6691, 0), new Vector3(-0.866, -0.5, 0), new Vector3(-0.9511, -0.309, 0), new Vector3(-0.9945, -0.1045, 0), new Vector3(-0.9945, 0.1045, 0),
            new Vector3(-0.9511, 0.309, 0), new Vector3(-0.866, 0.5, 0), new Vector3(-0.7431, 0.6691, 0), new Vector3(-0.5878, 0.809, 0), new Vector3(-0.4067, 0.9135, 0), new Vector3(-0.2079, 0.9781, 0), new Vector3(0, 1, 0),

            new Vector3(0, .9, 0.02), new Vector3(0.18301, 0.88029, 0.02), new Vector3(0.36603, 0.82215, 0.02), new Vector3(0.52902, 0.7281, 0.02), new Vector3(0.66879, 0.60219, 0.02), new Vector3(0.7794, 0.45, 0.02), new Vector3(0.85599, 0.2781, 0.02), new Vector3(0.89505, 0.09405, 0.02), new Vector3(0.89505, -0.09405, 0.02),
            new Vector3(0.85599, -0.2781, 0.02), new Vector3(0.7794, -0.45, 0.02), new Vector3(0.66879, -0.60219, 0.02), new Vector3(0.52902, -0.7281, 0.02), new Vector3(0.36603, -0.82215, 0.02), new Vector3(0.18711, -0.88029, 0.02), new Vector3(0, -0.9, 0.02),
            new Vector3(-0.18711, -0.88029, 0.02), new Vector3(-0.36603, -0.82215, 0.02), new Vector3(-0.52902, -0.7281, 0.02), new Vector3(-0.66879, -0.60219, 0.02), new Vector3(-0.7794, -0.45, 0.02), new Vector3(-0.85599, -0.2781, 0.02), new Vector3(-0.89505, -0.09405, 0.02), new Vector3(-0.89505, 0.09405, 0.02),
            new Vector3(-0.85599, 0.2781, 0.02), new Vector3(-0.7794, 0.45, 0.02), new Vector3(-0.66879, 0.60219, 0.02), new Vector3(-0.52902, 0.7281, 0.02), new Vector3(-0.36603, 0.82215, 0.02), new Vector3(-0.2079, 0.88029, 0.02), new Vector3(0, 0.9, 0.02),

            new Vector3(0, 1, .04), new Vector3(0.2079, 0.9781, .04), new Vector3(0.4067, 0.9135, .04), new Vector3(0.5878, 0.809, .04), new Vector3(0.7431, 0.6691, .04), new Vector3(0.866, 0.5, .04), new Vector3(0.9511, 0.309, .04), new Vector3(0.9945, 0.1045, .04), new Vector3(0.9945, -0.1045, .04),
            new Vector3(0.9511, -0.309, .04), new Vector3(0.866, -0.5, .04), new Vector3(0.7431, -0.6691, .04), new Vector3(0.5878, -0.809, .04), new Vector3(0.4067, -0.9135, .04), new Vector3(0.2079, -0.9781, .04), new Vector3(0, -1, .04),
            new Vector3(-0.2079, -0.9781, .04), new Vector3(-0.4067, -0.9135, .04), new Vector3(-0.5878, -0.809, .04), new Vector3(-0.7431, -0.6691, .04), new Vector3(-0.866, -0.5, .04), new Vector3(-0.9511, -0.309, .04), new Vector3(-0.9945, -0.1045, .04), new Vector3(-0.9945, 0.1045, .04),
            new Vector3(-0.9511, 0.309, .04), new Vector3(-0.866, 0.5, .04), new Vector3(-0.7431, 0.6691, .04), new Vector3(-0.5878, 0.809, .04), new Vector3(-0.4067, 0.9135, .04), new Vector3(-0.2079, 0.9781, .04), new Vector3(0, 1, .04)
            });

        protected static VBO<Vector3> Base2 = new VBO<Vector3>(new Vector3[] {
            new Vector3(0, 1, .04), new Vector3(0.2079, 0.9781, .04), new Vector3(0.4067, 0.9135, .04), new Vector3(0.5878, 0.809, .04), new Vector3(0.7431, 0.6691, .04), new Vector3(0.866, 0.5, .04), new Vector3(0.9511, 0.309, .04), new Vector3(0.9945, 0.1045, .04), new Vector3(0.9945, -0.1045, .04),
            new Vector3(0.9511, -0.309, .04), new Vector3(0.866, -0.5, .04), new Vector3(0.7431, -0.6691, .04), new Vector3(0.5878, -0.809, .04), new Vector3(0.4067, -0.9135, .04), new Vector3(0.2079, -0.9781, .04), new Vector3(0, -1, .04),
            new Vector3(-0.2079, -0.9781, .04), new Vector3(-0.4067, -0.9135, .04), new Vector3(-0.5878, -0.809, .04), new Vector3(-0.7431, -0.6691, .04), new Vector3(-0.866, -0.5, .04), new Vector3(-0.9511, -0.309, .04), new Vector3(-0.9945, -0.1045, .04), new Vector3(-0.9945, 0.1045, .04),
            new Vector3(-0.9511, 0.309, .04), new Vector3(-0.866, 0.5, .04), new Vector3(-0.7431, 0.6691, .04), new Vector3(-0.5878, 0.809, .04), new Vector3(-0.4067, 0.9135, .04), new Vector3(-0.2079, 0.9781, .04), new Vector3(0, 1, .04),

            new Vector3(0, .9, 0.1), new Vector3(0.18301, 0.88029, 0.1), new Vector3(0.36603, 0.82215, 0.1), new Vector3(0.52902, 0.7281, 0.1), new Vector3(0.66879, 0.60219, 0.1), new Vector3(0.7794, 0.45, 0.1), new Vector3(0.85599, 0.2781, 0.1), new Vector3(0.89505, 0.09405, 0.1), new Vector3(0.89505, -0.09405, 0.1),
            new Vector3(0.85599, -0.2781, 0.1), new Vector3(0.7794, -0.45, 0.1), new Vector3(0.66879, -0.60219, 0.1), new Vector3(0.52902, -0.7281, 0.1), new Vector3(0.36603, -0.82215, 0.1), new Vector3(0.18711, -0.88029, 0.1), new Vector3(0, -0.9, 0.1),
            new Vector3(-0.18711, -0.88029, 0.1), new Vector3(-0.36603, -0.82215, 0.1), new Vector3(-0.52902, -0.7281, 0.1), new Vector3(-0.66879, -0.60219, 0.1), new Vector3(-0.7794, -0.45, 0.1), new Vector3(-0.85599, -0.2781, 0.1), new Vector3(-0.89505, -0.09405, 0.1), new Vector3(-0.89505, 0.09405, 0.1),
            new Vector3(-0.85599, 0.2781, 0.1), new Vector3(-0.7794, 0.45, 0.1), new Vector3(-0.66879, 0.60219, 0.1), new Vector3(-0.52902, 0.7281, 0.1), new Vector3(-0.36603, 0.82215, 0.1), new Vector3(-0.2079, 0.88029, 0.1), new Vector3(0, 0.9, 0.1),

            new Vector3(0, 0.85, 0.2), new Vector3(0.17672, 0.83143, 0.2), new Vector3(0.34573, 0.77651, 0.2), new Vector3(0.49962, 0.68766, 0.2), new Vector3(0.63167, 0.56876, 0.2), new Vector3(0.73612, 0.425, 0.2), new Vector3(0.8084, 0.26266, 0.2), new Vector3(0.84534, 0.08885, 0.2), new Vector3(0.84534, -0.08885, 0.2),
            new Vector3(0.8084, -0.26266, 0.2), new Vector3(0.73612, -0.425, 0.2), new Vector3(0.63167, -0.56876, 0.2), new Vector3(0.49962, -0.68766, 0.2), new Vector3(0.34573, -0.77651, 0.2), new Vector3(0.17672, -0.83143, 0.2), new Vector3(0, -0.85, 0.2), new Vector3(-0.17672, -0.83143, 0.2), new Vector3(-0.34573, -0.77651, 0.2),
            new Vector3(-0.49962, -0.68766, 0.2), new Vector3(-0.63167, -0.56876, 0.2), new Vector3(-0.73612, -0.425, 0.2), new Vector3(-0.8084, -0.26266, 0.2), new Vector3(-0.84534, -0.08885, 0.2), new Vector3(-0.84534, 0.08885, 0.2), new Vector3(-0.8084, 0.26266, 0.2), new Vector3(-0.73612, 0.425, 0.2),
            new Vector3(-0.63167, 0.56876, 0.2), new Vector3(-0.49962, 0.68766, 0.2), new Vector3(-0.34573, 0.77651, 0.2), new Vector3(-0.17672, 0.83143, 0.2),

            new Vector3(0, 0.65, 0.3), new Vector3(0.13514, 0.6358, 0.3), new Vector3(0.26438, 0.5938, 0.3), new Vector3(0.38206, 0.52586, 0.3), new Vector3(0.48304, 0.43493, 0.3), new Vector3(0.56292, 0.325, 0.3), new Vector3(0.61819, 0.20086, 0.3), new Vector3(0.64644, 0.06794, 0.3), new Vector3(0.64644, -0.06794, 0.3), new Vector3(0.61819, -0.20086, 0.3), new Vector3(0.56292, -0.325, 0.3), new Vector3(0.48304, -0.43493, 0.3), new Vector3(0.38206, -0.52586, 0.3), new Vector3(0.26438, -0.5938, 0.3), new Vector3(0.13514, -0.6358, 0.3), new Vector3(0, -0.65, 0.3), new Vector3(-0.13514, -0.6358, 0.3), new Vector3(-0.26438, -0.5938, 0.3), new Vector3(-0.38206, -0.52586, 0.3), new Vector3(-0.48304, -0.43493, 0.3), new Vector3(-0.56292, -0.325, 0.3), new Vector3(-0.61819, -0.20086, 0.3), new Vector3(-0.64644, -0.06794, 0.3), new Vector3(-0.64644, 0.06794, 0.3), new Vector3(-0.61819, 0.20086, 0.3), new Vector3(-0.56292, 0.325, 0.3), new Vector3(-0.48304, 0.43493, 0.3), new Vector3(-0.38206, 0.52586, 0.3), new Vector3(-0.26438, 0.5938, 0.3), new Vector3(-0.13514, 0.6358, 0.3),

            new Vector3(0, 0.6, 0.6), new Vector3(0.12475, 0.58689, 0.6), new Vector3(0.24404, 0.54813, 0.6), new Vector3(0.35267, 0.48541, 0.6), new Vector3(0.44589, 0.40148, 0.6), new Vector3(0.51962, 0.3, 0.6), new Vector3(0.57063, 0.18541, 0.6), new Vector3(0.59671, 0.06272, 0.6), new Vector3(0.59671, -0.06272, 0.6),
            new Vector3(0.57063, -0.18541, 0.6), new Vector3(0.51962, -0.3, 0.6), new Vector3(0.44589, -0.40148, 0.6), new Vector3(0.35267, -0.48541, 0.6), new Vector3(0.24404, -0.54813, 0.6), new Vector3(0.12475, -0.58689, 0.6), new Vector3(0, -0.6, 0.6), new Vector3(-0.12475, -0.58689, 0.6), new Vector3(-0.24404, -0.54813, 0.6),
            new Vector3(-0.35267, -0.48541, 0.6), new Vector3(-0.44589, -0.40148, 0.6), new Vector3(-0.51962, -0.3, 0.6), new Vector3(-0.57063, -0.18541, 0.6), new Vector3(-0.59671, -0.06272, 0.6), new Vector3(-0.59671, 0.06272, 0.6), new Vector3(-0.57063, 0.18541, 0.6), new Vector3(-0.51962, 0.3, 0.6), new Vector3(-0.44589, 0.40148, 0.6),
            new Vector3(-0.35267, 0.48541, 0.6), new Vector3(-0.24404, 0.54813, 0.6), new Vector3(-0.12475, 0.58689, 0.6),

            new Vector3(0, 0.5, 0.9), new Vector3(0.10396, 0.48907, 0.9), new Vector3(0.20337, 0.45677, 0.9), new Vector3(0.29389, 0.40451, 0.9), new Vector3(0.37157, 0.33457, 0.9), new Vector3(0.43301, 0.25, 0.9), new Vector3(0.47553, 0.15451, 0.9), new Vector3(0.49726, 0.05226, 0.9), new Vector3(0.49726, -0.05226, 0.9), new Vector3(0.47553, -0.15451, 0.9),
            new Vector3(0.43301, -0.25, 0.9), new Vector3(0.37157, -0.33457, 0.9), new Vector3(0.29389, -0.40451, 0.9), new Vector3(0.20337, -0.45677, 0.9), new Vector3(0.10396, -0.48907, 0.9), new Vector3(0, -0.5, 0.9), new Vector3(-0.10396, -0.48907, 0.9), new Vector3(-0.20337, -0.45677, 0.9), new Vector3(-0.29389, -0.40451, 0.9), new Vector3(-0.37157, -0.33457, 0.9),
            new Vector3(-0.43301, -0.25, 0.9), new Vector3(-0.47553, -0.15451, 0.9), new Vector3(-0.49726, -0.05226, 0.9), new Vector3(-0.49726, 0.05226, 0.9), new Vector3(-0.47553, 0.15451, 0.9), new Vector3(-0.43301, 0.25, 0.9), new Vector3(-0.37157, 0.33457, 0.9), new Vector3(-0.29389, 0.40451, 0.9), new Vector3(-0.20337, 0.45677, 0.9), new Vector3(-0.10396, 0.48907, 0.9),
        });


        protected static VBO<uint> triangle1Elements = new VBO<uint>(new uint[] {
            1,2,33,32, 2,3,34,33, 3,4,35,34, 4,5,36,35, 5,6,37,36, 6,7,38,37, 7,8,39,38, 8,9,40,39, 9,10,41,40, 10,11,42,41, 11,12,43,42, 12,13,44,43, 13,14,45,44, 14,15,46,45, 15,16,47,46, 16,17,48,47, 17,18,49,48, 18,19,50,49, 19,20,51,50, 20,21,52,51, 21,22,53,52, 22,23,54,53, 23,24,55,54, 24,25,56,55, 25,26,57,56, 26,27,58,57, 27,28,59,58, 28,29,60,59, 29,30,61,60, 30,31,62,61,
            33,32,63,64, 34,33,64,65, 35,34,65,66, 36,35,66,67, 37,36,67,68, 38,37,68,69, 39,38,69,70, 40,39,70,71, 41,40,71,72, 42,41,72,73, 43,42,73,74, 44,43,74,75, 45,44,75,76, 46,45,76,77, 47,46,77,78, 48,47,78,79, 49,48,79,80, 50,49,80,81, 51,50,81,82, 52,51,82,83, 53,52,83,84, 54,53,84,85, 55,54,85,86, 56,55,86,87, 57,56,87,88, 58,57,88,89, 59,58,89,90, 60,59,90,91, 61,60,91,92, 62,61,92,93

        }, BufferTarget.ElementArrayBuffer);

        protected static VBO<uint> triangle2Elements = new VBO<uint>(new uint[] {
            0,1,32,31, 1,2,33,32, 2,3,34,33, 3,4,35,34, 4,5,36,35, 5,6,37,36, 6,7,38,37, 7,8,39,38, 8,9,40,39, 9,10,41,40, 10,11,42,41, 11,12,43,42, 12,13,44,43, 13,14,45,44, 14,15,46,45, 15,16,47,46, 16,17,48,47, 17,18,49,48, 18,19,50,49, 19,20,51,50, 20,21,52,51, 21,22,53,52, 22,23,54,53, 23,24,55,54, 24,25,56,55, 25,26,57,56, 26,27,58,57, 27,28,59,58, 28,29,60,59, 29,0,31,60,
            32,31,62,63, 33,32,63,64, 34,33,64,65, 35,34,65,66, 36,35,66,67, 37,36,67,68, 38,37,68,69, 39,38,69,70, 40,39,70,71, 41,40,71,72, 42,41,72,73, 43,42,73,74, 44,43,74,75, 45,44,75,76, 46,45,76,77, 47,46,77,78, 48,47,78,79, 49,48,79,80, 50,49,80,81, 51,50,81,82, 52,51,82,83, 53,52,83,84, 54,53,84,85, 55,54,85,86, 56,55,86,87, 57,56,87,88, 58,57,88,89, 59,58,89,90, 60,59,90,91, 61,60,91,62,
            62,63,93,92, 63,64,94,93, 64,65,95,94, 65,66,96,95, 66,67,97,96, 67,68,98,97, 68,69,99,98, 69,70,100,99, 70,71,101,100, 71,72,102,101, 72,73,103,102, 73,74,104,103, 74,75,105,104, 75,76,106,105, 76,77,107,106, 77,78,108,107, 78,79,109,108, 79,80,110,109, 80,81,111,110, 81,82,112,111, 82,83,113,112, 83,84,114,113, 84,85,115,114, 85,86,116,115, 86,87,117,116, 87,88,118,117, 88,89,119,118, 89,90,120,119, 90,91,121,120, 91,62,93,121,
            92,93,123,122, 93,94,124,123, 94,95,125,124, 95,96,126,125, 96,97,127,126, 97,98,128,127, 98,99,129,128, 99,100,130,129, 100,101,131,130, 101,102,132,131, 102,103,133,132, 103,104,134,133, 104,105,135,134, 105,106,136,135, 106,107,137,136, 107,108,138,137, 108,109,139,138, 109,110,140,139, 110,111,141,140, 111,112,142,141, 112,113,143,142, 113,114,144,143, 114,115,145,144, 115,116,146,145, 116,117,147,146, 117,118,148,147, 118,119,149,148, 119,120,150,149, 120,121,151,150, 121,151,122,92,
            122,123,153,152, 123,124,154,153, 124,125,155,154, 125,126,156,155, 126,127,157,156, 127,128,158,157, 128,129,159,158, 129,130,160,159, 130,131,161,160, 131,132,162,161, 132,133,163,162, 133,134,164,163, 134,135,165,164, 135,136,166,165, 136,137,167,166, 137,138,168,167, 138,139,169,168, 139,140,170,169, 140,141,171,170, 141,142,172,171, 142,143,173,172, 143,144,174,173, 144,145,175,174, 145,146,176,175, 146,147,177,176, 147,148,178,177, 148,149,179,178, 149,150,180,179, 150,151,181,180, 122,151,181,152
        }, BufferTarget.ElementArrayBuffer);

        protected void DrawBase(ShaderProgram program, float radius, float height)
        {
            uint vertexPositionIndex = (uint)Gl.GetAttribLocation(program.ProgramID, "vertexPosition");
            Gl.EnableVertexAttribArray(vertexPositionIndex);

            Gl.BindBuffer(triangle1Elements);

            Gl.VertexAttribPointer(vertexPositionIndex, triangle1Elements.Size, Base1.PointerType, true, 12, IntPtr.Zero);

            Gl.BindBuffer(triangle1Elements);

            Gl.BindBufferToShaderAttribute(Base1, program, "vertexPosition");

            program["model_matrix"].SetValue(Matrix4.CreateScaling(new Vector3(radius, radius, 1)));
            Gl.DrawElements(BeginMode.Quads, triangle1Elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);



            Gl.VertexAttribPointer(vertexPositionIndex, triangle2Elements.Size, Base2.PointerType, true, 12, IntPtr.Zero);

            Gl.BindBuffer(triangle2Elements);

            Gl.BindBufferToShaderAttribute(Base2, program, "vertexPosition");

            program["model_matrix"].SetValue(Matrix4.CreateScaling(new Vector3(radius, radius, height)));
            Gl.DrawElements(BeginMode.Quads, triangle2Elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        protected virtual void DrawCoping(ShaderProgram program)
        {

        }

        public virtual void Draw(ShaderProgram program)
        {
            
        }

        public Chessman()
        {

        }
    }
}
