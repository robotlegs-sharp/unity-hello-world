using UnityEngine;
using helloworldmulticontext.config;
using helloworld.views;
using robotlegs.bender.bundles;
using robotlegs.bender.extensions.eventDispatcher.api;
using robotlegs.bender.framework.api;
using robotlegs.bender.framework.impl;
using robotlegs.bender.platforms.unity.extensions.contextview.impl;
using robotlegs.bender.extensions.modularity;

namespace helloworldmulticontext
{
	public class ContextA : MonoBehaviour
	{
		IContext context;

		public void Start()
		{
			context = new Context ();
			context.Install<UnityMultiContextBundle> () // Install MVCS Framework
				.Configure<SendMessageConfig>() // Configure Send Message Mediation
				.Configure<MessageEventReceive>() // Receives message events from the channel and passes it to it's own event dispatcher
				.Configure<HelloWorldMappingConfig>() // Sets up the hello world model & mediator
				.Configure<AddReceiveMessageButton>() // Adds the receive message view
				.Configure<AddHelloWorldButtons>() // Adds the hello world click and display button
				.Configure (new TransformContextView (this.transform)); // Set this transform to boot up the application when it's alive
		}
	}
}

