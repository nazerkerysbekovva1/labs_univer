using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportcomlex
{
    public class NazEventArgs : System.EventArgs
    {
        public readonly string section;
        public NazEventArgs(string sect)
        {
            section = sect;
        }
    }
    class Sportsmen
    {
        public int id_sportsman { get; set; }
        public string sportsman_name { get; set; }
        public string sport_section { get; set; }
        public int the_weight { get; set; }
        public string skill_level { get; set; }

        public Sportsmen(int id_sportsman, string sportsman_name, string sport_section, int the_weight, string skill_level)
        {
            this.id_sportsman = id_sportsman;
            this.sportsman_name = sportsman_name;
            this.sport_section = sport_section;
            this.the_weight = the_weight;
            this.skill_level = skill_level;
        }

        public void Shygaru()
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("_Sportshy: " + id_sportsman + " - " + sportsman_name + "\n_Sport section: " + sport_section + "\n_Weight:" + the_weight + "\n_Skill level:" + skill_level);
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void AboutSportsmen(string name, List<Sportsmen> sportsmans) 
        {
            bool ok = false;
            foreach (Sportsmen s in sportsmans)
            {
                if (s.sportsman_name == name)
                {
                    s.Shygaru();
                    ok = true;
                }
            }
            if (!ok)
                Console.WriteLine("There is no Sportsman like that");
        }
    }

    class Sport_section
    {
        public int id_section { get; set; }
        public string sport_section { get; set; }
        public string coach { get; set; }
        public string category { get; set; }
        public string the_rules { get; set; }

        public event EventHandler<NazEventArgs> UserEvent2;
        public void OnUserEvent2(NazEventArgs sport)
        {
            if (UserEvent2 != null)
                UserEvent2(this, sport);
        }
        public void DisplayMessage2(object sender, NazEventArgs sport)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"___{sport.section} спортшылары дайындык устынде. '{((Sport_section)sender).sport_section}' - спортшылары Халыкаралык жарыска баруга жиналатын болады!!!");
            Console.ResetColor();
        }

        public static void Massiv(List<Sport_section> sp)
        {
            for (int i = 0; i < sp.Count; i++)
            {
                for (int j = 0; j < sp.Count-3; j++)
                {
                    if (i != j)
                    {
                        sp[i].UserEvent2 += sp[j].DisplayMessage2;
                    }
                }
            }
        }

        public Sport_section(int id_sport_section, string sport_section, string coach, string category, string the_rules)
        {
            this.id_section = id_sport_section;
            this.sport_section = sport_section;
            this.coach = coach;
            this.category = category;
            this.the_rules = the_rules;
        }

        public void Shygaru()
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("_Sport section: "+id_section+" - "+sport_section + "\n_Coach_name: " + coach + "\n_Category of sport section: " + category + "\n_The rules: " + the_rules );
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void SectionTop(string section, List<Sport_section> S)
        {
            bool ok = false;
            Console.WriteLine(section + " section turaly:");
            foreach (Sport_section s in S)
            {
                if (s.sport_section == section)
                {
                    s.Shygaru();
                    ok = true;
                }
                if (!ok)
                { Console.WriteLine("There is no sport section like that"); }
            }
        }

        public static void Premium(List<Competition> competition, List<Sport_section> sport_Sections)
        {
            foreach (Sport_section s in sport_Sections)
            {
                int sum = 0;
                int premium = 0;
                foreach (Competition C in competition)
                {
                    if (s.id_section == C.id_section)
                    {
                        sum += C.result;
                        if (sum > 480)
                        {
                            premium = 15000;
                        }
                    }
                }
                Console.WriteLine("- - - - - - - - - - - - - -");
                Console.WriteLine("_Секция: " + s.sport_section + "\n_Coach: " + s.coach + "\n_Sum: " + sum + "\n_Premium: " + premium);
                Console.WriteLine("- - - - - - - - - - - - - -");
            }
        }


        public void Collect(string section, List<Sport_section> sport_Sections)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (Sport_section s in sport_Sections)
            {
                if (s.sport_section == section)
                {
                    Console.WriteLine();
                    Console.WriteLine($"'{s.sport_section}' жолдама алды");
                    s.OnUserEvent2(new NazEventArgs(sport_section));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"'{s.sport_section}' жолдама алмады");
                }
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }
    }

    public delegate void datecomp(int id_sp, int res);
    class Competition
    {
        public int id_section { get; set; }
        public int result { get; set; }
        public int id_sportsman { get; set; }
        public DateTime data { get; set; }
        public string competition { get; set; }

        public event datecomp UserEvent1;
        public void OnUserEvent1()
        {
            if (UserEvent1 != null)
                UserEvent1(id_sportsman, result);
        }
        public void DisplayMessage1(int id_sp, int res)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"id - {this.id_sportsman}-ге тен спортшы - '{this.result}' результатпен жолдама алды!");
            Console.ResetColor();
        }

        public static void Massiv(List<Competition> cm)
        {
            for (int i = 0; i < cm.Count; i++)
            {
                cm[i].UserEvent1 += cm[i].DisplayMessage1;
            }
        }

        public Competition(int id_section, int result, int id_sportsman, DateTime data, string competition)
        {
            this.id_section = id_section;
            this.result = result;
            this.id_sportsman = id_sportsman;
            this.data = data;
            this.competition = competition;
        }

        public static void CompetetionSportsman(DateTime date, List<Competition> comp, List<Sportsmen> sportsmans) 
        {
            Console.WriteLine("---- " + date + "  kuni zharyska katyskan sportshylar tizimi:");
            bool ok = false;
            foreach (var c in comp)
            {
                if (c.data == date)
                {
                    foreach (var s in sportsmans)
                    {
                        if (c.id_sportsman == s.id_sportsman)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Id: {0}. {1}. Result: {2}. Place: {3}", s.id_sportsman, s.sportsman_name, c.result, Oryn(c.result));
                            ok = true;
                        }
                    }
                    if (Oryn(c.result) == "___1 place")
                    {
                        Console.WriteLine("Got a ticket to the championship!");
                        c.OnUserEvent1();
                    }
                    else
                    {
                        Console.WriteLine("Didnt get a ticket to the championship!");
                    }
                }
            }
            if (!ok)
                Console.WriteLine("No sportsmen.");
        }

        public static void Comp(DateTime date, List<Competition> comp, List<Sport_section> sport_Sections, List<Sportsmen> sportsmens)
        {
            foreach (Sport_section sport_Section in sport_Sections)
            {
                Console.WriteLine("---- Секция: " + sport_Section.sport_section);
                foreach (Competition C in comp)
                {
                    if (C.data == date)
                    {
                        foreach (Sportsmen sportsmen in sportsmens)
                        {
                            if (C.result >= 90)
                            {
                                if (C.id_sportsman == sportsmen.id_sportsman)
                                {
                                    if (sport_Section.sport_section == sportsmen.sport_section)
                                    {
                                        Console.WriteLine("- - - - - - - - - - - - - -");
                                        Console.WriteLine("ID: " + sportsmen.id_sportsman + "\nName: " + sportsmen.sportsman_name + "\nResult: " + C.result + "\nPlace: " + 1 + "\nSection: " + sportsmen.sport_section);
                                        Console.WriteLine("- - - - - - - - - - - - - -");

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string Oryn(int result)
        {
            if (result >= 90)
                return "___1 place";
            else if (result >= 80 && result < 90)
                return "___2 place";
            else if (result >= 70 && result < 80) 
                return "___3 place";
            else
                return "___Lost place";
        }

        public static void OrtaBall(List<Competition> comp, List<Sportsmen> sportsmans)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (var s in sportsmans)
                {
                double orta = 0;
                int count = 0;
                foreach (var c in comp)
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;
                    }
                }
                Console.WriteLine(s.sportsman_name + ": avg score for all shampionship = " + orta / count);
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void Skill_level(List<Competition> comp, List<Sportsmen> sportsmans)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (var c in comp)
            {
                double orta = 0;
                int count = 0;
                foreach (var s in sportsmans)
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;

                        if ((orta / count) >= 86)
                        {
                            s.skill_level = "1st level";
                        }
                        else if ((orta / count) >= 76)
                        {
                            s.skill_level = "2nd level";
                        }
                        else if ((orta / count) >= 66)
                        {
                            s.skill_level = "3rd level";
                        }
                        else
                        { s.skill_level = "0"; }
                        Console.WriteLine("ID: " + s.id_sportsman + ", " + s.sportsman_name + ": level of skill gained from result of championships = " + s.skill_level);
                    }}
                }
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }
    }

    public class Program
    {
        static void Main()
        {
            List<Sportsmen> sportsmens = new List<Sportsmen>()
            {
                new Sportsmen(1, "Нурадин Б", "Плавание", 50,"0"),
                new Sportsmen(2, "Омирбек А", "Таеквандо", 42,"0"),
                new Sportsmen(3, "Бекдаулет М", "Таеквандо", 35,"0"),
                new Sportsmen(4, "Аскерова А", "Таеквандо", 37,"0"),
                new Sportsmen(5, "Камараддин Р", "Бокс", 48,"0"),
                new Sportsmen(6, "Бектаева Ж", "Бокс", 52,"0"),
                new Sportsmen(7, "Абдимбекова А", "Плавание", 41,"0"),
                new Sportsmen(8, "Алирахимов Р", "Футбол", 60,"0"),
                new Sportsmen(9, "Болатбек Б", "Футбол", 58,"0"),
                new Sportsmen(10, "Самимолла У", "Футбол", 64,"0")
            };

            List<Sport_section> sections = new List<Sport_section>()
            {
                new Sport_section(11, "Плавание", "Беделхан Ы", "Юниор", "Жүзу бойынша жарыстар ұзындығы 25 немесе 50 метр болатын жабық немесе ашық бассейндерде өткізіледі, бастапқы тереңдігі 1,2 м. 3-деңгейдегі жарыстарды стандартты емес және жүзетін бассейндерде, ашық су қоймаларында өткізуге рұқсат етіледі."),
                new Sport_section(22, "Таеквандо", "Рахымжанов А",  "Юниор", "Жарысқа спарринг техникасы бойынша кемінде үш ай дайындалған спортшылар жіберіледі. Бір рет өлшенген және бірінші рет өлшенбеген қатысушы ресми салмақ өлшеу кезінде тағы бір салмақ өлшеуге құқылы."),
                new Sport_section(33, "Бокс", "Нурланов Р", "Юниор", "Бокс кеші раундтарға бөлінеді, олардың әрқайсысы кездесу деңгейіне байланысты (әуесқой немесе кәсіпқой) 3 -тен 5 минутқа дейін созылады. Боксшыларға раундтар арасында 1 минут демалуға уақыт беріледі."),
                new Sport_section(44, "Футбол", "Абдухашим Д", "Юниор", "Футбол эрежелері 13тен тарады, Үйғаша: Төреші, Туреші комекшілері, Ойын алыстығы, Ойын басталуы және қайта басталуы, Доп, Гол онықтау, Офсайд, Ойылышы бұзушылықтары")
            };

            List<Competition> competitions = new List<Competition>()
            {
                new Competition(44, 80, 10, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(44, 85, 8, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 60, 2, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 72, 4, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 87, 1, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 90, 6, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 79, 7, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 88, 5, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 91, 3, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(44, 99, 9, new DateTime(2021, 9, 20), "Чемпионат1"),

                new Competition(44, 84, 10, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(44, 89, 8, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 76, 2, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 98, 4, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(11, 92, 1, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(33, 70, 6, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(11, 80, 7, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(33, 50, 5, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 85, 3, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(44, 80, 9, new DateTime(2021, 10, 20), "Чемпионат2"),
            };


            Competition.Massiv(competitions);
            Sport_section.Massiv(sections);

            Console.WriteLine("#####################################################");
            Console.WriteLine("ABOUT SPORTCOMLEX!!!");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("if you want to finish enter 0, if you want to know something enter 1");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 1)
                {
                    Console.WriteLine("Enter 1, if you want to know About sportshylar || Enter 2, if you want to know About sport_section");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter sportsman name:");
                        string name = Console.ReadLine();
                        Sportsmen.AboutSportsmen(name, sportsmens);
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter name of sport section:  ");
                        string section = Console.ReadLine();
                        Sport_section.SectionTop(section, sections);
                    }
                }
                else break;
            }
            Console.WriteLine("\n\n#####################################################");
            Console.WriteLine("ABOUT THE COMPETITION AND ITS RESULTS!!!");
            Console.WriteLine();
            Console.WriteLine("Enter time of competition (year, month, day):");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("if you want to finish enter 0, if you want to know something enter 1");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 1)
                {
                    Console.WriteLine("Choose number which what you want to know: ");
                    Console.WriteLine("1.About List and Results of sportsmen who took part of the competition \n2.About The sportsman with the highest score in date \n3.Avg score of sportsmen \n4.Redefining skill level \n5.Premium for coach ");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        Competition.CompetetionSportsman(date, competitions, sportsmens);
                    }
                    else if (choice2 == 2)
                    {
                        Competition.Comp(date, competitions, sections, sportsmens);
                    }
                    else if (choice2 == 3)
                    {
                        Competition.OrtaBall(competitions, sportsmens);
                    }
                    else if (choice2 == 4)
                    {
                        Competition.Skill_level(competitions, sportsmens);
                    }
                    else if (choice2 == 5)
                    {
                        Sport_section.Premium(competitions, sections);
                    }
                }
                else break;
            }

            Console.WriteLine("\n\n#####################################################");
            Console.WriteLine("FOR A CHAMPIONSHIP OR COMPETITION!!!");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("if you want to finish enter 0, if you want to know something enter 1");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 1)
                {
                    Console.WriteLine("Enter 1, if you want to know About collection for the championsip || Enter 2, if you want to know About ssss");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.Write("Enter name of sport section:  ");
                        string section = Console.ReadLine();
                        for (int i = 0; i < sections.Count; i++)
                        {
                            sections[i].Collect(section, sections);
                        }
                    }
                }
                else break;
            }
            Console.WriteLine("Thank you for visiting!!!");
            Console.ReadKey(); 
        }
    }
}
