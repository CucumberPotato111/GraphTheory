using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1
{
    internal class Bai1
    {
        private int[,] adjMatrix;
        private int numVertices;

        public Bai1(int numVertices)
        {
            this.numVertices = numVertices;
            adjMatrix = new int[numVertices, numVertices];
        }

        public void ReadAdjacencyMatrix(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < numVertices; i++)
            {
                string[] elements = lines[i + 1].Split(' ');
                for (int j = 0; j < numVertices; j++)
                {
                    adjMatrix[i, j] = int.Parse(elements[j]);
                }
            }
        }

        public int[] CalculateDegrees()
        {
            int[] degrees = new int[numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (adjMatrix[i, j] == 1)
                    {
                        degrees[i]++;
                    }
                }
            }
            return degrees;
        }

        public void WriteDegrees(string filePath, int[] degrees) // Only use this when you want to output as file
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(numVertices);
                sw.WriteLine(string.Join(" ", degrees));
            }
        }
        public void PrintDegrees(int[] degrees)
        {
            Console.WriteLine(numVertices);
            for (int i = 0; i < degrees.Length; i++)
            {
                Console.Write(degrees[i] + (i < degrees.Length - 1 ? " " : "\n"));
            }
        }
    }
}
