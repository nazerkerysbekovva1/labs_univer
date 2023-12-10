using System;
using System.Threading;
namespace nusqa_1
{
    class Matrica
    {
        public int[,] matrica;
        public int[] vektor;
        public Matrica mt;
        public Thread th;
        public Matrica(int[,] a, int[] b)
        {
            th = new Thread(this.Display2);
            th.Start(mt);
            matrica = a;
            vektor = b;
        }
        public int[,] Kobeitu()
        {
            int[,] natizhe = matrica;
            for (int i = 0; i < vektor.Length; i++)
                for (int j = 0; j < (matrica.Length / vektor.Length); j++)
                    natizhe[i, j] *= vektor[i];
            return natizhe;
        }
        public void Display()
        {
            Console.WriteLine("Matrica:");
            for (int i = 0; i < vektor.Length; i++)
            {
                for (int j = 0; j < (matrica.Length / vektor.Length); j++)
                {
                    Console.Write($"{matrica[i, j]}\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Vektor:");
            for (int i = 0; i < vektor.Length; i++)
                Console.Write($"{vektor[i]}\t");
        }

        public void Display2(object obj)
        {
            if (obj is Matrica mt)
            {
                int[,] m = mt.Kobeitu();
                Console.WriteLine("\nNatizhe: ");

                for (int i = 0; i < mt.vektor.Length; i++)
                {
                    Console.WriteLine("\nagyn bastaldy!");
                    Thread.Sleep(500);
                    for (int j = 0; j < (mt.matrica.Length / mt.vektor.Length); j++)
                    {
                        Console.Write($"{m[i, j]}\t");
                    }
                    Console.WriteLine("agyn aiaktaldy!");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrica mt = new Matrica(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, new int[3] { 1, 2, 3 });
            mt.Display();
            mt.Display2(mt);
        }
    }
}