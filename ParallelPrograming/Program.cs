using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Test
{
	static void Main()
	{
		int[] nums = Enumerable.Range(0, 1000000).ToArray();
		long total = 0;

		// First type parameter is the type of the source elements
		// Second type parameter is the type of the thread-local variable (partition subtotal)
		Parallel.ForEach<int, long>(nums, 
				() => 0, 
				(j, loop, subtotal) => 
				{
				subtotal += j; 
				return subtotal;
				},
				(finalResult) => Interlocked.Add(ref total, finalResult)
				);

		Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);
	}
}
// The example displays the following output:
//        The total from Parallel.ForEach is 499,999,500,000
