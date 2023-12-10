//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Collections.Concurrent;
//namespace lab13
//{
//    class Zhugirushiler
//    {
//        public int[] n = new int[10];
//        //public string name;
//        public int num;
//        public static ConcurrentStack<int> stack;
//        public Zhugirushiler(int b)
//        {
//            num = b;
//        }
//        public void Massiv()
//        {
//            Random rand = new Random((int)DateTime.Now.Ticks);
//            for (int i = 0; i < n.Length; i++)
//            {
//                n[i] = rand.Next(1, 4);
//                Console.Write(n[i] + "\t");
//            }
//        }
//        public void Uaqyt()
//        {
//            int mare = 0;
//            for (int i = 0; i < n.Length; i++)
//            {
//                Thread.Sleep(n[i]);
//                mare += n[i];
//            }
//            if (stack.TryPeek(out mare))
//            {
//                Console.WriteLine("Peek: ", mare);
//                Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
//            }
//            if (stack.TryPop(out mare))
//            {
//                Console.WriteLine("Pop: ", mare);
//                Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
//            }
//        }
//        public void Display()
//        {
//            //Console.Write(name + "    ");
//            Console.Write(num + ":qatusushi    ");
//            Massiv();
//            Console.WriteLine("\n");
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Zhugirushiler.stack = new ConcurrentStack<int>() { };
//            for (int i = 0; i < 10; i++)
//            {
//                Zhugirushiler.stack.Push(i);
//            }
//            ConcurrentQueue<int> topJarys = new ConcurrentQueue<int>() { };
//            Zhugirushiler[] zh =
//                { new Zhugirushiler(1),
//                new Zhugirushiler(2),
//                new Zhugirushiler(3),
//                new Zhugirushiler(4),
//                new Zhugirushiler(5),
//                new Zhugirushiler(6),
//                new Zhugirushiler(7),
//                new Zhugirushiler(8),
//                new Zhugirushiler(9),
//                new Zhugirushiler(10),
//            };
//            for (int i = 0; i < 10; i++)
//            {
//                zh[i].Display();
//            }
//            for (int i = 0; i < 10; i++)
//            {
//                zh[i].Uaqyt();
//            }

//            Console.WriteLine();
//        }
//    }
//}


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
        public static ConcurrentQueue<int> bc = new ConcurrentQueue<int>();
        public int[] n = new int[10];
        public int num;
        public Zhugirushiler(int b)
        {
            num = b;
        }
        public void Massiv(ConcurrentQueue<int> t)
        {
            Random rnd = new Random();
            int r;
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = rnd.Next(0, 2);
                if (n[i] == 1)
                {
                    if (t.TryDequeue(out r))
                    {
                        n[i] = r;
                    }
                }
                Console.Write(n[i] + "\t");
            }
        }
        public void Uaqyt()
        {
            int mare = 0;
            for (int i = 0; i < n.Length; i++)
            {
                Thread.Sleep(n[i]);
                mare += n[i];
            }
            bc.Enqueue(mare);
            Console.WriteLine(mare);
           Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
        }
        public void Display(ConcurrentQueue<int> t)
        {
            Console.Write(num + ":qatusushi    ");
            Massiv(t);
            Console.WriteLine("\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zhugirushiler[] tr =
                {
                new Zhugirushiler(1),
                new Zhugirushiler(2),
                new Zhugirushiler(3),
                new Zhugirushiler(4),
                new Zhugirushiler(5),
                new Zhugirushiler(6),
                new Zhugirushiler(7),
                new Zhugirushiler(8),
                new Zhugirushiler(9),
                new Zhugirushiler(10)
            };
            var qu = new ConcurrentQueue<int>();
            qu.Enqueue(2);
            qu.Enqueue(3);
            qu.Enqueue(1);
            qu.Enqueue(2);
            qu.Enqueue(1);
            qu.Enqueue(4);
            qu.Enqueue(1);
            qu.Enqueue(2);
            qu.Enqueue(1);
            qu.Enqueue(4);

            for (int i = 0; i < tr.Length; i++)
            {
                tr[i].Display(qu);
            }

            Console.WriteLine("\nНегізгі ағын іске қосылды.");
            for (int i = 0; i < tr.Length; i++)
            {
                tr[i].Uaqyt();
            }
            Console.WriteLine("\nНегізгі ағын аяқталды.\n");

            Console.WriteLine();
        }
    }
}