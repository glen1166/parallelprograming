using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
		var data = ReadTask();
		Console.WriteLine("main thread");
		Console.WriteLine(data.Result);
        }
	
	public static Task<int> ReadTask()
	{
	    var tcs = new TaskCompletionSource<int>();
	    Task.Delay(5000).ContinueWith(task => tcs.SetResult(111));
	    return tcs.Task;
	}
    }
}
