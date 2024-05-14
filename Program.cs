using System;

class Rectangle
{
    private double length;
    private double width;

    public Rectangle()
    {
        length = 0;
        width = 0;
    }

    public Rectangle(double l, double w)
    {
        length = l;
        width = w;
    }

    ~Rectangle()
    {
        Console.WriteLine("Объект Прямоугольник уничтожен");
    }

    public static Rectangle operator *(Rectangle r1, Rectangle r2)
    {
        double intersectLength = Math.Min(r1.length, r2.length);
        double intersectWidth = Math.Min(r1.width, r2.width);
        return new Rectangle(intersectLength, intersectWidth);
    }

    public double GetArea()
    {
        return length * width;
    }

    public static bool operator >(Rectangle r1, Rectangle r2)
    {
        return r1.GetArea() > r2.GetArea();
    }

    public static bool operator <(Rectangle r1, Rectangle r2)
    {
        return r1.GetArea() < r2.GetArea();
    }

    public static bool operator ==(Rectangle r1, Rectangle r2)
    {
        return r1.GetArea() == r2.GetArea();
    }

    public static bool operator !=(Rectangle r1, Rectangle r2)
    {
        return r1.GetArea() != r2.GetArea();
    }

    public override string ToString()
    {
        return $"Прямоугольник: Длина = {length}, Ширина = {width}, Площадь = {GetArea()}";
    }

    public static Rectangle FromString(string rectangleStr)
    {
        string[] values = rectangleStr.Split(',');
        double l = double.Parse(values[0].Split('=')[1]);
        double w = double.Parse(values[1].Split('=')[1]);
        return new Rectangle(l, w);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размеры первого прямоугольника (длина,ширина): ");
        string[] input1 = Console.ReadLine().Split(',');
        double length1 = double.Parse(input1[0]);
        double width1 = double.Parse(input1[1]);
        Rectangle rect1 = new Rectangle(length1, width1);

        Console.WriteLine("Введите размеры второго прямоугольника (длина,ширина): ");
        string[] input2 = Console.ReadLine().Split(',');
        double length2 = double.Parse(input2[0]);
        double width2 = double.Parse(input2[1]);
        Rectangle rect2 = new Rectangle(length2, width2);


        Console.WriteLine($"Площадь первого прямоугольника: {rect1.GetArea()}");
        Console.WriteLine($"площадь второго прямоугольника: {rect2.GetArea()}");

        Console.WriteLine($"Сравнение прямоугольников:");
        Console.WriteLine($"первый прямоугольник > второй прямоугольник: {rect1 > rect2}");
        Console.WriteLine($"первый прямоугольник < второй прямоугольник: {rect1 < rect2}");
        Console.WriteLine($"первый прямоугольник == второй прямоугольник: {rect1 == rect2}");
        Console.WriteLine($"первый прямоугольник != второй прямоугольник: {rect1 != rect2}");

        Console.WriteLine("Введите строковое представление прямоугольника (например 'Прямоугольник: Длина = 2, Ширина = 3'): ");
        string rectangleStr = Console.ReadLine();
        Rectangle rectFromString = Rectangle.FromString(rectangleStr);
        Console.WriteLine($"Прямоугольник из строки: {rectFromString}");
    }
}