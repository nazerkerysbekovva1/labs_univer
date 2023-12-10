using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace labka_15
{
    class OiynTop
    {
        public int oiynshylar_sany;
        public int top_number;

        public OiynTop(int sany, int num)
        {
            oiynshylar_sany = sany;
            top_number = num;
        }

        public int Oiynshylar_sany
        {
            set
            {
                if (value <= 0)
                    oiynshylar_sany = 0;
                else
                    oiynshylar_sany = value;
            }
            get
            {
                return oiynshylar_sany;  
            }
        }

        public (int, int) Jarys(List<OiynTop> top, List<OiynTop> t, int rand1, int rand2)
        {
            Random rnd = new Random();

            if (t[rand1].top_number > t[rand2].top_number)
            {
                int oiynshy = rnd.Next(5, 7);
                t[rand2].Oiynshylar_sany += oiynshy;
                t[rand1].Oiynshylar_sany -= oiynshy;

                if (t[rand1].Oiynshylar_sany == 0)
                {
                    top.Remove(t[rand1]);
                }

                if (t[rand2].Oiynshylar_sany == 0)
                {
                    top.Remove(t[rand2]);
                }
            }
            else
            {
                int oiynshy = rnd.Next(5, 7);
                int buf = rand2;
                rand2 = rand1;
                rand1 = buf;

                t[rand2].Oiynshylar_sany += oiynshy;
                t[rand1].Oiynshylar_sany -= oiynshy;

                if (t[rand1].Oiynshylar_sany == 0)
                {
                    top.Remove(t[rand1]);
                }

                if (t[rand2].Oiynshylar_sany == 0)
                {
                    top.Remove(t[rand2]);
                }
            }
            return (t[rand1].top_number, t[rand2].top_number);
        }
    }
    class Qarsylasu
    {
        public int Garsylastar(List<OiynTop> topJarys, List<OiynTop> top, int rand)
        {
            Random rnd = new Random();
            for (int k = 0; k < top.Count; k++)
            {
                rand = rnd.Next(0, top.Count);
                if (!topJarys.Contains(top[rand]))
                {
                    topJarys.Add(top[rand]);
                    return rand;
                    //return top[rand].top_number;
                }
            }
            return rand;
        }
        public void ToptarJarysy(List<OiynTop> topJarys, List<OiynTop> top)
        {
            Parallel.For(0, topJarys.Count, i =>
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine($"Oinaidy>>>  {topJarys[i].Jarys(top, topJarys, (i - 1), i)}");
                }
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<OiynTop> top = new List<OiynTop>()
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

            //Console.Write("Jaristar ainalymdar sani = ");
            //int n = int.Parse(Console.ReadLine());
            int n = 4;

            int counter = 0;

            Console.WriteLine("\nBastapqi tizim: ");
            for (int i = 0; i < top.Count; i++)
                Console.WriteLine($" id: {top[i].top_number} - {top[i].Oiynshylar_sany}");

            while (counter < n)
            {
                Console.WriteLine("-------------------");

                if (topJarys.Count == 1) break;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nНегізгі ағын іске қосылды.");
                Console.ResetColor();

                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

                Qarsylasu qq = new Qarsylasu();
                int rand = 0;
                while (topJarys.Count < top.Count)
                {
                    Console.WriteLine($" Randomno anyktaldy  -  id: {(qq.Garsylastar(topJarys, top, rand)) + 1}");
                }
                qq.ToptarJarysy(topJarys, top);

                Console.WriteLine("\nKalgan tizim: ");
                for (int i = 0; i < topJarys.Count; i++)
                    Console.WriteLine($" id: {topJarys[i].top_number} - {topJarys[i].Oiynshylar_sany}");

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