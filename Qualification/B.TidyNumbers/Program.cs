/// <summary>
/// Google CodeJam contest.
/// Task: Tidy Numbers.
/// Application Expects all the data to be in correct format.
/// File contains two versions of the algorithm - Brute-force, applicable for small numbers 
/// and "Smmart" - it works with string.
/// </summary>
namespace CodeJam.TidyNumbers {
	using System;
	using System.Text;

	class Program {
		static void Main(string[] args) {
			var testCount = int.Parse(Console.In.ReadLine());
			for(var testIdx = 1; testIdx <= testCount; testIdx++) {
				var sourceNumber = Console.In.ReadLine();
				var res = maxTidySmart(sourceNumber);
				Console.Out.WriteLine($"Case #{testIdx}: {res}");
			}
		}

		/// <summary>
		/// Calculate the max tidy number below the given number represented by a string.
		/// Main idea is: copy all the digits until you find the "breaking" digit. Replace 
		/// that digit with "9" and then decrement previous digit. Check all the previous
		/// digits if they don't break the rule. After that replace the rest digits with 9.
		/// Example
		/// Source number: 1344421345566
		/// 1. Move forward until you meet "2" which is smaller than previous "4"
		/// 2. Perform replacement: 134442.. => 134439..
		/// 3. Move back until you fix the "broken" rules
		///    134439.. => 134399..
		///    134399.. => 133999..
		/// 4. Replace the rest digits with "9". Result is: 1339999999999
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		private static string maxTidySmart(string n) {
			StringBuilder res = new StringBuilder(n);
			var i = 0;
			var foundIt = false;
			for(i = 0; i < n.Length - 1; i++) {
				if(foundIt) {
					// 
					res[i + 1] = '9';
				} else {
					if(res[i] > res[i + 1]) {
						foundIt = true;
						res[i + 1] = '9';
						res[i] = (char)(res[i] - 1);
						// go back and fix changes if need
						// decrease all digits which violate the tidy rule
						var j = i - 1;
						while(j >= 0) {
							if(res[j] > res[j + 1]) {
								res[j + 1] = '9';
								res[j] = (char)(res[j] - 1);
							} else {
								break;
							}
							j--;
						}
					}
				}
			}
			while(res[0] == '0') {
				res.Remove(0, 1);
			}
			return res.ToString();
		}

		#region Brute-force realization

		/// <summary>
		/// Find maximum tidy number below the given number.
		/// </summary>
		/// <param name="n">String representation of the top margin number. Should fit the "int".</param>
		/// <returns>Maximum "tidy" number below the parameter.</returns>
		private static int maxTidy(string n) {
			return maxTidy(int.Parse(n));
		}

		/// <summary>
		/// Find maximum tidy number below the given number.
		/// Algorithm: decrement the number until the result is "tidy".
		/// </summary>
		/// <param name="n">Top margin number.</param>
		/// <returns>Maximum "tidy" number below the parameter.</returns>
		private static int maxTidy(int n) {
			for(var i = n; i > 0; i--) {
				if(IsTidy(i)) {
					return i;
				}
			}
			return 0;
		}

		/// <summary>
		/// Validate the number whatever it's tidy or not.
		/// Tidy means: every next digit is bigger or equal to the previous.
		/// </summary>
		/// <param name="number">Number to be verified.</param>
		/// <returns>true if number it "tidy".</returns>
		private static bool IsTidy(int number) {
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
		#endregion
	}
}
