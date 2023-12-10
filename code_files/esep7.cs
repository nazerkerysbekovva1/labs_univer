using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Предметная область: Интернет магазин.В информационной системе хранятся данные о товарах. Клиент звонит в магазин и оставляет заказ на товар.
    На все товары имеется скидка.На одни товары скидка задана в процентах, на другие предоставлена фиксированная скидка.
 
Система должна позволять выполнять следующие задачи:
• ввод информации о товарах;
• регистрация заказа клиента на покупку определенного товара;
• после ввода фамилии покупателя вывод списка заказанных им товаров;
• вычислять среднюю стоимость товара.
 
Добавить обработку исключительных ситуаций:
• наименование товара менее трех символов.
• стоимость с учетом скидки более 1 млн.руб.
Добавить перегруженный бинарный оператор для увеличения стоимости товара. */


namespace ConsoleInternetShop
{
    class Product
    {
        public string Title; //название продука
        public double Price; //стоимость товара

        public Product(string Title, double Price)
        {
            this.Title = Title;
            this.Price = Price;
        }

        public static Product operator +(Product x, double plus)
        {
            x.Price = x.Price + plus;
            return x;
        }

        public void AddProduct()
        {
            File.AppendAllText("Product.txt", Title + " " + Price + Environment.NewLine);

            Console.WriteLine("Продукт успешно добавлено!");
        }
    }

    class Client
    {
        public string Name;
        public string SecondName;
        public int[] NumberProduct { get; set; }
        public Location location;
        public int[] deliveredProducts { get; set; }

        public Client(string Name, string SecondName, int[] NumberProduct, Location location)
        {
            this.Name = Name;
            this.SecondName = SecondName;
            this.NumberProduct = NumberProduct;
            this.location = location;

        }

        public void AddClient()
        {
            string[] arr = File.ReadLines("Product.txt").ToArray();
            string product = "";

            int sum = 0;


            for (int i = 0; i < NumberProduct.Length; i++)
            {
                product += " " + arr[NumberProduct[i] - 1].Split(' ')[0] + ";";
                sum += Convert.ToInt32(arr[NumberProduct[i] - 1].Split(' ')[1]);
            }

            File.AppendAllText("Client.txt", Name + " " + SecondName + " - " + sum + " : " + product + " address:" +
                location.City + " " + location.Street + " " + location.House + " " +
                location.Kvartira + " Цена " + location.Sena + Environment.NewLine);

            Console.WriteLine("Клиент успешно добавлен!");
        }

        public void Stoimost()
        {
            Console.WriteLine("Покупатель приобрел - " + NumberProduct.Length + " товар:");

            string[] arr = File.ReadLines("Product.txt").ToArray();

            int sum = 0;

            for (int i = 0; i < NumberProduct.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + arr[NumberProduct[i] - 1].Split(' ')[0]);
                sum += Convert.ToInt32(arr[NumberProduct[i] - 1].Split(' ')[1]);
            }


