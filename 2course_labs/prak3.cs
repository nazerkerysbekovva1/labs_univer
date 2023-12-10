using System;

namespace prak3
{
    //class Tereze
    //{
    //    private string tereze_taqyryby;
    //    private int X;
    //    private int Y;
    //    private int H;
    //    private int L;

    //    public Tereze(string taqryp, int x, int y, int h, int l)
    //    {
    //        tereze_taqyryby = taqryp;
    //        X = x;
    //        Y = y;
    //        H = h;
    //        L = l;
    //    }

    //    public string taqryp
    //    {
    //        get { return tereze_taqyryby; }
    //        set { tereze_taqyryby = value; }
    //    }
    //    public int x
    //    {
    //        get { return X; }
    //        set { X = value; }
    //    }
    //    public int y
    //    {
    //        get { return Y; }
    //        set { Y = value; }
    //    }
    //    public int h
    //    {
    //        get { return H; }
    //        set { H = value; }
    //    }
    //    public int l
    //    {
    //        get { return L; }
    //        set { L = value; }
    //    }

    //    public static int koordinata1(int x)
    //    {
    //        if (x <= 100) { x = x + 50; }
    //        else Console.WriteLine("Qate");
    //        return x;
    //    }
    //    public static int koordinata2(int y)
    //    {
    //        if (y <= 100) { y = y + 50; }
    //        else Console.WriteLine("Qate");
    //        return y;
    //    }
    //    public static int h_ozgertu(int h) { h = h - 5; return h; }
    //    public static int l_ozgertu(int l) { l = l + 10; return l; }


    //    public void Shygaru()
    //    {
    //        Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tereze tereze = new Tereze("SL компаниясынын 40*50 стандартты олшемындегы терезе",0,0,40,50);
    //        tereze.Shygaru();
    //        Console.WriteLine();
    //        Console.WriteLine("Олшеми озгертилген терезе олшемдеры" + "\nСол жак тобе координатасы: z = (" + Tereze.koordinata1(0) + "," + Tereze.koordinata2(0) + ")" + "\nБиыктыгы:" + Tereze.h_ozgertu(40) + "\nУзындыгы:" + Tereze.l_ozgertu(50));
    //        Console.ReadKey();

    //    }
    //}

    //class Nusqa2
    //{
    //    private double b1;
    //    private double q;
    //    public Nusqa2(double b1, double q) { this.b1 = b1; this.q = q; }
    //    public double B1
    //    {
    //        get { return b1; }
    //        set { b1 = value; }
    //    }
    //    public double Q
    //    {
    //        get { return q; }
    //        set { if (value > 0) q = value; }
    //    }
    //    public double TandalganMushe(double n)
    //    {
    //        double bn = B1 * (Math.Pow(Q, n - 1));
    //        return bn;
    //    }
    //    public double TandalganKosyndy(double n)
    //    {
    //        double sn = (TandalganMushe(n) * q - b1) / (q - 1);
    //        return sn;
    //    }
    //    public static void Info(double n, Nusqa2 nn)
    //    {
    //        Console.WriteLine("b1=" + nn.b1 + "\nq=" + nn.q + "\nTandalganMushe=" + nn.TandalganMushe(n) + "\nTandalganKosyndy=" + nn.TandalganKosyndy(n));
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa2 geo = new Nusqa2(2, 3);
    //        Console.Write("mushe engiz: ");
    //        double n = double.Parse(Console.ReadLine());
    //        Nusqa2.Info(n, geo);
    //        Console.ReadKey();
    //    }
    //}

    //class Nusqa4
    //{
    //    private int hour;
    //    private int min;
    //    private int sec;
    //    public Nusqa4(int h, int m, int s)
    //    {
    //        hour = h; min = m; sec = s;
    //    }
    //    public int Hour
    //    {
    //        get { return hour; }
    //        set { if (value < 60) hour = value; }
    //    }
    //    public int Min
    //    {
    //        get { return min; }
    //        set { if (value < 60) min = value; }
    //    }
    //    public int Sec
    //    {
    //        get { return sec; }
    //        set { if (value < 60) sec = value; }
    //    }
    //    public void SecondOperation()
    //    {
    //        int san = int.Parse(Console.ReadLine());
    //        sec = sec - san;
    //        Console.WriteLine("Time - " + "(" + hour + "," + min + "," + sec + ")");
    //    }
    //    public int AinaldyruSec()
    //    {
    //        return (hour * 60 + min) * 60 + sec;
    //    }
    //    public int AinaldyruMin()
    //    {
    //        return (hour * 60 + min + sec / 60);
    //    }
    //    public static void Info(Nusqa4 nn)
    //    {
    //        Console.WriteLine("AinaldyruSec - " + nn.AinaldyruSec());
    //        Console.WriteLine("AinaldyruMin - " + nn.AinaldyruMin());
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa4 uagyt = new Nusqa4(2, 23, 11);
    //        uagyt.SecondOperation();
    //        Nusqa4.Info(uagyt);
    //        Console.ReadKey();
    //    }
    //}

