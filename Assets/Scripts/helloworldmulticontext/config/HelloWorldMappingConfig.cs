using helloworld.controller.commands;
using helloworld.events;
using helloworld.models;
using helloworld.views;
using helloworld.views.mediators;
using robotlegs.bender.extensions.eventCommandMap.api;
using robotlegs.bender.extensions.mediatorMap.api;
using robotlegs.bender.framework.api;

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

