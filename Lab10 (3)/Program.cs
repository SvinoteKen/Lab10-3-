using Lab10__3_.Graphs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10__3_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixAdj = 
            {
               //1 2 3 4 5 6 7 8
                {0,1,1,0,0,0,0,0}, //1
				{1,0,0,0,0,1,1,0}, //2
				{1,0,0,1,0,1,0,1}, //3
				{0,0,1,0,1,0,0,0}, //4
				{0,0,0,1,0,1,0,0}, //5
				{0,1,1,0,1,0,0,0}, //6
				{0,1,0,0,0,0,0,1}, //7
				{0,0,1,0,0,0,1,0}  //8
			};

            Graph1 graph = new Graph1(matrixAdj, 8);
            Console.Write("Введите вершину X:");
            int X = int.Parse(Console.ReadLine());
            while (X == 0 || X > 8)
            {
                Console.WriteLine("Значение введено не верно.Введите верное значение от 1 до 8:");
                X = int.Parse(Console.ReadLine());
            }
            Console.Write("Введите вершину Y:");
            int Y = int.Parse(Console.ReadLine());
            while (Y == 0 || Y > 8)
            {
                Console.WriteLine("Значение введено не верно.Введите верное значение от 1 до 8:");
                Y = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("В виде матрицы инцидентности:");

            Console.WriteLine("DFS:");
            Stack<int> DFS = graph.DFS(X - 1, Y - 1);
            PrintPath(DFS);
            Console.WriteLine();

            Console.WriteLine("BFS:");
            Stack<int> BFS = graph.BFS(X - 1, Y - 1);
            PrintPath(BFS);
            Console.WriteLine();

            
            Console.WriteLine("В виде связного списка:");

            Dictionary<int, List<int>> graph1 = new Dictionary<int, List<int>>();
            graph1[1] = new List<int> { 2, 3 };
            graph1[2] = new List<int> { 1, 6, 7 };
            graph1[3] = new List<int> { 1, 4, 6, 8 };
            graph1[4] = new List<int> { 3, 5 };
            graph1[5] = new List<int> { 4, 6 };
            graph1[6] = new List<int> { 2, 3, 5 };
            graph1[7] = new List<int> { 2, 8 };
            graph1[8] = new List<int> { 3, 7 };

            Graph2 graphList = new Graph2(graph1, 8);

            Console.WriteLine("DFS:");
            Stack<int> DFSList = graphList.DFS(X - 1, Y - 1);
            PrintPath(DFSList);
            Console.WriteLine();

            Console.WriteLine("BFS:");
            Stack<int> BFSList = graphList.BFS(X - 1, Y - 1);
            PrintPath(BFSList);

        }
        private static void PrintPath(Stack<int> path)
        {
            if (path.Count == 0)
            {
                Console.WriteLine("Путь не найден");
            }
            else
            {

                Console.WriteLine(string.Join(" -> ", path.Select(x => (x+1).ToString())));
            }
            
        }
    }
}
