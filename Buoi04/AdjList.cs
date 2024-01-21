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
       
        public void Output() // Xuất đồ thị
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
        public void RemoveEdgeX(int x)
        {
            // Iterate over each vertex i in the graph
            for (int i = 0; i < v.Length; i++)
            {
                // If i equals x, clear all elements in v[i]
                if (i == x)
                {
                    v[i].Clear();
                }
                else
                {
                    // Otherwise, remove x from v[i]
                    v[i].Remove(x);
                }
            }
        }
        public void RemoveEdgeXY(int x, int y)
        {
            v[x].Remove(y);
            v[y].Remove(x);
        }
        public void GridToAdjList(string filePath)
        {
            // Read the grid from the file
            // The grid is represented as a 2D array of integers
            int[,] grid = File.ReadAllLines(filePath).Select(selector: line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();

            // Get the dimensions of the grid
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);

            // Convert the grid to an adjacency list representation of a graph
            LinkedList<int>[] a = new LinkedList<int>[n * m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int k = i * m + j;
                    a[k] = new LinkedList<int>();
                    if (i > 0 && grid[i - 1, j] == 1) a[k].AddLast(k - m);
                    if (i < n - 1 && grid[i + 1, j] == 1) a[k].AddLast(k + m);
                    if (j > 0 && grid[i, j - 1] == 1) a[k].AddLast(k - 1);
                    if (j < m - 1 && grid[i, j + 1] == 1) a[k].AddLast(k + 1);
                }
            }

            // Find and print the shortest path from cell (x, y) to cell (col, col)
            PathOnGrid(x, y, col, a);
        }

        public void PathOnGrid(int x, int y, int col, LinkedList<int>[] a)
        {
            // Use a breadth-first search to find the shortest path
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[a.Length];
            int[] parent = new int[a.Length];

            queue.Enqueue(x);
            visited[x] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (var v in a[u])
                {
                    if (!visited[v])
                    {
                        queue.Enqueue(v);
                        visited[v] = true;
                        parent[v] = u;
                    }
                }
            }

            // Print the shortest path from cell (x, y) to cell (col, col)
            if (parent[col] != -1)
            {
                Stack<int> path = new Stack<int>();
                for (int v = col; v != -1; v = parent[v])
                {
                    path.Push(v);
                }
                while (path.Count > 0)
                {
                    Console.Write((path.Pop() / col) + ", " + (path.Pop() % col) + " ");
                }
            }
            else
            {
                Console.WriteLine("No path exists");
            }
        }


    }
}
