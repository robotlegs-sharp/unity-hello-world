using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace helloworld.events
{
	public class ClickCountEvent : Event
	{
		public enum Type
		{
			INCREMENT
		}

		public ClickCountEvent (ClickCountEvent.Type type) : base(type) {}
	}
}