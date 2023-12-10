//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;

//namespace labka_4
//{
//    class OiynTop
//    {
//        public int oiynshylar_sany;
//        public int top_number;
//        public static Thread thread;

//        public static Random rnd = new Random();

//        static ManualResetEvent mre;

//        public OiynTop(int sany, int num, string name_th, ManualResetEvent evt)
//        {
//            oiynshylar_sany = sany;
//            top_number = num;

//            thread = new Thread(new ParameterizedThreadStart(Jarys));

//            thread.Name = name_th;
//            mre = evt;
//        }

//        public static void Jarys(object ob)
//        {
//            int oiynshy = rnd.Next(5, 7);
//            if (ob is List<OiynTop> t)
//            {
//                Console.WriteLine("Внутри потока " + thread.Name);

//                for (int i = 0; i < t.Count; i++)
//                {
//                    if (i % 2 != 0)
//                    {
//                        int rand1 = i - 1;
//                        int rand2 = i;

//                        if (t[rand1].top_number > t[rand2].top_number)
//                        {
//                            t[rand2].oiynshylar_sany += oiynshy;
//                            t[rand1].oiynshylar_sany -= oiynshy;

//                            if (t[rand1].oiynshylar_sany <= 0)
//                            {
//                                t.Remove(t[rand1]);
//                            }
//                            if (t[rand2].oiynshylar_sany <= 0)
//                            {
//                                t.Remove(t[rand2]);
//                            }
//                            Console.Write($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number}");
//                        }
//                        else
//                        {
//                            int buf = rand2;
//                            rand2 = rand1;
//                            rand1 = buf;

//                            t[rand2].oiynshylar_sany += oiynshy;
//                            t[rand1].oiynshylar_sany -= oiynshy;

//                            if (t[rand1].oiynshylar_sany <= 0)
//                            {
//                                t.Remove(t[rand1]);
//                            }
//                            if (t[rand2].oiynshylar_sany <= 0)
//                            {
//                                t.Remove(t[rand2]);
//                            }
//                            Console.Write($"1_ID - {t[rand1].top_number} <=======> 2_ID - {t[rand2].top_number}    >>>");
//                        }
//                        Console.WriteLine(thread.Name);
//                        Thread.Sleep(500);
//                    }
//                }
//                Console.WriteLine(thread.Name + " завершен!");

//                // Уведомление о событии
//                mre.Set();
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ManualResetEvent evtObj = new ManualResetEvent(false);

//            List<OiynTop> top = new List<OiynTop>()
//            {
//                new OiynTop(11, 1, "поток-1", evtObj),
//                new OiynTop(11, 2, "поток-1", evtObj),
//                new OiynTop(11, 3, "поток-1", evtObj),
//                new OiynTop(11, 4, "поток-1", evtObj),
//                new OiynTop(11, 5, "поток-1", evtObj),
//                new OiynTop(11, 6, "поток-1", evtObj),
//                new OiynTop(11, 7, "поток-1", evtObj),
//                new OiynTop(11, 8, "поток-1", evtObj),
//            };

//            OiynTop.thread.Start(top);

//            Console.WriteLine("Основной поток ожидает событие");

//            evtObj.WaitOne();

//            Console.WriteLine("Основной поток получил уведомление о событии от первого потока");

//            evtObj.Reset();

//            top = new List<OiynTop>()
//            {
//                new OiynTop(11, 9, "поток-2", evtObj),
//                new OiynTop(11, 10, "поток-2", evtObj),
//                new OiynTop(11, 11, "поток-2", evtObj),
//                new OiynTop(11, 12, "поток-2", evtObj),
//                new OiynTop(11, 13, "поток-2", evtObj),
//                new OiynTop(11, 14, "поток-2", evtObj),
//                new OiynTop(11, 15, "поток-2", evtObj),
//                new OiynTop(11, 16, "поток-2", evtObj),
//            };

//            OiynTop.thread.Start(top);

//            evtObj.WaitOne();

//            Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
//            Console.ReadLine();
//        }
//    }
//}

////class Program
////{
////    static AutoResetEvent waitEvent = new AutoResetEvent(true); // Переводим объект в сигнальное состояние в конструкторе.
////    static int x;

