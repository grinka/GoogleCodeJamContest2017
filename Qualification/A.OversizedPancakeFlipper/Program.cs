/// <summary>
/// Google code jam contest Qualification Round.
/// Task: Oversized Pancake Flipper.
/// The application expects all the data to be in correct format.
/// </summary>
namespace CodeJam.OversizedPancakeFlipper {
	using System;

	class Program {
		static void Main(string[] args) {
			var testCount = int.Parse(Console.In.ReadLine());
			for(var testIndex = 1; testIndex <= testCount; testIndex++) {
				var testLine = Console.In.ReadLine().Split(' ');
				if(testLine.Length != 2) {
					throw new Exception("Test line should contain two elements separated by space");
				}
				// Expect that data is correct. If the second part of the line is not number, Exception
				// will be raised. We don't need to raise something else.
				var flipper = new Flipper(testLine[0], int.Parse(testLine[1]));
				var res = flipper.flipsCount();
				Console.Out.Write($"Case #{testIndex}: ");
				Console.Out.WriteLine((res > -1) ? res.ToString() : "IMPOSSIBLE");
			}
		}
	}
}
