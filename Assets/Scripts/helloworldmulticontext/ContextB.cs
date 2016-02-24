using UnityEngine;
using helloworldmulticontext.config;
using helloworld.views;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using Robotlegs.Bender.Extensions.Modularity;
using Robotlegs.Bender.Platforms.Unity.Bundles;

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

