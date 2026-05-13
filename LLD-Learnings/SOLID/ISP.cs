interface TwoDShape
{
    public double Area();
}
interface ThreeDShape
{
    public double Volume();
}
public class Circle : TwoDShape
{
    private double r;
    public Circle(double radius)
    {
        r = radius;
    }
    public double Area()
    {
        return Math.PI * r * r;
    }
}
public class Sphere : ThreeDShape
{
    private double r;
    public Sphere(double radius)
    {
        r = radius;
    }
    public double Volume()
    {
        return (4.0 / 3.0) * Math.PI * r * r * r;
    }
}
public class ISP
{
    public static void Main(String[] args)
    {
        TwoDShape circle = new Circle(5);
        Console.WriteLine($"Area of the circle: {circle.Area()}");
        
        ThreeDShape sphere = new Sphere(5);
        Console.WriteLine($"Volume of the sphere: {sphere.Volume()}");
    }
}