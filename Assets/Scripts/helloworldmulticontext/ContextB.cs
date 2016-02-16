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
	public class ContextB : MonoBehaviour
	{
		IContext context;

		public void Start()
		{
			context = new Context ();
			context.Install<UnityMultiContextBundle> () // Install MVCS Framework
				.Configure<SendMessageConfig>() // Sets up the send message mediator configuration
				.Configure<MessageEventRelay>() // Relays message events to a channel ready for another context to receive
				.Configure<HelloWorldMappingConfig>() // Sets up the hello world model & mediator
				.Configure<AddSendMessageButton>() // Adds the send message button
				.Configure<AddHelloWorldButtons>() // Adds the hello world click and display button
				.Configure (new TransformContextView (this.transform)); // Set this transform to boot up the application when it's alive
		}
	}
}

