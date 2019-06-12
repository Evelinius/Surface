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
                int xcurrent = coordinate.X;
                int ycurrent = coordinate.Y;
                cnt++;

                if ((L > xcurrent + 1) && map[xcurrent + 1, ycurrent].IsLake && !map[xcurrent + 1, ycurrent].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xcurrent + 1, ycurrent));
                    map[xcurrent + 1, ycurrent].LakeId = lakeId;
                    map[xcurrent + 1, ycurrent].Processed = true;
                }
                if ((xcurrent - 1 >= 0) && map[xcurrent - 1, ycurrent].IsLake && !map[xcurrent - 1, ycurrent].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xcurrent - 1, ycurrent));
                    map[xcurrent - 1, ycurrent].LakeId = lakeId;
                    map[xcurrent - 1, ycurrent].Processed = true;
                }
                if ((H > ycurrent + 1) && map[xcurrent, ycurrent + 1].IsLake && !map[xcurrent, ycurrent + 1].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xcurrent, ycurrent + 1));
                    map[xcurrent, ycurrent + 1].LakeId = lakeId;
                    map[xcurrent, ycurrent + 1].Processed = true;
                }
                if ((ycurrent - 1 >= 0) && map[xcurrent, ycurrent - 1].IsLake && !map[xcurrent, ycurrent - 1].Processed)
                {
                    coordinatesToProcess.Enqueue(new Point(xcurrent, ycurrent - 1));
                    map[xcurrent, ycurrent - 1].LakeId = lakeId;
                    map[xcurrent, ycurrent - 1].Processed = true;
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
