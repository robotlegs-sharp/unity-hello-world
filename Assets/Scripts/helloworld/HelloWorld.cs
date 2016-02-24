using UnityEngine;
using helloworld.config;
using helloworld.views;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using Robotlegs.Bender.Platforms.Unity.Bundles;

namespace helloworld
{
	public class HelloWorld : MonoBehaviour
	{
		IContext context;

		public void Start()
		{
			context = new Context ();
			context.Install<UnitySingleContextBundle> () // Install MVCS Framework
				.Configure<HelloWorldConfig> () // Setup our hello world config
				.Configure (new TransformContextView (this.transform)); // Set this transform to boot up the application when it's alive
		}
	}
}

