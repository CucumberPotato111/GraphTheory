namespace Buoi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Bai 1--");
            bai1();
            Console.WriteLine("--Bai 2--");
            bai2();
            Console.WriteLine("--Bai 3--");
            bai3();
            Console.WriteLine("--Bai 4--");
            bai4();
        }
        static void bai1()
        {
            string inputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai1.txt";
            string outputFilePath = "AdjecencyMatrix.OUT";

            string[] lines = File.ReadAllLines(inputFilePath);
            int numVertices = int.Parse(lines[0]);

            Bai1 graph = new Bai1(numVertices);
            graph.ReadAdjacencyMatrix(inputFilePath);

            int[] degrees = graph.CalculateDegrees();
            graph.PrintDegrees(degrees);
        }
        static void bai2()
        {
            string inputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai2.txt";
            string[] firstLine = File.ReadAllLines(inputFilePath)[0].Split(' ');
            int numVertices = int.Parse(firstLine[0]);

            Bai2 graph = new Bai2(numVertices);
            graph.ReadFromFile(inputFilePath);
            Console.WriteLine(numVertices);
            graph.CalculateDegrees();
        }
        static void bai3()
        {
            string inputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai3.txt";
            string outputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai3_OUT.txt";

            string[] lines = File.ReadAllLines(inputFilePath);
            int numVertices = int.Parse(lines[0]);

            Bai3 graph = new Bai3(numVertices);
            graph.ReadGraph(inputFilePath);
            graph.CalculateAndPrintDegrees();
        }
        static void bai4()
        {
            string inputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai4.txt";
            string outputFilePath = "B:\\Homeworks\\Code\\Buoi1\\bai4_OUT.txt";
            string[] lines = File.ReadAllLines(inputFilePath);
            int numVertices = int.Parse(lines[0].Split(' ')[0]);
            int numEdges = int.Parse(lines[0].Split(' ')[1]);

            Bai4 graph = new Bai4(numVertices);
            graph.ReadGraph(inputFilePath);
            graph.CalculateAndPrintDegrees();
        }
    }
}