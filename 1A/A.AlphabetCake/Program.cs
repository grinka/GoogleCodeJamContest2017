namespace CodeJam.AlphabetCake {
	using System;
	class Program {
		static void Main(string[] args) {
			var tCount = int.Parse(Console.In.ReadLine());
			for(var tIdx = 1; tIdx <= tCount; tIdx++) {
				ProcessOneTest(tIdx);
			}
		}

		static void ProcessOneTest(int testIdx) {
			var testLine = Console.In.ReadLine().Split(' ');
			var rowsCount = int.Parse(testLine[0]);
			var colsCount = int.Parse(testLine[1]);
			var chars = new char[colsCount, rowsCount];
			var gen = new char[colsCount, rowsCount];
			for(var rowIdx = 0; rowIdx < rowsCount; rowIdx++) {
				for(var colIdx = 0; colIdx < colsCount; colIdx++) {
					chars[colIdx, rowIdx] = (char)Console.In.Read();
					gen[colIdx, rowIdx] = chars[colIdx, rowIdx];
				}
				Console.In.ReadLine();
			}

			for(var r = 0; r < rowsCount; r++) {
				for(var c = 0; c < colsCount; c++) {
					if(chars[c, r] != '?') {
						var s = chars[c, r];
						// need to populate
						var c1 = c;
						var c2 = c;
						var r1 = r;
						var r2 = r;
						while(FloodH(gen, r1, r2, c1 - 1, s)) {
							c1--;
						}
						while(FloodV(gen, c1, c2, r1 - 1, s)) {
							r1--;
						}
						while(FloodH(gen, r1, r2, c2 + 1, s)) {
							c2++;
						}
						while(FloodV(gen, c1, c2, r2 + 1, s)) {
							r2++;
						}
					}
				}
			}
			Console.Out.WriteLine($"Case #{testIdx}:");
			for(var row = 0; row < rowsCount; row++) {
				for(var col = 0; col < colsCount; col++) {
					Console.Out.Write(gen[col, row]);
				}
				Console.Out.WriteLine();
			}
		}

		static bool FloodH(char[,] chars, int r1, int r2, int newcol, char s) {
			if(newcol<0 || newcol>=chars.GetLength(0)) {
				return false;
			}
			var canMove = true;
			for(var ri = r1; ri <= r2; ri++) {
				if(chars[newcol, ri] != '?') {
					canMove = false;
				}
			}
			if(canMove) {
				for(var ri = r1; ri <= r2; ri++) {
					chars[newcol, ri] = s;
				}
				return true;
			}
			return false;
		}

		static bool FloodV(char[,] chars, int c1, int c2, int newrow, char s) {
			if(newrow <0 || newrow >= chars.GetLength(1)) {
				return false;
			}
			var canMove = true;
			for(var ci = c1; ci <= c2; ci++) {
				if(chars[ci, newrow] != '?') {
					canMove = false;
				}
			}
			if(canMove) {
				for(var ci = c1; ci <= c2; ci++) {
					chars[ci, newrow] = s;
				}
				return true;
			}
			return false;
		}
	}
}
