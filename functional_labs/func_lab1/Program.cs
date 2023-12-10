using func_lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// СпортКомплекс проект
namespace func_lab1
{
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
                        Console.Write("Enter sport section: ");
                        string sectionn = Console.ReadLine();
                        Competition.Comp(date, sectionn, competitions, sections, sportsmens);
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
                        Sport_section.Premium(competitions, sections, sportsmens);
                    }
                }
                else break;
            }
            Console.WriteLine("Thank you for visiting!!!");
            Console.ReadKey();
        }
    }

}
/*
 OUTPUT:

#####################################################
ABOUT SPORTCOMLEX!!!

if you want to finish enter 0, if you want to know something enter 1
1
Enter 1, if you want to know About sportshylar || Enter 2, if you want to know About sport_section
1
Enter sportsman name:
Болатбек Б
- - - - - - - - - - - - - -
_Sportshy: 9 - Болатбек Б
_Sport section: Футбол
_Weight:58
_Skill level:0
- - - - - - - - - - - - - -

if you want to finish enter 0, if you want to know something enter 1
1
Enter 1, if you want to know About sportshylar || Enter 2, if you want to know About sport_section
2
Enter name of sport section:  Плавание
Плавание section turaly:
- - - - - - - - - - - - - -
_Sport section: 11 - Плавание
_Coach_name: Беделхан Ы
_Category of sport section: Юниор
_The rules: Ж?зу бойынша жарыстар ?зынды?ы 25 немесе 50 метр болатын жабы? немесе ашы? бассейндерде ?тк?з?лед?, бастап?ы тере?д?г? 1,2 м. 3-де?гейдег? жарыстарды стандартты емес ж?не ж?зет?н бассейндерде, ашы? су ?оймаларында ?тк?зуге р??сат ет?лед?.
- - - - - - - - - - - - - -

if you want to finish enter 0, if you want to know something enter 1
0


#####################################################
ABOUT THE COMPETITION AND ITS RESULTS!!!

Enter time of competition (year, month, day):
2021
10
20

if you want to finish enter 0, if you want to know something enter 1
1
Choose number which what you want to know:
1.About List and Results of sportsmen who took part of the competition
2.About The sportsman with the highest score in date
3.Avg score of sportsmen
4.Redefining skill level
5.Premium for coach
1
20.10.2021 0:00:00  kuni zharyska katyskan sportshylar tizimi:
Самимолла У. Result: 84. Place: ___2 place
Алирахимов Р. Result: 89. Place: ___2 place
Омирбек А. Result: 76. Place: ___3 place
Аскерова А. Result: 98. Place: ___1 place
Нурадин Б. Result: 92. Place: ___1 place
Бектаева Ж. Result: 70. Place: ___Lost place
Абдимбекова А. Result: 80. Place: ___2 place
Камараддин Р. Result: 50. Place: ___Lost place
Бекдаулет М. Result: 85. Place: ___2 place
Болатбек Б. Result: 80. Place: ___2 place

if you want to finish enter 0, if you want to know something enter 1
1
Choose number which what you want to know:
1.About List and Results of sportsmen who took part of the competition
2.About The sportsman with the highest score in date
3.Avg score of sportsmen
4.Redefining skill level
5.Premium for coach
2
Enter sport section: Плавание
---- Секция: Плавание
- - - - - - - - - - - - - -
ID: 1
Name: Нурадин Б
Result: 92
Place: 1
Section: Плавание
- - - - - - - - - - - - - -
---- Секция: Таеквандо
There is no sportsman with a high score in this section
---- Секция: Бокс
There is no sportsman with a high score in this section
---- Секция: Футбол
There is no sportsman with a high score in this section

if you want to finish enter 0, if you want to know something enter 1
1
Choose number which what you want to know:
1.About List and Results of sportsmen who took part of the competition
2.About The sportsman with the highest score in date
3.Avg score of sportsmen
4.Redefining skill level
5.Premium for coach
3
- - - - - - - - - - - - - -
Нурадин Б: avg score for all shampionship = 89,5
Омирбек А: avg score for all shampionship = 68
Бекдаулет М: avg score for all shampionship = 88
Аскерова А: avg score for all shampionship = 85
Камараддин Р: avg score for all shampionship = 69
Бектаева Ж: avg score for all shampionship = 80
Абдимбекова А: avg score for all shampionship = 79,5
Алирахимов Р: avg score for all shampionship = 87
Болатбек Б: avg score for all shampionship = 89,5
Самимолла У: avg score for all shampionship = 82
- - - - - - - - - - - - - -

if you want to finish enter 0, if you want to know something enter 1
1
Choose number which what you want to know:
1.About List and Results of sportsmen who took part of the competition
2.About The sportsman with the highest score in date
3.Avg score of sportsmen
4.Redefining skill level
5.Premium for coach
4
- - - - - - - - - - - - - -
Нурадин Б: level of skill gained from result of championships = 1st level
Омирбек А: level of skill gained from result of championships = 3rd level
Бекдаулет М: level of skill gained from result of championships = 1st level
Аскерова А: level of skill gained from result of championships = 2nd level
Камараддин Р: level of skill gained from result of championships = 3rd level
Бектаева Ж: level of skill gained from result of championships = 2nd level
Абдимбекова А: level of skill gained from result of championships = 2nd level
Алирахимов Р: level of skill gained from result of championships = 1st level
Болатбек Б: level of skill gained from result of championships = 1st level
Самимолла У: level of skill gained from result of championships = 2nd level
- - - - - - - - - - - - - -

if you want to finish enter 0, if you want to know something enter 1
1
Choose number which what you want to know:
1.About List and Results of sportsmen who took part of the competition
2.About The sportsman with the highest score in date
3.Avg score of sportsmen
4.Redefining skill level
5.Premium for coach
5
- - - - - - - - - - - - - -
_Секция: Плавание
_Coach: Беделхан Ы
_Sum: 0
_Premium: 0
- - - - - - - - - - - - - -
- - - - - - - - - - - - - -
_Секция: Таеквандо
_Coach: Рахымжанов А
_Sum: 0
_Premium: 0
- - - - - - - - - - - - - -
- - - - - - - - - - - - - -
_Секция: Бокс
_Coach: Нурланов Р
_Sum: 0
_Premium: 0
- - - - - - - - - - - - - -
- - - - - - - - - - - - - -
_Секция: Футбол
_Coach: Абдухашим Д
_Sum: 0
_Premium: 0
- - - - - - - - - - - - - -

if you want to finish enter 0, if you want to know something enter 1
0
Thank you for visiting!!!
 
 */
