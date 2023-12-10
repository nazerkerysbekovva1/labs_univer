using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Reactive.Disposables;

namespace reak_lab6
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

        static string Info(List<Tovar> tovars, int index)
        {
            // Имитация 
            Thread.Sleep(2000);

            if (index < tovars.Count())
                foreach(var t in tovars)
                    return  $"\n {t.id} <=> '{t.tovar_name}' <=> {t.vid} <=> {t.price} ";

            return tovars.Count().ToString();
        }

        public static IEnumerable<string> Generate(List<Tovar> tovars)
        {
            for (int i = 0; i < tovars.Count(); i++)
            {
                yield return Info(tovars, i);
            }
        }

        public async Task<IReadOnlyCollection<string>> GenerateAsync(List<Tovar> tovars)
        {
            return await Task.Run(() => Generate(tovars).ToList().AsReadOnly());
        }

        public IObservable<Tovar> GeneratePrimes_ManualAsync(List<Tovar> tovars, Nullable<Tovar> tovar)
        {
            var cts = new CancellationTokenSource();
            return Observable.Create<Tovar>(o =>
            {
                Task.Run(() =>
                {
                    foreach (var tv in Generate(tovars))
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        o.OnNext(tovar.Value);
                    }
                    o.OnCompleted();
                }, cts.Token);

                return new CancellationDisposable(cts);
            });
        }

        public IObservable<Tovar> GeneratePrimes_Sync(List<Tovar> tovars, Nullable<Tovar> tovar)
        {
            return Observable.Create<Tovar>(o =>
            {
                foreach (var tv in Generate(tovars))
                {
                    o.OnNext(tovar.Value);
                }
                o.OnCompleted();
                return Disposable.Empty;
            });
        }

        public IObservable<Tovar> GeneratePrimes_AsyncCreate(List<Tovar> tovars, Nullable<Tovar> tovar)
        {
            return Observable.Create<Tovar>((o, ct) =>
            {
                return Task.Run(() =>
                {
                    foreach (var tv in Generate(tovars))
                    {
                        ct.ThrowIfCancellationRequested();
                        o.OnNext(tovar.Value);
                    }
                    o.OnCompleted();
                }, ct);

            });
        }

        public IObservable<Tovar> GeneratePrimes3(List<Tovar> tovars, Nullable<Tovar> tovar)
        {
            return Observable.Create<Tovar>((o, ct) =>
            {
                return Task.Run(() =>
                {
                    foreach (var tv in Generate(tovars))
                    {
                        ct.ThrowIfCancellationRequested();
                        o.OnNext(tovar.Value);
                    }
                    o.OnCompleted();
                });

            });
        }

    }
}
