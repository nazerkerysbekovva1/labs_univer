using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace lab13
{
    class Zhugirushiler
    {
        public int[] n = new int[10] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 };
        public int num;
        public Zhugirushiler(int b)
        {
            num = b;
        }
        public void Massiv(ConcurrentQueue<int> qu)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(n[i] + "\t");
            }
            int r;
            if (qu.TryPeek(out r))
                Console.WriteLine("Peek: {0}", r);
            Console.WriteLine();
        }
        public void Uaqyt(ConcurrentStack<int> st)
        {
            int mare = 0;
            for (int i = 0; i < n.Length; i++)
            {
                Thread.Sleep(n[i]);
                mare += n[i];
            }
            Thread.Sleep(1000);
            st.Push(mare);
            //Console.WriteLine(mare + " - ондирилди\n");
        }
        public void Display(ConcurrentQueue<int> qu)
        {
            Console.Write(num + "qat    ");
            Massiv(qu);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zhugirushiler[] zh =
                { new Zhugirushiler(1),
                new Zhugirushiler(2),
                new Zhugirushiler(3),
                new Zhugirushiler(4),
                new Zhugirushiler(5),
                new Zhugirushiler(6),
                new Zhugirushiler(7),
                new Zhugirushiler(8),
                new Zhugirushiler(9),
                new Zhugirushiler(10),
            };
            var qu = new ConcurrentQueue<int>();
            qu.Enqueue(2);
            qu.Enqueue(3);
            qu.Enqueue(1);
            qu.Enqueue(2);
            qu.Enqueue(1);
            qu.Enqueue(4);

            int r;
            if (qu.TryDequeue(out r))
                Console.WriteLine(r);

            Task r1 = Task.Run(() => zh[0].Display(qu));
            foreach (var q in qu)
            {
                Console.WriteLine(q);
            }



            //var st = new ConcurrentStack<int>();
            //Task t1 = Task.Run(() =>zh[0].Uaqyt(st));
            //Task t2 = Task.Run(() => zh[1].Uaqyt(st));
            //Task t3 = Task.Run(() => zh[2].Uaqyt(st));
            //Task t4 = Task.Run(() => zh[3].Uaqyt(st));
            //Task t5 = Task.Run(() => zh[4].Uaqyt(st));
            //Task t6 = Task.Run(() => zh[5].Uaqyt(st));
            //Task t7 = Task.Run(() => zh[6].Uaqyt(st));
            //Task t8 = Task.Run(() => zh[7].Uaqyt(st));
            //Task t9 = Task.Run(() => zh[8].Uaqyt(st));
            //Task t10 = Task.Run(() => zh[9].Uaqyt(st));

            //Task.WaitAll(t1, t2, t3, t3, t4, t5, t6, t7, t8, t9, t10);
            //Console.WriteLine("LIFO - ");
            //foreach (var q in st)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(q + " - тутынылды");
            //}

            Console.WriteLine();
        }
    }
}