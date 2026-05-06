using System;

class Car
{
    private string brand;
    private string model;
    private bool isEngineOn = false;
    private int currentSpeed = 0;
    private int currentGear = 0;
    private string tyreCompany;

    public Car(string brand, string model, string tyreCompany) {
        this.brand = brand;
        this.model = model;
        this.tyreCompany = tyreCompany;
    }
    public int getCurrentSpeed() {
        return currentSpeed;
    }
    public string GetTyreCompany()
    {
        return tyreCompany;
    }

    public void SetTyreCompany(string tyreCompany)
    {
        this.tyreCompany = tyreCompany;
    }
    public void StartEngine()
    {
        isEngineOn = true;
        Console.WriteLine($"{brand} {model} : Engine starts with a roar!");
    }

    public void ShiftGear(int gear)
    {
        currentGear = gear;
        Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
    }
    public void Accelerate()
    {
        if (!isEngineOn)
        {
            Console.WriteLine($"{brand} {model} : Engine is off! Cannot accelerate.");
            return;
        }
        currentSpeed += 10;
        Console.WriteLine($"{brand} {model} : Accelerating... Current speed: {currentSpeed} km/h");
    }
     public void Brake()
    {
        currentSpeed -= 20;
        if (currentSpeed < 0) currentSpeed = 0;
        Console.WriteLine($"{brand} {model} : Braking! Speed is now {currentSpeed} km/h");
    }

    public void StopEngine()
    {
        isEngineOn = false;
        currentGear = 0;
        currentSpeed = 0;
        Console.WriteLine($"{brand} {model} : Engine turned off.");
    }
}
class Encapsulation
{
    public static void Main(string[] args)
    {
        Car c=new Car("Toyota","Camry","Bridgestone");
        c.StartEngine();
        c.ShiftGear(1); 
        c.Accelerate();
        c.Brake();
        c.StopEngine();
        Console.WriteLine("Current Speed: " + c.getCurrentSpeed());
    }
}