using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratatouille {
	class Program {

		private class Package {
			public int Size { get; set; }
			public double MinP { get; set; }
			public double MaxP { get; set; }

			public Package(int size, int n) {
				Size = size;
				MinP = Math.Ceiling((size / 1.1) / n);
				MaxP = Math.Floor((size / 0.9) / n);
			}
		}

		private class Supply {
			public Supply() {
				Packages = new Stack<Package>();
			}
			public Stack<Package> Packages { get; set; }
		}

		static void Main(string[] args) {
			var tCount = int.Parse(Console.In.ReadLine());
			for(var tIdx = 1; tIdx <= tCount; tIdx++) {
				ProcessOneTest(tIdx);
			}
			Console.WriteLine();
			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}

		static void ProcessOneTest(int testIdx) {
			var tLine = Console.In.ReadLine().Split(' ');
			var N = int.Parse(tLine[0]); // number of ingridients
			var P = int.Parse(tLine[1]); // number of packages
			var nValuesLine = Console.In.ReadLine().Split(' ');
			var nValues = nValuesLine.Select(x => int.Parse(x)).ToArray();
			var pValues = new Supply[N];
			var foundMatches = 0;
			for(var i = 0; i < N; i++) {
				var pValuesLine = Console.In.ReadLine().Split(' ');
				pValues[i] = new Supply();
				var plist = new List<Package>();
				for(var j = 0; j < P; j++) {
					var package = new Package(int.Parse(pValuesLine[j]), nValues[i]);
					plist.Add(package);
				}
				foreach(var p in plist.OrderByDescending(x => x.MinP)) {
					pValues[i].Packages.Push(p);
				}
			}

			if(N == 1) {
				Console.WriteLine("1");
			} else {
				while(pValues[0].Packages.Any() && pValues[1].Packages.Any()) {
					while(pValues[0].Packages.Any() && pValues[0].Packages.Peek().MaxP < pValues[1].Packages.Peek().MinP) {
						pValues[0].Packages.Pop();
					}
					if(pValues[0].Packages.Any()) {
						while(pValues[1].Packages.Any() && pValues[1].Packages.Peek().MaxP < pValues[0].Packages.Peek().MinP) {
							pValues[1].Packages.Pop();
						}

						if(pValues[1].Packages.Any() && InSame(pValues[1].Packages.Peek(), pValues[0].Packages.Peek())) {
							pValues[1].Packages.Pop();
							pValues[0].Packages.Pop();
							foundMatches++;
						}
					}
				}
			}

			Console.Out.WriteLine($"Case #{testIdx}: {foundMatches}");

		}

		static bool InSame(Package x, Package y) {
			return x.MinP <= y.MaxP && y.MinP <= x.MaxP;
		}
	}
}
