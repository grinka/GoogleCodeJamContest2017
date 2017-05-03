/// <summary>
/// Google CodeJam Contest.
/// Round 1B: Problem B. Stable Neigh-bors
/// </summary>
namespace StableNeighbors {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class Program {

		// i'd replace dictionary with integer array using this enum if i have time
		private enum ManeColors {
			R = 0, O = 1, Y = 2, G = 3, B = 4, V = 5
		}

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
			var stalls = new char[N];
			var unicornStack = new Dictionary<char, int> {
				{ 'R', int.Parse(l[1]) },
				{ 'O', int.Parse(l[2]) },
				{ 'Y', int.Parse(l[3]) },
				{ 'G', int.Parse(l[4]) },
				{ 'B', int.Parse(l[5]) },
				{ 'V', int.Parse(l[6]) }
			};
			var res = FindNextNeighbor(unicornStack, stalls, 0);
			if(res) {
				Console.Out.WriteLine($"Case #{testIdx}: {new string(stalls)}");
			} else {
				Console.Out.WriteLine($"Case #{testIdx}: IMPOSSIBLE");
			}
		}

		static bool FindNextNeighbor(Dictionary<char, int> unicornStack, char[] stalls, int currentIndex) {
			if(currentIndex == stalls.Length) {
				return (CanBeNeighbor(stalls[currentIndex - 1], stalls[0]));
			}

			var prevMane = currentIndex == 0 ? ' ' : stalls[currentIndex - 1];
			var possibleManes = NextNeighbors(unicornStack, prevMane);

			if(possibleManes.Length == 0) {
				return false;
			}
			foreach(var m in possibleManes) {
				unicornStack[m]--;
				stalls[currentIndex] = m;
				var tryIt = FindNextNeighbor(unicornStack, stalls, currentIndex + 1);
				if(tryIt) return true;
				unicornStack[m]++;
				stalls[currentIndex] = ' ';
			}
			return false;
		}

		static char[] NextNeighbors(Dictionary<char, int> unicornStack, char m) {
			var possible = GetPossibleNeighbors(m);
			var maxV = unicornStack.Where(x => possible.Contains(x.Key)).Max(x => x.Value);
			return possible
				.Where(x => unicornStack[x] == maxV)
				.ToArray();
		}

		static char[] PriorityOrder(Dictionary<char, int> unicornStack, char m) {
			var possible = GetPossibleNeighbors(m);
			return possible
				.Where(x => unicornStack[x] > 0)
				.OrderByDescending(x => unicornStack[x])
				.ToArray();
		}

		static bool CanBeNeighbor(char m1, char m2) {
			return GetPossibleNeighbors(m1).Contains(m2);
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
