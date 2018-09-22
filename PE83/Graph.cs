﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE83
{  
    class Graph
    {
        private readonly int MAX_VERTS = 80;
        private readonly int INFINITY = 1000000;
        private Vertex[] vertexList;
        private int[,] adjMat;
        private int nVerts;
        private int nTree;
        private int CurrentVert;
        private int StartToCurrent;
        private DistPar[] sPath;
        public Graph()
        {
            vertexList = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;
            nTree = 0;
            CurrentVert = 0;
            StartToCurrent = 0;
            sPath = new DistPar[MAX_VERTS];
            adjMat = readInput("d:\\p083_matrix.txt");
        }
        public  int[,] readInput(string filename)
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
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        public void addEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
        }
        public void path()
        {
            int startTree = 0;
            vertexList[startTree].isInTree = true;
            nTree = 1;

            for (int i = 0; i < nVerts; i++)
            {
                int tempDist = adjMat[startTree, i];
                sPath[i] = new DistPar(startTree, tempDist);
            }

            while (nTree < nVerts)
            {
                int indexMin = getMin();
                int minDist = sPath[indexMin].distance;

                if (minDist == INFINITY)
                {
                    Console.WriteLine("There are unreachable vertices");
                    break;
                }
                else
                {
                    CurrentVert = indexMin;
                    StartToCurrent = sPath[indexMin].distance;
                }
                vertexList[CurrentVert].isInTree = true;
                nTree++;
                adjust_sPath();
            }
            displayPaths();

            nTree = 0;
            for (int i = 0; i < nVerts; i++)
                vertexList[i].isInTree = false;

        }
        public int getMin()
        {
            int minDist = INFINITY;
            int indexMin = 0;

            for (int i = 1; i < nVerts; i++)
            {
                if (!vertexList[i].isInTree && sPath[i].distance < minDist)
                {
                    minDist = sPath[i].distance;
                    indexMin = i;
                }
            }
            return indexMin;
        }
        public void adjust_sPath()
        {
            int colum = 1;
            while (colum < nVerts)
            {
                if (vertexList[colum].isInTree)
                {
                    colum++;
                    continue;
                }
                int currentToFringe = adjMat[CurrentVert, colum];
                int startToFringe = StartToCurrent + currentToFringe;
                int sPathDist = sPath[colum].distance;

                if (startToFringe < sPathDist)
                {
                    sPath[colum].parentVert = CurrentVert;
                    sPath[colum].distance = startToFringe;
                }
                colum++;
            }
        }
        public void displayPaths()
        {
            for (int i = 0; i < nVerts; i++)
            {
                Console.Write(vertexList[i].lable + "=");
                if (sPath[i].distance == INFINITY)
                    Console.Write("inf");
                else
                    Console.Write(sPath[i].distance);
                char parent = vertexList[sPath[i].parentVert].lable;
                Console.Write("(" + parent + ") ");
            }
            Console.WriteLine();
        }
    }
}
