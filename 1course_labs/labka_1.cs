using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka1
{
    class OiynTop
    {
        public int oiynshylar_sany;
        public int top_number;
        public static List<OiynTop> top;

        public OiynTop(int sany, int num)
        {
            oiynshylar_sany = sany;
            top_number = num;
            
        }

        public static void Jarys(ref List<OiynTop> t, int rand1, int rand2)
        {
            Random rnd = new Random();
            if (t[rand1].top_number > t[rand2].top_number)
            {
                int oiynshy = rnd.Next(5, 7);
                t[rand2].oiynshylar_sany += oiynshy;
                t[rand1].oiynshylar_sany -= oiynshy;
                Console.Write($"1-Qarsylas id - {t[rand1].top_number};  Oiynshylar sany - {t[rand1].oiynshylar_sany} " + " <=======> ");
                Console.WriteLine($"2-Qarsylas id - {t[rand2].top_number};  Oiynshylar sany - {t[rand2].oiynshylar_sany} ");

                if (t[rand1].oiynshylar_sany <= 0)
                {
                    Console.Write($"1-Qarsylas id - {t[rand1].top_number};  Oiynshylar sany - {t[rand1].oiynshylar_sany} " + " Oiynnan shygyp ketty!\n");
                    top.Remove(t[rand1]);
                }

                if (t[rand2].oiynshylar_sany <= 0)
                {
                    Console.Write($"2-Qarsylas id - {t[rand2].top_number};  Oiynshylar sany - {t[rand2].oiynshylar_sany} " + " Oiynnan shygyp ketty!\n");
                    top.Remove(t[rand2]);
                }
            }
            else
            {
                int oiynshy = rnd.Next(5, 7);

                int buf = rand2;
                rand2 = rand1;
                rand1 = buf;

                t[rand2].oiynshylar_sany += oiynshy;
                t[rand1].oiynshylar_sany -= oiynshy;
                Console.Write($"1-Qarsylas id - {t[rand1].top_number};  Oiynshylar sany - {t[rand1].oiynshylar_sany} " + " <=======> ");
                Console.WriteLine($"2-Qarsylas id - {t[rand2].top_number};  Oiynshylar sany - {t[rand2].oiynshylar_sany} ");

                if (t[rand1].oiynshylar_sany <= 0)
                {
                    Console.Write($"1-Qarsylas id - {t[rand1].top_number};  Oiynshylar sany - {t[rand1].oiynshylar_sany} " + " Oiynnan shygyp ketty!\n");
                    top.Remove(t[rand1]);
                }

                if (t[rand2].oiynshylar_sany <= 0)
                {
                    Console.Write($"2-Qarsylas id - {t[rand2].top_number};  Oiynshylar sany - {t[rand2].oiynshylar_sany} " + " Oiynnan shygyp ketty!\n");
                    top.Remove(t[rand2]);
                }
            }
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

        public void ToptarJarysy(ref List<OiynTop> topJarys)
        {
            for (int i = 0; i < topJarys.Count; i++)
            {
                if (i % 2 != 0)
                {
                    OiynTop.Jarys(ref topJarys, (i - 1), i);
                    Console.WriteLine((i - 1) + " " + i);
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
                qq.Garsylastar( ref topJarys);

                Console.WriteLine("______________________________________");
                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

                qq.ToptarJarysy(ref topJarys);

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