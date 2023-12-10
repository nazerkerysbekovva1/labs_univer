using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace reak_lab1
{
    class Makler
    {
        public int id;
        public string name;
        public string address;
        public int year_of_birth;
        public Makler(int maklerId, string name_Makler, string address_Makler, int year_of_birth)
        {
            id = maklerId;
            name = name_Makler;
            address = address_Makler;
            this.year_of_birth = year_of_birth;
        }

        public void Info()
        {
            Console.WriteLine($" {id} <=> {name} <=> {address} <=> year_of_birth: {year_of_birth}");
        }

        // 4. по маклеру, совершившему максимальное количество сделок, – сведения о нем и фирмах-поставщиках; +
        public static void Sdelok(List<Sdelki> sd, List<Makler> mk)
        {
            List<int> list = new List<int>();
            foreach (var mak in mk)
            {
                var makler = sd.Where(n => n.name_makler == mak.name).Select(d => d).Count();
                list.Add(makler);
            }
            int max = list.Max();
            var maklerr = mk.Where(e => max == sd.Where(r => r.name_makler == e.name).AsParallel().Select(d => d).Count()).First();
            Console.WriteLine();
            Console.WriteLine($" @Makler Id = {maklerr.id} \n @Name Maklera = '{maklerr.name}'  \n @Address Maklera = '{maklerr.address}' \n @Year of birth = '{maklerr.year_of_birth}' \n @Optovaya firma postavshchik = '{maklerr}'");
        }
    }
}