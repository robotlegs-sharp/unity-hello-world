using Robotlegs.Bender.Extensions.Modularity.API;
using Robotlegs.Bender.Framework.API;
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

