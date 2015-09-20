
namespace helloworld.models
{
	// Models store data and are peristant througout the application
	public class ClickCountModel : IClickCountModel
	{
		// These methods and the getter are exposed through the interface
		public int Count { get; private set; }

		public void IncrementCount ()
		{
			Count++;
		}

		public void ResetCount ()
		{
			Count = 0;
		}
	}
}