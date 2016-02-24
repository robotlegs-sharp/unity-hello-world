using System;
using helloworld.events;
using helloworld.views;
using Robotlegs.Bender.Bundles.MVCS;
using Robotlegs.Bender.Extensions.EventManagement.API;


namespace helloworld.views.mediators
{
	// Mediators are always attached to views
	public class ButtonMediator : Mediator
	{
		// The view instance can optionally be injected into the mediator
		[Inject] public ButtonView view;

		public override void Initialize ()
		{
			// Adds a callback for when the view dispatches a ClickCountEvent of type INCREMENT
			AddViewListener<ClickCountEvent>(ClickCountEvent.Type.INCREMENT, Dispatch);
			/*
			 * You can alternativly pass the event to the global event dispatcher this way:
			 * AddViewListener (ClickCountEvent.Type.INCREMENT, Dispatch);
			 */

			/*
			 * To handle events from the global event dispatcher (and potentially notifying the view)
			 * use AddContextListener passing a callback
			 * AddContextListener<CountUpdatedEvent>(CountUpdatedEvent.Type.VALUE_CHANGED, HandleCountUpdatedEvent);
			 */
		}

		private void HandleClickCountEvent(ClickCountEvent evt)
		{
			// Passes the event to the global event dispatcher triggering anything mapped to the event
			Dispatch(evt);
		}
	}
}