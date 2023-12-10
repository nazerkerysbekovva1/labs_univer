using System;
using System.Threading;
using System.Threading.Tasks;

//class DemoCancelTask
//{

//    // Тапсырма ретінде орындалатын әдіс
//    static void MyTask(Object ct)
//    {
//        CancellationToken cancelTok = (CancellationToken)ct;
//        // Тапсырманы іске қосудың алдында одан бас тартылғанын тексеру
//        cancelTok.ThrowIfCancellationRequested();
//        Console.WriteLine("MyTask() иске косылды");
//        for (int count = 0; count < 10; count++)
//        {
//            // Тапсырмадан бас тартылғанын бақылау үшін сұрастыру тәсілі қолданылады
//            if (cancelTok.IsCancellationRequested)
//            {
//                Console.WriteLine("Тапсырманы жоюга сураныс тусти");
//                cancelTok.ThrowIfCancellationRequested();
//            }
//            Thread.Sleep(500);
//            Console.WriteLine("MyTask() адисиндеги санауыш мани: " + count);
//        }
//        Console.WriteLine("MyTask аякталды");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Негизги агын иске косылды");
//        // Тапсырмадан бас тарту белгілерінің көзін құру
//        CancellationTokenSource cancelTokSrc = new CancellationTokenSource();
//        // Тапсырманы іске қосу, тапсырмаға және делегатқа бас тарту белгісін беру
//        Task tsk = Task.Factory.StartNew(MyTask, cancelTokSrc.Token, cancelTokSrc.Token);
//        // Тапсырманың күші жойылғанға дейін орындалуына мүмкіндік беру
//        Thread.Sleep(2000);
//        try
//        {
//            // Тапсырманың орындалуынан бас тарту
//            cancelTokSrc.Cancel();
//            // tsk тапсырмасы аяқталғанға дейін Main() әдісінің орындалуын кідірту
//            tsk.Wait();
//        }
//        //catch (OperationCanceledException ex)
//        //{
//        //    Console.WriteLine("dsf");
//        //}
//        catch (AggregateException exc)
//        {
//            if (tsk.IsCanceled)
//                Console.WriteLine("\ntsk тапсырмасынын орындалуынан бас тарту\n");
//            Console.WriteLine(exc);
//        }
//        finally
//        {
//            tsk.Dispose();
//            cancelTokSrc.Dispose();
//        }
//        Console.WriteLine("Негизги агын аякталды.");
//    }
//}

//using System;
//using System.Threading;
//class MyThread
//{
//    public Thread Thrd;
//    public MyThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }
//    // Ағынға кіру нүктесі.
//    void Run()
//    {
//        try
//        {
//            Console.WriteLine(Thrd.Name + " басталды.");
//            for (int i = 1; i <= 1000; i++)
//            {
//                Console.Write(i + " ");
//                if ((i % 10) == 0)
//                {
//                    Console.WriteLine();
//                    Thread.Sleep(250);
//                }
//            }
//            Console.WriteLine(Thrd.Name + " қалыпты аяқталды.");
//        }
//        catch (ThreadAbortException exc)
//        {
//            Console.WriteLine("Ағын тоқтатылды, аяқтау коды " + exc.ExceptionState);
//        }
//    }
//}
//class UseAltAbort
//{
//    static void Main()
//    {
//        MyThread mt1 = new MyThread("Ағын 1");
//        Thread.Sleep(1000); // туынды ағынның жұмысына рұқсат беру
//        Console.WriteLine("Ағынды тоқтату.");
//        mt1.Thrd.Abort(100);
//        mt1.Thrd.Join(); // ағын тоқтатылуын күту
//        Console.WriteLine("Негізгі ағын тоқтатылды.");
//    }
//}

//using System;
//using System.Threading;
//using System.Threading.Tasks;
//class Program
//{
//    static void Main()
//    {
//        var parent = Task.Factory.StartNew(() =>
//        {
//            // We'll throw 3 exceptions at once using 3 child tasks:
//            int[] numbers = { 0 };
//            var childFactory = new TaskFactory
//            (TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
//            childFactory.StartNew(() => 5 / numbers[0]); // Division by zero
//            childFactory.StartNew(() => numbers[1]); // Index out of range
//            childFactory.StartNew(() => { throw null; }); // Null reference
//        });
//        try { parent.Wait(); }
//        catch (AggregateException aex)
//        {
//            aex.Flatten().Handle(ex =>
//            {
//                if (ex is DivideByZeroException)
//                {
//                    Console.WriteLine("Divide by zero");
//                    return true;
//                }
//                if (ex is IndexOutOfRangeException)
//                {
//                    Console.WriteLine("Index out of range");
//                    return true;
//                }
//                return false; // All other exceptions will get rethrown
//            });
//        }
//    }
//}


