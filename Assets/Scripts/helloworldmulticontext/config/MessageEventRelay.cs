using robotlegs.bender.extensions.modularity.api;
using robotlegs.bender.framework.api;
using helloworld.events;

namespace helloworldmulticontext.config
{
	public class MessageEventRelay : IConfig
	{
		[Inject] public IModuleConnector moduleConnector;

		public void Configure ()
		{
			moduleConnector.OnDefaultChannel().RelayEvent(MessageEvent.Type.SEND);
		}
	}
}

