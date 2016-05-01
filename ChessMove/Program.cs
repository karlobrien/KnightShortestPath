using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMove
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cols = 1000;
            var rows = 1000;
            var startCol = 0;
            var startRow = 1;
            var endCol = 799;
            var endRow = 899;

            //var result = GetShortestPath(rows, cols, startRow, startCol, endRow, endCol);
            //Console.WriteLine("Array Result: " + result);
            //Console.ReadLine();

            BFS bfs = new BFS(rows, cols);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var bfsResult = bfs.MinMoves(startRow, startCol, endRow, endCol);
            sw.Stop();

            Console.WriteLine("BFS Result: " + bfsResult + " Time: " + sw.Elapsed);
            Console.ReadLine();

        }

        public static int GetShortestPath(int rows, int cols, int startRow, int startCol, int endRow, int endCol)
        {
            int[][] board = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] inner = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    inner[j] = -1;
                }
                board[i] = inner;
            }

            int[] movementX = new int[] { 1, 2, 2, 1, -1, -2, -2, 1 };
            int[] movementY = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };

            var totalSteps = 500;
            board[startRow][startCol] = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int step = 0; step < totalSteps; step++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (board[i][j] == step)
                        {
                            for (var k = 0; k < 8; k++)
                            {
                                if (i + movementY[k] >= 0 && i + movementY[k] < rows && j + movementX[k] >= 0 && j + movementX[k] < cols)
                                    if (board[i + movementY[k]][j + movementX[k]] == -1)
                                        board[i + movementY[k]][j + movementX[k]] = step + 1;
                                if (board[endCol][endRow] != -1)
                                {
                                    sw.Stop();
                                    Console.WriteLine(sw.Elapsed);
                                    return board[endCol][endRow];
                                }
                            }
                        }
                    }
                }
            }

            return -1;
        }

        public static void PrintBoard(int[][] board, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
