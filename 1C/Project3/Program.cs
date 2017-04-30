/// <summary>
/// Google CodeJam Contest.
/// Round 1C: Problem C.
/// </summary>
namespace GoogleCodeJam.Contest2017.Round1C.Project3 {
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
			//DisplayEnter();
		}

		static void DisplayEnter() {
			Console.WriteLine();
			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}

		static void ProcessOneTest(int testIdx) {
		}
	}
}
