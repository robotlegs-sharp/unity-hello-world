using System;
using robotlegs.bender.framework.api;
using robotlegs.bender.extensions.mediatorMap.api;
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

