using System;
using System.Collections.Generic;


namespace ConsoleAppHowManyWagons
{
    class Train
    {
        private List<Wagon> wagons;
        private int wagonsShown;
        public Train()
        {
            wagons = new List<Wagon>();
            SetWagonsInTrain();
            wagonsShown = -1;
        }
        /// <summary>
        /// Устанавливает произвольное кол-во вагонов 
        /// и произвольно устанавливает состояние света в вагонах
        /// </summary>
        private void SetWagonsInTrain()
        {
            Random rand = new Random();
            int wagonCount = rand.Next(1, 200);
            for (int i = 0; i < wagonCount; i++)
            {
                Wagon w = new Wagon(Convert.ToBoolean(rand.Next(0, 2)));
                wagons.Add(w);
            }
        }
        private void NextWagon()
        {
            wagonsShown++;
            if (wagonsShown == wagons.Count)
                wagonsShown = 0;
        }
        private void PreviousWagon()
        {
            wagonsShown--;
            if (wagonsShown == -1)
                wagonsShown = wagons.Count - 1;
        }
        /// <summary>
        /// Возвращает вагоны из списка вагонов
        /// </summary>
        /// <param name="command">
        /// true- возвращает следующий вагон, false - предыдущий
        /// </param>
        /// <returns></returns>
        public Wagon GetWagon(bool command)
        {
            if (command == true)
                NextWagon();
            if (command == false)
                PreviousWagon();

            Console.WriteLine($"вагон {wagonsShown.ToString()}, свет {wagons[wagonsShown].GetLightState().ToString()}");
            return wagons[wagonsShown];
        }
        /// <summary>
        /// Проверяет, правильно ли посчитанны вагоны
        /// </summary>
        /// <param name="num">количество вагонов</param>
        public void CheckWagonNumbers(int num)
        {
            if (num == wagons.Count)
                Console.WriteLine("Вагоны посчитанны правильно!");
            else
                Console.WriteLine("Вагоны посчитанны не правильно!");
        }
    }
}
