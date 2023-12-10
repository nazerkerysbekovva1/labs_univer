using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace srs
{
    class OiynTop
    {
        public int oiynshylar_sany;
        public int top_number;
        public static Thread thread;
        public static List<OiynTop> top;

        public static Random rnd = new Random();

        static ManualResetEvent mre;

        public OiynTop(int sany, int num, ManualResetEvent evt)
        {
            oiynshylar_sany = sany;
            top_number = num;
            mre = evt;
        }

        public static void Jarys(object ob)
        {
            int oiynshy = rnd.Next(5, 7);
            if (ob is List<OiynTop> t)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        int rand1 = i - 1;
                        int rand2 = i;

                        if (t[rand1].top_number > t[rand2].top_number)
                        {
                            t[rand2].oiynshylar_sany += oiynshy;
                            t[rand1].oiynshylar_sany -= oiynshy;

                            if (t[rand1].oiynshylar_sany <= 0)
                            {
                                t.Remove(t[rand1]);
                            }
                            if (t[rand2].oiynshylar_sany <= 0)
                            {
                                t.Remove(t[rand2]);
                            }
                            Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number}");
                        }
                        else
                        {
                            int buf = rand2;
                            rand2 = rand1;
                            rand1 = buf;

                            t[rand2].oiynshylar_sany += oiynshy;
                            t[rand1].oiynshylar_sany -= oiynshy;

                            if (t[rand1].oiynshylar_sany <= 0)
                            {
                                t.Remove(t[rand1]);
                            }
                            if (t[rand2].oiynshylar_sany <= 0)
                            {
                                t.Remove(t[rand2]);
                            }
                            Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number}    >>>");
                        }
                    }
                }
                // Уведомление о событии, переводим объект в сигнальное состоянии, чтобы поток мог захватить ресурс.
                mre.Set();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent evtObj = new ManualResetEvent(true);

            OiynTop.top = new List<OiynTop>()
            {
                new OiynTop(11, 1,  evtObj),
                new OiynTop(11, 2,  evtObj),
                new OiynTop(11, 3,  evtObj),
                new OiynTop(11, 4,  evtObj),
                new OiynTop(11, 5,  evtObj),
                new OiynTop(11, 6,  evtObj),
                new OiynTop(11, 7,  evtObj),
                new OiynTop(11, 8,  evtObj),
            };

            int count = 0;
            for (int j = 0; j <= 2; j++)  // 3 итераций в которых будет запущено 3 потоков.
            {
                Console.WriteLine(" Поток-" + (count + 1));
                OiynTop.thread = new Thread(new ParameterizedThreadStart(OiynTop.Jarys));
                OiynTop.thread.Start(OiynTop.top);
                //Thread.Sleep(500);
                Console.WriteLine("Поток ожидает событие");
                evtObj.WaitOne();
                Console.WriteLine($"Поток получил уведомление о событии от {count + 1} потока");
                evtObj.Reset();
                count++;
            }
            Console.ReadLine();
        }
    }
}