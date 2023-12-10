using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab_2;

// Цель: Observable<T> интерфеисын жузеге асыру
namespace reak_lab_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RegistryTovar registr = new RegistryTovar();
            QueryTovar q1 = new QueryTovar("zapros 1"); //екы наблюдаемый обьект жасаимыз
            q1.Subscribe(registr); //1 наблюдателге наблюдаемый обьектты тыркеимыз
            QueryTovar q2 = new QueryTovar("zapros 2");
            q2.Subscribe(registr); //2 наблюдателге наблюдаемый обьектты тыркеимыз
            registr.ListTovar(new Tovar(1, "Sisley", "Female", 7645, "P1", new DateTime(2025, 02, 07), 7));
            registr.ListTovar(new Tovar(2, "Kenzo", "Female", 2575, "P1", new DateTime(2025, 02, 07), 9));
            q1.Unsubscribe();  //1 наблюдателды босатамыз, сонда обьектты тек 2ншы наблюдател алады
            registr.ListTovar(new Tovar(3, "Cerruti", "Male", 4315, "P2", new DateTime(2025, 02, 07), 12));
            registr.ListTovar(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));
            registr.End(); //запросты тыркеуды аяктап, каи наблюдателмен(запроспен) аякталганын корсетемз
        }
    }
}
/*Output:
 * 
 zapros 1    
: The name tovara is Sisley
 1 <=> 'Sisley' <=> Female <=> 7645 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 7
zapros 2     
: The name tovara is Sisley
 1 <=> 'Sisley' <=> Female <=> 7645 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 7
zapros 1
: The name tovara is Kenzo
 2 <=> 'Kenzo' <=> Female <=> 2575 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 9
zapros 2
: The name tovara is Kenzo
 2 <=> 'Kenzo' <=> Female <=> 2575 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 9
zapros 2
: The name tovara is Cerruti
 3 <=> 'Cerruti' <=> Male <=> 4315 <=> postavshchik: P2 <=> srok: 07.02.2025 0:00:00 <=> 12
zapros 2
: The name tovara is Bottega Veneta
 5 <=> 'Bottega Veneta' <=> Female <=> 6685 <=> postavshchik: P3 <=> srok: 07.02.2025 0:00:00 <=> 10
Request query ended by name on zapros 2.


*/