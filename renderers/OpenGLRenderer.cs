using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;

namespace ThreeSharp
{
	public class OpenGLRenderer: GameWindow
	{
		private Matrix4 modelviewMatrix, projectionMatrix;
        private Matrix4 rotationviewMatrix;
		const float rotation_speed = 18.0f;
		float angle;

		public OpenGLRenderer ():base(800, 768, GraphicsMode.Default, "OpenTK Quick Start Sample")
		{
			VSync = VSyncMode.On;
		}

		public void setSize(int width, int height)
		{
			Width = 1024;
			Height = 600;
		}

		public void Render(PerspectiveCamera camera)
		{

		}


		public float getMaxAnisotropy()
		{
			return 1.0f;
		}

		public void render(Scene scene, PerspectiveCamera camera)
		{
			this.Run();
		}

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
			GL.ClearColor(0.0f, 0.4f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

			modelviewMatrix = Matrix4.LookAt(0, 4, 7, 0, 0, 0, 0, 1, 0);
 
            rotationviewMatrix = Matrix4.CreateRotationX((float)System.Math.PI / 100);
		}

		protected override void OnResize(EventArgs e)
        {
 
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView((float)System.Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projectionMatrix);
 			
        }

		protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard[Key.Escape])
                Exit();
        }

		protected override void OnRenderFrame(FrameEventArgs e)
        {
 
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            angle += rotation_speed * (float)e.Time;
            float translateby = (float)System.Math.Sin(DateTime.Now.Second) * 0.05f;
            rotationviewMatrix = Matrix4.CreateTranslation(0f, 0f, translateby);
 
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelviewMatrix);
            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            DrawCube();
            SwapBuffers();
        }

		private void DrawCube()
        {
            GL.Begin(BeginMode.Quads);
 

            GL.Color4(OpenTK.Graphics.Color4.ForestGreen);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, -1.0f);
 
            GL.Color4(OpenTK.Graphics.Color4.Honeydew);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 1.0f);
 
            GL.Color4(OpenTK.Graphics.Color4.Goldenrod);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f);
 
 
            GL.Color4(OpenTK.Graphics.Color4.DodgerBlue);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-1.0f, 1.0f, 1.0f);
 
            GL.Color4(OpenTK.Graphics.Color4.Purple);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1.0f, 1.0f, -1.0f);
 
            GL.Color4(OpenTK.Graphics.Color4.ForestGreen);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 1.0f);
 
            GL.End();
 
        }

	}
}

