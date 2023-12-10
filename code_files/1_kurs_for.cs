using System;

namespace _1_kurs_for
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("height:" );
            int height = int.Parse(Console.ReadLine());
            for(int i=0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
