using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using LaYumba.Functional.Option;
using LaYumba.Functional;
using System.Transactions;

namespace aw
{
    public delegate void Mydelegate(string message);

    internal class Order
    {
        public string tv;
        public int pr;
        public double count;

        public event EventHandler<TovarInfoEventArgs> NewTovarInfo;

        public void NewTovar()
        {
            Console.WriteLine($"TovarPostav, new tv {tv}");

            NewTovarInfo?.Invoke(this, new TovarInfoEventArgs(tv));
        }

        public void Pricee()
        {
            Console.WriteLine($"{tv} ---> {pr} $ ");

            NewTovarInfo?.Invoke(this, new TovarInfoEventArgs(pr));
        }

        public void SumAll()
        {
            Console.WriteLine($"{count} tovars in the store of {tv}");
            Console.WriteLine($"All sum of = {count * pr}");

            NewTovarInfo?.Invoke(this, new TovarInfoEventArgs(count));
        }

        public event Mydelegate UserEvent;
        public void OnUserEvent()
        {
            if (UserEvent != null)
                UserEvent(tv);
        }
        public void DisplayMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"tovar name - {this.tv}");
            Console.ResetColor();
        }

        public static void Massiv(List<Order> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].UserEvent += orders[i].DisplayMessage;
                orders[i].OnUserEvent();
            }
        }
    }

    public class Consumer
    {
        private string Consumer_name;

        public Consumer(string name) => Consumer_name = name;

        public void NewTovarIsHere(object sender, TovarInfoEventArgs e) =>
          Console.WriteLine($"{Consumer_name}: Tovar {e.TovarName} is new");
    }

    public class TovarInfoEventArgs : EventArgs
    {
        public string TovarName { get; }
        public TovarInfoEventArgs(string tovar_name) => TovarName = tovar_name;

        public int Price { get; }
        public TovarInfoEventArgs(int price_tovara) => Price = price_tovara;

        public double Count { get; }

        public double Sum { get; }
        public TovarInfoEventArgs(double sum) => Sum = sum;
    }
}
