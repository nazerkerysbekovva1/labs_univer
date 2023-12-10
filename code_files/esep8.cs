using System;
using System.Collections.Generic;
namespace SRS_Avtosalon
{
    class Qyzmetkerler
    {
        public int ID;
        public string FIO;
        public int Zarplata;
        public long Nomeri;
        public Qyzmetkerler(int ID, string FIO, int Zarplata, long Nomeri)
        {
            this.ID = ID;
            this.FIO = FIO;
            this.Zarplata = Zarplata;
            this.Nomeri = Nomeri;
            kolikter = new List<Kolikter>();


        }
        public List<Kolikter> kolikter;


        public void Info_Qyzmetkerler()
        {
            Console.WriteLine("\nИдентификатор сотрудника: " + ID + "\nФИО: " + FIO + "\nЗарплата: " + Zarplata + " тг" + "\nНомер телефона: " + Nomeri);
        }
        public static void Inf(List<Qyzmetkerler> qyzmetkerler, int id)
        {
            foreach (Qyzmetkerler q in qyzmetkerler)
            {
                if (q.ID == id)
                {
                    q.Info_Qyzmetkerler();
                }
            }
        }


    }
    class Kolikter
    {
        public int ID_avto;
        public string Marka;
        public string Strana;
        public string Color;
        public int God_vypuska;
        public int Price;
        public int Kolichestvo;
        public Kolikter(int ID_avto, string Marka, string Strana, string Color, int God_vypuska, int Price, int Kolichestvo)
        {
            this.ID_avto = ID_avto;
            this.Marka = Marka;
            this.Strana = Strana;
            this.Color = Color;
            this.God_vypuska = God_vypuska;
            this.Price = Price;
            this.Kolichestvo = Kolichestvo;
            qyzmetkerler = new List<Qyzmetkerler>();

        }
        public List<Qyzmetkerler> qyzmetkerler;


        public void Info_Kolikter()
        {
            Console.WriteLine("\nИдентификатор авто: " + ID_avto + "\nМарка : " + Marka + "\nСтрана:" + Strana + "\nЦвет: " + Color + "\nГод выпуска: " + God_vypuska + "\nЦена: " + Price + " тг" + "\nКоличество: " + Kolichestvo + " штук");
        }

        public static void Info(List<Kolikter> kolikter, int id_avto)
        {
            foreach (Kolikter k in kolikter)
            {
                if (k.ID_avto == id_avto)
                {
                    k.Info_Kolikter();
                }
            }

        }
        public static void Avto_satu(Kolikter k, Qyzmetkerler q, int i, int c)
        {
            int san; double syiaqy;
            if (i == 1)
            {

                san = k.Kolichestvo - 1;

                Console.WriteLine("Автомобиль " + k.Marka + " был продан");
                Console.WriteLine(k.Marka + " выехала из салона. " + "\nОсталось " + san + " автомобилей " + k.Marka);
            }

            else
                Console.WriteLine("Клиент ничего не купил!");

            if (c == 1)
            {
                syiaqy = k.Price * 5 / 100;
                Console.WriteLine("Сотруднику " + q.FIO + " вознаграждение в сумме " + syiaqy + " тг");
            }
            if (c == 3)
            {
                syiaqy = k.Price * 6 / 100;
                Console.WriteLine("Сотруднику " + q.FIO + " вознаграждение в сумме " + syiaqy + " тг");
            }
            if (c == 5)
            {
                syiaqy = k.Price * 7 / 100;
                Console.WriteLine("Сотруднику " + q.FIO + " вознаграждение в сумме " + syiaqy + " тг");
            }

            if (c == 0)
            {
                Console.WriteLine("Вознаграждение сотруднику" + q.FIO + " не начисляется!");
            }
        }

        class Klient
        {
            public string Name;
            public string Sname;
            public string Nomer;


            public Klient(string Name, string Sname, string Nomer)
            {
                this.Name = Name;
                this.Sname = Sname;
                this.Nomer = Nomer;
            }

            public void Info_klient()
            {
                Console.WriteLine("Клиент: " + Sname + Name + "\nНомер:" + Nomer);
            }


