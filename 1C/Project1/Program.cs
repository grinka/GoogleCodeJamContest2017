/// <summary>
/// Google CodeJam Contest.
/// Round 1C: Problem A: Ample Syrup
/// </summary>
namespace GoogleCodeJam.Contest2017.Round1C.Project1 {

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
			var widest = stack.OrderByDescending(x => x.AddedSize).Take(K).Max(x => x.r);
			var baseC = stack.Where(x => x.r >= widest).OrderByDescending(x => x.CoveredSize).First();
			var addedAizesList = stack
				.Where(x => (x.idx != baseC.idx && x.r <= baseC.r))
				.OrderByDescending(x => x.AddedSize)
				.Take(K - 1);
			sum = baseC.CoveredSize;
			foreach(var ac in addedAizesList) {
				sum += ac.AddedSize;
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
