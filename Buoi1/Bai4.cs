using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1
{
    internal class Bai4
    {
        private List<int>[] adjacencyList;

        public Bai4(int numVertices)
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
            int numVertices = int.Parse(lines[0].Split(' ')[0]);
            int numEdges = int.Parse(lines[0].Split(' ')[1]);

            for (int i = 0; i < numEdges; i++)
            {
                string[] vertices = lines[i + 1].Split(' ');
                int vertex1 = int.Parse(vertices[0]) - 1;
                int vertex2 = int.Parse(vertices[1]) - 1;
                adjacencyList[vertex1].Add(vertex2 + 1);
                adjacencyList[vertex2].Add(vertex1 + 1);
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
