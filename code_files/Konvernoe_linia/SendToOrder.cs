using System;
using System.Collections.Generic;
using System.Text;

namespace Konvernoe_linia
{
    internal class SendToOrder
    {
        private DateTime date;
        private string marka;
        private string colorCar;
        private double price;
        private bool shipping;
        public SendToOrder(DateTime date, string marka, string colorCar, double price, bool shipping)
        {
            this.date = date;
            this.marka = marka;
            this.colorCar = colorCar;
            this.price = price;
            this.shipping = shipping;
        }   
    }
}
