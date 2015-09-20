using System;
using helloworld.events;
using helloworld.views;
using robotlegs.bender.bundles.mvcs;
using robotlegs.bender.extensions.eventDispatcher.api;


namespace helloworld.views.mediators
{
	public class ClickCountMediator : Mediator
	{
		[Inject] public ClickCountView view;

		public override void Initialize ()
		{
			AddContextListener<CountUpdatedEvent>(CountUpdatedEvent.Type.VALUE_CHANGED, HandleChangeButtonText);
		}

		private void HandleChangeButtonText(CountUpdatedEvent evt)
		{
			view.ChangeButtonText (evt.Count);
		}
	}
}