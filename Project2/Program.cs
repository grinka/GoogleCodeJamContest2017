/// <summary>
/// Google CodeJam Contest.
/// Round 1B: Problem B. Stable Neigh-bors
/// </summary>
namespace Project2 {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class Program {

		static char[] colorNames = new char[] { 'R', 'O', 'Y', 'G', 'B', 'V' };
		// i'd replace dictionary with integer array using this enum if i have time
		private enum ManeColors {
			R = 0, O = 1, Y = 2, G = 3, B = 4, V = 5
		}

		static void Main(string[] args) {
			var testQty = int.Parse(Console.In.ReadLine());
			for(var t = 1; t <= testQty; t++) {
				ProcessOneTestSmall(t);
			}
			//DisplayEnter();
		}

		static void DisplayEnter() {
			Console.WriteLine();
			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}

		static void ProcessOneTestSmall(int testIdx) {
			var l = Console.In.ReadLine().Split(' ');
			var N = int.Parse(l[0]);
			var stalls = new char[N];
			var stack = new int[6];
			for(var i = 0; i < 6; i++) {
				stack[i] = int.Parse(l[i + 1]);
			}

			Console.Out.WriteLine($"Case #{testIdx}: {BuildNeighborsSmall(stack, N)}");
		}

		static string BuildNeighborsSmall(int[] stack, int N) {
			if(stack.Max() > N / 2) {
				return "IMPOSSIBLE";
			}
			var ret = new char[N];
			var i = 0;
			var j = 0;
			var idxMax = stack.ToList().IndexOf(stack.Max());
			var c = colorNames[idxMax];

			while(j < N) {
				ret[i] = c;
				stack[idxMax]--;
				if(stack[idxMax] == 0) {
					idxMax = stack.ToList().IndexOf(stack.Max());
					c = colorNames[idxMax];
				}
				i += 2;
				if(i >= N) {
					i = 1;
				}
				j++;
			}
			return new string(ret);

		}

		static char[] GetPossibleNeighbors(char maneColor) {
			switch(maneColor) {
				case 'R':
					return new char[] { 'B', 'G', 'Y' };
				case 'O':
					return new char[] { 'B' };
				case 'G':
					return new char[] { 'R' };
				case 'V':
					return new char[] { 'Y' };
				case 'Y':
					return new char[] { 'B', 'V', 'R' };
				case 'B':
					return new char[] { 'R', 'O', 'Y' };
				default:
					return new char[] { 'B', 'Y', 'R', 'G', 'V', 'O' };
			}
		}
	}
}
