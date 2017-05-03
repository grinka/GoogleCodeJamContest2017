/// <summary>
/// Performs the pancake flipping process and calculates the result.
/// </summary>
namespace CodeJam.OversizedPancakeFlipper {
	using System.Text;
	internal class Flipper {
		/// <summary>
		/// Contains the "pancakes" string. Use stringbuilder for easier characters manipulation.
		/// </summary>
		private readonly StringBuilder _s;
		/// <summary>
		/// Flipper size.
		/// </summary>
		private readonly int _size;

		/// <summary>
		/// Initializes the new instance of pancakes flipper.
		/// </summary>
		/// <param name="s">Original string representing the pancakes line.</param>
		/// <param name="size">Size of the flipper.</param>
		public Flipper(string s, int size) {
			_s = new StringBuilder(s);
			_size = size;
		}

		/// <summary>
		/// Calculate the minimum amount of flips needed to flip all pancakes to "happy" side.
		/// The main idea is: you move from the left side and every time when you meet the "-"
		/// (wrong side) you flip all the cakes starting from this one.
		/// You skip last "size" cakes because you can not flip less than "size" of them.
		/// After finishing the process you need to check only last "size" cakes for their
		/// "happiness" because all the cakes on the left already made "happy" - we don't change the
		/// state of cakes we already passed.
		/// </summary>
		/// <returns>Minimum amount of the moves needed to flip all the cakes. 
		/// Returns -1 if it's impossible to achieve the result.</returns>
		public int flipsCount() {
			var cnt = 0;
			for(var mainStringIndex = 0; mainStringIndex < _s.Length - _size + 1; mainStringIndex++) {
				if(_s[mainStringIndex] == '-') {
					cnt++;
					for(var j = 0; j < _size; j++) {
						_s[mainStringIndex + j] = _s[mainStringIndex + j] == '-' ? '+' : '-';
					}
				}
			}
			for(var i = _s.Length - _size; i < _s.Length; i++) {
				if(_s[i] == '-') {
					return -1;
				}
			}
			return cnt;
		}


	}
}
