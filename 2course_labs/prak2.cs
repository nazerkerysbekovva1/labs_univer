using System;

namespace prak2
{
    //class Nusqa2
    //{
    //    public double b1;
    //    public double q;
    //    public double TandalganMushe(double n)
    //    {
    //        double bn = b1 * (Math.Pow(q, n - 1));
    //        return bn;
    //    }
    //    public double TandalganKosyndy(double n)
    //    {
    //        double sn = (TandalganMushe(n) * q - b1) / (q - 1);
    //        return sn;
    //    }
    //    public void Info(double n)
    //    {
    //        Console.WriteLine("b1=" + b1 + "\nq=" + q + "\nTandalganMushe=" + TandalganMushe(n) + "\nTandalganKosyndy=" + TandalganKosyndy(n));
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa2 geo = new Nusqa2();
    //        geo.b1 = 2;
    //        geo.q = 3;
    //        Console.Write("mushe engiz: ");
    //        double n = double.Parse(Console.ReadLine());
    //        geo.TandalganMushe(n);
    //        geo.TandalganKosyndy(n);
    //        geo.Info(n);
    //        Console.ReadKey();
    //    }
    //}

    //class Nusqa4
    //{
    //    public int hour;
    //    public int min;
    //    public int sec;
    //    public Nusqa4(int h, int m, int s)
    //    {
    //        hour = h; min = m; sec = s;
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
    //    public void Info()
    //    {
    //        Console.WriteLine("AinaldyruSec - " + AinaldyruSec());
    //        Console.WriteLine("AinaldyruMin - " + AinaldyruMin());
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Nusqa4 uagyt = new Nusqa4(2, 23, 11);
    //        uagyt.SecondOperation();
    //        uagyt.Info();
    //        Console.ReadKey();
    //    }
    //}

    class Esepshot
    {
        public string name;
        public int shotNumber;
        public double premium;
        public double shotMoney;
        public Esepshot(string name, int shotNumber, int premium, int shotMoney)
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
            Esepshot shot = new Esepshot("Erassyl", 7777777, 10000, 757400);
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
    //    public int a1;
    //    public int d;
    //    public Nusqa12(int a1, int d) { this.a1 = a1; this.d = d; }
    //    public int TandalganMushe(int n)
    //    {
    //        int an = a1+(n-1)*d;
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
//    {
//        static void Main(string[] args)
//        {
//            Nusqa12 arif = new Nusqa12(2,3);
//            Console.Write("mushe engiz: ");
//            int n = int.Parse(Console.ReadLine());
//            arif.TandalganMushe(n);
//            arif.TandalganKosyndy(n);
//            arif.Info(n);
//            Console.ReadKey();
//        }
//    }
}
