using System;

namespace prak6
{
    //class Tereze
    //{
    //    public static string tereze_taqyryby = "SL компаниясынын стандартты олшемындегы терезе";
    //    public int X;
    //    public int Y;
    //    public int H;
    //    public int L;

    //    public Tereze(int X, int Y, int H, int L)
    //    {
    //        this.X = X;
    //        this.Y = Y;
    //        this.H = H;
    //        this.L = L;
    //    }
    //    public void Shygaru()
    //    {
    //        Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
    //    }
    //    public int Area()
    //    {
    //        return H.Kob(L);
    //    }
    //}
        
    //static class Terezeler 
    //{
    //    public static int ZhanaTereze(this Tereze t1, Tereze t2)
    //    {
    //        int a = 0, b = 0;
    //        if ((t1.Y >= t2.Y && t2.Y < t1.Y + t1.H) && (t1.X <= t2.X && t2.X > t1.X + t1.L))
    //        {
    //            a = t1.H + t1.H - (t1.Y - t2.Y);
    //            b = t1.L + t2.L + (t2.X - t1.L);
    //        }
    //        else { Console.WriteLine("Еки терезе киылысады"); }
    //        return a * b;
    //    }
    //    public static int Kob(this int H, int L)
    //    {
    //        return H * L;
    //    }

    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tereze tereze1 = new Tereze(0, 80, 40, 50);
    //        tereze1.Shygaru();
    //        Console.Write("Tereze audany: ");
    //        tereze1.Area();

    //        Console.WriteLine();
    //        Tereze tereze2 = new Tereze(70, 60, 60, 30);
    //        tereze2.Shygaru();
    //        Console.Write("Tereze audany: ");
    //        tereze2.Area();

    //        Console.WriteLine();
    //        Console.WriteLine("Еки терезени камтитын жана терезе ауданы:" + Terezeler.ZhanaTereze(tereze1, tereze2));
    //        Console.ReadKey();
    //    }
    //}


    class Nusqa2
    {
        private double b1;
        private double q;
        public Nusqa2(double b1, double q) { this.b1 = b1; this.q = q; }
        public double B1
        {
            get { return b1; }
            set { b1 = value; }
        }
        public double Q
        {
            get { return q; }
            set { if (value > 0) q = value; }
        }
        
        public static void Info(double n, Nusqa2 nn)
        {
            Console.WriteLine("b1=" + nn.b1 + "\nq=" + nn.q );
        }
    }
    class MetodyRash
    {
        public static double TandalganMushe(double n, Nusqa2 geo)
        {
            double bn = geo.B1 * (Math.Pow(geo.Q, n - 1));
            return bn;
        }
        public static double TandalganKosyndy(double n, Nusqa2 geo)
        {
            double sn = (TandalganMushe(n, geo) * geo.Q - geo.B1) / (geo.Q - 1);
            return sn;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Nusqa2 geo = new Nusqa2(2, 3);
            Console.Write("mushe engiz: ");
            double n = double.Parse(Console.ReadLine());
            Nusqa2.Info(n, geo);
            Console.WriteLine("TandalganMushe=" + MetodyRash.TandalganMushe(n,geo));
            Console.WriteLine("TandalganKosyndy=" + MetodyRash.TandalganKosyndy(n,geo));
            Console.ReadKey();
        }
    }
}

