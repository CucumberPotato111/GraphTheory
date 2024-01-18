using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1
{
    internal class Bai2
    {
        private int[,] adjMatrix;
        private int numVertices;

        public Bai2(int numVertices)
        {
            this.numVertices = numVertices;
            adjMatrix = new int[numVertices, numVertices];
        }

        public void ReadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 1; i <= numVertices; i++)
            {
                string[] elements = lines[i].Split(' ');
                for (int j = 0; j < numVertices; j++)
                {
                    adjMatrix[i - 1, j] = int.Parse(elements[j]);
                }
            }
        }

        public void CalculateDegrees()
        {
            for (int i = 0; i < numVertices; i++)
            {
                int inputDegree = 0;
                int outputDegree = 0;
                for (int j = 0; j < numVertices; j++)
                {
                    if (adjMatrix[i, j] > 0) outputDegree++;
                    if (adjMatrix[j, i] > 0) inputDegree++;
                }
                Console.WriteLine($"{inputDegree} {outputDegree}");
            }
        }
    }
}
