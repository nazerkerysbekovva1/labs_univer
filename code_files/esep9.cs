using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka_10
{
    delegate void TemirStateHandler(string information);
    abstract class Temir
    {
        public double qalyndyq;
        public double tygyzdyq;
        public Temir(double a, double b)
        {
            qalyndyq = a;
            tygyzdyq = b;
        }
        public abstract double Audan();
        public TemirStateHandler _del;
        public abstract void AcceptHandler(TemirStateHandler del);
        public double Salmaq()
        {
            return Audan() * tygyzdyq * qalyndyq;
        }
        public abstract void Display();
    }
    class Sharshy : Temir
    {
        public double qabyrga;
        public Sharshy(double a, double b, double c) : base(a, b)
        {
            qabyrga = c;
        }

        public override void AcceptHandler(TemirStateHandler del)
        {
            _del = del;
        }

        public override double Audan()
        {
            double audan = qabyrga * qabyrga;

            return audan;
        }
        public override void Display()
        {
            _del($"Qabyrga: {qabyrga}mm;  tygyzdygy: {tygyzdyq}kg/mm3; qalyndyq: {qalyndyq}mm;\nAudany: {Audan()}mm2; Salmagy: {Salmaq()}kg");

        }

    }
    class Tiktortburysh : Temir
    {
        public double uzyndyq;
        public double eni;
        public Tiktortburysh(double a, double b, double c, double d) : base(a, b)
        {
            uzyndyq = c;
            eni = d;
        }

        public override void AcceptHandler(TemirStateHandler del)
        {
            _del = del;
        }

        public override double Audan()
        {
            return uzyndyq * eni;
        }
        public override void Display()
        {
            _del($"Uzyndyq: {uzyndyq}mm; eni: {eni}mm; tygyzdygy: {tygyzdyq}kg/mm3; qalyndyq: {qalyndyq}mm;\nAudany: {Audan()}mm2; Salmagy{Salmaq()}");

        }
    }
    class Ushburysh : Temir
    {
        public double katet1;
        public double katet2;
        public Ushburysh(int a, int b, int c, int d) : base(a, b)
        {
            katet1 = c;
            katet2 = d;
        }

        public override void AcceptHandler(TemirStateHandler del)
        {
            _del = del;
        }

        public override double Audan()
        {
            return (katet1 * katet2) / 2;
        }
        public override void Display()
        {
            _del($"Katet1: {katet1}mm; katet2: {katet2}mm; tygyzdygy: {tygyzdyq}kg/mm3; qalyndyq: {qalyndyq}mm;\nAudany: {Audan()}mm2; Salmagy: {Salmaq()}");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {



            Temir[] mas = { new Sharshy(1,1,1), new Sharshy(2,2,2), new Sharshy(3,3,3), new Sharshy(4,4,4), new Sharshy(5,5,5), 
                            new Tiktortburysh(1,1,1,2), new Tiktortburysh(2,2,2,3), new Tiktortburysh(3,3,3,4), new Tiktortburysh(4,4,4,5), new Tiktortburysh(5,5,5,6), new Tiktortburysh(6,6,6,7), new Tiktortburysh(7,7,7,8),
                            new Ushburysh(1,1,1,1), new Ushburysh(2,2,2,2), new Ushburysh(3,3,3,3)};

            foreach (Temir a in mas)
            {
                a.AcceptHandler(ColorInfo);
                a.Display();
            }
            Console.ReadKey();
        }
        static void Info(String information)
        {
            Console.WriteLine(information);
        }
        static void ColorInfo(String information)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(information);
            Console.ResetColor();
        }
    }
}