////    static void Main(string[] args)
////    {
////        for (int i = 0; i < 5; i++) // Пять итераций в которых будет запущено 5 потоков.
////        {
////            Thread newThread = new Thread(CountMethod); // Создаем обьект потока и передаем ему ссылку на метод.
////            newThread.Name = "Поток №" + i.ToString();// Присваиваем имя каждому потоку.
////            newThread.Start(); // Запускаем потоки.
////        }

////        Console.ReadLine();
////    }
////    public static void CountMethod()
////    {
////        waitEvent.WaitOne(); // Из метода, который выполняется в каждом потоке запускаем WaitOne, чтобы перевести потоки в состояние ожидания сигнального состояния. Теперь все потоки в состоянии ожидания.
////        for (x = 1; x < 9; x++)
////        {
////            Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
////            Thread.Sleep(100);
////        }
////        waitEvent.Set(); // Переводим объект в сигнальное состоянии, чтобы поток мог захватить ресурс.
////    }
////}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace lab5
//{
//    class Zhugirushiler
//    {
//        public int[] n;
//        public string name;
//        public int num;
//        public Thread Thrd;  // ағындық типтегі объект
//        public ManualResetEvent mre;
//        public Zhugirushiler(string c, int b, int a, string d, ManualResetEvent evt)
//        {
//            name = c;
//            num = b;
//            n = new int[a];
//            Thrd = new Thread(Uaqyt); // ағынды құру
//            Thrd.Name = d;
//            mre = evt;
//            Thrd.Start();
//        }
//        public void Uaqyt()
//        {
//            Random rand = new Random((int)DateTime.Now.Ticks);
//            int mare = 0;
//            for (int i = 0; i < 10; i++)
//            {
//                n[i] = rand.Next(1, 4);
//                Thread.Sleep(n[i]);
//                mare += n[i];
//            }
//            Thread.Sleep(1000);
//            Console.Write(mare);
//            Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
//            mre.WaitOne();
//            mre.Set();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ManualResetEvent evtObj = new ManualResetEvent(false);
//            Zhugirushiler[] tr = new Zhugirushiler[]
//                {
//                new Zhugirushiler("Murat", 1, 10, "1 qatsushy", evtObj),
//                new Zhugirushiler("Laura", 2, 10, "2 qatsushy", evtObj),
//                new Zhugirushiler("Nazym", 3, 10, "3 qatsushy", evtObj),
//                new Zhugirushiler("Aibek", 4, 10, "4 qatsushy", evtObj),
//                new Zhugirushiler("Ademi", 5, 10, "5 qatsushy", evtObj),
//                new Zhugirushiler("Rasul", 6, 10, "6 qatsushy", evtObj),
//                new Zhugirushiler("Aknur", 7, 10, "7 qatsushy", evtObj),
//                new Zhugirushiler("Islam", 8, 10, "8 qatsushy", evtObj),
//                new Zhugirushiler("Aqjol", 9, 10, "9 qatsushy", evtObj),
//                new Zhugirushiler("Ernar", 10, 10, "10 qatsushy", evtObj)
//            };
//                Console.WriteLine("Поток ожидает событие");
//                evtObj.WaitOne();
//                Console.WriteLine($"Поток получил уведомление о событии от первого потока");
//                //evtObj.Reset();

//            tr = new Zhugirushiler[]
//                {
//                new Zhugirushiler("Murat", 1, 10, "1 qatsushy", evtObj),
//                new Zhugirushiler("Laura", 2, 10, "2 qatsushy", evtObj),
//                new Zhugirushiler("Nazym", 3, 10, "3 qatsushy", evtObj),
//                new Zhugirushiler("Aibek", 4, 10, "4 qatsushy", evtObj),
//                new Zhugirushiler("Ademi", 5, 10, "5 qatsushy", evtObj),
//                new Zhugirushiler("Rasul", 6, 10, "6 qatsushy", evtObj),
//                new Zhugirushiler("Aknur", 7, 10, "7 qatsushy", evtObj),
//                new Zhugirushiler("Islam", 8, 10, "8 qatsushy", evtObj),
//                new Zhugirushiler("Aqjol", 9, 10, "9 qatsushy", evtObj),
//                new Zhugirushiler("Ernar", 10, 10, "10 qatsushy", evtObj)
//            };

//            evtObj.WaitOne();
//            Console.WriteLine("Поток получил уведомление о событии от второго потока");

