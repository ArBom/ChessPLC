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

        private static VBO<Vector3> Base;
        private static VBO<Vector3> Coping;

        protected void DrawBase(ShaderProgram program, float radius, float height)
        {
            Gl.BindBufferToShaderAttribute(Base, program, "vertexPosition");
            //Gl.DrawArrays(BeginMode.Triangles,)
        }

        protected virtual void DrawCoping(ShaderProgram program)
        {

        }

        public virtual void Draw(ShaderProgram program)
        {
            
        }

        public Chessman()
        {
            float triPerC = 30;
            float alpha = 360 / triPerC;
            float DeltaH = 1.0f;
            for (int h = 0; h != 1; ++h)
            {
                float Alpha = 0;
                for (int a = 0; a != triPerC; ++a)
                {
                    Gl.DrawArrays(BeginMode.Quads, 0, 5);
                    //Base.BufferSubData.
                }
            }
        }
    }
}
