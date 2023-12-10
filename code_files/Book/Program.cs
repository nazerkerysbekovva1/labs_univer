using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;
using LaYumba.Functional;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Box1> box1 = new List<Box1>()
        {
             new Box1(1, "Цветы для Элджерона", "Дэниел Киз", "Художественная литература", "роман", 1959),
             new Box1(2, "Над пропастью воржи", "Джером Дэвид", "Художественная литература", "приключения", 1951),
             new Box1(3, "Маленькие женщины", "Луиза Мей Олкотт", "Художественная литература", "роман", 1868),
             new Box1(4, "Скотный двор", "Джордж Оруэлл", "Художественная литература", "триллер", 1945),
             new Box1(5, "Десять Негритят", "Агата Кристи", "Художественная литература", "приключения", 1939),
             new Box1(6, "Задача трех тел", "Лю Цысинь", "Художественная литература", "триллер", 2006),
             new Box1(7, "Коллекционер", "Джон Флоуз", "Художественная литература", "роман", 1933),
             new Box1(8, "Живые и мертвые", "Константин Симонов", "Художественная литература", "приключения", 1963),
             new Box1(9, "Смерть на Ниле", "Агата Кристи", "Художественная литература", "триллер", 1937),
             new Box1(10, "Не отпускай меня", "Кадзуо Исигуро", "Художественная литература", "роман", 2002),
        };

        List<Box2> box2 = new List<Box2>()
        {
             new Box2(1, "Происхождение видов", "Чарльз Дарвин", "Наука", "история", 1859),
             new Box2(2, "Феймаонвские лекции по физике", "Ричард Фейман", "Наука", "физика", 1964),
             new Box2(3, "Хомо Деус", "Юваль Ной Харари", "Наука", "история", 2015),
             new Box2(4, "Хаос. Создание новой науки", "Джеимс Клейк", "Наука", "физика",1987),
             new Box2(5, "Двойная спираль", "Джеимс Уотсон", "Наука", "химия", 1968),
             new Box2(6, "Исчезающая ложка", "Сэм Кин", "Наука", "химия", 2020),
             new Box2(7, "Краткая истории химии", "Айзек Азимов", "Наука", "химия", 2002),
             new Box2(8, "Живая математика", "Яков Перельман", "Наука", "математика", 2013),
             new Box2(9, "Путь к реальности", "Роджер Пенроуз", "Наука", "математика", 2007),
             new Box2(10, "Вечность", "Шон Кэрролл", "Наука", "история", 2016),
        };

        List<Box3> box3 = new List<Box3>()
        {
             new Box3(1, "Словарь русского языка", "Сергей Ожегов", "Справочники", "словарь", 1949),
             new Box3(2, "Толковый словарь живого великорусского языка", "Владимир Даль", "Справочники", "словарь", 1863),
             new Box3(3, "Книга рекордов Гиннеса", "Крэг Глендей", "Справочники", "энциклопедия", 1955),
             new Box3(4, "Британская энциклопедия", "Эндрю Белл", "Справочники", "энциклопедия", 1751),
             new Box3(5, "Словарь Сатаны", "Амброз Бирс", "Справочники", "словарь", 1881),
             new Box3(6, "Анатомия Грея", "Ренри Грей", "Справочники", "энциклопедия", 1858),
             new Box3(7, "Итальнского энциклопедия", "Энтони Рпа", "Справочники", "энциклопедия", 1929),
             new Box3(8, "Забытые храмы Свердловской области", "Бурлакова Надежда", "Справочники", "словарь", 2011),
             new Box3(9, "Грузинская", "Кермани Пред", "Справочники", "энциклопедия", 1965),
             new Box3(10, "Исторически словарь американского сленга", "Джонатхан Лаитер", "Справочники", "словарь", 1994),
        };
        
        Books books = new Books(box1, box2, box3);

        List<Books> books1 = new List<Books>();
        foreach(var b in box1)
            books1.Add(b);
        foreach (var b in box2)
            books1.Add(b);
        foreach (var b in box3)
            books1.Add(b);

        List<Konvernoe_linia> linia = new List<Konvernoe_linia>() 
        {
            new Konvernoe_linia("Box1", new TimeSpan(15, 35, 00), books),
            new Konvernoe_linia("Box2", new TimeSpan(19, 55, 30), books),
            new Konvernoe_linia("Box3", new TimeSpan(23, 03, 54), books),
        };

        linia.ForEach(c => Console.WriteLine(c.TurnOn()));

        Console.WriteLine($"\nBox1");
        books.box1
            .ToList()
            .ForEach(x => x.Shygaru(x));
        Console.WriteLine($"\nBox2");
        books.box2
            .ToList()
            .ForEach(x => x.Shygaru(x));
        Console.WriteLine($"\nBox3");
        books.box3
            .ToList()
            .ForEach(x => x.Shygaru(x));

        Similar(box2);
        Run1(books);
        Run2(books);
        Run3(box2);
        Run4(books1);


        Console.ReadLine();
    }

    static void Run1(Books books)
    {
        Konvernoe_linia.DisplayHeader("группировать по жанру");
        Box1.Method(books.box1);
        Box2.Method(books.box2);
        Box3.Method(books.box3);
    }
    static void Similar(List<Box2> box2)
    {
        Konvernoe_linia.DisplayHeader("проверить на сходство");
        var book2 = new Books(1, "Происхождение видов", "Чарльз Дарвин", "Наука", "история", 1859);
        Console.Write($"{box2[0].name} and {book2.name} are the same publication: " +
              $"{((Books)box2[0]).Equals(book2)}\n");
    }

    static void Run2(Books books)
    {
        Konvernoe_linia.DisplayHeader("упорядочить по последнему году выпуска");
        Tools.Sort1(books.box1).ToList().ForEach(c => Console.WriteLine(c));  //box2, box3.
    }

    static void Run3(List<Box2> box)
    {
        Konvernoe_linia.DisplayHeader("группировать по виду(по бокс)");
        IEnumerable<Books> results = (
            from b in box
            group b by b.vid into g
            select new Books()
            {
                vid = g.Key,
                box2 = g.Select(cs => cs).ToList()
            }
            ).ToList();

        foreach (Books item in results)
        {
            Console.WriteLine(item.vid);
            item.box2.ForEach(k => Console.WriteLine(k));
        }
    }

    static void Run4(List<Books> book)
    {
        Konvernoe_linia.DisplayHeader("книги изданные за эти годы");

        int d1 = 1950;
        int d2 = 2000;

        var period = book.Where(k => (d1 < k.year && k.year < d2))
            .Select(t => t);
        period.ToList().ForEach(h => h.kitap(h));
    }

}















//string connectionString = "Server=NAZER\\SQLEXPRESS;Database=PISATELI;Trusted_Connection=True;TrustServerCertificate=true;";

//string sqlExpression = "SELECT * FROM pisatelii";
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();   // открываем подключение

//    SqlCommand command = new SqlCommand(sqlExpression, connection);
//    // определяем выполняемую команду
//    SqlDataReader reader = command.ExecuteReader();

//    if (reader.HasRows) // если есть данные
//    {
//        // выводим названия столбцов
//        string columnName1 = reader.GetName(0);
//        string columnName2 = reader.GetName(1);
//        string columnName3 = reader.GetName(2);

//        Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

//        while (reader.Read()) // построчно считываем данные
//        {

//            object id = reader.GetValue(0);
//            object name = reader.GetValue(2);
//            object age = reader.GetValue(1);

//            Console.WriteLine($"{id} \t{name} \t{age}");
//        }
//    }

//    reader.Close();
//}
//Console.Read();