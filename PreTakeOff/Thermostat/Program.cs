using TempControlSytem;

ThermostatController thermostatController = ThermostatController.Start(initialTemp: 20, minTemp: 25, maxTemp: 40);

thermostatController.PrintInfo();
thermostatController.SetTemp(30);
thermostatController.Increase(10);
thermostatController.Decrease(50);
thermostatController.Increase(25);
thermostatController.Increase(25);

Console.ReadKey();