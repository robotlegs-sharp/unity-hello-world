using robotlegs.bender.extensions.eventDispatcher.impl;

namespace helloworld.events
{
	public class MultiContextEvent : Event
	{
		public enum Type
		{
			TEST
		}

		public MultiContextEvent (MultiContextEvent.Type type) : base(type) {}
	}
}