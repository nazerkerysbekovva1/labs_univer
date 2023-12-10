using System;
namespace Ernazar
{
    class Qasqyr
    {
        private int x;
        private int y;
        private static bool IsValid(int x, int y) => (0 <= x && x < 10 && 0 <= y && y < 10);
        public Qasqyr(int a, int b, int[,] taqta)
        {
            if (!IsValid(a, b))
                throw new Exception("x zhane y 0 den kishi blou kerek");
            x = a;
            y = b;
            taqta[x, y] = -1;
        }
    }
    class Qoi
    {
        private int x;
        private int y;
        private static bool IsValid(int x, int y) => (0 <= x && x < 10 && 0 <= y && y < 10);
        public Qoi(int a, int b, int[,] taqta)
        {
            if (!IsValid(a, b))
                throw new Exception("x zhane y 0 den kishi blou kerek");
            x = a;
            y = b;
            taqta[x, y] += 1;
        }
    }
    class Program
    {
        static int[,] oin(int[,] taqta)
        {
            int[,] taqta2 = new int[10, 10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (taqta[i, j] >= 1)
                    {
                        while (taqta[i, j] >= 1)
                        {
                            int x = i;
                            int y = j;
                            taqta[x, y]--;
                            x = rnd.Next(0, 10);
                            y = rnd.Next(0, 10);
                            if (taqta[x, y] == -1)
                                taqta2[x, y] += 0;
                            else if (taqta[x, y] >= 1)
                            {
                                taqta2[x, y] += 1;
                                new Qoi(x, y, taqta2);
                            }
                            else taqta2[x, y] += 1;
                        }
                    }
                    if (taqta[i, j] == -1)
                    {
                        int x = i;
                        int y = j;
                        taqta[x, y]++;
                        x = rnd.Next(0, 10);
                        y = rnd.Next(0, 10);
                        taqta2[x, y] = -1;
                    }

                }
            }
            return taqta2;
        }
        static void Display(int[,] taqta)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Console.Write($"{taqta[i, j]}    ");
                Console.WriteLine("\n");
            }
        }
        static void Main(string[] args)
        {
            int[,] taqta = new int[10, 10];
            Qoi[] otar = { new Qoi(0, 0, taqta), new Qoi(0, 1, taqta), new Qoi(1, 0, taqta), new Qoi(1, 1, taqta), new Qoi(1, 2, taqta), };
            Qasqyr bori = new Qasqyr(9, 9, taqta);
            int t = 0;
            while (t == 0)
            {
                Display(taqta);
                taqta = oin(taqta);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}