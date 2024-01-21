using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi04
{
    internal class AdjList
    {
        LinkedList<int>[] v;
        int n;  // Số đỉnh
        bool[] visited;
        int[] index;
        int inconnect;
        //Propeties
        public int N { get => n; set => n = value; }
        public int Inconnect { get => inconnect; set => inconnect = value; }
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
        // Contructor
        public AdjList() { }
        public AdjList(int k)   // Khởi tạo v có k đỉnh
        {
            v = new LinkedList<int>[k];
        }
        // copy g --> đồ thị hiện tại v
        public AdjList(LinkedList<int>[] g)
        {
            v = g;
        }
        // Đọc file AdjList.txt --> danh sách kề v
        public void FileToAdjList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                string st = sr.ReadLine();
                // Đặt điều kiện không phải đỉnh cô lập
                if (st != "")
                {
                    string[] s = st.Split();
                    for (int j = 0; j < s.Length; j++)
                    {
                        int x = int.Parse(s[j]);
                        v[i].AddLast(x);
                    }
                }
            }
            sr.Close();
        }
        // Xuất đồ thị
        public void Output()
        {
            Console.WriteLine("Đồ thị danh sách kề - số đỉnh : " + n);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("   Đỉnh {0} ->", i);
                foreach (int x in v[i])
                    Console.Write("{0, 3}", x);
                Console.WriteLine();
            }
        }
        public void BFS(int s)
        {
            // Initialize visited[] array
            visited = new bool[v.Length];

            // Declare Queue
            Queue<int> q = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            q.Enqueue(s);

            // Loop through the queue until it's empty
            while (q.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                int vertex = q.Dequeue();
                Console.Write(vertex + " ");

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it visited and enqueue it
                foreach (int u in v[vertex])
                {
                    if (!visited[u])
                    {
                        visited[u] = true;
                        q.Enqueue(u);
                    }
                }
            }
        }
        public void Connected()
        {
            // Initialize inconnect to 0
            inconnect = 0;

            // Initialize index[]
            index = new int[v.Length];
            for (int i = 0; i < index.Length; i++)
                index[i] = -1;

            // Initialize visited[]
            visited = new bool[v.Length];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            // Loop through each vertex i
            for (int i = 0; i < visited.Length; i++)
            {
                // If vertex i has not been visited
                if (!visited[i])
                {
                    // Start a new connected component
                    inconnect++;

                    // Find and mark vertices in the same connected component
                    BFS_Connected(i);
                }
            }

            Console.WriteLine();
        }

        public void BFS_Connected(int s)
        {
            // Initialize a queue for the algorithm
            Queue<int> q = new Queue<int>();

            // Visit vertex s (set visited[s] = true)
            // Add s to the queue
            visited[s] = true;
            q.Enqueue(s);

            // While the queue is not empty
            while (q.Count != 0)
            {
                // Dequeue a vertex from the queue and assign it to s
                int vertex = q.Dequeue();

                // Assign the connected component to s
                index[vertex] = inconnect;

                // For each vertex u adjacent to s
                foreach (int u in v[vertex])
                {
                    // If u has not been visited
                    if (!visited[u])
                    {
                        // Visit u (set visited[u] = true)
                        visited[u] = true;

                        // Enqueue u
                        q.Enqueue(u);
                    }
                }
            }
        }
        public void OutConnected()
        {
            for (int i = 1; i <= inconnect; i++)
            {
                Console.Write("  TPLT {0} : ", i);
                for (int j = 0; j < index.Length; j++)
                    if (index[j] == i)
                        Console.Write(j + " ");
                Console.WriteLine();
            }
        }



        public void BFS_XtoY(int x, int y)
        {
            // Initialize pre[] and set initial value: pre[i] = -1 for i = 0..<n
            int[] pre = new int[v.Length];
            for (int i = 0; i < v.Length; i++)
                pre[i] = -1;

            // Initialize visited[] and set value: visited[i] = false for i = 0..<n
            bool[] visited = new bool[v.Length];
            for (int i = 0; i < v.Length; i++)
                visited[i] = false;

            // Declare Queue
            Queue<int> q = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[x] = true;
            q.Enqueue(x);

            // Loop through the queue until it's empty
            while (q.Count != 0)
            {
                // Dequeue a vertex from queue
                int s = q.Dequeue();

                // Get all adjacent vertices of the dequeued vertex s
                // If an adjacent has not been visited, then mark it visited and enqueue it
                // Also, set the parent of u to be s
                foreach (int u in v[s])
                {
                    if (!visited[u])
                    {
                        visited[u] = true;
                        q.Enqueue(u);
                        pre[u] = s;
                    }
                }
            }

            // Print the path from x to y
            Console.Write("Path from " + x + " -> " + y + " : " + x);
            if (pre[y] != -1)
            {
                // Use a Stack to trace the path from y to x using the parent pointers
                Stack<int> stk = new Stack<int>();
                int k = y;
                while (pre[k] != -1)
                {
                    stk.Push(k);
                    k = pre[k];
                }

                while (stk.Count > 0)
                {
                    k = stk.Pop();
                    Console.Write(" -> " + k);
                }
            }
        }
        public void RemoveEdgeX(int x)
        {

        }

    }
}
