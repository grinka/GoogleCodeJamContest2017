/// <summary>
/// Google CodeJam Contest.
/// Round 1C: Problem A: Ample Syrup
/// </summary>
namespace CodeJam.AmpleSyrup {

	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Program1 {
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
			var N = int.Parse(l[0]);
			var K = int.Parse(l[1]);
			var stack = new List<Cake>();
			for(var i = 0; i < N; i++) {
				l = Console.In.ReadLine().Split(' ');
				var c = new Cake(ulong.Parse(l[0]), ulong.Parse(l[1]), i);
				stack.Add(c);
			}

			decimal sum = 0.0M;
			// find K max items
			var topPart = stack.OrderByDescending(x => x.AddedSize).Take(K);
			var maxR = topPart.Max(x => x.r);
			var minH = topPart.Where(x => x.r == maxR).Min(x => x.h);
			// there are no difference between the order of the cakes in the top part
			// we take the cake with bigger radius and smaller height, so it has the smallest
			// covering surface of all possible bases from the top.
			// If we found something better (with bigger covering surface), we will just replace
			// this one with it.
			var possibleBase = topPart.First(x => x.r == maxR && x.h == minH);

			// now find the possible base in the rest of stack
			var baseC = stack.Where(x => (!topPart.Contains(x) && x.r >= maxR)).OrderByDescending(x => x.CoveredSize).First();

			// take covered size from the cake with bigger covered surface.
			sum = Math.Max(baseC.CoveredSize, possibleBase.CoveredSize);
			// add all the heights except the base cake.
			// So we skip the "possibleBase" whatever if it's a base
			// or it's replaced
			foreach(var ac in topPart) {
				if(ac != possibleBase) {
					sum += ac.AddedSize;
				}
			}
			var result = (decimal)(sum) * (decimal)Math.PI;

			Console.Out.WriteLine($"Case #{testIdx}: {result:#.0##########}");
		}

		private class Cake {
			public ulong r { get; }
			public ulong h { get; }
			public int idx { get; }
			public Cake(ulong r, ulong h, int idx) {
				this.r = r;
				this.h = h;
				this.idx = idx;
				this.CoveredSize = r * (r + 2 * h);
				this.AddedSize = 2 * r * h;
			}
			public ulong CoveredSize { get; }
			public ulong AddedSize { get; }
		}
	}
}
