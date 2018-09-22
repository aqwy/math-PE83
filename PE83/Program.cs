using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE83
{
    class Program
    {
        public static int[,] readInput(string filename)
        {
            int lines = 0;
            string line;
            string[] linePieces;
            int[,] grid;
            StreamReader r = new StreamReader(filename);
            while (r.ReadLine() != null)
                lines++;

            grid = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(',');
                for (int i = 0; i < linePieces.Length; i++)
                    grid[j, i] = int.Parse(linePieces[i]);              
                j++;
            }
            r.Close();
            return grid;
        }
        static void Main(string[] args)
        {
            int[,] adjMat = readInput("d:\\p083_matrix.txt");
            Console.ReadLine();
        }
    }
}
