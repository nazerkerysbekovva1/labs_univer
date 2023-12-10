using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstRxExample
{
    public class StockTick
    {
        public string QuoteSymbol { get; set; }
        public decimal Price { get; set; }

        //other properties
    }
    public class StockTicker : IStockTicker
    {
        public event EventHandler<StockTick> StockTick = delegate { };

        public void Notify(StockTick tick)
        {
            StockTick(this, tick);
        }
    }
    public interface IStockTicker
    {
        event EventHandler<StockTick> StockTick;
    }
    class StockInfo
    {
        public StockInfo(string symbol, decimal price)
        {
            Symbol = symbol;
            PrevPrice = price;
        }
        public string Symbol { get; set; }
        public decimal PrevPrice { get; set; }
    }
    public class StockSimulator
    {
        private readonly StockTicker _ticker;
        private IEnumerable<StockTick> _ticks;
        private int _itemToDrasticUpdate = 0;
        public StockSimulator(StockTicker ticker)
        {
            _ticker = ticker;
            _ticks = new[]
            {
                new StockTick() {QuoteSymbol = "MSFT", Price = 53.49M},
                new StockTick() {QuoteSymbol = "INTC", Price = 32.68M},
                new StockTick() {QuoteSymbol = "ORCL", Price = 41.48M},
                new StockTick() {QuoteSymbol = "CSCO", Price = 28.33M},
            };
        }

        public void Run()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    UpdatePrices();
                    PrintPrices();
                    Emit();
                    Thread.Sleep(2000);
                }
            });
        }

        private void Emit()
        {
            Console.WriteLine("Emitting...");
            foreach (var stockTick in _ticks)
            {
                _ticker.Notify(stockTick);
            }
        }

        private void PrintPrices()
        {
            Console.WriteLine("Next series to emit:");
            Console.WriteLine("\t");
            foreach (var stockTick in _ticks)
            {
                Console.WriteLine("{{{0} - {1}}}, ", stockTick.QuoteSymbol, stockTick.Price);
            }
            Console.WriteLine();

        }

        private void UpdatePrices()
        {
            _ticks = _ticks.Select((tick, i) =>
            {
                var changePercentage = _itemToDrasticUpdate == i ? 1.2M : 1.1M;
                return new StockTick() { Price = tick.Price * changePercentage, QuoteSymbol = tick.QuoteSymbol };
            }).ToList();

            _itemToDrasticUpdate++;
            _itemToDrasticUpdate %= _ticks.Count();
        }
    }
    class Program
    {
        private static StockTicker _stockTicker;

        private static void Main(string[] args)
        {
            _stockTicker = new StockTicker();
            var stockMonitor = new RxStockMonitor(_stockTicker);

            ShowMenu();

            GC.KeepAlive(stockMonitor);
            Console.WriteLine("Press <enter> to continue...");
            Console.ReadLine();
            Console.WriteLine("Bye Bye");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Choose a simulation type (or x to exit):");
            Console.WriteLine("1) Manual     - you enter the symbol and price");
            Console.WriteLine("2) Automatic  - the system emits and updates a predefined collection of ticks");
            Console.WriteLine("3) Concurrent - tests what happens when ticks are emitted concurrently");

            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    ManualSimulator(_stockTicker);
                    break;
                case "2":
                    AutomaticSimulator(_stockTicker);
                    break;
                case "3":
                    TestConcurrentTicks(_stockTicker);
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Unknow selection");
                    return;
            }
        }

        private static void AutomaticSimulator(StockTicker stockTicker)
        {
            var simulator = new StockSimulator(stockTicker);
            simulator.Run();
        }

        private static void ManualSimulator(StockTicker stockTicker)
        {
            while (true)
            {
                Console.Write("enter symbol (or x to exit): ");
                var symbol = Console.ReadLine();
                if (symbol.ToLower() == "x")
                {
                    break;
                }
                Console.WriteLine("enter price: ");
                decimal price;
                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    stockTicker.Notify(new StockTick() { Price = price, QuoteSymbol = symbol });
                }
                else
                {
                    Console.WriteLine("price should be decimal");
                }
            }
        }
        private static void TestConcurrentTicks(StockTicker stockTicker)
        {
            ThreadPool.QueueUserWorkItem((_) => stockTicker.Notify(new StockTick() { Price = 100, QuoteSymbol = "MSFT" }));
            ThreadPool.QueueUserWorkItem((_) => stockTicker.Notify(new StockTick() { Price = 150, QuoteSymbol = "INTC" }));
            ThreadPool.QueueUserWorkItem((_) => stockTicker.Notify(new StockTick() { Price = 170, QuoteSymbol = "MSFT" }));
            ThreadPool.QueueUserWorkItem((_) => stockTicker.Notify(new StockTick() { Price = 195.5M, QuoteSymbol = "MSFT" }));
        }
    }
}
