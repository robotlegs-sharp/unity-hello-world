using robotlegs.bender.extensions.modularity.api;
using robotlegs.bender.framework.api;
using helloworld.events;

namespace helloworldmulticontext.config
{
	public class MessageEventReceive : IConfig
	{
		[Inject] public IModuleConnector moduleConnector;

		public void Configure ()
		{
			moduleConnector.OnDefaultChannel().ReceiveEvent(MessageEvent.Type.SEND);
		}
	}
}

