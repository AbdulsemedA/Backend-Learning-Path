public class Shape {
    private string Name;
    protected double X, Y;

    public Shape(string name, double x, double y) {
        Name = name;
        X = x;
        Y = y;
    }
    public virtual double CalculateArea() {
        return X * Y;   
    }

    public string GetName() {
        return Name;
    }
}
public class Circle : Shape 
{
    public const double PI = Math.PI;
    private double Radius;

    public Circle(string name, double radius) : base(name, radius, 0) 
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return PI * Radius * Radius;
    }

}

public class Rectangle : Shape
{
    private double Width, Height;

    public Rectangle(string name, double width, double height) : base(name, width, height) 
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    private double Base, Height;

    public Triangle(string name, double @base, double height) : base(name, @base, height) 
    {
        Base = @base;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Base * Height / 2;
    }
}

public class Program
{
    
    public static void PrintShapeArea(Shape shape) {
        Console.WriteLine("{0} area: {1}", shape.GetName(), shape.CalculateArea());
    }
    
    public static void Main() {
        Shape circle = new Circle("Circle", 5);
        Shape rectangle = new Rectangle("Rectangle", 5, 10);
        Shape triangle = new Triangle("Triangle", 5, 10);
        
        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
        
    }
}