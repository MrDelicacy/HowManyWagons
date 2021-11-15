using System;


namespace ConsoleAppHowManyWagons
{
    class Program
    {
        static void Main(string[] args)
        {
            Train t = new Train();
            WagonObserver observer = new WagonObserver();
            while (observer.Calculeted == false)
            {
                observer.AnalyzeWagonState(t.GetWagon(observer.Command));

            }
            Console.WriteLine($"в поезде {observer.GetNumbersWagon()} вагонов");
            t.CheckWagonNumbers(observer.GetNumbersWagon());
            Console.ReadKey();
        }
    }
}
