using System;

namespace prak13
{
    class TooLong : Exception
    {
        public int Int { get; }
        public TooLong() : base() { }
        public TooLong(string str, int nt) : base(str) { Int = nt; }
    }
    class OutOfString : Exception
    {
        public char Char { get; }
        public OutOfString() : base() { }
        public OutOfString(string str, char ch) : base(str) { Char = ch; }
    }
    class Symbol
    {
        public char[] symbol;
        public int length;

        public Symbol(string str)
        {
            symbol = str.ToCharArray();
            length = symbol.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Symbol simm = new Symbol("programming");
            Console.WriteLine("Длина массива: " + simm.length);
            Console.WriteLine("Массив символов:  " + string.Join(" ", simm.symbol));
            Console.WriteLine();
            Console.Write("Введите string: ");
            string str = Console.ReadLine();
            Symbol simm2 = new Symbol(str);
            Console.WriteLine("Длина массива: " + simm2.length);
            Console.WriteLine("Массив символов:  " + string.Join(" ", simm2.symbol));

            for (int i = 0; i < simm.symbol.Length; i++)
            {
                try
                {
                    if (simm.length > simm2.symbol.Length)
                        throw new TooLong("берылген тыркес жиымнан yзын! ", simm.symbol.Length);
                    else
                    {
                        if (simm.symbol[i] == simm2.symbol[i]) throw new OutOfString("кате индекс корсетылген! ", simm2.symbol[i]);
                        else
                        {
                            Random rnd = new Random();
                            simm.symbol[rnd.Next(simm.symbol.Length)] = simm2.symbol[i];
                            Console.WriteLine(" " + simm2.symbol[i]);
                            Console.WriteLine($"Поменяли рандомный символ на {simm2.symbol[i]}: " + string.Join(" ", simm.symbol));
                        }
                    }
                }
                catch (TooLong ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Сложилась ситуация исключения!"+ex.Message);
                    Console.WriteLine("длинная строка: " + ex.Int);
                }
                catch (OutOfString ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Сложилась ситуация исключения!" + ex.Message);
                    Console.WriteLine("Некорректный индекс: " + ex.Char);
                }
                Console.ReadKey();
            }
        }
    }
}
