using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace labka_13
{
    class OiynTop
    {
        public static List<int> top;

        public static void Jarys(int rand1, int rand2)
        {
            Console.WriteLine($"{rand1} <=> {rand2}  oiyndy bastady!");

            if (rand1 > rand2)
            {
                Console.WriteLine($"{rand1} <=======> {rand2} oiyndy aiaktady!");
                top.Remove(rand2);
            }
            else
            {
                int buf = rand2;
                rand2 = rand1;
                rand1 = buf;

                Console.WriteLine($"{rand1} <=======> {rand2} oiyndy aiaktady!");
                top.Remove(rand2);
            }
        }
    }
    class Qarsylasu
    {
        static Random rnd = new Random();

        public void Garsylastar(ConcurrentQueue<int> topJarys)
        {
            Console.WriteLine();
            Console.WriteLine(topJarys.Count + " <>  "+ OiynTop.top.Count);
            while (topJarys.Count < OiynTop.top.Count)
            {
                for (int k = 1; k <= OiynTop.top.Count; k++)
                {
                    int rand = rnd.Next(1, OiynTop.top.Count + 1);
                    if (!topJarys.Contains(rand))
                    {
                        topJarys.Enqueue(rand);
                        foreach (var t in topJarys)
                            Console.WriteLine(t);
                        Console.WriteLine($" Randomno anyktaldy  -  id: {rand}");
                    }
                }
            }
            Console.WriteLine();
        }
        public void ToptarJarysy(ConcurrentQueue<int> topJarys)
        {
            Console.WriteLine("Jarys bastaldy\n");
            int a;
            int a2;
            int a3=0;
            //      for (int i = 0; i <= topJarys.Count+1; i++)
            // Parallel.For(0, topJarys.Count + 1, i =>
            while (true)
            {
                while (topJarys.Count<2)
                {
                    a3++;
                }
                if (topJarys.TryDequeue(out a) && topJarys.TryDequeue(out a2))
                {
                    OiynTop.Jarys(a, a2);
                }
                foreach (var y in topJarys)
                    Console.WriteLine(y);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OiynTop.top = new List<int>() { };
            for (int i = 1; i <= 8; i++)
            {
                OiynTop.top.Add(i);
            }
            ConcurrentQueue<int> topJarys = new ConcurrentQueue<int>() { };

            //Console.Write("Jaristar ainalymdar sani = ");
            //int n = int.Parse(Console.ReadLine());
            int n = 4;

            int counter = 0;

            Console.WriteLine("\nBastapqi tizim: ");
            for (int i = 1; i <= OiynTop.top.Count; i++)
                Console.WriteLine($" id: {i} ");

            while (counter < n)
            {
                Console.WriteLine("-------------------");

                if (topJarys.Count == 1) break;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nНегізгі ағын іске қосылды.");
                Console.ResetColor();

                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

                Qarsylasu qq = new Qarsylasu();
                //Task tsk = Task.Run(() => qq.Garsylastar(topJarys));
                //tsk.Wait();
                //Task tsk2 = Task.Run(() => qq.ToptarJarysy(topJarys));


                qq.Garsylastar(topJarys);
                qq.ToptarJarysy(topJarys);

                Thread.Sleep(700);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nНегізгі ағын аяқталды.\n");
                Console.ResetColor();

                counter++;
                topJarys.Clear();
            }
            Console.WriteLine("-------------------");
        }
    }
}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace labka_11
//{
//    class OiynTop
//    {
//        public int oiynshylar_sany;
//        public int top_number;
//        public static List<OiynTop> top;

//        public OiynTop(int sany, int num)
//        {
//            oiynshylar_sany = sany;
//            top_number = num;
//        }

//        public void Jarys(List<OiynTop> t, int rand1, int rand2)
//        {
//            Console.WriteLine($"{t[rand1].top_number} <=> {t[rand2].top_number}  oiyndy bastady!");

//            Random rnd = new Random();
//            if (t[rand1].top_number > t[rand2].top_number)
//            {
//                int oiynshy = rnd.Next(5, 7);
//                t[rand2].oiynshylar_sany += oiynshy;
//                t[rand1].oiynshylar_sany -= oiynshy;

//                if (t[rand1].oiynshylar_sany <= 0)
//                {
//                    top.Remove(t[rand1]);
//                }
//                if (t[rand2].oiynshylar_sany <= 0)
//                {
//                    top.Remove(t[rand2]);
//                }
//                Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} oiyndy aiaktady!");
//            }
//            else
//            {
//                int oiynshy = rnd.Next(5, 7);

//                int buf = rand2;
//                rand2 = rand1;
//                rand1 = buf;

//                t[rand2].oiynshylar_sany += oiynshy;
//                t[rand1].oiynshylar_sany -= oiynshy;

//                if (t[rand1].oiynshylar_sany <= 0)
//                {
//                    top.Remove(t[rand1]);
//                }
//                if (t[rand2].oiynshylar_sany <= 0)
//                {
//                    top.Remove(t[rand2]);
//                }
//                Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} oiyndy aiaktady!");
//            }
//            Console.WriteLine($" thread = {Thread.CurrentThread.ManagedThreadId}   -----    {t[rand1].top_number}, {t[rand2].top_number}");
//        }
//    }
//    class Qarsylasu
//    {
//        public Qarsylasu() { }

//        static Random rnd = new Random();

//        public void Garsylastar(List<OiynTop> topJarys)
//        {
//            Console.WriteLine();
//            while (topJarys.Count < OiynTop.top.Count)
//            {
//                for (int k = 0; k < OiynTop.top.Count; k++)
//                {
//                    int rand = rnd.Next(0, OiynTop.top.Count);
//                    if (!topJarys.Contains(OiynTop.top[rand]))
//                    {
//                        topJarys.Add(OiynTop.top[rand]);
//                        Console.WriteLine($" Randomno anyktaldy  -  id: { OiynTop.top[rand].top_number}");
//                    }
//                }
//            }
//            Console.WriteLine();
//        }
//        public void ToptarJarysy(List<OiynTop> topJarys)
//        {
//            for (int i = 0; i < topJarys.Count; i++)
//            {
//                if (i % 2 != 0)
//                {
//                    topJarys[i].Jarys(topJarys, (i - 1), i);
//                }
//            }
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            OiynTop.top = new List<OiynTop>()
//            {
//                new OiynTop(11, 1),
//                new OiynTop(11, 2),
//                new OiynTop(11, 3),
//                new OiynTop(11, 4),
//                new OiynTop(11, 5),
//                new OiynTop(11, 6),
//                new OiynTop(11, 7),
//                new OiynTop(11, 8),
//            };
//            List<OiynTop> topJarys = new List<OiynTop>() { };

//            //Console.Write("Jaristar ainalymdar sani = ");
//            //int n = int.Parse(Console.ReadLine());
//            int n = 4;

//            int counter = 0;

//            Console.WriteLine("\nBastapqi tizim: ");
//            for (int i = 0; i < OiynTop.top.Count; i++)
//                Console.WriteLine($" id: {OiynTop.top[i].top_number} - {OiynTop.top[i].oiynshylar_sany}");

//            while (counter < n)
//            {
//                Console.WriteLine("-------------------");

//                if (topJarys.Count == 1) break;

//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("\nНегізгі ағын іске қосылды.");
//                Console.ResetColor();

//                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

//                Qarsylasu qq = new Qarsylasu();
//                qq.Garsylastar(topJarys);
//                qq.ToptarJarysy(topJarys);

//                Thread.Sleep(700);
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("\nНегізгі ағын аяқталды.\n");
//                Console.ResetColor();

//                counter++;
//                topJarys.Clear();
//            }
//            Console.WriteLine("-------------------");
//        }
//    }
//}

