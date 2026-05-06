using System;

// Abstract parent class
abstract class Car
{
    protected string brand;
    protected string model;
    protected bool isEngineOn;
    protected int currentSpeed;

    public Car(string brand, string model)
    {
        this.brand = brand;
        this.model = model;
        this.isEngineOn = false;
        this.currentSpeed = 0;
    }

    // Common methods
    public void StartEngine()
    {
        isEngineOn = true;
        Console.WriteLine($"{brand} {model} : Engine started.");
    }

    public void StopEngine()
    {
        isEngineOn = false;
        currentSpeed = 0;
        Console.WriteLine($"{brand} {model} : Engine turned off.");
    }

    // Abstract methods
    public abstract void Accelerate();
    public abstract void Brake();
}

// Manual Car
class ManualCar : Car
{
    private int currentGear;

    public ManualCar(string brand, string model) : base(brand, model)
    {
        currentGear = 0;
    }

    public void ShiftGear(int gear)
    {
        currentGear = gear;
        Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
    }

    public override void Accelerate()
    {
        if (!isEngineOn)
        {
            Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
            return;
        }

        currentSpeed += 20;
        Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h");
    }

    public override void Brake()
    {
        currentSpeed -= 20;
        if (currentSpeed < 0) currentSpeed = 0;

        Console.WriteLine($"{brand} {model} : Braking! Speed is now {currentSpeed} km/h");
    }
}

// Electric Car
class ElectricCar : Car
{
    private int batteryLevel;

    public ElectricCar(string brand, string model) : base(brand, model)
    {
        batteryLevel = 100;
    }

    public void ChargeBattery()
    {
        batteryLevel = 100;
        Console.WriteLine($"{brand} {model} : Battery fully charged!");
    }

    public override void Accelerate()
    {
        if (!isEngineOn)
        {
            Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
            return;
        }

        if (batteryLevel <= 0)
        {
            Console.WriteLine($"{brand} {model} : Battery dead! Cannot accelerate.");
            return;
        }

        batteryLevel -= 10;
        currentSpeed += 15;

        Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h. Battery at {batteryLevel}%.");
    }

    public override void Brake()
    {
        currentSpeed -= 15;
        if (currentSpeed < 0) currentSpeed = 0;

        Console.WriteLine($"{brand} {model} : Regenerative braking! Speed is now {currentSpeed} km/h. Battery at {batteryLevel}%.");
    }
}

// Main
class DynamicPoly
{
    static void Main(string[] args)
    {
        Car myManualCar = new ManualCar("Suzuki", "WagonR");
        myManualCar.StartEngine();
        myManualCar.Accelerate();
        myManualCar.Accelerate();
        myManualCar.Brake();
        myManualCar.StopEngine();

        Console.WriteLine("----------------------");

        Car myElectricCar = new ElectricCar("Tesla", "Model S");
        myElectricCar.StartEngine();
        myElectricCar.Accelerate();
        myElectricCar.Accelerate();
        myElectricCar.Brake();
        myElectricCar.StopEngine();
    }
}