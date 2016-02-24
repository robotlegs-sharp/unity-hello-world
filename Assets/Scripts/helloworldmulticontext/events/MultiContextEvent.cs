using Robotlegs.Bender.Extensions.EventManagement.Impl;

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