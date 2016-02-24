using System;
using Robotlegs.Bender.Bundles.MVCS;
using helloworld.events;

namespace helloworldmulticontext.view.mediator
{
	public class SendMessageMediator : Mediator
	{
		public override void Initialize ()
		{
			AddViewListener(MessageEvent.Type.SEND, Dispatch);
		}
	}
}

