using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace helloworld.events
{
	public class CountUpdatedEvent : Event
	{
		public enum Type
		{
			VALUE_CHANGED
		}

		public int Count { get; protected set; }

		public CountUpdatedEvent (CountUpdatedEvent.Type type, int count) : base(type)
		{
			Count = count;
		}
	}
}