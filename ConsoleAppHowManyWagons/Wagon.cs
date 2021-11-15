namespace ConsoleAppHowManyWagons
{
    class Wagon
    {
        private bool lightOnWagon;
        public Wagon(bool lighState)
        {
            lightOnWagon = lighState;
        }
        public void LightOn()
        {
            lightOnWagon = true;
        }
        public void LightOff()
        {
            lightOnWagon = false;
        }
        public bool GetLightState()
        {
            return lightOnWagon;
        }
    }
}
