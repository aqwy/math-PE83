using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PE83
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Graph theGraph = new Graph();
            int plusN = 2;
            int maxV = 80;
            theGraph.addVertex("A1"); // 0
            for (int i = 0; i < maxV - 1; i++)
            {
                theGraph.addVertex("A" + plusN.ToString());
                plusN++;
            }

            theGraph.path();
            Console.WriteLine();*/

            Stopwatch clock = Stopwatch.StartNew();
            clock.Start();
            var matrix = File.ReadAllLines("d:\\p083_matrix.txt")
                .Select((x, i) => x.Split(',').Select((y, j) => new Node(int.Parse(y), i, j)).ToArray()).ToArray();
            matrix[0][0].Distance = matrix[0][0].Weight;
            var set = matrix.SelectMany(x => x).ToArray();
            Array.Sort(set, Node.DistanceComparer);
            for (int i = 0; i < set.Length; i++)
            {
                var node = set[i];
                bool needsSort = false;
                foreach (var (addi, addj) in new[] { (0, 1), (0, -1), (1, 0), (-1, 0) })
                {
                    if (node.I + addi < 0 || node.J + addj < 0 || node.I + addi >= matrix.Length ||
                        node.J + addj >= matrix.Length)
                    {
                        continue;
                    }
                    var neighbour = matrix[node.I + addi][node.J + addj];
                    var newDistance = node.Distance + neighbour.Weight;
                    if (newDistance < neighbour.Distance)
                    {
                        neighbour.Distance = newDistance;
                        needsSort = true;
                    }
                }
                if (needsSort)
                {
                    Array.Sort(set, i + 1, set.Length - i - 1, Node.DistanceComparer);
                }
            }
            clock.Stop();
            Console.WriteLine(matrix[matrix.Length - 1][matrix.Length - 1].Distance);
            Console.WriteLine(clock.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
