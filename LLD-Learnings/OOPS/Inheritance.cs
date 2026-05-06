using System;

class Car
{
    public string brand;
    public string model;
    public bool isEngineOn = false;
    public int currentSpeed = 0;

    public Car(string brand, string model)
    {
        this.brand = brand;
        this.model = model;
    }

    public void StartEngine()
    {
        isEngineOn = true;
        Console.WriteLine($"{brand} {model} : Engine starts with a roar!");
    }

    public void GetCurrentSpeed(int speed)
    {
        if (!isEngineOn)
        {
            Console.WriteLine($"{brand} {model} : Engine is off! Current speed is 0 km/h");
            return;
        }
        currentSpeed = speed;
        Console.WriteLine($"{brand} {model} : Current speed is {currentSpeed} km/h");
    }
}

// Child class 1
class ManualCar : Car
{
    private int currentGear = 0;

    public ManualCar(string brand, string model) : base(brand, model) {}

    public void ShiftGear(int gear)
    {
        currentGear = gear;
        Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
    }
}

// Child class 2
class EV : Car
{
    private int batteryLevel = 100;

    public EV(string brand, string model) : base(brand, model) {}

    public void CheckBattery()
    {
        Console.WriteLine($"{brand} {model} : Battery level is at {batteryLevel}%");
    }
}

class Inheritance
{
    static void Main(string[] args)
    {
        ManualCar myManualCar = new ManualCar("Toyota", "Corolla");
        myManualCar.StartEngine();
        myManualCar.ShiftGear(1);
        myManualCar.GetCurrentSpeed(40);

        EV myEV = new EV("Tesla", "Model 3");
        myEV.StartEngine();
        myEV.CheckBattery();
        myEV.GetCurrentSpeed(20);
    }
}