using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1
{
    internal class Bai3
    {
        private List<int>[] adjacencyList;

        public Bai3(int numVertices)
        {
            adjacencyList = new List<int>[numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void ReadGraph(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int numVertices = int.Parse(lines[0]);

            for (int i = 0; i < numVertices; i++)
            {
                string[] neighbors = lines[i + 1].Split(' ');
                foreach (var neighbor in neighbors)
                {
                    int neighborId = int.Parse(neighbor);
                    if (!adjacencyList[i].Contains(neighborId)) // Check if the edge is already present
                    {
                        adjacencyList[i].Add(neighborId);
                    }
                }
            }
        }

        public void CalculateAndPrintDegrees()
        {
            Console.WriteLine(" "+adjacencyList.Length); // Print the number of vertices

            for (int i = 0; i < adjacencyList.Length; i++)
            {
                Console.Write($" {adjacencyList[i].Count}");
            }

        }
    }
}
