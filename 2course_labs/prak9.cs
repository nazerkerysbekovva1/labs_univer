using System;
using System.Collections;

namespace prak9
{
    //class Sportsman: IComparable
    //{
    //    public string name;
    //    public string sport_section;
    //    public string date_of_birth;
    //    public string pol;
    //    public int height;
    //    public int weight;

    //    public Sportsman(string name, string sport_section, string date_of_birth, string pol, int height, int weight)
    //    {
    //        this.name = name;
    //        this.sport_section = sport_section;
    //        this.date_of_birth = date_of_birth;
    //        this.pol = pol;
    //        this.height = height;
    //        this.weight = weight;
    //    }

    //    public int CompareTo(Object ob)
    //    {
    //        if (ob == null) return 1;
    //        if (!(ob is Sportsman))
    //            throw new ArgumentException();

    //        Sportsman sp = (Sportsman)ob;
    //        if (sp.height == this.height)
    //            return 0;
    //        else if (sp.height < this.height)
    //            return 1;
    //        else return -1;
    //    }

    //    public void Shygaru()
    //    {
    //        Console.WriteLine("- - - - - - - - - - - - - -");
    //        Console.WriteLine("_Sportshy: " + name + "\n_Sport section: " + sport_section + "\n_Date_of_birth:" + date_of_birth + "\n_Pol:" + pol + "\n_Height:" + height + "\n_Weight:" + weight);
    //    }
    //}

    //class Sport_club: IEnumerable
    //{
    //    public string name_club;
    //    public string coach;
    //    public Sportsman[] sportsmen;

    //    public Sport_club(string name_club, string coach, Sportsman[] sportsmen)
    //    {
    //        this.name_club = name_club;
    //        this.coach = coach;
    //        this.sportsmen = sportsmen;
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        return sportsmen.GetEnumerator();
    //    }

    //    public IEnumerable Sortirovka(bool sort)
    //    {
    //        Array.Sort(sportsmen);
    //        if (sort)
    //        {
    //            for (int i = 0; i < sportsmen.Length; i++)
    //            {
    //                yield return sportsmen[i];
    //            }
    //        }
    //        else
    //        {
    //            foreach (Sportsman c in sportsmen)
    //            {
    //                yield return c;
    //            }
    //        }
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Sportsman[] sp1 = {
    //            new Sportsman("Нурадин Б", "Плавание","02.08.2005","er", 174, 50),
    //            new Sportsman("Омирбек А", "Плавание","15.09.2008","aiel", 168, 42),
    //            new Sportsman("Абдимбекова А", "Плавание", "04.07.2008","aiel",169, 41) };
    //        Sportsman[] sp2 = {
    //            new Sportsman("Бекдаулет М", "Таеквандо", "25.12.2009","er", 178, 35),
    //            new Sportsman("Аскерова А", "Таеквандо", "13.08.2006","aiel",171, 37) };

    //        Console.WriteLine("Sport_club: \n");
    //        Sport_club a = new Sport_club("Akula", "Ғанидин О", sp1);
    //        Sport_club b = new Sport_club("Tarlan", "Айдарбеков А", sp2);

    //        Console.WriteLine("__________________________________________1:" +
    //            "\nName_club: " + a.name_club+ "\nCoach: "+ a.coach);
    //        foreach (Sportsman aa in a)
    //            aa.Shygaru();
    //        Console.WriteLine("___________________________________________2:" +
    //            "\nName_club: " + a.name_club + "\nCoach: " + a.coach);
    //        foreach (Sportsman sportsman in a.Sortirovka(true))
    //            sportsman.Shygaru();

    //        Console.WriteLine("__________________________________________1:" +
    //            "\nName_club: " + b.name_club + "\nCoach: " + b.coach);
    //        foreach (Sportsman bb in b)
    //            bb.Shygaru();
    //        Console.WriteLine("___________________________________________2:" +
    //            "\nName_club: " + b.name_club + "\nCoach: " + b.coach);
    //        foreach (Sportsman sportsman in b.Sortirovka(true))
    //            sportsman.Shygaru();

    //        Console.Read();
    //    }
    //}


    //10nusqa
    class Teledidar:IComparable
    {
        public string firma;
        public string model;
        public double kolemi;
        public double salmagy;
        public double bagasy;
        public Teledidar(string f, string m, double k, double s, double b)
        {
            firma = f;
            model = m;
            kolemi = k;
            salmagy = s;
            bagasy = b;
        }
        public int CompareTo(Object ob)
        {
            if (ob == null) return 1;
            if (!(ob is Teledidar))
                throw new ArgumentException();

            Teledidar tel = (Teledidar)ob;
            if (tel.bagasy == this.bagasy)
                return 0;
            else if (tel.bagasy < this.bagasy)
                return 1;
            else return -1;
        }
        public void Info()
        {
            Console.WriteLine("------");
            Console.WriteLine($"_Firma: {firma} \n_Model: {model} \n_Kolemi: {kolemi} \n_Salmagy: {salmagy} \n_Bagasy: {bagasy}");
        }
    }
    class TurmystyqElectronika : IEnumerable
    {
        public string aty;
        public string mekenZhayi;
        Teledidar[] teledidars;
        public TurmystyqElectronika(string a, string m, Teledidar[] t)
        {
            aty = a;
            mekenZhayi = m;
            teledidars = t;
        }
        public IEnumerator GetEnumerator()
        {
            return teledidars.GetEnumerator();
        }
        public IEnumerable Sortirovka(bool sort)
        {
            Array.Sort(teledidars);
            if (sort)
            {
                for (int i = 0; i < teledidars.Length; i++)
                {
                    yield return teledidars[i];
                }
            }
            else
            {
                foreach (Teledidar c in teledidars)
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
            Teledidar[] t = {
                    new Teledidar("A", "a", 111,111, 3000),
                    new Teledidar("B", "b", 222,222, 1000),
                    new Teledidar("C", "c", 333,333, 2000)};

            TurmystyqElectronika el = new TurmystyqElectronika("Sulpak", "Turkestan", t);

            Console.WriteLine("Turmystyq Electronika dukeni: \n");
            Console.WriteLine($"_MagazAty: {el.aty} \n_Meken zhayi: {el.mekenZhayi} \n_Teledidarlar:");
            foreach (Teledidar tel in el.Sortirovka(true))
                tel.Info();

            Console.Read();
        }
    }
}
