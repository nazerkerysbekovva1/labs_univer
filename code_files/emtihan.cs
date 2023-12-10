using System;
using System.Collections.Generic;

namespace emtihan
{
    //class Ushak
    //{
    //    public string marka;
    //    public string model;
    //    public int max_v;
    //    public int max_h;
    //    public Ushak(string marka, string model, int v, int h)
    //    {
    //        this.marka = marka;
    //        this.model = model;
    //        max_v = v;
    //        max_h = h;
    //    }
    //    public virtual int Price()
    //    {
    //        int price = max_v * 1000 + max_h * 100;
    //        return price;
    //    }
    //    public virtual void Info()
    //    {
    //        Console.WriteLine($"marka:{marka} \nmodel:{model} \nmax_v:{max_v} \nmax_h:{max_h} \nprice:{Price()}");
    //    }
    //}
    //class Bomber:Ushak
    //{
    //    public Bomber(string marka, string model, int v, int h): base(marka, model, v, h) { }
    //    public override int Price()
    //    {
    //        return 2* base.Price();
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Ushak[] ushak =
    //        {
    //            new Ushak("qw","qw", 112,123),
    //            new Bomber("we","we", 112, 123)
    //        };
    //        for (int i = 0; i < ushak.Length; i++)
    //        {
    //            Console.WriteLine();
    //            ushak[i].Info();
    //        }
    //    }
    //}


    //class Ushak
    //{
    //    public string marka;
    //    public string model;
    //    public int max_v;
    //    public int max_h;
    //    public Ushak(string marka, string model, int v, int h)
    //    {
    //        this.marka = marka;
    //        this.model = model;
    //        max_v = v;
    //        max_h = h;
    //    }
    // Перегружаем логический оператор ==
    //    public static bool operator ==(Ushak u1, Ushak u2)
    //    {
    //        if ((u1.max_v == u2.max_v) && (u1.max_h == u2.max_h)) return true;
    //        else return false;
    //    }
    // Теперь обязательно нужно перегрузить логический оператор !=
    //    public static bool operator !=(Ushak u1, Ushak u2)
    //    {
    //        if ((u1.max_v == u2.max_v) || (u1.max_h == u2.max_h)) return true;
    //        else return false;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Ushak u1 = new Ushak("qw", "qw", 112, 123);
    //        Ushak u2 = new Ushak("qw", "qw", 112, 123);

    //        if (u1 == u2)
    //            Console.WriteLine("Объекты равны");
    //        else
    //            Console.WriteLine("Объекты неравны");
    //        Console.ReadLine();
    //    }
    //}

    //class Tauar : IComparable
    //{
    //    public string tauar_aty;
    //    public int price;
    //    public DateTime date;

    //    public Tauar(string tauar_aty, int price, DateTime date)
    //    {
    //        this.tauar_aty = tauar_aty;
    //        this.price = price;
    //        this.date = date;
    //    }

    //    public int CompareTo(Object ob)
    //    {
    //        if (ob == null) return 1;
    //        if (!(ob is Tauar))
    //            throw new ArgumentException();

    //        Tauar sp = (Tauar)ob;
    //        if (sp.date == this.date)
    //            return 0;
    //        else if (sp.date < this.date)
    //            return 1;
    //        else return -1;
    //    }
    //    public void Info()
    //    {
    //        Console.WriteLine("- - - - - - - - - - - - - -");
    //        Console.WriteLine("tauar_aty: " + tauar_aty + "\nprice: " + price + "\ndate:" + date);
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tauar[] tauar =
    //        {
    //            new Tauar("albeni", 500, new DateTime(2021,10,10)),
    //            new Tauar("snickers", 500, new DateTime(2021,11,10)),
    //            new Tauar("twix", 500, new DateTime(2021,1,10)),
    //            new Tauar("nestle", 500, new DateTime(2021,9,10)),
    //            new Tauar("kitkat", 500, new DateTime(2021,7,10)),
    //            new Tauar("alpengold", 500, new DateTime(2021,3,10)),
    //            new Tauar("kinder", 500, new DateTime(2021,6,10)),
    //            new Tauar("ozera", 500, new DateTime(2021,12,10)),
    //            new Tauar("biskrem", 500, new DateTime(2021,5,10)),
    //        };
    //        Array.Sort(tauar);
    //        foreach (Tauar aa in tauar)
    //            aa.Info();

    //    }
    //}

