
namespace helloworld.models
{
	public interface IClickCountModel
	{
		void ResetCount();
		void IncrementCount();
		int Count { get; }
	}
}