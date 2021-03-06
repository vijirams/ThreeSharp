using System;
using System.Collections.Generic;
using ThreeSharp;


namespace TestThreeSharp
{
	public class Tester
	{
		OpenGLRenderer renderer;
		PerspectiveCamera camera;
		Mesh mesh;
		Scene scene;


		int width = 800;
		int height = 600;


		public static void Main (String[] args)
		{

			Tester test = new Tester();
			
			test.init();
			

		}

		public void init ()
		{
			renderer = new OpenGLRenderer();

			renderer.setSize(width,height);

			camera = new PerspectiveCamera((float)(System.Math.PI/180.0f)*70.0f,width/(float)height,1.0f,100.0f);
			camera.position.Z = 400.0f;

			scene = new Scene();

			CubeGeometry geometry = new CubeGeometry(200,200,200);


			Texture texture =  (new ImageUtils()).loadTexture("textures/crate.gif");
			texture.anisotropy = renderer.getMaxAnisotropy();


			MeshBasicMaterial material = new MeshBasicMaterial(texture);

			mesh = new Mesh(geometry,material);
			scene.add(mesh);

			renderer.render(scene,camera);

		}




	}
}

