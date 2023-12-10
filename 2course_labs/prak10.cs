using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak10
{ 
    class Samolet
    {
     //   public delegate void Action<T>(T obj);
        public Action samodel;
        public void AA(Action _samodel)
        {
            samodel =_samodel;
        }
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
            Console.WriteLine("______________________________");
            Console.WriteLine("Самолет: " + "\nmarka: " + marka + "\nmodel: " + model + "\nmax_speed: " + max_speed + " km/ch" + "\nheight: " + height + " m" + "\nPrice: " + Price() + " tenge");
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
            Samolet[] array1 = {new Samolet("AirAstana", "A300", 11230, 37650),
                               new Bomber("AirAstana Bomber", "A300", 11230, 37650),
                               new Fighter("AirAstana Fighter", "A300", 11230, 37650) };
            Samolet[] array2 = {new Samolet("Airbus", "kaz01", 12329, 45950),
                               new Bomber("Airbus Bomber", "kaz01", 12329, 45950),
                               new Fighter("Airbus Fighter", "kaz01", 12329, 45950) };

            Action obj;

            foreach (Samolet a in array1)
            {
                obj = a.Information;
                obj();
            }
            foreach (Samolet b in array2)
            {
                obj = b.Information;
                obj();
            }
            Console.ReadLine();
            Console.ReadKey();
        }
        static void Info(string information)
        {
            Console.WriteLine(information);
        }
    } 
}
