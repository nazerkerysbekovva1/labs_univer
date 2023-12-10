using System;

namespace esep3
{
    class Telephon
    {
        public long number;
        public int minute;
        public int discount;
        public int talktime;
        public Telephon(long a, int b, int c, int d)
        {

            number = a;
            minute = b;
            discount = c;
            talktime = d;
        }
        public void getData()
        {
            Console.WriteLine("number= {0}", number);
            Console.WriteLine("minute= {0}", minute);
            Console.WriteLine("discount= {0}", discount);
            Console.WriteLine("talktime= {0}", talktime);
        }
    }
    static class Tolem1
    {
        public static int tolem(this Telephon Tolem)
        {
            int b = 0; int c = 0; int d = 0; int T = 0;
            T = (b * c * d / 100);
            return T;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Telephon obj = new Telephon(87473257483, 25, 10, 55);
            obj.getData();
            Console.WriteLine("__");
            Console.WriteLine("tolem={0}");
            Console.Write(Tolem1.tolem(obj));
            Console.ReadKey();
        }
    }
}
