//using System;
//using System.Threading;
//class TickTock
//{
//    object lockOn = new object();  // бұғаттауға қажетті жабық объект
//    public void Tick(bool running)
//    {
//        lock (lockOn)
//        { // әдісті бұғаттау
//            if (!running)
//            { // сағатты тоқтату
//                Monitor.Pulse(lockOn); // күтудегі ағындарға хабарлау
//                return;
//            }
//            Console.Write("тик ");
//            Monitor.Pulse(lockOn); // Tock() әдісінің орындалуына рұқсат беру
//            Monitor.Wait(lockOn); // Tock() әдісінің аяқталуын күту
//        }
//    }
//    public void Tock(bool running)
//    {
//        lock (lockOn)
//        { // әдісті бұғаттау
//            if (!running)
//            { // сағатты тоқтату 
//                Monitor.Pulse(lockOn); // күтудегі ағындарға хабарлау
//                return;
//            }
//            Console.WriteLine("так");
//            Monitor.Pulse(lockOn); // Tick()әдісінің орындалуына рұқсат беру
//            Monitor.Wait(lockOn); // Tick()әдісінің аяқталуын күту
//        }
//    }
//}
//class MyThread
//{
//    public Thread Thrd;
//    TickTock ttOb;
//    // Жаңа ағын құру
//    public MyThread(string name, TickTock tt)
//    {
//        Thrd = new Thread(this.Run);
//        ttOb = tt;
//        Thrd.Name = name;
//        Thrd.Start();
//    }
//    // Жаңа ағын жұмысын бастау.
//    void Run()
//    {
//        if (Thrd.Name == "Tick")
//        {
//            for (int i = 0; i < 5; i++) ttOb.Tick(true);
//            ttOb.Tick(false);
//        }
//        else
//        {
//            for (int i = 0; i < 5; i++) ttOb.Tock(true);
//            ttOb.Tock(false);
//        }
//    }
//}
//class TickingClock
//{
//    static void Main()
//    {
//        TickTock tt = new TickTock();
//        MyThread mt1 = new MyThread("Tick", tt);
//        MyThread mt2 = new MyThread("Tock", tt);
//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//        Console.WriteLine("Сағат тоқтатылды");
//    }
//}

using System;
using System.Threading;
// Келесі ағын оның конструкторына оқиға берілгенін хабарлайды.
class MyThread
{
    public Thread Thrd;
    ManualResetEvent mre;
    public MyThread(string name, ManualResetEvent evt)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        mre = evt;
        Thrd.Start();
    }
    // Ағынға кіру нүктесі.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " ағынында");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(Thrd.Name);
            Thread.Sleep(500);
        }
        Console.WriteLine(Thrd.Name + " аяқталды!");
        // Оқиға жөнінде хабарлау.
        mre.Set();
    }
}
class ManualEventDemo
{
    static void Main()
    {
        ManualResetEvent evtObj = new ManualResetEvent(false);
        MyThread mt1 = new MyThread("1-ші оқиғалық ағын", evtObj);
        Console.WriteLine("Негізгі ағын оқиғаны күтуде.");
        // Оқиға туралы хабарламаны күту.
        evtObj.WaitOne();
        Console.WriteLine("Негізгі ағын бірінші ағыннан оқиға туралы хабарлама алды.");
        //// Оқиғалық объектіні бастапқы күйге орнату.
        //evtObj.Reset();
        //mt1 = new MyThread("2-ші оқиғалық ағын", evtObj);
        //// Оқиға туралы хабарламаны күту.
        //evtObj.WaitOne();
        //Console.WriteLine("Негізгі ағын екінші ағыннан оқиға туралы хабарлама алды.");
    }
}