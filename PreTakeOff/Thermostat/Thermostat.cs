namespace TempControlSystem
{
    internal class Thermostat
    {
        private readonly int _minTemp;
        private readonly int _maxTemp;
        private int _currentTemp;

        internal int CurrentTemp => _currentTemp;
        internal int MinTemp => _minTemp;
        internal int MaxTemp => _maxTemp;

        internal Thermostat(int initialTemp, int minTemp = 10, int maxTemp = 30)
        {
            _minTemp = minTemp;
            _maxTemp = maxTemp;
            _currentTemp = Restrict(initialTemp, _minTemp, _maxTemp);
        }

        internal void PrintInfo()
        {
            Console.WriteLine($"Thermostat Info: Current Temp: {_currentTemp}°C, Min Temp: {_minTemp}°C, Max Temp: {_maxTemp}°C");
        }

        internal void IncreaseTemp(int step = 1)
        {
            SetTemp(_currentTemp + step);
        }

        internal void DecreaseTemp(int step = 1)
        {
            SetTemp(_currentTemp - step);
        }

        internal void SetTemp(int newTemp)
        {
            _currentTemp = Restrict(newTemp, _minTemp, _maxTemp);
        }

        private static int Restrict(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