    class Nusqa6
    {
        public string name;
        public int shotNumber;
        public double premium;
        public double shotMoney;
        public Nusqa6(string name, int shotNumber, int premium, int shotMoney)
        {
            this.name = name;
            this.shotNumber = shotNumber;
            this.premium = premium;
            this.shotMoney = shotMoney;
        }
        public double ShotOperation()
        {
            Console.WriteLine("kerek summa engiz: ");
            double aqsha = int.Parse(Console.ReadLine());
            return shotMoney - aqsha;
        }
        public double Premium()
        {
            Console.WriteLine("stazh engiz: ");
            int stazh = int.Parse(Console.ReadLine());
            switch (stazh)
            {
                case 5: return premium + premium * 0.05;
                case 10: return premium + premium * 0.1;
                case 20: return premium + premium * 0.2;
                case 30: return premium + premium * 0.3;
                default: return premium;
            }
            Console.WriteLine("Name: " + name + "\nPremia summasy: " + premium);
        }
        public void Info()
        {
            Console.WriteLine("Name: " + name + "\nShot nomeri: " + shotNumber + "\nShottagy agsha: " + shotMoney);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Nusqa6 shot = new Nusqa6("Erassyl", 7777777, 10000, 757400);
            shot.Info();
            Console.WriteLine();
            Console.WriteLine("Shottagy qalgan agsha: " + shot.ShotOperation());
            Console.WriteLine();
            Console.WriteLine("Premia summasy: " + shot.Premium());
            Console.ReadKey();
        }
    }

    //class Nusqa8
    //{
    //    public int k;
    //    public int n;
    //    public Nusqa8(int k, int n)
    //    {
    //        this.k = k;
    //        this.n = n;
    //    }
    //    public int Factorial(int nn)
    //    {
    //        int factorial = 1;
    //        for (int i = 1; i <= nn; i++)
    //            factorial *= i;
    //        return factorial;
    //    }
    //    public void Iqtimaldylyk()
    //    {
    //        if (k < n)
    //        {
    //            int C = 0;
    //            C = Factorial(n) * ((Factorial(n - k) * Factorial(k)));
    //            Console.WriteLine("Iqtimaldylyk: " + C);
    //        }
    //        else Console.WriteLine("k n-nan ulken!!!");
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa8 koordinatsia = new Nusqa8(2, 3);
    //        koordinatsia.Iqtimaldylyk();
    //        Console.ReadKey();
    //    }
    //}

    //class Nusqa10
    //{
    //    public double telNomeri;
    //    public double baga1Min;
    //    public double jenildik;
    //    public double soilesuUagytMin;
    //    public double aksha;
    //    public Nusqa10(double telNomeri, double baga1Min, double jenildik, double soilesuUagytMin, double aksha)
    //    {
    //        this.telNomeri = telNomeri;
    //        this.baga1Min = baga1Min;
    //        this.soilesuUagytMin = soilesuUagytMin;
    //        this.jenildik = jenildik;
    //        this.aksha = aksha;
    //    }
    //    public double Price()
    //    {
    //        Console.WriteLine("ozgeris engiz: ");
    //        double number = double.Parse(Console.ReadLine());
    //        Console.WriteLine("\n-bez skidok-- price minutyna " + (baga1Min + number) + "$");
    //        return baga1Min + number;
    //    }
    //    public double Jenildik()
    //    {
    //        baga1Min = Price() * jenildik / 100;
    //        Console.WriteLine("\n-so skidkoi-- % skidkamen price minutyna " + baga1Min + "$");
    //        return baga1Min;
    //    }
    //    public void AkshaInfo()
    //    {
    //        if (soilesuUagytMin >= 10)
    //        {
    //            aksha = soilesuUagytMin * Jenildik();
    //            Console.WriteLine("Abonent nomeri - " + telNomeri + "\nSoilesu uagyty - " + soilesuUagytMin + "\nTolemge arnalgan summasy - " + aksha);
    //        }
    //        else
    //        {
    //            aksha = soilesuUagytMin * Price();
    //            Console.WriteLine("Abonent nomeri - " + telNomeri + "\nSoilesu uagyty - " + soilesuUagytMin + "\nTolemge arnalgan summasy - " + aksha);
    //        }
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa10 telefon = new Nusqa10(87764627293, 8, 50, 10, 0);
    //        telefon.AkshaInfo();
    //        Console.ReadKey();
    //    }
    //}

    //class Nusqa12
    //{
    //    public int a1 {get; set;}
    //    public int d {get; set;}
    //    public Nusqa12(int a1, int d) 
    //     { 
    //         this.a1 = a1; 
    //         this.d = d; 
            }
    //    public int TandalganMushe(int n)
    //    {
    //        int an = a1 + (n - 1) * d;
    //        return an;
    //    }
    //    public int TandalganKosyndy(int n)
    //    {
    //        int sn = (TandalganMushe(n) + a1) * n / 2;
    //        return sn;
    //    }
    //    public void Info(int n)
    //    {
    //        Console.WriteLine("a1=" + a1 + "\nd=" + d + "\nTandalganMushe=" + TandalganMushe(n) + "\nTandalganKosyndy=" + TandalganKosyndy(n));
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa12 arif = new Nusqa12(2, 3);
    //        Console.Write("mushe engiz: ");
    //        int n = int.Parse(Console.ReadLine());
    //        arif.TandalganMushe(n);    //10
    //        arif.TandalganKosyndy(n);
    //        arif.Info(n);
    //        Console.ReadKey();
    //    }
    //}

}
