using System;
namespace Caching
{
	public interface IFibonaciiCache
	{
		int? Get(int number);

		void Set(int number, int value);
	}
}

