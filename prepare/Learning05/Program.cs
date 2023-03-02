using System;

class Program 
{
        static void Main(string[] args)
    {
        
        List<Shape> figures = new List<Shape>();

        var square = new Square("Red", 5);
        var rectangle = new Rectangle("Yellow", 6, 8);
        var circle = new Circle("Blue", 10);

        figures.Add(square);
        figures.Add(rectangle);
        figures.Add(circle);

        foreach (Shape f in figures)
        {
            string color = f.getColor();
            double area = f.GetArea();
            
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}

abstract class Shape {
    protected string _color;

    public Shape(string color){ 
        _color = color;
    }

    public string getColor() {
        return _color;
    }

    public void setColor(string color) {
        _color = color;
    }

    abstract public double GetArea();

}

class Square: Shape {
    private double _side;

    public Square(string color, double side) : base (color){
        _side = side;
    }

    public override double GetArea() {
        return _side * _side;
    }
    
}

class Rectangle: Shape {
    private double _length;
    private double _width;

    public Rectangle(string color, double lenght, double width) : base (color) {
        _length = lenght;
        _width = width;
    }

        public override double GetArea() {
        return _length * _width;
    }

}

class Circle: Shape {
    private double _radius;

    public Circle(string color, double radius) : base (color) {
        _radius = radius;
    }

        public override double GetArea() {
        return (_radius * _radius) * double.Pi;
    }

}