/// <summary>
/// Google CodeJam Contest. Qualification Round.
/// Task: Bathroom Stalls. Brute-Force version.
/// Problem
/// 
/// A certain bathroom has N + 2 stalls in a single row; the stalls on the left 
/// and right ends are permanently occupied by the bathroom guards.The other 
/// N stalls are for users.
/// 
/// Whenever someone enters the bathroom, they try to choose a stall that is as far 
/// from other people as possible.To avoid confusion, they follow deterministic rules: 
/// For each empty stall S, they compute two values LS and RS, each of which is the 
/// number of empty stalls between S and the closest occupied stall to the left or 
/// right, respectively.Then they consider the set of stalls with the farthest closest 
/// neighbor, that is, those S for which min(LS, RS) is maximal.If there is only one 
/// such stall, they choose it; otherwise, they choose the one among those where max(LS, RS)
/// is maximal.If there are still multiple tied stalls, they choose the leftmost stall 
/// among those.
///
/// K people are about to enter the bathroom; each one will choose their stall before 
/// the next arrives.Nobody will ever leave.
///
/// When the last person chooses their stall S, what will the values of max(LS, RS) and 
/// min(LS, RS) be?
/// 
/// Application expects all the data in correct format.
/// </summary>
namespace BathroomStalls {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Program {
		static void Main(string[] args) {
			var testCount = int.Parse(Console.In.ReadLine());
			for(var testIdx = 1; testIdx <= testCount; testIdx++) {
				var testLine = Console.In.ReadLine().Split(' ');
				var res = LastTry(testLine[0], testLine[1]);
				Console.Out.WriteLine($"Case #{testIdx}: {res.Item1} {res.Item2}");
			}
			Console.ReadLine();
		}

		private static Tuple<ulong, ulong> LastTry(string stallsCount, string visitorsCount) {
			return LastTry(ulong.Parse(stallsCount), ulong.Parse(visitorsCount));
		}

		/// <summary>
		/// Find the larger and smaller interval for the last visitor entrance.
		/// Visitor always goes to the stall inside the largest existing inteval.
		/// For this interval to calculate two new intervals it's needed to subtract 
		/// 1 from interval size (for new visitor) and divide it on two. Add 1 to greater
		/// half if original interval size is even.
		/// In our calculation we divide on two and then substract 1 from smaller part
		/// if original interval size was odd.
		/// To minify the calculation time we don't count each visitor data, but divide
		/// them by droups. At the same time we have N stall intervals with same maximum
		/// size. So we perform splitting for all them and change the current visitor index
		/// by N. If visitor index becomes bigger than total visitors count, our last visitor
		/// is in the group. All visitors in the group have same min and max intervals because
		/// source interval for them is the same. After each splitting we get 2*N new
		/// intervals what means, that algorithm complexity will be Log(N) instead of N.
		/// </summary>
		/// <param name="stallsCount">Stalls quantity (N)</param>
		/// <param name="visitorsCount">Visitors quantity.</param>
		/// <returns>Two ulong numbers - maximum and minimum intervals for last visitor.</returns>
		private static Tuple<ulong, ulong> LastTry(ulong stallsCount, ulong visitorsCount) {
			var _spaces = new SortedDictionary<ulong, ulong> {
				{ stallsCount, 1 }
			};

			ulong minInterval = 0, maxInterval = 0;
			ulong visitor = 0;
			while(visitor < visitorsCount) {
				ulong maxKey = _spaces.Keys.Max();
				var mq = _spaces[maxKey];
				visitor += mq;
				_spaces.Remove(maxKey);

				maxInterval = maxKey / 2;
				minInterval = (maxKey % 2 > 0) ? maxInterval : maxInterval - 1;
				if(_spaces.ContainsKey(maxInterval)) {
					var newBigger = _spaces[maxInterval] + mq;
					_spaces[maxInterval] = newBigger;
				} else {
					_spaces.Add(maxInterval, mq);
				}
				if(_spaces.ContainsKey(minInterval)) {
					var newSmaller = _spaces[minInterval] + mq;
					_spaces[minInterval] = newSmaller;
				} else {
					_spaces.Add(minInterval, mq);
				}

			}
			return new Tuple<ulong, ulong>(maxInterval, minInterval);
		}

	}
}
