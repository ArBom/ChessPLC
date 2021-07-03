using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace Graphic
{
    public class Game
    {
        private static List<Chessman> chessmans;
        private static int width = 1280, height = 720;
        private static ShaderProgram program;
        private static VBO<Vector3> ground;
        private static VBO<uint> groundQuads;
        private static VBO<Vector2> groundUV;
        private static System.Diagnostics.Stopwatch watch;
        private static float angle;
        private static List<Texture> textures;
        //private static Texture crateTexture;
        private static bool mouseDown = false;
        private static int downX, downY;
        private static float xCamAngle, yCamAngle;
        private const float camRadius = 5.0f;

        private static Chessboard chessboardP;

        public Game()
        { 
            // create an OpenGL window
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("Chess");

            // provide the Glut callbacks that are necessary for running this tutorial
            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            Glut.glutMouseFunc(OnMouse);
            Glut.glutMotionFunc(OnMove);

            // enable depth testing to ensure correct z-ordering of our fragments
            Gl.Enable(EnableCap.DepthTest);

            // compile the shader program
            program = new ShaderProgram(VertexShader, FragmentShader);
            textures = new List<Texture>();
            //Texture tempT = new Texture("C://Users//arkad//source//repos//Chess_PLC//Chess_PLC//textures//rounded-rocks.jpg");
            //textures.Add(tempT);
            // set the view and projection matrix, which are static throughout this tutorial
            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));

            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(1, 2, 1.5), Vector3.Zero, new Vector3(0, 0, 1)));

            ground = new VBO<Vector3>(new Vector3[] {
                new Vector3(-4, -4, -.25), new Vector3(4, -4, -.25),
                new Vector3(-4,  4, -.25), new Vector3(4,  4, -.25)
                            });

            groundUV = new VBO<Vector2>(new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0) });
            groundQuads = new VBO<uint>(new uint[] { 0, 1, 2, 3 });

            chessboardP = new Chessboard();

            //Knight k = new Knight();
            King k = new King();

            chessmans = new List<Chessman>();
            chessmans.Add(k);

            watch = System.Diagnostics.Stopwatch.StartNew();

            Glut.glutMainLoop();
        }

        private static void OnClose()
        {
        ground.Dispose();
        groundQuads.Dispose();
        groundUV.Dispose();

        // dispose of all of the resources that were created
        program.DisposeChildren = true;
        program.Dispose();
        }

        private static void OnDisplay()
        {

        }

        private static void OnMouse(int button, int state, int x, int y)
        {
            // this method gets called whenever a new mouse button event happens
            if (button == Glut.GLUT_LEFT_BUTTON) mouseDown = (state == Glut.GLUT_DOWN);

            // if the mouse has just been clicked then we hide the cursor and store the position
            if (mouseDown)
            {
                Glut.glutSetCursor(Glut.GLUT_CURSOR_NONE);
                downX = x;
                downY = y;
            }
            else // unhide the cursor if the mouse has just been released
                Glut.glutSetCursor(Glut.GLUT_CURSOR_LEFT_ARROW);
        }

        private static void OnMove(int x, int y)
        {
            // if the mouse move event is caused by glutWarpPointer then do nothing
            if (x == downX && y == downY) return;

            // update the rotation of our cube if the mouse is down
            if (mouseDown)
            {
                yCamAngle += (x - downX) * 0.005f;
                xCamAngle += (y - downY) * 0.005f;

                Glut.glutWarpPointer(downX, downY);
            }
        }

        private static void OnRenderFrame()
        {
            // calculate how much time has elapsed since the last frame
            watch.Stop();
            float deltaTime = (float)watch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency;
            watch.Restart();

            // use the deltaTime to adjust the angle of the cube and pyramid
            angle += deltaTime;

            // set up the OpenGL viewport and clear both the color and depth bits
            Gl.Viewport(0, 0, width, height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // use our shader program
            Gl.UseProgram(program);
            
            program["model_matrix"].SetValue(Matrix4.CreateRotationZ(yCamAngle) * Matrix4.CreateTranslation(new Vector3(0, 0, 0)));

            Gl.BindBufferToShaderAttribute(ground, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(groundUV, program, "vertexUV");
            Gl.BindBuffer(groundQuads);
            //Gl.BindTexture(textures[0]);

            chessboardP.Draw(program);
            foreach (var c in chessmans)
            {
                c.Draw(program);
            }

            Glut.glutSwapBuffers();
        }

        public static string VertexShader = @"
            #version 130

            in vec3 vertexPosition;
            in vec2 vertexUV;

            out vec2 uv;

            uniform mat4 projection_matrix;
            uniform mat4 view_matrix;
            uniform mat4 model_matrix;

            void main(void)
            {
                uv = vertexUV;
                gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
            }
            ";

        public static string FragmentShader = @"
            #version 130

            uniform sampler2D texture;

            in vec2 uv;

            out vec4 fragment;

            void main(void)
            {
                fragment = texture2D(texture, uv);
            }
            ";   
    }
}
