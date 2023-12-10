using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace labka_4
{
    class OiynTop
    {
        public int oiynshylar_sany;
        public int top_number;
        public static List<OiynTop> top;
        public Thread thread;
        public static Mutex Mtx = new Mutex();
        public OiynTop(int sany, int num)
        {
            oiynshylar_sany = sany;
            top_number = num;
            // thread.Name = name;
        }
        public void Jarys(List<OiynTop> t, int rand1, int rand2)
        {
            thread = new Thread(() =>
            {
                Console.WriteLine($"\n{t[rand1].top_number} <=> {t[rand2].top_number}  мьютекст кутуде!"); // Получить мьютекс.
                Mtx.WaitOne();
                Console.WriteLine($"\n{t[rand1].top_number} <=> {t[rand2].top_number}  мьютекст кабылдады!");
                Random rnd = new Random();
                if (t[rand1].top_number > t[rand2].top_number)
                {
                    int oiynshy = rnd.Next(5, 7);
                    t[rand2].oiynshylar_sany += oiynshy;
                    t[rand1].oiynshylar_sany -= oiynshy;

                    if (t[rand1].oiynshylar_sany <= 0)
                    {
                        top.Remove(t[rand1]);
                    }
                    if (t[rand2].oiynshylar_sany <= 0)
                    {
                        top.Remove(t[rand2]);
                    }
                    Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} мьютекст босатты!");
                    Mtx.ReleaseMutex();// Мьютексті босату.
                }
                else
                {
                    int oiynshy = rnd.Next(5, 7);

                    int buf = rand2;
                    rand2 = rand1;
                    rand1 = buf;

                    t[rand2].oiynshylar_sany += oiynshy;
                    t[rand1].oiynshylar_sany -= oiynshy;

                    if (t[rand1].oiynshylar_sany <= 0)
                    {
                        top.Remove(t[rand1]);
                    }
                    if (t[rand2].oiynshylar_sany <= 0)
                    {
                        top.Remove(t[rand2]);
                    }
                    Thread.Sleep(500);
                    Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} мьютекст босатты!");
                    Mtx.ReleaseMutex();// Мьютексті босату.
                }
            });
            thread.Start();
        }
    }
    class Qarsylasu
    {
        public Qarsylasu() { }

        Random rnd = new Random();

        public void Garsylastar(ref List<OiynTop> topJarys)
        {
            while (topJarys.Count < OiynTop.top.Count)
            {
                for (int k = 0; k < OiynTop.top.Count; k++)
                {
                    int rand = rnd.Next(0, OiynTop.top.Count);
                    if (!topJarys.Contains(OiynTop.top[rand]))
                    {
                        topJarys.Add(OiynTop.top[rand]);
                    }
                }
            }
        }
        public void ToptarJarysy(List<OiynTop> topJarys)
        {
            for (int i = 0; i < topJarys.Count; i++)
            {
                if (i % 2 != 0)
                {
                    topJarys[i].Jarys(topJarys, (i - 1), i);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OiynTop.top = new List<OiynTop>()
            {
                new OiynTop(11, 1),
                new OiynTop(11, 2),
                new OiynTop(11, 3),
                new OiynTop(11, 4),
                new OiynTop(11, 5),
                new OiynTop(11, 6),
                new OiynTop(11, 7),
                new OiynTop(11, 8),
            };
            List<OiynTop> topJarys = new List<OiynTop>() { };

            Console.Write("Jaristar ainalymdar sani = ");
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            Console.WriteLine("\nBastapqi tizim: ");
            for (int i = 0; i < OiynTop.top.Count; i++)
                Console.WriteLine($" id: { OiynTop.top[i].top_number} - {  OiynTop.top[i].oiynshylar_sany}");

            while (counter < n)
            {
                Qarsylasu qq = new Qarsylasu();
                qq.Garsylastar(ref topJarys);

                Console.WriteLine("______________________________________");
                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

                qq.ToptarJarysy(topJarys);

                Thread.Sleep(5000);
                Console.WriteLine("\nposle " + (counter + 1) + " raunda:");
                for (int i = 0; i < topJarys.Count; i++)
                    Console.WriteLine($" id: { topJarys[i].top_number} - {  topJarys[i].oiynshylar_sany}");

                counter++;
                topJarys.Clear();
            }
            Console.WriteLine("______________________________________");
            Console.ReadKey();
        }
    }
}
