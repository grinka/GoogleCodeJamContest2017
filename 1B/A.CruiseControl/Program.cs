/// <summary>
/// Google CodeJam Contest.
/// Round 1B: Problem A. Steed 2: Cruise Control
/// </summary>
namespace CodeJam.CruiseControl {
	using System;

	class Program {
		static void Main(string[] args) {
			var testQty = int.Parse(Console.In.ReadLine());
			for(var t = 1; t <= testQty; t++) {
				ProcessOneTest(t);
			}
			//DisplayEnter();
		}

		static void DisplayEnter() {
			Console.WriteLine();
			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}

		static void ProcessOneTest(int testIdx) {
			var l = Console.In.ReadLine().Split(' ');
			var D = int.Parse(l[0]);
			var N = int.Parse(l[1]);
			float maxTime = 0.0f;
			for(var n = 0; n < N; n++) {
				l = Console.In.ReadLine().Split(' ');
				var k = int.Parse(l[0]);
				var s = int.Parse(l[1]);
				float newTime = ((float)(D - k)) / s;
				if(newTime > maxTime)
					maxTime = newTime;
			}
			float cruiseSpeed = D / maxTime;
			Console.Out.WriteLine($"Case #{testIdx}: {cruiseSpeed:#.0########}");
		}
	}
}
