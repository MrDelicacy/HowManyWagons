using System;
namespace ConsoleAppHowManyWagons
{
    enum CountingStage
    {
        SETMARKER,
        SEARCHMARKER,
        COMEBACK
    }

    class WagonObserver
    {
        /// <summary>
        /// считает количество вагонов
        /// </summary>
        private int wagonCount;
        /// <summary>
        /// передается в метод GetWagon экземпляра объекта Train(true - следующий вагон, false - предыдущий вагон)
        /// </summary>
        private bool command;
        /// <summary>
        /// ожидаемое количество вагонов
        /// </summary>
        private int estimatedNumberWagons;
        /// <summary>
        /// показывает, правильно ли подсчитанны вагоны
        /// </summary>
        private bool calculated;
        public WagonObserver()
        {
            wagonCount = 0;
            command = true;
            calculated = false;
            estimatedNumberWagons = 0;
            Stage = CountingStage.SETMARKER;

        }
        public CountingStage Stage { get; set; }
        public bool Command
        {
            get
            {
                return command;
            }
        }
        public bool Calculeted
        {
            get
            {
                return calculated;
            }
        }
        public void AnalyzeWagonState(Wagon wagon)
        {
            switch (Stage)
            {
                case CountingStage.SETMARKER:
                        LightOnInFirstWagon(wagon);
                    break;
                case CountingStage.SEARCHMARKER:
                        SearchLightOnWagon(wagon);
                    break;
                case CountingStage.COMEBACK:
                        Check(wagon);
                    break;
            }
        }
        /// <summary>
        /// Включает свет в первом вагоне
        /// </summary>
        private void LightOnInFirstWagon(Wagon wagon)
        {
                if (wagon.GetLightState() != true)
                {
                    wagon.LightOn();
                    Console.WriteLine("включен свет в первом вагоне");
                }
                Console.WriteLine("включен свет в первом вагоне");
                Stage = CountingStage.SEARCHMARKER;              
        }
        /// <summary>
        /// Ищет вагон со включенным светом и выключает в нем свет. Считает количество пройденных вагонов
        /// </summary>
        private void SearchLightOnWagon(Wagon wagon)
        {
                wagonCount++;
                if (wagon.GetLightState() == true)
                {
                    estimatedNumberWagons = wagonCount;
                    wagon.LightOff();
                    Console.WriteLine("выключили свет. предполагаемое кол-во вагонов: "+ estimatedNumberWagons.ToString());
                    command = false;
                    Stage = CountingStage.COMEBACK;
                }
        }
        /// <summary>
        /// Проверяет, выключен ли свет в первом вагоне
        /// </summary>
        private void Check(Wagon wagon)
        {
            wagonCount--;
            if (wagonCount == 0 && wagon.GetLightState() == false)
            {
                calculated = true;
            }
            if (wagonCount == 0 && wagon.GetLightState() == true)
            {
                command = true;
                Stage = CountingStage.SEARCHMARKER;
            }
        }

        public int GetNumbersWagon()
        {
            return estimatedNumberWagons;
        }
    }
}
