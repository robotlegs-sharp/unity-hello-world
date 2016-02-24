using System;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using helloworldmulticontext.view;
using helloworldmulticontext.view.mediator;

namespace helloworldmulticontext.config
{
	public class SendMessageConfig : IConfig
	{
		[Inject] public IMediatorMap mediatorMap;

		public void Configure ()
		{
			mediatorMap.Map<ISendMessageView>().ToMediator<SendMessageMediator>();
			mediatorMap.Map<IReceiveMessageView>().ToMediator<ReceiveMessageMediator>();
		}
	}
}

