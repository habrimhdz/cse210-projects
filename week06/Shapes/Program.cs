using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Square square = new Square("Red", 5);
        Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea()}");

        Circle circle = new Circle("Blue", 3);
        Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea()}");

        Rectangle rectangle = new Rectangle("Green", 4, 6);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");

        List<Shape> shapes = new List<Shape> { square, circle, rectangle };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}