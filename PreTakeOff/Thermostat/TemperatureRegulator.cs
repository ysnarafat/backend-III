using TempControlSystem;

namespace TempControlSytem
{
    internal class TemperatureRegulator
    {
        public string Control(Thermostat thermostat)
        {
            if (thermostat.CurrentTemp <= thermostat.MinTemp)
                return "Heater turned ON (too cold).";

            if (thermostat.CurrentTemp >= thermostat.MaxTemp)
                return "Cooler turned ON (too hot).";

            return "System idle. Temperature within range.";
        }
    }
}
