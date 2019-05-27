using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surface
{
    struct Surface
    {
        public bool IsLake;
        public bool Processed;
    }
    class Coordinate
    {
        public int X;
        public int Y;
    }

    class Program
    {
        static int cnt = 0;
        static List<Coordinate> coors = new List<Coordinate>();
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            Surface[,] map = new Surface[H, L];

            for (int i = 0; i < H; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < row.Length; j++)
                {
                    map[i, j] = new Surface() { IsLake = row[j] == 'O', Processed = false };
                }
            }
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int X = int.Parse(inputs[0]);
                int Y = int.Parse(inputs[1]);
                coors.Add(new Coordinate() { X = X, Y = Y });
            }

            for (int i = 0; i < N; i++)
            {
                IsLake(map, coors[i].X, coors[i].Y);
                Console.WriteLine(cnt);
                cnt = 0;
                DropProcessed(map);
            }
        }

        static void IsLake(Surface[,] map, int X, int Y)
        {
            if (!map[Y, X].IsLake)
            {
                return;
            }
            if (map[Y, X].IsLake && !map[Y, X].Processed)
            {
                cnt++;
                map[Y, X].Processed = true;
            }
            if (!(map.GetLength(1) <= X + 1) && map[Y, X + 1].IsLake && !map[Y, X + 1].Processed)
            {
                IsLake(map, X + 1, Y);
            }
            if (!(X - 1 < 0) && map[Y, X - 1].IsLake && !map[Y, X - 1].Processed)
            {
                IsLake(map, X - 1, Y);

            }
            if (!(map.GetLength(0) <= Y + 1) && map[Y + 1, X].IsLake && !map[Y + 1, X].Processed)
            {
                IsLake(map, X, Y + 1);
            }
            if (!(Y - 1 < 0) && map[Y - 1, X].IsLake && !map[Y - 1, X].Processed)
            {
                IsLake(map, X, Y - 1);
            }
        }

        static void DropProcessed(Surface[,] surfaces)
        {
            for (int i = 0; i < surfaces.GetLength(0); i++)
            {
                for (int j = 0; j < surfaces.GetLength(1); j++)
                {
                    surfaces[i, j].Processed = false;
                }
            }
        }
    }
}