            Console.WriteLine("Общая сумма: " + sum);
        }
    }
    class Location
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Kvartira { get; set; }
        public int Sena { get; set; }
        public int Rastoyanie { get; set; }

        public Location(string sity, string street, string house, string kvartira, int sena, int rastoyanie)
        {
            this.City = sity;
            this.Street = street;
            this.House = house;
            this.Kvartira = kvartira;
            this.Sena = sena;
            this.Rastoyanie = rastoyanie;
        }
    }

    class Program
    {
        static void View()
        {
            string[] arr = File.ReadLines("Product.txt").ToArray();
            Console.WriteLine("Список продуктов:");
            int number = 1;
            foreach (string s in arr)
            {
                Console.WriteLine(number + "." + s);
                number++;
            }
        }

        static void ViewClient()
        {
            string[] arr = File.ReadLines("Client.txt").ToArray();
            Console.WriteLine("Список клиентов:");
            int number = 1;
            foreach (string s in arr)
            {
                Console.WriteLine(number + "." + s);
                number++;
            }
        }

        static string readInput(string Text1, string Text2)
        {
            string answer = "";
            while (true)
            {
                Console.Write(Text1);
                answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                    Console.WriteLine(Text2);
                else
                    break;
            }
            return answer;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nВыберите действие:\n1-Ввод продукта\n2-Вывод существующих товаров\n3-Покупка товара клиентом\n4-Поиск клиента\n5-Увеличение стоимости товара\n6-Товор доставлен\n0-Выход\nВвод: ");
                try
                {
                    int n = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (n)
                    {
                        case 1:
                            {
                                string Title;
                                while (true)
                                {
                                    Console.Write("Введиет название продукта: ");
                                    Title = Console.ReadLine();
                                    if (Title.Length < 3)//длина поля наименования продукта меньше 3 символов.
                                        Console.WriteLine("Поле наименования продукта не может быть меньше 3 символов!");
                                    else
                                        break;
                                }
                                Console.Write("Введите цену продукта: ");
                                double Price = double.Parse(Console.ReadLine());
                                Product a = new Product(Title, Price);
                                a.AddProduct();
                            }
                            break;
                        case 2:
                            {
                                View();
                            }
                            break;
                        case 3:
                            {
                                string Name, SecondName, NumberProduct;
                                List<int> price;

                                Console.WriteLine("Введите данные о покупателе");

                                while (true)
                                {
                                    Console.Write("Введите имя: ");
                                    Name = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(Name))
                                        Console.WriteLine("Имя покупателя не может быть пустым!");
                                    else
                                        break;
                                }
                                while (true)
                                {
                                    Console.Write("Введите фамилию: ");
                                    SecondName = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(SecondName))
                                        Console.WriteLine("Фамилия покупателя не может быть пустой!");
                                    else
                                        break;
                                }
                                string city = readInput("Введите город: ", "Город покупателя не может быть пустой!");
                                string street = readInput("Введите улицу", "Улица не может быть пустой!");
                                string house = readInput("Введите дом", "Дом не может быть пустой!");
                                string kvartira = readInput("Введите квартиру", "Квартира не может быть пустой!");
                                int rastoyanie = int.Parse(readInput("Введите расстояние", "Расстояние не может быть пустой!"));
                                int cena = rastoyanie * 50;
                                Location location = new Location(city, street, house, kvartira, rastoyanie, cena);
                                while (true)
                                {
                                    Console.WriteLine("Выберите товар: ");
                                    View();
                                    Console.Write("Введите номер (через пробел): ");
                                    NumberProduct = Console.ReadLine();

                                    try
                                    {
                                        string[] arr = NumberProduct.Split(' ');
                                        price = new List<int>();
                                        for (int i = 0; i < arr.Length; i++)
                                        {
                                            price.Add(Int32.Parse(arr[i]));
                                        }
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Неверный формат данных!\n");
                                    }
                                }
                                Client cl = new Client(Name, SecondName, price.ToArray(), location);
                                cl.AddClient();
                                cl.Stoimost();
                            }
                            break;
                        case 4:
                            {
                                string SecondName;
                                while (true)
                                {
                                    Console.Write("Введите фамилию: ");
                                    SecondName = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(SecondName))
                                        Console.WriteLine("Фамилия покупателя не может быть пустой!");
                                    else
                                        break;
                                }

                                List<string> array = File.ReadAllLines("Client.txt").ToList();

                                foreach (var a in array)
                                {
                                    if (a.Split('-')[0].Split(' ')[1].Equals(SecondName))
                                    {
                                        Console.WriteLine(a);
                                    }
                                }
                            }
                            break;
                        case 5:
                            {
                                string[] arr = File.ReadLines("Product.txt").ToArray();
                                Console.WriteLine("Введите сумму на которую необходимо увеличить все введенные товары");
                                double plus = double.Parse(Console.ReadLine());
                                string Title = null;
                                double Price = 0;
                                File.Delete(@"Product.txt");
                                foreach (string s in arr)
                                {
                                    string[] mas = s.Split(' ');
                                    Title = string.Copy(mas[0]);
                                    Price = double.Parse(mas[1]);
                                    Product b = new Product(Title, Price) + plus;
                                    b.AddProduct();
                                }
                                break;
                            }
                        case 6:
                            {
                                string LastName = readInput("Введите фамилию: ", "Фамилия покупателя не может быть пустой!");
                                string[] arr = File.ReadLines("Product.txt").ToArray();
                                Console.WriteLine("Выберите товар который доставлен: ");
                                View();
                                Console.Write("Введите номер (через пробел): ");
                                int deleviredProduct = int.Parse(Console.ReadLine());
                                File.AppendAllText("Client.txt", "Товар " + arr[deleviredProduct - 1] + " был доставлен. " + LastName);
                                break;
                            }
                        case 0: return;
                        default: Console.WriteLine("Нет такой команды!"); break;
                    }
                }
                catch (FileNotFoundException)
                { Console.WriteLine("Файл невозможно открыть по причине его отсутствия"); }
                catch (IOException)
                { Console.WriteLine("Файл невозможно открыть из-за ошибки ввода-вывода"); }
                catch (ArgumentNullException)
                { Console.WriteLine("Имя файла представляет собой null-значение"); }
                catch (FormatException)
                { Console.WriteLine("Неверный формат ввода данных"); }
            }
        }
    }
}
