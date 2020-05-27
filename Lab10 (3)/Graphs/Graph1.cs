using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10__3_.Graphs
{
    class Graph1
    {
        private int V = 0;

        private int[,] graph = null;

        public Graph1(int[,] adj, int numOfVert)
        {
            graph = adj;
            V = numOfVert;
        }

        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }

        public Stack<int> DFS(int startPos, int endPos)
        {
            Stack<int> stack = new Stack<int>();

            int[] vPath = new int[V];

            int[] checkedv = new int[V];

            stack.Push(startPos);
            checkedv[startPos] = 1;

            while (stack.Count > 0)
            {
                int i = stack.Pop();

                for (int j = V - 1; j >= 0; j--)
                {
                    if (graph[i, j] > 0 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        stack.Push(j);
                        vPath[j] = i;

                        if (j == endPos)
                        {
                            return backChain(vPath, startPos, endPos);
                        }
                    }
                }
            }

            return null;
        }
        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            int[] vPath = new int[V];

            int[] checkedv = new int[V];

            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] > 0 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                        {
                            return backChain(vPath, startPos, endPos);
                        }
                    }
                }


            }
            return null;
        }

    }
}