//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//namespace Ernazar
//{
//    class Qasqyr
//    {
//        public int x;
//        public int y;
//        public static Random rnd = new Random();
//        public Qasqyr(int a, int b)
//        {
//            x = a;
//            y = b;
//        }
//        public void Qozgalu()
//        {
//            Console.WriteLine($"Qasqyr zhuriz bastady!");
//            x = rnd.Next(10);
//            y = rnd.Next(10);
//            Console.WriteLine($"Qasqyr zhuriz ayaqtady!");
//        }
//    }
//    class Qoi
//    {
//        public int id;
//        public int x;
//        public int y;
//        public int belgilenui;
//        public static CancellationTokenSource cancelTokSrc = new CancellationTokenSource();
//        Random rnd = new Random();
//        public Qoi(int san1, int a, int b)
//        {
//            id = san1;
//            x = a;
//            y = b;
//            belgilenui = 1;
//        }
//        public double Qozgalu()
//        {
//            Console.WriteLine($"Qoi{id} zhuris bastady:");
//            int a = rnd.Next(10);
//            int b = rnd.Next(10);
//            if (a < 5 && b < 5)
//                if (cancelTokSrc.Token.IsCancellationRequested)
//                {
//                    Console.WriteLine($"Qoi{id} toqtady:");
//                    cancelTokSrc.Token.ThrowIfCancellationRequested();

//                }
//            x = a;
//            y = b;
//            Console.WriteLine($"Qoi{id} zhuriz zhasady!");
//            return Math.Sqrt(x * x + y * y);
//        }
//    }
//    class Program
//    {
//        static List<Task<double>> zadachi = new List<Task<double>>();
//        static Task zadacha_s;
//        public static void Qoi_zheu(ref List<Qoi> otar, Qasqyr bori)
//        {
//            int san = 1;
//            for (int i = otar.Count - 1; i >= 0; i--)
//            {
//                if (bori.x == otar[i].x && bori.y == otar[i].y)
//                {
//                    Qoi q = otar[i];
//                    otar.RemoveAt(i);
//                    Console.WriteLine($"{san}. {q.x};{q.y} nuktesinde {q.id} qoiyn qasqyr zhep qoydy! ");
//                    san++;
//                }
//            }
//            Console.WriteLine();
//        }
//        public static void Qoi_kobeitu(ref List<Qoi> otar, ref int num)
//        {
//            int san = 1;
//            for (int i = otar.Count - 1; i >= 1; i--)
//            {
//                for (int j = i - 1; j >= 0; j--)
//                {
//                    if (otar[i].x == otar[j].x && otar[i].y == otar[j].y)
//                    {
//                        otar.Add(new Qoi(num, otar[i].x, otar[i].y));
//                        Console.WriteLine($"{san}. {otar[i].x};{otar[i].y} nuktesinde {i + 1} zhane {j + 1} qoilarynyn qosyluynan {num} nomerinshi zhana qoi paida boldy!");
//                        num++;
//                        san++;
//                    }
//                }
//            }
//            Console.WriteLine();
//        }
//        public static void Ornalastyru(int[,] taqta, List<Qoi> otar, Qasqyr bori)
//        {
//            foreach (Qoi qoi in otar)
//                taqta[qoi.x, qoi.y] += qoi.belgilenui;
//            taqta[bori.x, bori.y] = -1;
//        }
//        public static void Display(int[,] taqta, int a)
//        {
//            for (int i = 0; i < a; i++)
//            {
//                for (int j = 0; j < a; j++)
//                    Console.Write($"{taqta[i, j]}\t");
//                Console.WriteLine("\n");
//            }
//        }
//        public static void Zadacha_qosu(List<Qoi> otar, Qasqyr bori)
//        {
//            zadachi.Clear();
//            foreach (Qoi qoi in otar)
//                zadachi.Add(new Task<double>(qoi.Qozgalu));
//            zadacha_s = Task.WhenAll(zadachi).ContinueWith(ant =>
//            {
//                bori.Qozgalu();
//                double min = 100000;
//                int n = 0;
//                for (int i = 0; i < ant.Result.Length; i++)
//                {
//                    if (min > ant.Result[i])
//                    {
//                        min = ant.Result[i];
//                        n = i;
//                    }
//                }
//                Console.WriteLine($"Koordinattar basyna en zhaqyn qoi:{otar[n].id} \taraqashyqtyq {min}");
//            }, Qoi.cancelTokSrc.Token
//            );
//        }
//        static void Main(string[] args)
//        {
//            List<Qoi> otar = new List<Qoi>()
//            {
//                new Qoi(1,0,0),  new Qoi(2,0,1),  new Qoi(3,0,2),  new Qoi(4,0,3),  new Qoi(5,1,0),
//                new Qoi(6,1,1),  new Qoi(7,1,2),  new Qoi(8,2,0),  new Qoi(9,2,1),  new Qoi(10,2,2),
//            };
//            int num = 11;
//            Qasqyr bori = new Qasqyr(9, 9);
//            int[,] taqta = new int[10, 10];
//            string qora = "zhoq";
//            while (otar.Count != 0)
//            {
//                Qoi_zheu(ref otar, bori);
//                Qoi_kobeitu(ref otar, ref num);
//                Ornalastyru(taqta, otar, bori);
//                Display(taqta, 10);
//                Console.WriteLine($"Otardgy qoi sany: {otar.Count}");
//                Console.Write("Qoilardy qoraga aidaymyzba: ");
//                qora = Console.ReadLine();
//                try
//                {
//                    if (qora == "ya")
//                        Qoi.cancelTokSrc.Cancel();

