using System.Text;

namespace Buoi04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bai4();
        }
    
        static void bai3()
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.UTF8;

            /* Tạo menu */
            Menu menu = new Menu();
            string title = "TÌM KIẾM TRÊN ĐỒ THỊ BẰNG THUẬT TOÁN BFS (Breadth First Search)"; string[] ms = { "1. Bài 1 : Liệt kê các đỉnh liên thông với đỉnh x bằng thuật toán BFS",
                "2. Bài 2 : Tìm đường đi từ đỉnh x -> y",
                "3. Bài 3 : Xét tính liên thông. Số TPLT, xuất các TPLT",
                "0. Thoát" };
            int chon;
            do
            {
                Console.Clear();
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {   // Bài 1 : duyệt đồ thị từ đỉnh x theo BFS
                            // Tạo đường dẫn file filePath = "../../../TextFile/AdjList1.txt";
                            // Khởi tạo đồ thị g : AdjList g = new AdjList();
                            // Đọc file ra đồ thị g; Xuất đồ thị lên màn hình

                            string filePath = "..//..//..//TextFile//AdjList1.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            Console.Write("  Nhập đỉnh xuất phát x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Các đỉnh liên thông với {0} : ", x);
                            // Gọi phương thức BFS(x);
                            g.BFS(x);
                            break;
                        }
                    case 2:
                        {
                            // Bài 2 : Tìm đường đi từ đỉnh x -> y
                            // Tạo đường dẫn file filePath = "../../../TextFile/AdjList2.txt";
                            // Khởi tạo đồ thị g : AdjList g = new AdjList();
                            // Đọc file ra đồ thị g; Xuất đồ thị lên màn hình
                            string filePath = "..//..//..//TextFile//AdjList2.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            Console.Write("  Nhập đỉnh xuất phát x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("        Nhập đỉnh đến y : ");
                            int y = int.Parse(Console.ReadLine());
                            // Gọi phương thức BFS_XtoY(x, y);
                            g.BFS_XtoY(x, y);
                            break;
                        }
                    case 3:
                        {
                            string filePath = "..//..//..//TextFile//AdjList2.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            if (g.Inconnect == 1)
                                Console.WriteLine("  Đồ thị liên thông");
                            else
                            {
                                Console.WriteLine("  Đồ thị có {0} thành phần liên thông", g.Inconnect);
                                g.OutConnected();
                            }
                            break;
                        }

                }
                Console.WriteLine(" Nhấn một phím bất kỳ");
                Console.ReadKey();
                Console.Clear();
            } while (chon != 0);
        }
        static void bai4()
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.UTF8;
            Menu menu = new Menu();
            string title = "Ứng dụng thuật toán Breadth First Search – BFS"; string[] ms = { "1. Bài 1 : Đỉnh khớp",
                "2. Bài 2 : Cạnh cầu",
                "3. Bài 3 : Bài toán đi trên lưới",
                "0. Thoát" };
            int chon;
            do
            {
                Console.Clear();
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            string filePath = "..//..//..//TextFile//CutBridge.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            int gInconnect1 = g.Inconnect;
                            Console.Write("  Nhập đỉnh cần xét x : ");
                            int x = int.Parse(Console.ReadLine());
                            g.RemoveEdgeX(x);
                            g.Connected();
                            int gInconnect2 = g.Inconnect;
                            if (gInconnect2 > gInconnect1 + 1)
                            {
                                Console.WriteLine($"Đỉnh {x} là đỉnh khớp.");
                            }
                            else
                            {
                                Console.WriteLine($"Đỉnh {x} không phải là đỉnh khớp.");
                            }
                            break;
                        }
                    case 2:
                        {
                            string filePath = "..//..//..//TextFile//CutBridge.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            int gInconnect1 = g.Inconnect;
                            Console.Write("  Nhập đỉnh x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Nhập đỉnh y : ");
                            int y = int.Parse(Console.ReadLine());
                            g.RemoveEdgeXY(x, y);
                            g.Connected();
                            int gInconnect2 = g.Inconnect;
                            if (gInconnect2 > gInconnect1)
                                Console.WriteLine("Cạnh ({0},{1}) là cạnh cầu", x, y);
                            else
                                Console.WriteLine("Cạnh ({0},{1}) không phải là cạnh cầu", x, y);
                            break;
                        }
                    case 3:
                        {
                            string filePath = "..//..//..//TextFile//AdjList2.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            if (g.Inconnect == 1)
                                Console.WriteLine("  Đồ thị liên thông");
                            else
                            {
                                Console.WriteLine("  Đồ thị có {0} thành phần liên thông", g.Inconnect);
                                g.OutConnected();
                            }
                            break;
                        }

                }
                Console.WriteLine(" Nhấn một phím bất kỳ");
                Console.ReadKey();
                Console.Clear();
            } while (chon != 0);
        }
    }
}