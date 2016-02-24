using helloworld.controller.commands;
using helloworld.events;
using helloworld.models;
using helloworld.views;
using helloworld.views.mediators;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;

namespace helloworldmulticontext.config
{
	public class HelloWorldMappingConfig : IConfig
	{
		[Inject] public IEventCommandMap eventCommandMap;
		[Inject] public IMediatorMap mediatorMap;
		[Inject] public IInjector injector;

		public void Configure ()
		{
			eventCommandMap.Map (ClickCountEvent.Type.INCREMENT).ToCommand<IncrementClickCounterCommand>();
			mediatorMap.Map<ButtonView> ().ToMediator<ButtonMediator> ();
			mediatorMap.Map<ClickCountView> ().ToMediator<ClickCountMediator> ();
			injector.Map<IClickCountModel> ().ToSingleton<ClickCountModel> ();
		}
	}
}

