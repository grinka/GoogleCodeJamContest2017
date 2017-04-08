/// <summary>
/// Brute-force implementation to find the largest tidy number below given number.
/// </summary>
namespace TidyNumbers {
	internal class TidyCounterSmall {
		/// <summary>
		/// Find the largest tidy number below given number.
		/// </summary>
		/// <param name="n">String representation of the top margin number.</param>
		/// <returns>Largest tidy number below the top margin.</returns>
		public int maxTidy(string n) {
			return maxTidy(int.Parse(n));
		}

		/// <summary>
		/// Find the largest tidy number below given number.
		/// </summary>
		/// <param name="n">The top margin number.</param>
		/// <returns>Largest tidy number below the top margin.</returns>
		public int maxTidy(int n) {
			for(var i = n; i > 0; i--) {
				if(IsTidy(i)) {
					return i;
				}
			}
			return 0;
		}

		/// <summary>
		/// Validates if given number is tidy.
		/// </summary>
		/// <param name="number">The number to be validated.</param>
		/// <returns>True if number is "tidy" - every next digit is not smaller than previous.</returns>
		private bool IsTidy(int number) {
			var lastDigit = number % 10;
			var runner = number / 10;
			while(runner > 0) {
				var newLast = runner % 10;
				if(newLast > lastDigit) {
					return false;
				}
				lastDigit = newLast;
				runner = runner / 10;
			}
			return true;
		}
	}
}
