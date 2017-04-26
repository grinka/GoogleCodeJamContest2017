/// <summary>
/// Google CodeJam Contest.
/// Round 1B: Problem C.
/// </summary>
namespace Project3 {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class Program {
		static void Main(string[] args) {
			var testQty = int.Parse(Console.In.ReadLine());
			for(var t = 1; t <= testQty; t++) {
				ProcessOneTest(t);
			}
		}

		static void ProcessOneTest(int testIdx) {
			var l = Console.In.ReadLine().Split(' ');
			var N = int.Parse(l[0]);
			var Q = int.Parse(l[1]);
			var speeds = new int[N];
			var distance = new int[N];
			for(var i = 0; i < N; i++) {
				var h = Console.In.ReadLine().Split(' ');
				speeds[N] = int.Parse(h[0]);
				distance[N] = int.Parse(h[1]);
			}
			var cities = new int[N, N];
			for(var i = 0; i < N; i++) {
				l = Console.In.ReadLine().Split(' ');
				for(var j = 0; j < N; j++) {
					cities[i, j] = int.Parse(l[j]);
				}
			}

			l = Console.In.ReadLine().Split(' ');
			var first = int.Parse(l[0]);
			var last = int.Parse(l[1]);

			// smallest distance

			var currentHorse = 0;
			var totalTime = 0.0F;
			for(var i = 0; i < N - 1; i++) {
				if(distance[currentHorse] >= cities[i, i + 1]) {
					if(speeds[currentHorse] > speeds[i]) {

					}
				} else {
					currentHorse = i;
				}
			}
		}
	}
}
