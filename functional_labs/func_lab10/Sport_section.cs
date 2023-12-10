using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using NUnit.Framework;

namespace func_lab10
{
    public delegate Validation<T> Validator<T>(T t);

    class Sport_section
    {
        static readonly Validator<int> Success = i => Valid(i);
        static readonly Validator<int> Failure = _ => Error("Invalid");

        public int id_section { get; set; }
        public string sport_section { get; set; }
        public string coach { get; set; }
        public string category { get; set; }
        public string the_rules { get; set; }

        public event EventHandler<NazEventArgs> UserEvent2;
        public void OnUserEvent2(NazEventArgs sport)
        {
            if (UserEvent2 != null)
                UserEvent2(this, sport);
        }
        public void DisplayMessage2(object sender, NazEventArgs sport)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"___{sport.section} спортшылары дайындык устынде. '{((Sport_section)sender).sport_section}' - спортшылары Халыкаралык жарыска баруга жиналатын болады!!!");
            Console.ResetColor();
        }

        public static void Massiv(List<Sport_section> sp)
        {
            for (int i = 0; i < sp.Count; i++)
            {
                for (int j = 0; j < sp.Count - 3; j++)
                {
                    if (i != j)
                    {
                        sp[i].UserEvent2 += sp[j].DisplayMessage2;
                    }
                }
            }
        }

        public Sport_section(int id_sport_section, string sport_section, string coach, string category, string the_rules)
        {
            this.id_section = id_sport_section;
            this.sport_section = sport_section;
            this.coach = coach;
            this.category = category;
            this.the_rules = the_rules;
        }

        static Validator<T> FailFast<T>
         (IEnumerable<Validator<T>> validators)
         => t
         => validators.Aggregate(Valid(t)
            , (acc, validator) => acc.Bind(_ => validator(t)));

        //запускает все валидаторы, накапливая все ошибки валидации
        static Validator<T> HarvestErrors<T>
           (IEnumerable<Validator<T>> validators)
           => t =>
           {
               var errors = validators
                .Map(validate => validate(t))
                .Bind(v => v.Match(
                   Invalid: errs => Some(errs),
                   Valid: _ => None))
                .ToList();

               return errors.Count == 0
                ? Valid(t)
                : Invalid(errors.Flatten());
           };

        static Action WhenAllValidatorsSucceed_ThenSucceed = () => {   //Assert.AreEgual - метод для сравнения
            Assert.AreEqual(
           actual: FailFast(List(Success, Success))(3),     //Это объект, которого ожидают тесты.
           expected: Valid(3));                             //Это объект, созданный тестируемым кодом.
            Console.WriteLine("All Validators Succeed:  " + FailFast(List(Success, Success))(3) + " == " + Valid(3));
        };

        static Action WhenNoValidators_ThenSucceed = () =>
        {
            Assert.AreEqual(
           actual: FailFast(List<Validator<string>>())("success"),
           expected: Valid("success"));
            Console.WriteLine("No Validators:  " + FailFast(List<Validator<string>>())("success") + " == " + Valid("success"));
        };

        static Action WhenOneValidatorFails_ThenFail = () =>
        {
            HarvestErrors(List(Success, Failure))(1).Match(
               Valid: (_) => Assert.Fail(),
               Invalid: (errs) => Assert.AreEqual(1, errs.Count()));
            Console.WriteLine("One Validator Fails:  " + HarvestErrors(List(Success, Failure))(2));
        };

        static Action WhenSeveralValidatorsFail_ThenFail = () =>
        {
            HarvestErrors(List(Success, Failure, Failure, Success))(4).Match(
               Valid: (_) => Assert.Fail(),
               Invalid: (errs) => Assert.AreEqual(2, errs.Count()));
            Console.WriteLine("Several Validator Fails:  " + HarvestErrors(List(Success, Failure, Failure, Success))(4));
        };

        internal static void Run()
        {
            Console.WriteLine("\n all success are returned:");
            WhenAllValidatorsSucceed_ThenSucceed();
            WhenNoValidators_ThenSucceed();
            Console.WriteLine("\n all errors are returned:");
            WhenOneValidatorFails_ThenFail();
            WhenSeveralValidatorsFail_ThenFail();
        }

        public void Collect(string section, List<Sport_section> sport_Sections)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (Sport_section s in sport_Sections)
            {
                if (s.sport_section == section)
                {
                    Console.WriteLine();
                    Console.WriteLine($"'{s.sport_section}' жолдама алды");
                    s.OnUserEvent2(new NazEventArgs(sport_section));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"'{s.sport_section}' жолдама алмады");
                }
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }
    }
}
