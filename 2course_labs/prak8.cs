using System;

namespace prak8
{
    abstract class Ushtik
    {
        public abstract DateTime Birge_arttyru();
        public abstract void Shygaru();
    }
    class Data: Ushtik
    {
        public int day;
        public int month;
        public int year;

        public Data(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public override DateTime Birge_arttyru()
        {
            if (day < 30 && month < 12)
            {
                day++;
                month++;
                year++;
                DateTime data = new DateTime(year, month, day);
                return data;
            }
            else
            {
                if (day == 30)
                { day = 1; month=month+2; year++; }
                else if (month == 12)
                { day++; month = 1; year=year+2;}
                DateTime data = new DateTime(year, month, day);
                return data;
            }
        }
        public override void Shygaru()
        {
            Console.WriteLine("Birge_arttyru data:  " + Birge_arttyru());
        }
    }
    class Uaqyt:Ushtik
    {
        public int day;
        public int month;
        public int year;

        public int second;
        public int minute;
        public int hour;

        public Uaqyt(int day, int month, int year, int sec, int min, int hour)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            second = sec;
            minute = min;
            this.hour = hour;
        }

        public override DateTime Birge_arttyru()
        {
            if (day < 30 && month < 12)
            {
                if (hour < 24 && minute < 60 && second < 60)
                {
                    hour++;
                    minute++;
                    second++;
                    DateTime data = new DateTime(year, month, day, hour, minute, second);
                    return data;
                }
                else
                {
                    if (second == 60) { second = 1; minute = minute + 2; hour++; day++; month++; year++; }
                    if (minute == 60) { second++; minute = 1; hour = hour + 2; day++; month++; year++; }
                    if (hour == 24) { second++; minute++; hour = 1; day = day + 2; month++; year++; }
                    DateTime data = new DateTime(year, month, day, hour, minute, second);
                    return data;
                }
            }
            else
            {
                if (day == 30)
                { day = 1; month = month + 2; year++; }
                else if (month == 12)
                { day++; month = 1; year = year + 2; }
                DateTime data = new DateTime(year, month, day);
                return data;
            }
            
        }
        public override void Shygaru()
        {
            Console.WriteLine("Birge_arttyru uaqyt:  " + Birge_arttyru());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DateTime engiz: " );
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            Data d = new Data(day, month, year);
            DateTime Datetime = new DateTime(year, month, day);
            Console.WriteLine("Data: "+ Datetime);
            d.Shygaru();
            Console.WriteLine();

            Uaqyt u = new Uaqyt(day, month, year, second, minute, hour);
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
            Console.WriteLine("Uaqyt: " + dateTime);
            u.Shygaru();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
