using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1lab_5nuska
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new object();
            Random r = new Random();
            int n = 10;
            int[] TeamsA = new int[n];
            int[] TeamsB = new int[n];

            for (int i = 0; i < n; i++)
            {
                TeamsA[i] = r.Next(0, 60);
                TeamsB[i] = r.Next(0, 60);
            }
            int tt = 0, count = 0;
            Thread thread = null;
            while (true)
            {
                tt++;
                thread = new Thread(() =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(thread.ManagedThreadId + " - id агыны басталды!");
                    Console.WriteLine("-------------------------------------");
                    Console.ResetColor();
                    int a = r.Next(0, 10), b = r.Next(0, 10);
                    Zharys(TeamsA, TeamsB, a, b, count);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(thread.ManagedThreadId + " - id агыны аякталды!");
                    Console.WriteLine("-------------------------------------");
                    Console.ResetColor();
                });
                //
                thread.Start();
                thread.Join();
                count++;

                if (tt == 60)
                {
                    break;
                }
            }
            Console.ReadKey();
        }
        public static void Zharys(int[] TeamsA, int[] TeamsB, int i, int j, int count)
        {
            if (TeamsA[i] == 0 || TeamsB[j] == 0)
            {
                try
                {
                    Thread.CurrentThread.Abort();
                }
                catch (PlatformNotSupportedException)
                {
                    throw new Exception("Утылган ойыншалар кайта жарыска катыса алмайды!");
                }
            }
            else
            {
                Random r = new Random();
                int col = r.Next(0, 25);
                int col2 = r.Next(0, 25);

                Console.Write($"[Команда - 1] - Игрок {i} - " + TeamsA[i] + "\t\t");

                Console.WriteLine(TeamsB[j] + $" - Игрок {j} - [Команда - 2]");
                if (count % 2 == 0)
                {
                    TeamsA[i] += col;
                    TeamsB[j] -= col;
                }
                else
                {
                    TeamsB[i] += col2;
                    TeamsA[j] -= col2;
                }
                if (TeamsA[i] < 0)
                {
                    TeamsA[i] = 0;
                    Console.Write($"[Команда - 1] - Игрок {i}" + " выходить из игры!\n");
                }
                if (TeamsB[j] < 0)
                {
                    TeamsB[j] = 0;
                    Console.Write($"[Команда - 2] - Игрок {j}" + " выходить из игры!\n");
                }
            }
        }
    }


    //class Sport
    //{
    //	public int id;
    //	public int members;
    //	public static List<Sport> sports = new List<Sport>();
    //	public static List<int[]> end = new List<int[]>();
    //	static Random random = new Random();
    //	public Sport(int id, int members)
    //	{
    //		this.id = id;
    //		this.members = members;
    //	}
    //	public Func<List<Sport>, List<Sport>> Game = (List<Sport> sports) =>
    //	{
    //		int i = 0;
    //		while (i < 3)
    //		{

    //			int rand1 = random.Next(0, sports.Count);
    //			int rand2 = random.Next(0, sports.Count);
    //			if (sports[rand1].members > sports[rand2].members)
    //			{
    //				int adam = random.Next(1, 10);
    //				sports[rand1].members += adam;
    //				sports[rand2].members -= adam;
    //				if (sports[rand2].members <= 0)
    //				{
    //                       //Console.WriteLine(sports[rand2].id + " Game over");
    //                       //Console.WriteLine(sports[rand1].id + " Game win ");
    //                       sports.RemoveAt(rand2);
    //				}
    //				else
    //				{
    //					end.Add(new int[2] { sports[rand1].id, sports[rand2].id });
    //				}
    //			}
    //			i++;
    //		}
    //		return sports;
    //	};
    //}
    //class Program
    //{

    //	static Random random = new Random();
    //	public static void Main(string[] args)
    //	{

    //		int i = 0;
    //		while (i < 10)
    //		{
    //			int n = random.Next(11, 30);
    //			Sport.sports.Add(new Sport(i + 1, n));

    //			Console.WriteLine($"{i + 1} - { n}");
    //			i++;
    //		}
    //		for (int k = 0; k < Sport.sports.Count; k++)
    //		{
    //			Sport.sports = Sport.sports[k].Game(Sport.sports);
    //		}

    //		Console.WriteLine("\nGame: ");
    //		foreach (var item in Sport.end)
    //		{
    //			Console.WriteLine(item[0] + "<====>" + item[1]);
    //		}

    //		Console.WriteLine("\nПосле игра: ");
    //		for (i = 0; i < Sport.sports.Count; i++)	
    //		{

    //			Console.WriteLine($"{  Sport.sports[i].id} - {  Sport.sports[i].members}");
    //		}

    //		Console.ReadLine();
    //	}
    //}
}
//namespace labka1
//{
//    class OiynTop
//    {
//        public int oiynshylar_sany;
//        public int gol;
//        public int top_number;
//        public OiynTop(int sany, int gol) { oiynshylar_sany = sany; this.gol = gol; }

