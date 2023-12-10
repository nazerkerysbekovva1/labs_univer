using System;
using System.Threading;

namespace srs3._3
{
    class Program
    {
        static ManualResetEvent ARE = new ManualResetEvent(true);
        static void Main()
        {
            int n = 80;
            new Thread(Meth1).Start(n);
            new Thread(Meth2).Start(n);
            ARE.Reset();
            n *= n;
            Thread.Sleep(1000);
            Console.WriteLine(n);
            ARE.Set(); ARE.Reset();
            Console.WriteLine(n/=10);
        }
        static void Meth1(object n)
        {
            Console.WriteLine((int)n);
            ARE.WaitOne();
            int g = (int)n;
            g += 20;
            Console.WriteLine(g);
        }
        static void Meth2(object n)
        {
            Console.WriteLine((int)n * 2);
            ARE.WaitOne();
            int g = (int)n;
            g *= g;
            Console.WriteLine(g);
        }
    }
}
