using System;

namespace процедура
{
    class Program
    {
        public static void SortInc3(ref int[] sort, int A, int B, int C)
        {

            if (A <= B && A <= C)
            {
                sort[0] = A;
                if (B <= C)
                {
                    sort[1] = B;
                    sort[2] = C;
                }
                else
                {
                    sort[2] = B;
                    sort[1] = C;
                }
            }
            else if (B <= A && B <= C)
            {
                sort[0] = B;
                if (A <= C)
                {
                    sort[1] = A;
                    sort[2] = C;
                }
                else
                {
                    sort[2] = A;
                    sort[1] = C;
                }
            }
            else
            {
                sort[0] = C;
                if (B <= A)
                {
                    sort[1] = B;
                    sort[2] = A;
                }
                else
                {
                    sort[2] = B;
                    sort[1] = A;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("A1 = ");
            int A1 = int.Parse(Console.ReadLine());
            Console.Write("B1 = ");
            int B1 = int.Parse(Console.ReadLine());
            Console.Write("C1 = ");
            int C1 = int.Parse(Console.ReadLine());
            int[] sort1 = new int[3];
            SortInc3(ref sort1, A1, B1, C1);
            for (int i = 0; i < sort1.Length; i++)
            {
                Console.Write(sort1[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("A2 = ");
            int A2 = int.Parse(Console.ReadLine());
            Console.Write("B2 = ");
            int B2 = int.Parse(Console.ReadLine());
            Console.Write("C2 = ");
            int C2 = int.Parse(Console.ReadLine());
            int[] sort2 = new int[3];
            SortInc3(ref sort2, A2, B2, C2);
            for (int i = 0; i < sort2.Length; i++)
            {
                Console.Write(sort2[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
