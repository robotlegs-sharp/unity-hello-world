using System;
using Robotlegs.Bender.Bundles.MVCS;
using helloworld.events;

namespace helloworldmulticontext.view.mediator
{
	public class ReceiveMessageMediator : Mediator
	{
		[Inject] public IReceiveMessageView view;

		public override void Initialize ()
		{
			AddContextListener<MessageEvent>(MessageEvent.Type.SEND, OnReceiveMessage);
		}

		private void OnReceiveMessage(MessageEvent evt)
		{
			view.ReciveMessage(evt.Message);
		}
	}
}