//                }
//                catch (AggregateException ae)
//                {
//                    Console.WriteLine("Операция прервана");
//                }
//                Console.Clear();
//                Array.Clear(taqta, 0, 100);
//                Zadacha_qosu(otar, bori);
//                for (int i = 0; i < zadachi.Count; i++)
//                    zadachi[i].Start();
//                zadacha_s.Wait();
//            }
//            Console.WriteLine("Otar barin qasqyr zhep qoidy!");
//        }
//    }
//}

class Zhugirushiler
{
    public int[] n;
    public string name;
    public int num;
    public static Task tsk;
    public Zhugirushiler(string c, int b, int a)
    {
        name = c;
        num = b;
        n = new int[a];
    }
    public void Massiv(int b)
    {
        Random rand = new Random((int)DateTime.Now.Ticks);
        for (int i = 0; i < b; i++)
        {
            n[i] = rand.Next(1, 4);
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
        Console.Write(mare);
    }
    public void Display()
    {
        Console.Write(name + "    ");
        Massiv(10);
        Console.WriteLine("\n");
    }
    public void Display2(Object ct)
    {
        CancellationToken cancelTok = (CancellationToken)ct;
        {
            cancelTok.ThrowIfCancellationRequested();
            Console.WriteLine("Oiyn №" + Task.CurrentId + " іске қосылды");


            for (int i = 0; i < n.Length; i++)
            {
                if (cancelTok.IsCancellationRequested)
                {
                    Console.WriteLine("Тапсырманы жоюга сураныс тусти");
                    cancelTok.ThrowIfCancellationRequested();
                }
                Uaqyt();
                Console.WriteLine("- мареге жеттим, реттик номерым: {0} ", num);
            }
            Console.WriteLine("Oiyn №" + Task.CurrentId + " аяқталды");

        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Zhugirushiler[] tr =
            {
                new Zhugirushiler("Murat", 1, 10),
                new Zhugirushiler("Laura", 2, 10),
                new Zhugirushiler("Nazym", 3, 10),
                new Zhugirushiler("Aibek", 4, 10),
                new Zhugirushiler("Ademi", 5, 10),
                new Zhugirushiler("Rasul", 6, 10),
                new Zhugirushiler("Aknur", 7, 10),
                new Zhugirushiler("Islam", 8, 10),
                new Zhugirushiler("Aqjol", 9, 10),
                new Zhugirushiler("Ernar", 10, 10)
            };
        CancellationTokenSource cancelTokSrc = new CancellationTokenSource();
        for (int i = 0; i < tr.Length; i++)
        {
            tr[i].Display();
        }
        Console.WriteLine("\nНегізгі ағын іске қосылды.");

        Task task = Task.Factory.StartNew(tr[0].Display2, cancelTokSrc.Token);
        Task task1 = Task.Factory.StartNew(tr[1].Display2, cancelTokSrc.Token);
        Task task2 = Task.Factory.StartNew(tr[2].Display2, cancelTokSrc.Token);



        Thread.Sleep(1000);
        try
        {
            // Отменить задачу.
            cancelTokSrc.Cancel();
            // Приостановить выполнение метода Main() до тех пор,
            // пока не завершится задача tsk.
            task.Wait();
            task1.Wait();
            task2.Wait();
        }
        catch (AggregateException exc)
        {
            if (task.IsCanceled && task1.IsCanceled && task2.IsCanceled)
                Console.WriteLine("\ntsk тапсырмасынын орындалуынан бас тарту\n");
            Console.WriteLine(exc);
        }
        finally
        {
            task.Dispose();
            task1.Dispose();
            task2.Dispose();
            cancelTokSrc.Dispose();
        }
        Console.WriteLine("\nНегізгі ағын аяқталды.\n");


        Console.WriteLine();
    }
}