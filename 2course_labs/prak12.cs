using System;

namespace prak12
{
    //class Symbol
    //{
    //    public char[] symbol;
    //    public int length;

    //    public Symbol(string str)
    //    {
    //        symbol = str.ToCharArray();
    //        length = symbol.Length;
    //    }

    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Symbol simm = new Symbol("programming");
    //        Console.WriteLine("Длина массива: " + simm.length);
    //        Console.WriteLine("Массив символов:  " + string.Join(" ", simm.symbol));
    //        Console.WriteLine();
    //        Console.Write("Введите string: ");
    //        string str = Console.ReadLine();
    //        Symbol simm2 = new Symbol(str);
    //        Console.WriteLine("Длина массива: " + simm2.length);
    //        Console.WriteLine("Массив символов:  " + string.Join(" ", simm2.symbol));

    //        for (int i = 0; i < simm.symbol.Length; i++)
    //        {
    //            try
    //            {
    //                Random rnd = new Random();
    //                simm.symbol[rnd.Next(simm.symbol.Length)] = simm2.symbol[i];
    //                Console.WriteLine(" " + simm2.symbol[i]);
    //                Console.WriteLine($"Поменяли рандомный символ на {simm2.symbol[i]}: " + string.Join(" ", simm.symbol));
    //            }
    //            catch (IndexOutOfRangeException ex)
    //            {
    //                Console.WriteLine("Сложилась ситуация исключения!");
    //                Console.WriteLine(ex.Message);

    //            }
    //            Console.ReadKey();
    //        }
    //    }
    //}

    class Uravnenie
    {
        public double a;
        public double b;
        public double c;
        public Uravnenie(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        static void Main(string[] args)
        {
            Uravnenie urav = new Uravnenie(0, 3, -9);

            try
            {
                //if (urav.a == 0 || urav.b == 0 || urav.c == 0) throw new Exception("0ge ten bolmauy kerek!");
                //else
                {
                    double D = Math.Sqrt(Math.Pow(urav.b, 2) - 4 * urav.a * urav.c);
                    if (D == 0)
                    {
                        double x = ((-urav.b) / (2 * urav.a));
                        Console.WriteLine("x = " + x);
                    }
                    else if (D > 0)
                    {
                        double x1 = ((-urav.b + D) / (2 * urav.a));
                        double x2 = ((-urav.b - D) / (2 * urav.a));
                        Console.WriteLine("x1 = " + x1 + "\nx2 = " + x2) ;
                    }
                    else Console.WriteLine("tubiri jox!");
                } 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("0ge boluge bolmaidy!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
            
