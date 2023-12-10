using System;
using System.Collections;
namespace labka9interface
{
    public class TV : IComparable
    {
        public string Firma { get; set; }
        public int Model { get; set; }
        public int Kolem { get; set; }
        public int Salmagy { get; set; }
        public int Bagasy { get; set; }
        public TV(string firma, int model, int kolem, int salmagy, int bagasy)
        {
            Firma = firma;
            Model = model;
            Kolem = kolem;
            Salmagy = salmagy;
            Bagasy = bagasy;
        }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            if (!(obj is TV))
                throw new ArgumentException();
            TV tv = (TV)obj;
            Double diff = this.Kolem - tv.Kolem;
            if (diff == 0)
                return 0;
            else if (diff > 0)
                return 1;
            else return -1;
        }
        public void Display()
        {
            Console.WriteLine("Данные о TV:\n" +
                "- Фирма: {0}\n" +
                "- Model: {1}\n" +
                "- Экран колемі: {2} м^3\n" +
                "- Салмагы: {3} кг\n" +
                "- Багасы: {4} тг\n",
                Firma, Model, Kolem, Salmagy, Bagasy);
        }
    }
    public class Turmystyq_electronica_duken : IEnumerable
    {
        public string Aty { get; set; }
        public string Meken_zhaiy { get; set; }
        public TV[] Televisor;
        public Turmystyq_electronica_duken(string aty, string meken_zhaiy, TV[] tv)
        {
            Aty = aty;
            Meken_zhaiy = meken_zhaiy;
            Televisor = tv;
        }
        public IEnumerator GetEnumerator()
        {
            return Televisor.GetEnumerator();
        }
        public IEnumerable Sort(bool sort)
        {
            if (sort)
            {
                for (int i = 0; i < Televisor.Length; i++)
                {
                    yield return Televisor[i];
                }
            }
            else
            {
                foreach (TV c in Televisor)
                {
                    yield return c;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TV[] tv = { new TV("Samsung", 1123, 124, 15, 449990),
                new TV("LG", 1232, 115, 12, 599990),
                new TV("OLED", 4221, 120, 10, 1099990) };
            Console.WriteLine("Turmystyq_electronica_duken: \n");
            Turmystyq_electronica_duken elec_duken = new Turmystyq_electronica_duken("Mechta", "12A mkr 5 dom", tv);
            Array.Sort(tv);
            Console.WriteLine("Bastapqy turi:\nDuken aty: {0}, meken-zhaiy: {1}\n", elec_duken.Aty, elec_duken.Meken_zhaiy);
            foreach (TV a in elec_duken)
                a.Display();
            Console.WriteLine("Songy turi:\nDuken aty: {0}, meken-zhaiy: {1}\n", elec_duken.Aty, elec_duken.Meken_zhaiy);
            foreach (TV a in elec_duken.Sort(true))
                a.Display();
            Console.Read();
        }
    }
}