//        //kosu
//        public static void Operation(OiynTop f1, OiynTop f2)
//        {//azaitatyn toptagy adam sany kosatyn toptagy adam sanynan ulken ne ten boluy kerek
//            Random rnd = new Random();
//            int oiynshy = rnd.Next(1, 5);
//            if (f1.oiynshylar_sany > f2.oiynshylar_sany)
//            {
//                f1.oiynshylar_sany = f1.oiynshylar_sany + oiynshy;
//                f2.oiynshylar_sany = f2.oiynshylar_sany - oiynshy;
//            }
//            else
//            {
//                f1.oiynshylar_sany = f1.oiynshylar_sany - oiynshy;
//                f2.oiynshylar_sany = f2.oiynshylar_sany + oiynshy;
//            }
//        }


//    }
//    class Qarsylasu
//    {
//        public List<OiynTop> top;
//        public Qarsylasu(List<OiynTop> top) { this.top = top; }

//        //qarsylastar, randomno

//        public static void Zharys(int[] top1, int[] top2, int i, int j, int count)
//        {

//            Random r = new Random();
//            int col = r.Next(0, 25);
//            int col2 = r.Next(0, 25);

//            Console.Write($"[Команда - 1] - Игрок {i} - " + top1[i] + "\t\t");

//            Console.WriteLine(top2[j] + $" - Игрок {j} - [Команда - 2]");
//            if (count % 2 == 0)
//            {
//                top1[i] += col;
//                top2[j] -= col;
//            }
//            else
//            {
//                top2[i] += col2;
//                top1[j] -= col2;
//            }
//            if (top1[i] < 0)
//            {
//                top1[i] = 0;
//                Console.Write($"[Команда - 1] - Игрок {i}" + " выходить из игры!\n");
//            }
//            if (top2[j] < 0)
//            {
//                top2[j] = 0;
//                Console.Write($"[Команда - 2] - Игрок {j}" + " выходить из игры!\n");
//            }
//        }

//        //public void Qarsylastar(List<OiynTop> t1, List<OiynTop> t2)
//        //{           
//        //    Random rnd = new Random((int)DateTime.Now.Ticks);

//        //        for (int count = 0; count < (top.Count / 2); count++)
//        //        {
//        //            t1[count] =t1[ rnd.Next(1, top.Count)];
//        //        t2[count] = t2[rnd.Next(1, top.Count)];
//        //        Console.WriteLine(count + "  " + t2[count]);
//        //        }
//        // bool half1 = true;
//        //if (half1)
//        //{
//        //    if (f1.gol > f2.gol)//f1 den adam azaitu, f2 kosu
//        //    {
//        //        OiynTop.Operation(f2, f1);
//        //    }
//        //}

//        //jarys adisi, erezhe adisin shakyryp, natuzhesnde kosu azaity adistern shakyru
//        //oiyn ainalymdarymen

//        class Program
//        {
//            static void Main(string[] args)
//            {
//                Random rnd = new Random();

//                int n = 10;
//                int[] top1 = new int[n];
//                int[] top2 = new int[n];

//                for (int i = 0; i < n; i++)
//                {
//                    top1[i] = rnd.Next(0, 60);
//                    top2[i] = rnd.Next(0, 60);
//                }
//                int tt = 0, count = 0;

//                while (true)
//                {
//                    tt++;
//                    int a = rnd.Next(0, 10), b = rnd.Next(0, 10);
//                    Zharys(top1, top2, a, b, count);


//                    count++;

//                    if (tt == 60)
//                    {
//                        break;
//                    }
//                }
//                Console.ReadKey();
//            }
//        }
//    }
//}

