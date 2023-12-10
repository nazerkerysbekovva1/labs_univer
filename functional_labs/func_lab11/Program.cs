using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace func_lab11
{
    using static Console;
    using static F; 

    interface IRepository1<T>
    {
        Option<T> Get(Guid id);
    }

    interface IRepository2<T>
    {
        Option<T> Get(Guid id);
        void Save(T obj);
    }

    class CachingRepository<T> : IRepository1<T>
    {
        private IRepository1<T> cache;
        private IRepository1<T> db;

        public Option<T> Get(Guid id)
           //=> cache.Get(id).OrElse(db.Get(id)); // eagerly gets from DB, defeating the purpose of having the cache
           => cache.Get(id).OrElse(() => db.Get(id));
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string value = "Anton";
            Func<string, string> toUpper = s => s.ToUpper();
            Func<string, Unit> print = s => { WriteLine(s); return Unit(); };

            Identity(value)
               .Map(toUpper)
               .Map(print)();

            Guid g = new Guid(12345678 - 1234 - 1234 - 1234 - 123456789012);
            Model m = new Model();
            m.With("Naz", "Erke");

            ViewModel v = new ViewModel(); 

            Func_Map_Example func_Map_Example = new Func_Map_Example();

            func_Map_Example.ModelFactory(g);
            func_Map_Example.GetOrCreate(g);
            func_Map_Example.GetOrCreateModel(g);
            func_Map_Example.CreateAndCacheViewModel(g);


            ReadKey();
        }
    }

    class Model
    {
        public Guid Id { get; }
        public static Model Create(Guid id) => new Model();
    }
    class ViewModel { public Guid Id { get; } }

    static class Mapper
    {
        public static ViewModel ToViewModel(this Model model) => new ViewModel();
    }

    class Func_Map_Example
    {
        IRepository2<ViewModel> cache;
        IRepository2<Model> models;

        public Func<Model> ModelFactory(Guid id) => ()
           => models.Get(id).GetOrElse(Model.Create(id));

        public ViewModel GetOrCreate(Guid id)
           => cache.Get(id)
              .GetOrElse(ModelFactory(id).Map(Mapper.ToViewModel));

        public Model GetOrCreateModel(Guid id)
         => models.Get(id)
            .GetOrElse(Model.Create(id).Pipe(models.Save));

        public ViewModel CreateAndCacheViewModel(Guid id)
           => GetOrCreateModel(id).ToViewModel().Pipe(cache.Save);
    }
}