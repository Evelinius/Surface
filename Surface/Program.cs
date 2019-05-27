using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surface
{
    class Coordinate
    {
        public int X;
        public int Y;
    }

    class Program
    {
        static int cnt = 0;
        static List<string> Detected = new List<string>();
        static List<Coordinate> coors = new List<Coordinate>();
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            string[] map = new string[H];

            for (int i = 0; i < H; i++)
            {
                string row = Console.ReadLine();
                map[i] = row;
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
                IsLake(map,coors[i].X, coors[i].Y);
                Console.WriteLine(Detected.Count);
                Detected.Clear();
            }
        }

        static void IsLake(string[] map, int X, int Y)
        {

            if (map[Y][X] == '#')
            {
                return;
            }
            if (map[Y][X] == 'O' && !Detected.Contains($"{Y} {X}"))
            {
                Detected.Add($"{Y} {X}");
            }
            if(!(map[Y].Length <= X + 1) && map[Y][X+1] == 'O' && !Detected.Contains($"{Y} {X + 1}"))
            {
                IsLake(map, X + 1, Y);
            }
            if (!(X - 1 < 0) && map[Y][X - 1] == 'O' && !Detected.Contains($"{Y} {X - 1}") )
            {
                IsLake(map, X - 1, Y);
            }
            if(!(map.Length <= Y + 1) && map[Y+1][X] == 'O' && !Detected.Contains($"{Y+1} {X}"))
            {
                IsLake(map, X, Y + 1);
            }
            if (!(Y - 1 < 0) && map[Y - 1][X] == 'O' && !Detected.Contains($"{Y - 1} {X}"))
            {
                IsLake(map, X, Y - 1);
            }
        }
    }
}
