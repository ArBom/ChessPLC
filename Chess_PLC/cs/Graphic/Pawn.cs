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
        public override void Draw(ShaderProgram program)
        {
            DrawBase(program, 1.0f, 2.0f);
            DrawCoping(program);
        }

        protected override void DrawCoping(ShaderProgram program)
        {

        }

        public Pawn()
        {
            chessman_T = Chessman_type.Pawn;
            //coping =;
        }
    }
}
