using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;


namespace labka5
{
    class labka5
    {
        static void Main()
        {
            Console.Write("Количество участников: ");
            int uch = int.Parse(Console.ReadLine());
            line();

            double[] speeds = new double[uch];
            Time_def(ref speeds);
            line();

            int h = 10;
            int[,] trassa = Trassa(uch, h);
            line();

            for (int i = 0; i < uch; i++)
            {
                Dannie dannie = new Dannie(i, trassa, uch, h, speeds, DateTime.Now);
                Thread myThread = new Thread(new ParameterizedThreadStart(Time));
                myThread.Start(dannie);
            }
        }
        static double[] Time_def(ref double[] speeds)
        {
            Random rnd = new Random();
            for (int i = 0; i < speeds.Length; i++)
            {
                speeds[i] = 8 + rnd.NextDouble();//между 8-9 с 
                Console.WriteLine($"Скорость участника №{i + 1}: " + speeds[i] + " c.");
            }
            return speeds;
        }

        static int[,] Trassa(int uch, int h)
        {
            Random rnd = new Random();
            int[,] trassa = new int[uch, h];

            for (int i = 0; i < uch; i++)
                Console.Write($"Уч.{i + 1}:\t");
            Console.WriteLine();

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < uch; i++)
                {
                    trassa[i, j] = rnd.Next(0, 4);
                    Console.Write(trassa[i, j] + "\t");
                }
                Console.WriteLine();
            }

            return trassa;
        }

        static ManualResetEvent manual = new ManualResetEvent(true);
        static void Time(object danniee)
        {
            Dannie dannie = (Dannie)danniee;
            Thread.Sleep((int)dannie.speeds[dannie.i] * 1000);
            for (int j = 0; j < dannie.h; j++)
            {
                if (dannie.trassa[dannie.i, j] == 1)
                    Thread.Sleep(400);
                else if (dannie.trassa[dannie.i, j] == 2)
                    Thread.Sleep(700);
                else if (dannie.trassa[dannie.i, j] == 3)
                    Thread.Sleep(900);
            }

            manual.WaitOne();
            manual.Reset();
            Console.WriteLine("Участник №" + (dannie.i + 1) + ": " + (DateTime.Now - dannie.dateTime));

            manual.Set();

        }
        static void line()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***********************************");
            Console.ResetColor();
        }
    }
    class Dannie
    {
        public int i;
        public int[,] trassa;
        public int uch;
        public int h;
        public double[] speeds;
        public DateTime dateTime;
        public Dannie(int i, int[,] trassa, int uch, int h, double[] speeds, DateTime dateTime)
        {
            this.i = i;
            this.trassa = trassa;
            this.uch = uch;
            this.h = h;
            this.speeds = speeds;
            this.dateTime = dateTime;
        }
    }
}

    //class MyThread
    //{
    //    public int Count;
    //    public Thread Thrd;  // ағындық типтегі объект
    //    public MyThread(string name)
    //    {
    //        Count = 0;
    //        Thrd = new Thread(this.Run); // ағынды құру
    //        Thrd.Name = name;
    //        Thrd.Start(); // ағынның атқарылуын бастау
    //    }
    //    ағынға кіру нүктесі
    //    void Run()
    //    {
    //        Console.WriteLine(Thrd.Name + " басталды.");
    //        do
    //        {
    //            ағынды уақытша тоқтату
    //            Thread.Sleep(500);
    //            Console.WriteLine(Thrd.Name + " ағынында, Count = " + Count);
    //            Count++;
    //        }
    //        while (Count < 10);
    //        Console.WriteLine(Thrd.Name + " аяқталды.");
    //    }
    //}
    //class JoinThreads
    //{
    //    static void Main()
    //    {
    //        Console.WriteLine("Негізгі ағын басталды.");
    //        Үш ағын құру
    //       MyThread mt1 = new MyThread("#1 буын");
    //        MyThread mt2 = new MyThread("#2 буын");
    //        MyThread mt3 = new MyThread("#3 буын");
    //        Join() әдісінің көмегімен ағындар аяқталғанша күтуді ұйымдастыру
    //        mt1.Thrd.Join();
    //        Console.WriteLine("#1 буын қосылды.");
    //        mt2.Thrd.Join();
    //        Console.WriteLine("#2 буын қосылды.");
    //        mt3.Thrd.Join();
    //        Console.WriteLine("#3 буын қосылды.");
    //        Console.WriteLine("Негізгі ағын аяқталды.");
    //    }
    //}

//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace lab1_2sem
//{

//    class Zhugirushiler
//    {
//        public int[] n;
//        public string name;
//        public int num;
//        public Thread Thrd;  // ағындық типтегі объект
//        public Zhugirushiler(string c, int b, int a, string d)
//        {
//            name = c;
//            num = b;
//            n = new int[a];
//            Thrd = new Thread(Display2); // ағынды құру
//            Thrd.Name = d;
//            Thrd.Start(); // ағынның атқарылуын бастау

//        }
//        public void Massiv(int b)
//        {
//            Random rand = new Random((int)DateTime.Now.Ticks);
//            for (int i = 0; i < b; i++)
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
//                mare += n[i];
//            }
//            Console.Write(mare);
//        }
//        public void Display()
//        {
//            Thread.Sleep(10);
//            Console.Write(name + "    ");
//            Massiv(10);
//            Console.WriteLine("\n");
//        }
//        void Display2()
//        {
//            Console.WriteLine(Thrd.Name + " zharys bastady.");
//            do
//            {
//                Thread.Sleep(750);
//                Uaqyt();
//                Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
//            } while (num > 11);

//        }

//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Zhugirushiler[] tr =
//                {
//                new Zhugirushiler("Murat", 1, 10, "1 qatsushy"),
//                new Zhugirushiler("Laura", 2, 10, "2 qatsushy"),
//                new Zhugirushiler("Nazym", 3, 10, "3 qatsushy"),
//                new Zhugirushiler("Aibek", 4, 10, "4 qatsushy"),
//                new Zhugirushiler("Ademi", 5, 10, "5 qatsushy"),
//                new Zhugirushiler("Rasul", 6, 10, "6 qatsushy"),
//                new Zhugirushiler("Aknur", 7, 10, "7 qatsushy"),
//                new Zhugirushiler("Islam", 8, 10, "8 qatsushy"),
//                new Zhugirushiler("Aqjol", 9, 10, "9 qatsushy"),
//                new Zhugirushiler("Ernar", 10, 10, "10 qatsushy")
//            };
//            for (int i = 0; i < tr.Length; i++)
//            {
//                tr[i].Display();
//            }
//            for (int i = 0; i < tr.Length; i++)
//            {
//                do
//                {
//                    tr[i].Thrd.Join();
//                    Thread.Sleep(100);
//                } while (true);
//            }
//            Console.WriteLine();

//            Console.ReadKey();
//        }
//    }
//}
