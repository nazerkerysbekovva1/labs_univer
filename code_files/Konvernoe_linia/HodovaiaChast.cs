using System;
using System.Collections.Generic;
using System.Text;

namespace Konvernoe_linia
{
    internal class HodovaiaChast
    {
        private int id;
        private string name;
        private int amount;
        public HodovaiaChast(int id, string name, int amount)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
        }   
    }
}
