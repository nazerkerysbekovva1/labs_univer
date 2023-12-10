using System;
using System.Collections.Generic;
using System.Text;
using Konvernoe_linia;

namespace Konvernoe_linia
{
    internal class PosledniaOborudovanie
    {
        private HodovaiaChast hodovaiaChast;
        private Cuzov cuzov;
        private Dvigatel dvigatel;
        private int id;
        //private
        //private
        //private
        //private
        //private
        public PosledniaOborudovanie(HodovaiaChast hodovaiaChast, Cuzov cuzov, Dvigatel dvigatel, int id)
        {
            this.hodovaiaChast = hodovaiaChast;
            this.cuzov = cuzov;
            this.dvigatel = dvigatel;
            this.id = id;
        }
    }
}
