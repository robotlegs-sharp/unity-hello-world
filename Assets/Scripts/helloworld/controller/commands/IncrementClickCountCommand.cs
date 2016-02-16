using robotlegs.bender.extensions.commandCenter.api;
using robotlegs.bender.framework.api;
using helloworld.events;
using robotlegs.bender.extensions.eventDispatcher.api;
using System;
using helloworld.models;

namespace helloworld.controller.commands
{
	// Commands are small snippets of code that 'do things' in your application
	public class IncrementClickCounterCommand : ICommand
	{
		// In IConfig classes you can inject values based on rules from the injector
		[Inject] public ILogging logger;
		[Inject] public IEventDispatcher dispatcher;
		[Inject] public IClickCountModel model;
		
		// You can also inject the event that triggered the command to pass a payload
		[Inject] public ClickCountEvent evt;

		public void Execute ()
		{
			// Entry point into the command

			// Logger outputs to console
			logger.Info ("Command Incrementing Count");

			// We access the model from the injected value
			model.IncrementCount ();

			// Sends off an event to the global event dispatcher with a payload
			// This event can then trigger other commands and be heard from mediators
			dispatcher.Dispatch(new CountUpdatedEvent(CountUpdatedEvent.Type.VALUE_CHANGED, model.Count));

			// After execute is finished commands are disposed
		}
	}
}