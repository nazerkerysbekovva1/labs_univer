using System;
using System.Collections.Generic;
namespace Cinema
{
    class Movie
    {
        public static string Venom = "Веном 2";
        public static string NoTimetoDie = "Не время умерать";
        public static string Dune = "Дюна";
        public static string Shang_Chi = "Шан-чи и легенда десяти колец";
        public static string TheAddamsFamily = "Семейка Аддамс: Горящий тур";
        public static string Eiffel = "Эйфель";
        public void Choose_Movie()
        {
            Dictionary<int, string> filmnumber = new Dictionary<int, string>();
            filmnumber.Add(1, Venom);
            filmnumber.Add(2, NoTimetoDie);
            filmnumber.Add(3, Dune);
            filmnumber.Add(4, Shang_Chi);
            filmnumber.Add(5, TheAddamsFamily);
            filmnumber.Add(6, Eiffel);
            Console.WriteLine("Cписок фильмов:\n 1. {0}\n 2. {1}\n 3. {2}\n 4. {3}\n 5. {4}\n 6. {5}", Venom, NoTimetoDie, Dune, Shang_Chi, TheAddamsFamily, Eiffel);
            Console.WriteLine("Выберите фильм(введите номер фильма): ");
            int fn = int.Parse(Console.ReadLine());
            Console.WriteLine(filmnumber[fn]);
        }
    }
    class Place
    {
        public int[,] place;
        
        public void Bos_Oryn()
        {
            int p = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    p++;
                    if ((p - 1) % 10 != 0 || p == 1) Console.Write("{0}  ", p);
                    else Console.Write("\n{0}  ", p);


                }
                Console.WriteLine();

                for (int q = 0; q < 10; q++)
                {
                    if (place[i, q] == 1)
                    {
                        if (i == 0) Console.Write("{0}  ", place[i, q]);
                        else Console.Write("{0}   ", place[i, q]);
                    }
                    else
                    {
                        if (i == 0) Console.Write("{0}  ", place[i, q]);
                        else Console.Write("{0}   ", place[i, q]);
                    }
                }
            }
            Console.WriteLine();
        }
        public void OrynAlu(int o)
        {
            int a = (o - 1) / 10;
            int b = o % 10 - 1;
            place[a, b] = 1;
        }
    }
    class Kassa
    {
        public int detski_bilet;
        public int vzrosli_bilet;
        public int biletforstudents;
        public int bilet_sany;
        public Kassa(int bs)
        {
            bilet_sany = bs;
        }
        public void Bilet()
        {
            Console.WriteLine("Сколько детских билетов нужно(до 15 лет) ");
            int db = int.Parse(Console.ReadLine());
            Console.WriteLine("Сколько билетов для студентов (скидка 20%) ");
            int bfs = int.Parse(Console.ReadLine());
            detski_bilet = db;
            biletforstudents = bfs;
            vzrosli_bilet = bilet_sany - detski_bilet - biletforstudents;
            Console.WriteLine("Сумма = {0} тг", Bilet_Chek());
        }
        public int Bilet_Chek()
        {
            return vzrosli_bilet * 1300 + detski_bilet * 700 + biletforstudents * 1040;
        }

    }
    class Magaz
    {
        public int popcorn;
        public int crisps;
        public int coca_cola;
        public int kirieshki;
        public void Menu()
        {
            Console.Write("\nЕще что-нибудь купите?(Если да, то введите \"1\", если нет, то введите \"0\") ");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                Console.WriteLine("============MENU============");
                Console.WriteLine("Товар         Стоимость  Сколько штук");
                Console.Write("Попкорн           500 тг     "); popcorn = int.Parse(Console.ReadLine());
                Console.Write("Кока кола(0,5 л)  300 тг     "); coca_cola = int.Parse(Console.ReadLine());
                Console.Write("Чипсы             350 тг     "); crisps = int.Parse(Console.ReadLine());
                Console.Write("Кириешки          250 тг     "); kirieshki = int.Parse(Console.ReadLine());
            }
            if (answer == 0)
            {
                popcorn = 0; crisps = 0; coca_cola = 0; kirieshki = 0;
            }
            Console.WriteLine("Сумма = {0} тг", Chek());
        }
        public int Chek()
        {
            return popcorn * 500 + crisps * 350 + coca_cola * 300 + kirieshki * 250;
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Movie m = new Movie();
            m.Choose_Movie();
            Console.WriteLine();
            Place kino = new Place();
            kino.place = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    kino.place[i, j] = 0;
                }
            }
            Console.WriteLine("Свободные места");
            kino.Bos_Oryn();
            Console.Write("\nСколько билетов нужно ");
            int bs = int.Parse(Console.ReadLine());
            for(int i = 1; i <= bs; i++)
            {
                Console.Write("\nКакое место нужно ");
                int o = int.Parse(Console.ReadLine());
                kino.OrynAlu(o);
            }
            Console.Clear();
            kino.Bos_Oryn();
            Kassa chek = new Kassa(bs);
            chek.Bilet();
            Magaz magaz = new Magaz();
            magaz.Menu();
            Console.WriteLine("Общая сумма = {0}тг", chek.Bilet_Chek() + magaz.Chek());
        }
    }
}
