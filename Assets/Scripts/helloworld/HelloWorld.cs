using UnityEngine;
using helloworld.config;
using helloworld.views;
using robotlegs.bender.bundles;
using robotlegs.bender.extensions.eventDispatcher.api;
using robotlegs.bender.framework.api;
using robotlegs.bender.framework.impl;
using robotlegs.bender.platforms.unity.extensions.contextview.impl;

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

