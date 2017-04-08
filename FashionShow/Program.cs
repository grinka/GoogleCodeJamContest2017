using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShow {
	// x - model
	// + - model
	// o - model
	// X - place for x model or empty
	// = - place for + model or empty
	// Y - empty only
	class FashionShow {

		private class FashionModel {
			public int x { get; set; }
			public int y { get; set; }
			public char model { get; set; }
		}

		static void Main(string[] args) {
			var size = 10;
			var init = InitM(size);
			var m = CloneM(init, size);

			var newM = matrixWithMaxWeight(m, 0, 0, size);
			DisplayMatrix(newM);
			Console.WriteLine(mWeight(newM));
			Console.WriteLine();
			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}

		private static char[,] matrixWithMaxWeight(char[,] initMatrix, int x, int y, int size) {
			if(x == size - 1 && y == size - 1) {
				return initMatrix;
			}
			var maxWeight = 0;
			var newX = x + 1;
			var newY = y;
			if(newX == size) {
				newX = 0;
				newY++;
			}

			var best = initMatrix;
			var c = initMatrix[x, y];
			if(c == ' ') {
				var om = matrixWithMaxWeight(AddItemToMatrix(x, y, 'o', initMatrix, size), newX, newY, size);
				maxWeight = mWeight(om);
				best = om;
				var xm = matrixWithMaxWeight(AddItemToMatrix(x, y, 'x', initMatrix, size), newX, newY, size);
				var xw = mWeight(xm);
				var pm = matrixWithMaxWeight(AddItemToMatrix(x, y, '+', initMatrix, size), newX, newY, size);
				var pw = mWeight(xm);
				var em = matrixWithMaxWeight(initMatrix, newX, newY, size);
				var ew = mWeight(em);
				if(xw > maxWeight) {
					best = xm;
					maxWeight = xw;
				}
				if(pw > maxWeight) {
					best = pm;
					maxWeight = pw;
				}
				if(ew > maxWeight) {
					best = em;
					maxWeight = ew;
				}
			} else if(c == 'X') {
				best = matrixWithMaxWeight(AddItemToMatrix(x, y, 'x', initMatrix, size), newX, newY, size);
				maxWeight = mWeight(best);
				var em = matrixWithMaxWeight(initMatrix, newX, newY, size);
				var ew = mWeight(em);
				if(ew > maxWeight) {
					best = em;
					maxWeight = ew;
				}
			} else if(c == '=') {
				best = matrixWithMaxWeight(AddItemToMatrix(x, y, '+', initMatrix, size), newX, newY, size);
				maxWeight = mWeight(best);
				var em = matrixWithMaxWeight(initMatrix, newX, newY, size);
				var ew = mWeight(em);
				if(ew > maxWeight) {
					best = em;
					maxWeight = ew;
				}
			}
			return best; ;
		}

		private static int mWeight(char[,] m) {
			var weight = 0;
			for(var x = 0; x < m.GetLength(0); x++) {
				for(var y = 0; y < m.GetLength(1); y++) {
					switch(m[x, y]) {
						case 'x':
						case '+':
							weight++;
							break;
						case 'o':
							weight += 2;
							break;
					}
				}
			}
			return weight;
		}

		static char[,] CloneM(char[,] m, int size) {
			var ret = new char[size, size];
			for(var x = 0; x < size; x++) {
				for(var y = 0; y < size; y++) {
					ret[x, y] = m[x, y];
				}
			}
			return ret;
		}

		static char[,] InitM(int size) {
			var ret = new char[size, size];
			for(var x = 0; x < size; x++) {
				for(var y = 0; y < size; y++) {
					ret[x, y] = ' ';
				}
			}
			return ret;
		}

		static char[,] AddItemToMatrix(int x, int y, char item, char[,] matrix, int size) {
			var ret = new char[size, size];
			for(var col = 0; col < size; col++) {
				for(var row = 0; row < size; row++) {
					if(row == y && col == x) {
						ret[col, row] = item;
					} else {
						switch(matrix[col, row]) {
							case '+':
							case 'Y':
							case 'o':
							case 'x':
								ret[col, row] = matrix[col, row];
								break;
							case ' ':
								if((item == 'x' || item == 'o') && (row == y || col == x)) {
									ret[col, row] = '=';
								} else if((item == '+' || item == 'o') && ((x - y == col - row) || (x + y == col + row))) {
									ret[col, row] = 'X';
								} else {
									ret[col, row] = ' ';
								}
								break;
							case '=':
								if((item == '+' || item == 'o') && ((x - y == col - row) || (x + y == col + row))) {
									ret[col, row] = 'Y';
								} else {
									ret[col, row] = '=';
								}
								break;
							case 'X':
								if((item == 'x' || item == 'o') && (row == y || col == x)) {
									ret[col, row] = 'Y';
								} else {
									ret[col, row] = 'X';
								}
								break;
						}
					}
				}
			}
			return ret;
		}

		static void DisplayMatrix(char[,] m) {
			for(var i = 0; i < m.GetLength(1); i++) {
				for(var j = 0; j < m.GetLength(0); j++) {
					Console.Write($"{m[j, i]}  ");
				}
				Console.WriteLine();
			}
		}

	}
}