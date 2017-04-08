/// <summary>
/// Google CodeJam contest.
/// Task: Tidy Numbers.
/// Application Expects all the data to be in correct format.
/// </summary>
namespace TidyNumbers {
	using System;

	class Program {
		static void Main(string[] args) {
			var testCount = int.Parse(Console.In.ReadLine());
			var counter = new TidyCounterSmall();
			for(var testIdx = 1; testIdx <= testCount; testIdx++) {
				Console.Out.WriteLine($"Case #{testIdx}: {counter.maxTidy(Console.In.ReadLine())}");
			}
		}
	}
}
