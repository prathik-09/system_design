using System;

// ---------------- Strategy Interface for Walk ----------------
interface IWalkableRobot
{
    void Walk();
}

// ---------------- Concrete Strategies for Walk ----------------
class NormalWalk : IWalkableRobot
{
    public void Walk()
    {
        Console.WriteLine("Walking normally...");
    }
}

class NoWalk : IWalkableRobot
{
    public void Walk()
    {
        Console.WriteLine("Cannot walk.");
    }
}

// ---------------- Strategy Interface for Talk ----------------
interface ITalkableRobot
{
    void Talk();
}

// ---------------- Concrete Strategies for Talk ----------------
class NormalTalk : ITalkableRobot
{
    public void Talk()
    {
        Console.WriteLine("Talking normally...");
    }
}

class NoTalk : ITalkableRobot
{
    public void Talk()
    {
        Console.WriteLine("Cannot talk.");
    }
}

// ---------------- Strategy Interface for Fly ----------------
interface IFlyableRobot
{
    void Fly();
}

// ---------------- Concrete Strategies for Fly ----------------
class NormalFly : IFlyableRobot
{
    public void Fly()
    {
        Console.WriteLine("Flying normally...");
    }
}

class NoFly : IFlyableRobot
{
    public void Fly()
    {
        Console.WriteLine("Cannot fly.");
    }
}

// ---------------- Base Robot Class ----------------
abstract class Robot
{
    protected IWalkableRobot walkBehavior;
    protected ITalkableRobot talkBehavior;
    protected IFlyableRobot flyBehavior;

    // Constructor Injection
    public Robot(
        IWalkableRobot walk,
        ITalkableRobot talk,
        IFlyableRobot fly)
    {
        walkBehavior = walk;
        talkBehavior = talk;
        flyBehavior = fly;
    }

    // Delegating behavior
    public void Walk()
    {
        walkBehavior.Walk();
    }

    public void Talk()
    {
        talkBehavior.Talk();
    }

    public void Fly()
    {
        flyBehavior.Fly();
    }

    // Abstract method
    public abstract void Projection();
}

// ---------------- Concrete Robot Types ----------------
class CompanionRobot : Robot
{
    public CompanionRobot(
        IWalkableRobot walk,
        ITalkableRobot talk,
        IFlyableRobot fly)
        : base(walk, talk, fly)
    {
    }

    public override void Projection()
    {
        Console.WriteLine("Displaying friendly companion features...");
    }
}

class WorkerRobot : Robot
{
    public WorkerRobot(
        IWalkableRobot walk,
        ITalkableRobot talk,
        IFlyableRobot fly)
        : base(walk, talk, fly)
    {
    }

    public override void Projection()
    {
        Console.WriteLine("Displaying worker efficiency stats...");
    }
}

// ---------------- Main Program ----------------
class StrategyDP
{
    static void Main(string[] args)
    {
        // Companion Robot
        Robot robot1 = new CompanionRobot(
            new NormalWalk(),
            new NormalTalk(),
            new NoFly()
        );

        robot1.Walk();
        robot1.Talk();
        robot1.Fly();
        robot1.Projection();

        Console.WriteLine("----------------------");

        // Worker Robot
        Robot robot2 = new WorkerRobot(
            new NoWalk(),
            new NoTalk(),
            new NormalFly()
        );

        robot2.Walk();
        robot2.Talk();
        robot2.Fly();
        robot2.Projection();
    }
}