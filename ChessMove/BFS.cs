using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMove
{
    public class Node
    {
        public int row { get; set; }
        public int col { get; set; }
        public int step { get; set; }
    }

    public class BFS
    {
        private Queue<Node> _queue;
        private int[] movementX = new int[] { 1, 2, 2, 1, -1, -2, -2, 1 };
        private int[] movementY = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
        private int _rows;
        private int _cols;

        private bool[][] _visited;

        public BFS(int rows, int cols)
        {
            _queue = new Queue<Node>();
            _rows = rows;
            _cols = cols;
            initialiseVisited();
        }

        private void initialiseVisited()
        {
            _visited = new bool[_rows][];

            for (int i = 0; i < _rows; i++)
            {
                bool[] inner = new bool[_cols];
                for (int j = 0; j < _cols; j++)
                {
                    inner[j] = false;
                }
                _visited[i] = inner;
            }
        }

        public int MinMoves(int row, int col, int destRow, int destCol)
        {
            Node start = new Node();
            start.row = row;
            start.col = col;
            start.step = 0;

            _queue.Enqueue(start);

            while (_queue.Count != 0)
            {
                Node top = _queue.Dequeue();

                if (top.row == destRow && top.col == destCol)
                    return top.step;

                for (var k = 0; k < 8; k++)
                {
                    if (top.row + movementY[k] >= 0 && top.row + movementY[k] < _rows &&
                        top.col + movementX[k] >= 0 && top.col + movementX[k] < _cols)
                    {
                        var newRow = top.row + movementY[k];
                        var newCol = top.col + movementX[k];

                        Node node = new Node() { row = newRow, col = newCol, step = top.step + 1 };
                        PushToQueue(node);
                    }
                }
            }

            return -1;
        }

        private void PushToQueue(Node v)
        {
            if (_visited[v.row][v.col]) return;
            _queue.Enqueue(v);
            _visited[v.row][v.col] = true;
        }
    }
}
