using TempControlSystem;

namespace TempControlSytem
{
    public class ThermostatController
    {
        private readonly Thermostat _thermostat;
        private readonly TemperatureRegulator _regulator;

        private ThermostatController(Thermostat thermostat)
        {
            _thermostat = thermostat;
            _regulator = new TemperatureRegulator();
        }

        public static ThermostatController Start(int initialTemp, int minTemp = 10, int maxTemp = 30)
        {
            return new ThermostatController(new Thermostat(initialTemp, minTemp, maxTemp));
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Thermostat Info: Current Temp: {_thermostat.CurrentTemp}°C, Min Temp: {_thermostat.MinTemp}°C, Max Temp: {_thermostat.MaxTemp}°C");
        }

        public void SetTemp(int value)
        {
            _thermostat.SetTemp(value);
            LogState();
        }

        public void Increase(int step = 1)
        {
            _thermostat.IncreaseTemp(step);
            LogState();
        }

        public void Decrease(int step = 1)
        {
            _thermostat.DecreaseTemp(step);
            LogState();
        }

        private void LogState()
        {
            Console.WriteLine($"Temperature set to {_thermostat.CurrentTemp}°C");
            Console.WriteLine(_regulator.Control(_thermostat));
        }
    }
}