    //abstract class Sportshylar
    //{
    //    public string sportshy_aty;
    //    public double zhasy;
    //    public Sportshylar(string sportshy_aty, double zhasy)
    //    {
    //        this.sportshy_aty = sportshy_aty;
    //        this.zhasy = zhasy;
    //    }
    //    public abstract double Algan_bally();
    //    public abstract void Informatcia();
    //}
    //class Dengei_detskii : Sportshylar
    //{
    //    public double synyby;
    //    public Dengei_detskii(string sportshy_aty, double zhasy, double synyby) : base(sportshy_aty, zhasy)
    //    {
    //        this.synyby = synyby;
    //    }

    //    public override double Algan_bally()
    //    {
    //        return (zhasy / synyby)*3;
    //    }
    //    public override void Informatcia()
    //    {
    //        Console.WriteLine("sportshy_aty: " + sportshy_aty + "\nzhasy: " + zhasy + "\nsynyby:" + synyby + "\nAlgan_bally:" + Algan_bally());
    //    }
    //}
    //class Dengei_vzroslyy : Sportshylar
    //{
    //    public double kursy;
    //    public Dengei_vzroslyy(string sportshy_aty, double zhasy, double kursy) : base(sportshy_aty, zhasy)
    //    {
    //        this.kursy = kursy;
    //    }

    //    public override double Algan_bally()
    //    {
    //        return zhasy / kursy;
    //    }
    //    public override void Informatcia()
    //    {
    //        Console.WriteLine("sportshy_aty: " + sportshy_aty + "\nzhasy: " + zhasy + "\nkursy:" + kursy + "\nAlgan_bally:" + Algan_bally());
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Sportshylar[] spor =
    //        {
    //            new Dengei_detskii("Aiym", 12, 5),
    //            new Dengei_vzroslyy("Kunim",19, 2)
    //        };
    //        for(int i=0; i < spor.Length; i++)
    //        {
    //            spor[i].Algan_bally();
    //            spor[i].Informatcia();
    //        }
    //    }
    //}
    public class SportEventArgs : System.EventArgs
    {
        public readonly string sectcia;
        public SportEventArgs(string sect)
        {
            sectcia = sect;
        }
    }
    class SportSectcia
    {
        public string sport_sectcia;
        public string zhattyktyrushy;
        public string kategoria;

        public event EventHandler<SportEventArgs>SportEvent;
        public void OnSportEvent(SportEventArgs sport)
        {
            if (SportEvent != null)
                SportEvent(this, sport);
        }
        public void DisplayMessage2(object sender, SportEventArgs sport)
        {
            Console.WriteLine($"___{sport.sectcia} спортшылары дайындык устынде. '{((SportSectcia)sender).sport_sectcia}' - спортшылары Халыкаралык жарыска баруга жиналатын болады!!!");
        }

        public static void Massiv(List<SportSectcia> sp)
        {
            for (int i = 0; i < sp.Count; i++)
            {
                for (int j = 0; j < sp.Count - 3; j++)
                {
                    if (i != j)
                    {
                        sp[i].SportEvent += sp[j].DisplayMessage2;
                    }
                }
            }
        }

        public SportSectcia(string sport_sectcia, string zhattyktyrushy, string kategoria)
        {
            this.sport_sectcia = sport_sectcia;
            this.zhattyktyrushy = zhattyktyrushy;
            this.kategoria = kategoria;
        }
        public void Collect(string sectcia, List<SportSectcia> sport_Sections)
        {
            foreach (SportSectcia s in sport_Sections)
            {
                if (s.sport_sectcia == sectcia)
                {
                    Console.WriteLine($"'{s.sport_sectcia}' жолдама алды");
                    s.OnSportEvent(new SportEventArgs(sport_sectcia));
                }
                else
                    Console.WriteLine($"'{s.sport_sectcia}' жолдама алмады");
            }
        }
    }
    public class Program
    {
        static void Main()
        {
            List<SportSectcia> sections = new List<SportSectcia>()
            {
                new SportSectcia("Плавание", "Беделхан Ы", "Юниор"),
                new SportSectcia("Таеквандо", "Рахымжанов А",  "Юниор"),
                new SportSectcia("Бокс", "Нурланов Р", "Юниор"),
                new SportSectcia("Футбол", "Абдухашим Д", "Юниор")
            };
            SportSectcia.Massiv(sections);
            string sectcia = "Таеквандо";
            for (int i = 0; i < sections.Count; i++)
            {
                sections[i].Collect(sectcia, sections);
            }
        }
    }
}