//            Console.ReadLine();
//        }
//    }
//}


//using System;
//using System.Threading;
//using System.Collections.Generic;

//namespace srs3
//{
//    class Student
//    {
//        public string name;
//        public string specialty;
//        public int course;
//        public double GPA_score;

//        public static Thread Thrd;
//        ManualResetEvent mre;

//        public Student(string name, string spec, int course, double gpa, string name_th, ManualResetEvent evt)
//        {
//            this.name = name;
//            specialty = spec;
//            this.course = course;
//            GPA_score = gpa;

//            Thrd = new Thread(new ParameterizedThreadStart(Run));
//            Thrd.Name = name_th;
//            mre = evt;
//            //Thrd.Start();
//        }

//        void Run(object obj)
//        {
//            if (obj is List<Student> info)
//            {
//                Console.WriteLine("Внутри потока " + Thrd.Name);

//                foreach (var s in info)
//                {
//                    Console.WriteLine("___Student_");
//                    Console.WriteLine($"Name: {s.name}. \nSpecialty: {s.specialty}. \nCourse: {s.course}. \nGPA_score: {s.GPA_score}.");

//                    Console.WriteLine(Thrd.Name);
//                    Thread.Sleep(500);
//                }

//                Console.WriteLine(Thrd.Name + " завершен!");

//                // Уведомление о событии
//                mre.Set();
//            }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            ManualResetEvent evtObj = new ManualResetEvent(true);

//            List<Student> mt1 = new List<Student> {
//                new Student("Даулетбай Бакыт", "IT-specialist", 2, 3.77,"Событийный поток 1", evtObj),
//                new Student("Аскерова Асем", "IT-specialist", 2, 3.77,"Событийный поток 1", evtObj),
//                new Student("Камараддин Расул", "IT-specialist", 2, 3.77,"Событийный поток 1", evtObj),
//            };

//            Student.Thrd.Start(mt1);

//            Console.WriteLine("Основной поток ожидает событие");

//            evtObj.WaitOne();

//            Console.WriteLine("Основной поток получил уведомление о событии от первого потока");

//            evtObj.Reset();

//            mt1 = new List<Student> {
//                new Student("Даулетбай Бакыт", "IT-specialist", 2, 3.77,"Событийный поток 2", evtObj),
//                new Student("Аскерова Асем", "IT-specialist", 2, 3.77,"Событийный поток 2", evtObj),
//                new Student("Камараддин Расул", "IT-specialist", 2, 3.77,"Событийный поток 2", evtObj),
//            };

//            Student.Thrd.Start(mt1);

//            evtObj.WaitOne();

//            Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
//            Console.ReadLine();
//        }
//    }
//}


using System;
using System.Threading;
using System.Collections.Generic;
class Geo
{
    public double b1;
    public double q;

    public static Thread Thrd;
    ManualResetEvent mre;

    public Geo(double b1, double q, string name_th, ManualResetEvent evt)
    {
        this.b1 = b1;
        this.q = q;

        Thrd = new Thread(TandalganKosyndy);
        Thrd.Name = name_th;
        mre = evt;
        Thrd.Start();
    }

    public void TandalganKosyndy()
    {
        Console.WriteLine("Внутри потока " + Thrd.Name);
        for (int i = 2; i <= 6; i++)
        {
            double bn = b1 * (Math.Pow(q, i - 1));
            double sn = (bn * q - b1) / (q - 1);
            Console.Write($"{i} Mushe Kosundysy = {sn}   >>>> ");
            Console.WriteLine(Thrd.Name);
            Thread.Sleep(500);
        }
        Console.WriteLine(Thrd.Name + " завершен!");

        // Уведомление о событии
        mre.Set();
    }
}
class Program
{
    static void Main(string[] args)
    {
        ManualResetEvent evtObj = new ManualResetEvent(false);
        
        Geo mt1 = new Geo(1, 5, "Событийный поток 1", evtObj);

        Console.WriteLine("Основной поток ожидает событие");
        evtObj.WaitOne();
        Console.WriteLine("Основной поток получил уведомление о событии от первого потока");
        evtObj.Reset();

        mt1 = new Geo(2, 5, "Событийный поток 2", evtObj);

        evtObj.WaitOne();
        Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
        Console.ReadLine();
    }
}