using System;

namespace esep10
{
    class Filial
    {
        public delegate void DisPlay(string message);//делегат ашамыз
        public event DisPlay Uvedomlenie;// DisPlay делегатын представлять ететін оқиға ашамыз.
        //1)оқиғаны жариялау

        public int ID, sanat;
        public Filial(int ID, int sanat)
        {
            this.ID = ID;
            this.sanat = sanat;
        }
        public void Zhetkizu()
        {
            Random rnd = new Random();
            int zhetkizilu_payizi = rnd.Next(0, 100);

            if (sanat == 1)
            {
                if (zhetkizilu_payizi >= 95) Zhetkizilmedi();
                else Zhetkizildi();
            }

            else if (sanat == 2)
            {
                if (zhetkizilu_payizi >= 80) Zhetkizilmedi();
                else Zhetkizildi();
            }
            else if (sanat == 3)
            {
                if (zhetkizilu_payizi >= 70) Zhetkizilmedi();
                else Zhetkizildi();
            }
        }
        public void Zhetkizilmedi()
        {
            Console.ForegroundColor = ConsoleColor.Red;//Шыққан уведомлениени басқа түспен белгілеп қоюды шештім
            Uvedomlenie?.Invoke($"№{ID} филиалга газеттер уакытылы жеткизилмеди!");//.?арқылы нуль-ға тексереміз..Invoke арқылы Делегаттың параметріне мән береміз.
            Console.ResetColor();//Осы жерден бастап қайта стандартты ақ түске оралады.
        }
        public void Zhetkizildi()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;//Шыққан уведомлениени басқа түспен белгілеп қоюды шештім
            Uvedomlenie?.Invoke($"№{ID} филиалга газеттер уакытылы жеткизилди!");//.?арқылы нуль-ға тексереміз..Invoke арқылы Делегаттың параметріне мән береміз.
            Console.ResetColor();//Осы жерден бастап қайта стандартты ақ түске оралады.
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Filial[] filials =
            {
                new Filial(1,1),
                new Filial(2,2),
                new Filial(3,1),
                new Filial(4,3),
                new Filial(5,2),
                new Filial(6,3),
                new Filial(7,1),
                new Filial(8,3),
                new Filial(9,2),
                new Filial(10,3),
                new Filial(11,2)
            };

            for (int i = 0; i < filials.Length; i++)
            {
                filials[i].Uvedomlenie += DisplayMessage;
                filials[i].Zhetkizu();
            }
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
