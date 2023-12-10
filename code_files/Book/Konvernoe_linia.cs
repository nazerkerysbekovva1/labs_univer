using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace Book
{
    internal class Konvernoe_linia
    {
        public string name_linia;
        public TimeSpan come;
        public bool status;
        public Books books;

        public Konvernoe_linia(string name_linia, TimeSpan come, Books books)
        {
            this.name_linia = name_linia;
            this.come = come;
            status = true;   //iske kosuly
            this.books = books;
            this.books.box1 = books.box1;
            this.books.box2 = books.box2;
            this.books.box3 = books.box3;
        }

        public string TurnOn()
        {
            if (status)
                return name_linia + " -> линиядан келды. Time: " + come;
            else return "dont work!";
        }
        public static void DisplayHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine("---- {0} ----", header);
        }
    }

    class Books: IEquatable<Books>
    {
        public int id;
        public string name;
        public string author;
        public string vid;
        public string zhanr;
        public int year;

        public List<Box1> box1;
        public List<Box2> box2;
        public List<Box3> box3;


        public Books(int id, string name, string author, string vid, string zhanr, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.vid = vid;
            this.zhanr = zhanr;
            this.year = year;
        }

        public Books(List<Box1> b1, List<Box2> b2, List<Box3> b3)
        {
            box1 = b1;
            box2 = b2;
            box3 = b3;
        }

        public Books() { }

        public override string ToString()
        {
            return year + "   ID: " + id + "   Name: " + name;
        }

        public Action<Books> Shygaru = x =>
                        Console.WriteLine($"Book: {x.id} - {x.name}, year of issue - {x.year}");

        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }
        public bool Equals(Books other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }

        public Action<Books> kitap = x =>
                        Console.WriteLine($" {x.year}  '{x.name}'");

        //  public void me1()
        //  {
        //      Console.WriteLine();
        //      var optionalAges = books1.Map(p => p.box1).ToArray().ForEach(n => Console.Write(n + " "));
        //      // => [Some(33), None, Some(37)]

        //      Console.WriteLine();
        //      var statedAges = books1.Bind(p => p.box1).ToArray();
        //      statedAges.ForEach(n => Console.Write(n + " "));
        //      // => [33, 37]
        //  }

        //  IEnumerable<Books> books1 => new[]
        //{
        //       new Books { box1 = Some(new Box1(2, "book2", "author2", "vid2", "zh2", 9)) },
        //       new Books { },
        //       new Books { box1 = Some(new Box1(7, "book7", "author7", "vid7", "zh7", 8)) },
        //    };
    }

class Box1 : Books  //Hudozhestvennye literatura
    {
        public Box1(int id, string name, string author, string vid, string zhanr, int year) : base(id, name, author, vid, zhanr, year) { }

        public static void Method(List<Box1> books)
        {
            Lookup<string, string> lookup = (Lookup<string, string>)books.ToLookup(p => p.zhanr,
                                                   p => p.name);

            foreach (IGrouping<string, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
        }
    }
      
    class Box2 : Books  //Nauka
    {
        public Box2(int id, string name, string author, string vid, string zhanr, int year) : base(id, name, author, vid, zhanr, year) { }

        public static void Method(List<Box2> books)
        {
            Lookup<string, string> lookup = (Lookup<string, string>)books.ToLookup(p => p.zhanr,
                                                   p => p.name);

            foreach (IGrouping<string, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
        }

        public override string ToString()
        {
            return author + " - " + $"'{name}'";
        }
    }

    class Box3 : Books  //spravochniki
    {
        public Box3(int id, string name, string author, string vid, string zhanr, int year) : base(id, name, author, vid, zhanr, year) { }

        public static void Method(List<Box3> books)
        {
            Lookup<string, string> lookup = (Lookup<string, string>)books.ToLookup(p => p.zhanr,
                                                   p => p.name);

            foreach (IGrouping<string, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
        }
    }
}