            class Program
            {
                static void Main()
                {
                    List<Qyzmetkerler> qyzmetkerler = new List<Qyzmetkerler>
            {
                new Qyzmetkerler(1,"Келменбетов Алмаз", 150000, 87472017526),
                new Qyzmetkerler(2,"Мухамедиярулы Акжол", 150000, 87072017526),
                new Qyzmetkerler(3,"Талап Гибрат", 150000, 87772017524),
                new Qyzmetkerler(4,"Артыкбаев Тимур", 150000, 87712017375),
                new Qyzmetkerler(5,"Ерсары Нурдаулет", 150000, 87002018536),
                new Qyzmetkerler(6,"Хамзабек Нурсултан", 150000, 87002417536),
                new Qyzmetkerler(7,"Эльбрус Ерасыл", 150000, 87002017336),
                new Qyzmetkerler(8,"Ермекова Гулдиана", 150000, 87002014536),
                new Qyzmetkerler(9,"Рысбек Назерке", 150000, 87002017556),
                new Qyzmetkerler(10,"Келменбет Нурсултан", 150000, 87002717536)

            };
                    List<Kolikter> kolikter = new List<Kolikter>
            {
                new Kolikter(1,"Mercedes", "Germany", "Black", 2021, 15000000, 6),
                new Kolikter(2,"Audi", "Germany", "White", 2020, 10000000, 10),
                new Kolikter(3,"Toyota", "Japan", "Black", 2020, 12000000, 7),
                new Kolikter(4,"Lexus", "Japan", "Blue", 2021, 14000000, 10),
                new Kolikter(5,"Ford", "USA", "Blue", 2020, 9000000, 12),
                new Kolikter(6,"Lexus 570", "Japan", "Yellow", 2021, 13000000, 10),
                new Kolikter(7,"BMW", "Germany", "Black", 2020, 18000000, 8),
                new Kolikter(8,"Golf", "Germany", "Black", 2020, 8000000, 10),
                new Kolikter(9,"Lada", "Germany", "Black", 2020, 5000000, 9),
                new Kolikter(10,"BMW M5", "Germany", "Black", 2020, 17000000, 10)
            };

                    Console.Write("Введите вашу фамилию: ");
                    string sname = Console.ReadLine();
                    Console.Write("Введите ваше имя:");
                    string name = Console.ReadLine();
                    Console.Write("Введите ваш номер телефона: ");
                    string nomer = Console.ReadLine();
                    Console.Clear();
                    Klient klient = new Klient(sname, name, nomer);

                    foreach (Qyzmetkerler q in qyzmetkerler)
                    {
                        q.Info_Qyzmetkerler();
                    }
                    Console.WriteLine("-----------------------------------");

                    Console.Write("Выберите идентификатор сотрудника: ");
                    int id = int.Parse(Console.ReadLine());
                    foreach (Kolikter k in kolikter)
                    {
                        k.Info_Kolikter();
                    }

                    Console.WriteLine("-----------------------------------");

                    foreach (Kolikter k in kolikter)
                    {
                        k.Info_Kolikter();
                    }

                    Console.WriteLine("-----------------------------------");

                    Console.Write("Выберите идентификатор автомобиля: ");
                    int id_avto = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Qyzmetkerler.Inf(qyzmetkerler, id);
                    Kolikter.Info(kolikter, id_avto);
                    Console.WriteLine("Нажмите 1, чтобы купить | Нажмите любую кнопку, чтобы выйти: ");
                    int i = int.Parse(Console.ReadLine());
                    Console.WriteLine("Оцените работу сотрудника!");
                    Console.WriteLine("Если средний то 1 | Если хорошо то 3 | Если отлично то 5 | Если не хотите то 0");
                    int c = int.Parse(Console.ReadLine());
                    Kolikter.Avto_satu(kolikter[id_avto - 1], qyzmetkerler[id - 1], i, c);
                    klient.Info_klient();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Вы успешно совершили покупку!");
                    Console.ReadKey();
                }
            }
        }
    }
}