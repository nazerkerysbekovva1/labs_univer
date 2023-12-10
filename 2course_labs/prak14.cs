using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak14
{
    class Knockout
    {
        public DateTime fight_date;
        public TimeSpan beginning_time_fight;
        public string FIO_napadaiushego;
        public string FIO_poterpevshego;
        public int round_number;
        public TimeSpan time_of_round;

        public Knockout(DateTime fight_date, TimeSpan beginning_time_fight, string FIO_napadaiushego, string FIO_poterpevshego, int round_number, TimeSpan time_of_round)
        {
            this.fight_date = fight_date;
            this.beginning_time_fight = beginning_time_fight;
            this.FIO_napadaiushego = FIO_napadaiushego;
            this.FIO_poterpevshego = FIO_poterpevshego;
            this.round_number = round_number;
            this.time_of_round = time_of_round;
        }
        public void Info()
        {
            Console.WriteLine();
            Console.WriteLine($"дата поединка: {fight_date} \nвремя начала поединка: {beginning_time_fight} \nФИО боксера, нанесшего удар: {FIO_napadaiushego}  \nФИО потерпевшего поражение: { FIO_poterpevshego}  \nномер раунда нокаута: {round_number} \nвремя окончания текущего раунда нокаутом: { time_of_round}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Knockout[] kn = new[]
            {
                new Knockout(new DateTime(2021,10,15), new TimeSpan(00,00,00), "Almaz Kelmenbetov", "Nuridin Aidynbekov", 2, new TimeSpan(00,02,00)),
                new Knockout(new DateTime(2021,9,15), new TimeSpan(00,00,00), "Erassyl Elbrus", "Azamat Muhtarov", 1, new TimeSpan(00,03,00)),
                new Knockout(new DateTime(2021,8,15), new TimeSpan(00,00,00), "Nursultan Zauirbek", "Dias Bozhbanbaev", 3, new TimeSpan(00,01,00))
            };

            foreach (var inf in kn)
            {
                inf.Info();
            }

            TimeSpan round = new TimeSpan(00, 03, 00);
            TimeSpan pause = new TimeSpan(00, 02, 00);

            var knn = kn.Where(k => k.round_number == 1 || k.round_number == 2 || k.round_number == 3)
                .Select(t => new 
                { 
                    time_boi = (t.round_number * round + (t.round_number - 1) * pause) - (round - t.time_of_round), 
                    FIO_napadaiushego = t.FIO_napadaiushego, 
                    FIO_poterpevshego=t.FIO_poterpevshego, 
                    round_number=t.round_number });

            Console.WriteLine("\n\n-----1st query-----");
            foreach (var knock in knn)
            {
                Console.WriteLine();
                Console.WriteLine($"время окончания боя нокаутом {knock.time_boi}");
                Console.WriteLine($"'{knock.FIO_napadaiushego}' отправил '{knock.FIO_poterpevshego}' в нокаут в {knock.round_number} раунде");
            }

            DateTime date = DateTime.Now;
            var knn1 = kn.Where(k => (date >= k.fight_date && k.fight_date <= date.AddMonths(-3)));

            Console.WriteLine("\n\n-----2nd query-----");
            foreach (var month in knn1)
            {
                Console.WriteLine();
                Console.WriteLine($"{ month.fight_date}, {month.FIO_poterpevshego} ");
            }

            Console.ReadKey();
        }
    }
}