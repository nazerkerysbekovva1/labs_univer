using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace reak_lab4
{
    struct Tovar
    {
        public int id;
        public string tovar_name;
        public string vid;
        public int price;
        public string postavshik;
        public DateTime srok;
        public int kolichestvo;

        IList<IQueryRegistration> iquery = new List<IQueryRegistration>();

        public Tovar(int tovarId, string name, string vid, int price, string optovaya_firma_postavshchik, DateTime srok_godnosti, int kolichestvo_postavlennykh_yedinits)
        {
            id = tovarId;
            tovar_name = name;
            this.vid = vid;
            this.price = price;
            postavshik = optovaya_firma_postavshchik;
            srok = srok_godnosti;
            kolichestvo = kolichestvo_postavlennykh_yedinits;
        }
        public void Info()
        {
            Console.WriteLine($" {id} <=> '{tovar_name}' <=> {vid} <=> {price} <=> postavshchik: {postavshik} <=> srok: {srok} <=> {kolichestvo}");
        }

        public IQueryRegistration Connect(string user, string password)
        { 
            Console.WriteLine("Connect");  //registr
            var registration = new QueryRegistration();
            iquery.Add(registration);
            return registration;
        }

        public IObservable<string> ObserveMessages(string user, string password)
        {
            var connection = Connect(user, password);
            return connection.ToObservable();
        }
    }
}
