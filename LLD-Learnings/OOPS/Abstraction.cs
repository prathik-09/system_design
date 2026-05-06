using System;

interface Car {
    void startEngine(); 
    void shiftGear(int gear);
    void accelerate();
    void brake();
    void stopEngine();
}

namespace CarExample
{
    class Sportscar : Car {

    
    public void startEngine() {
        isEngineOn = true;
        Console.WriteLine("Starting the sports car engine...");
    }

    
    public void shiftGear(int gear) {
        Console.WriteLine("Shifting to gear " + gear + " in the sports car...");
    }

    
    public void accelerate() {
        Console.WriteLine("Accelerating the sports car...");
    }

    
    public void brake() {
        Console.WriteLine("Braking the sports car...");
    }

    
    public void stopEngine() {
        Console.WriteLine("Stopping the sports car engine...");
    }
}
}

class Abstraction
{
    public static void Main(string[] args) {
        Car myCar = new CarExample.Sportscar();
        myCar.startEngine();
        myCar.shiftGear(1);
        myCar.accelerate();
        myCar.brake();
        myCar.stopEngine();
    }
}