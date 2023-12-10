using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace esep2
{
    class Sportsmen
    {
        public int id_sportsman;
        public string sportsman_name;
        public string sport_section;
        public int the_weight;

        public Sportsmen(int id_sportsman, string sportsman_name, string sport_section, int the_weight)
        {
            this.id_sportsman = id_sportsman;
            this.sportsman_name = sportsman_name;
            this.sport_section = sport_section;
            this.the_weight = the_weight;
        }
        public void Shygaru()
        {
            Console.WriteLine(sportsman_name + " " + sport_section + " " + the_weight);
        }
    }
    class Sport_section
    {
        public int id_sport_section;
        public int id_sportsman;
        public string sport_section;
        public string category;
        public string the_rules;

        public Sport_section(int id_sport_section, int id_sportsman, string sport_section, string category, string the_rules)
        {
            this.id_sport_section=id_sport_section;
            this.id_sportsman = id_sportsman;
            this.sport_section = sport_section;
            this.category = category;
            this.the_rules = the_rules;
        }

        public void Shygaru()
        {
            Console.WriteLine(sport_section + " " + category + " " + the_rules + " ");
        }
    }
    class Competiton
    {
        public int id_sport_section;
        public string result;
        public DateTime data;

        public Competiton(int id_sport_section, string result, DateTime data)
        {
            this.id_sport_section = id_sport_section;
            this.result = result;
            this.data = data;
        }
    }
    public class Program
    {
        static void Main()
        {
            List<Abonent> Abonentter = new List<Abonent>
            {
                new Abonent(1,"A1","Zhansugyrova 12",87473234241),
                new Abonent(2,"A2","Abylaihana 345",87053457682),
                new Abonent(3,"A3","Ryskulova 23b",87476783298),
                new Abonent(4,"A4","Shalapina 37",87472378191),
                new Abonent(5,"A5","Zhandosova 121",87056783241),
                new Abonent(6,"A6","Auezova 78a",87777839270),
                new Abonent(7,"A7","Kurmangazy 92",87087453729),
                new Abonent(8,"A8","Bokina 27",87479972643),
                new Abonent(9,"A9","Seifullina 3",87085635621),
                new Abonent(10,"A10","Esenberlina 112",87056783254)
            };
            List<Book> Books = new List<Book>
            {
                new Book(1,"Чистый код: создание, анализ и рефакторинг","Роберт Мартин",2018),
                new Book(2,"Приемы объектно-ориентированного проектирования. Паттерны проектирования","Эрих Гамма, Ральф Джонсон, Джон Влиссидес",2020),
                new Book(3,"Программист-фанатик","Фаулер Чад",2015),
                new Book(4,"Грокаем алгоритмы. Иллюстрированное пособие для программистов и любопытствующих","Адитья Бхаргава",2018),
                new Book(5,"Эффективная работа с унаследованным кодом","Майкл Физерс",2018),
                new Book(6,"Экстремальное программирование. Разработка через тестирование","Бек Кент",2017),
                new Book(7,"Unity и C#. Геймдев от идеи до реализации","Джереми Гибсон Бонд",2018),
                new Book(8,"Программирование на C# для начинающих. Особенности языка","Алексей Васильев",2018),
                new Book(9,"Алгоритмы. Разработка и применение","Джон Клейнберг, Ева Тардос",2016),
                new Book(10,"Android. Программирование для профессионалов","Билл Филлипс",2016)
            };
            List<Recording> Record = new List<Recording>()
            {

            };
            Console.WriteLine("book_aty + " + "book_avtor" +" book_data");
            Console.WriteLine();
        }
    }
}   
