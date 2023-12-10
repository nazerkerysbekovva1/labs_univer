//using System;
//using System.Threading;
//class SharedRes
//{
//    public static int Count = 0; // ортақ қолданылатын ресурс
//    public static Mutex Mtx = new Mutex(); // ортақ қолданылатын ресурсқа қол жеткізуді 
//                                           // басқаратын мьютекс
//}
//// Бұл ағында SharedRes.Count айнымалысы инкременттеледі
//class IncThread
//{
//    int num;
//    public Thread Thrd;
//    public IncThread(string name, int n)
//    {
//        Thrd = new Thread(this.Run);
//        num = n;
//        Thrd.Name = name;
//        Thrd.Start();
//    }
//    // ағынға кіру нүктесі.
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " мьютексті күтуде.");
//        // Получить мьютекс.
//        SharedRes.Mtx.WaitOne();
//        Console.WriteLine(Thrd.Name + " мьютексті қабылдады.");
//        do
//        {
//            Thread.Sleep(500);
//            SharedRes.Count++;
//            Console.WriteLine(Thrd.Name + " ағынында, SharedRes.Count = " + SharedRes.Count);
//            num--;
//        } while (num > 0);
//        Console.WriteLine(Thrd.Name + " мьютексті босатты.");
//        // Мьютексті босату.
//        SharedRes.Mtx.ReleaseMutex();
//    }
//}
////Бұл ағында SharedRes.Count айнымалысы декременттеледі.
//class DecThread
//{
//    int num;
//    public Thread Thrd;
//    public DecThread(string name, int n)
//    {
//        Thrd = new Thread(new ThreadStart(this.Run));
//        num = n;
//        Thrd.Name = name;
//        Thrd.Start();
//    }
//    // ағынға кіру нүктесі.
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " мьютексті күтуде.");
//        // Получить мьютекс.
//        SharedRes.Mtx.WaitOne();
//        Console.WriteLine(Thrd.Name + " мьютексті қабылдады.");
//        do
//        {
//            Thread.Sleep(500);
//            SharedRes.Count--;
//            Console.WriteLine(Thrd.Name + " ағынында, SharedRes.Count = " + SharedRes.Count);
//            num--;
//        } while (num > 0);
//        Console.WriteLine(Thrd.Name + " мьютексті босатты.");
//        // Мьютексті босату.
//        SharedRes.Mtx.ReleaseMutex();
//    }
//}
//class MutexDemo
//{
//    static void Main()
//    {
//        // Екі ағынды құру
//        IncThread mt1 = new IncThread("Инкременттеуші ағын", 5);
//        Thread.Sleep(1); // ағынды іске қосу
//        DecThread mt2 = new DecThread("Декременттеуші ағын", 5);
//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//    }
//}

//using System;
//using System.Threading;
//// Келесі ағын өзінің тек екі экземплярын қатар орындауға рұқсат береді
//class MyThread
//{
//    public Thread Thrd;
//    // Семафор құрылады, ол бастапқыда бар 2 рұқсаттың екеуін береді
//    static Semaphore sem = new Semaphore(2, 2);
//    public MyThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }
//    // Ағынға кіру нүктесі.
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " рұқсатты күтуде.");
//        sem.WaitOne();
//        Console.WriteLine(Thrd.Name + " рұқсатты алды.");
//        for (char ch = 'A'; ch < 'D'; ch++)
//        {
//            Console.WriteLine(Thrd.Name + " : " + ch + " ");
//            Thread.Sleep(500);
//        }
//        Console.WriteLine(Thrd.Name + " рұқсатты босатты.");
//        // Семафорды босату.
//        sem.Release();
//    }
//}
//class SemaphoreDemo
//{
//    static void Main()
//    {
//        // Үш ағын құру.
//        MyThread mt1 = new MyThread("#1 ағын");
//        MyThread mt2 = new MyThread("#2 ағын");
//        MyThread mt3 = new MyThread("#3 ағын");
//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//        mt3.Thrd.Join();
//    }
//}

//using System;
//using System.Threading;

//class SumArray
//{
//    int sum;
//    object lockOn = new object(); // бұғаттауға қолжетімді жабық объект

//    public int SumIt(int[] nums)
//    {
//        lock (lockOn)
//        { // әдісті толығымен бұғаттау
//            sum = 0; // қосындының бастапқы мәні
//            for (int i = 0; i < nums.Length; i++)
//            {
//                sum += nums[i];
//                Console.WriteLine(Thread.CurrentThread.Name + " агыны ушiн агымдагы косынды манi: " +
//                +sum);
//                Thread.Sleep(3000); // тапсырмаларды алмастыруға рұқсат беру
//            }
//            return sum;
//        }
//    }
//}
//class MyThread
//{
//    public Thread Thrd;
//    int[] a;
//    int answer;

//    // MyThread класының барлық экземплярлары үшін 
//    // SumArray типті бір объект құру
//    static SumArray sa = new SumArray();

//    // жаңа ағынды құру
//    public MyThread(string name, int[] nums)
//    {
//        a = nums;
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start(); // ағынды бастау
//    }

//    // Жаңа ағынды атқаруды бастау.
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " басталды.");
//        answer = sa.SumIt(a);
//        Console.WriteLine(Thrd.Name + " агыны ушiн косынды: " + answer);
//        Console.WriteLine(Thrd.Name + " аякталды.");
//    }
//}
//class Sync
//{
//    static void Main()
//    {
//        int[] a = { 1, 2, 3, 4, 5 };
//        MyThread mt1 = new MyThread("#1 буын", a);
//        MyThread mt2 = new MyThread("#2 буын", a);
//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//    }
//}
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
        public OiynTop(int sany, int num)
        {
            oiynshylar_sany = sany;
            top_number = num;
            // thread.Name = name;
        }

        static object lockOn = new object(); // бұғаттауға қолжетімді жабық объект

        public void Jarys(List<OiynTop> t, int rand1, int rand2)
        {
            thread = new Thread(() =>
            {
                lock (lockOn)// әдісті толығымен бұғаттау
                {
                    Console.WriteLine($"\n{t[rand1].top_number} <=> {t[rand2].top_number}  oiyndy bastady!");

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
                        Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} oiyndy aiaktady!");
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
                        Console.WriteLine($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number} oiyndy aiaktady!");
                    }
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

                Console.WriteLine("______________");
                Console.WriteLine("Jarys - " + (counter + 1) + ": ");

                qq.ToptarJarysy(topJarys);

                Thread.Sleep(5000);
                Console.WriteLine("\nposle " + (counter + 1) + " raunda:");
                for (int i = 0; i < topJarys.Count; i++)
                    Console.WriteLine($" id: { topJarys[i].top_number} - {  topJarys[i].oiynshylar_sany}");

                counter++;
                topJarys.Clear();
            }
            Console.WriteLine("______________");
            Console.ReadKey();
        }
    }
}