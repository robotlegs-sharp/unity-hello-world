using Robotlegs.Bender.Extensions.Modularity.API;
using Robotlegs.Bender.Framework.API;
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

