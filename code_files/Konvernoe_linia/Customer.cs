using System;
using System.Collections.Generic;
using System.Text;

namespace Konvernoe_linia
{
    internal class Customer
    {
        private int id;
        private string name;
        private string email;   
        private string phone;
        private string city;    
        public Customer(int id, string name, string email, string phone, string city)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.city = city;
        }   
    }
}
