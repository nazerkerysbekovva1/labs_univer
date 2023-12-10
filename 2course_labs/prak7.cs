using System;

namespace prak7
{
    class Samolet
    {
        public string marka;
        public string model;
        public double max_speed;
        public double height;

        public Samolet(string mr, string ml, double ms, double ht)
        {
            marka = mr;
            model = ml;
            max_speed = ms;
            height = ht;
        }

        public virtual double Price()
        {
            return max_speed * 1000 + height * 100;
        }

        public void Information()
        {
            Console.WriteLine("Самолет: " + "\nmarka: " + marka + "\nmodel: " + model + "\nmax_speed: " + max_speed+" km/ch" + "\nheight: " + height+" m" + "\nPrice: " + Price()+" tenge");
        }
    }
    class Bomber : Samolet
    {
        public Bomber(string mr, string ml, double ms, double ht) : base(mr, ml, ms, ht) { }
        public override double Price()
        {
            Console.WriteLine("__удвоенная стоимость");
            return base.Price() * 2;
        }
    }
    class Fighter : Samolet
    {
        public Fighter(string mr, string ml, double ms, double ht) : base(mr, ml, ms, ht) { }
        public override double Price()
        {
            Console.WriteLine("__утроенная стоимость");
            return base.Price() * 3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Samolet s = new Samolet("Airbus", "A300", 11230, 37650);
            s.Information();
            Console.WriteLine();
            Bomber b = new Bomber("Airbus Bomber", "A300", 11230, 37650);
            b.Information();
            Console.WriteLine();
            Fighter f = new Fighter("Airbus Fighter", "A300", 11230, 37650);
            f.Information();

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
