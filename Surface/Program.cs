using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Surface
{
    struct Surface
    {
        public bool IsLake;
        public bool Processed;
        public int LakeId;
    }

    class Program
    {
        static int H, L;
        static List<Point> coors = new List<Point>();
        static Dictionary<int, int> Squares = new Dictionary<int, int>();
        static int Algorithm(Surface[,] map, int x, int y, int lakeId)
        {
            Queue<Point> coordinatesToProcess = new Queue<Point>();
            coordinatesToProcess.Enqueue(new Point(x, y));
            int cnt = 0;
            map[x, y].Processed = true;
            map[x, y].LakeId = lakeId;

            while (coordinatesToProcess.Count > 0)
            {
                var coordinate = coordinatesToProcess.Dequeue();
                int xCurrent = coordinate.X;
                int yCurrent = coordinate.Y;
                cnt++;

                if ((L > xCurrent + 1) && map[xCurrent + 1, yCurrent].IsLake && !map[xCurrent + 1, yCurrent].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xCurrent + 1, yCurrent));
                    map[xCurrent + 1, yCurrent].LakeId = lakeId;
                    map[xCurrent + 1, yCurrent].Processed = true;
                }
                if ((xCurrent - 1 >= 0) && map[xCurrent - 1, yCurrent].IsLake && !map[xCurrent - 1, yCurrent].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xCurrent - 1, yCurrent));
                    map[xCurrent - 1, yCurrent].LakeId = lakeId;
                    map[xCurrent - 1, yCurrent].Processed = true;
                }
                if ((H > yCurrent + 1) && map[xCurrent, yCurrent + 1].IsLake && !map[xCurrent, yCurrent + 1].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xCurrent, yCurrent + 1));
                    map[xCurrent, yCurrent + 1].LakeId = lakeId;
                    map[xCurrent, yCurrent + 1].Processed = true;
                }
                if ((yCurrent - 1 >= 0) && map[xCurrent, yCurrent - 1].IsLake && !map[xCurrent, yCurrent - 1].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xCurrent, yCurrent - 1));
                    map[xCurrent, yCurrent - 1].LakeId = lakeId;
                    map[xCurrent, yCurrent - 1].Processed = true;
                }
            }

            return cnt;
        }

        static void Main(string[] args)
        {
            L = int.Parse(Console.ReadLine());
            H = int.Parse(Console.ReadLine());
            var map = new Surface[L, H];

            for (int i = 0; i < H; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < row.Length; j++)
                {
                    map[j, i] = new Surface() { IsLake = row[j] == 'O', Processed = false, LakeId = -1 };
                }
            }

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                coors.Add(new Point(x, y));
            }

            for (int i = 0; i < N; i++)
            {
                int y = coors[i].Y;
                int x = coors[i].X;
                if (map[x, y].Processed)
                {
                    Console.WriteLine(Squares[map[x, y].LakeId]);
                }
                else
                {
                    if (map[x, y].IsLake)
                    {
                        int square = Algorithm(map, x, y, i);
                        Console.WriteLine(square);
                        Squares.Add(i, square);
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                }
            }
        }

    }
}
