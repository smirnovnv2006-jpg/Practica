public class Rectangle
{
    private double _x;
    private double _y;
    private double _width;
    private double _height;

    public double X
    {
        get => _x;
        set => _x = value;
    }

    public double Y
    {
        get => _y;
        set => _y = value;
    }

    public double Width
    {
        get => _width;
        set
        {
            if (value < 0)
                throw new ArgumentException("Ширина не может быть отрицательной");
            _width = value;
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (value < 0)
                throw new ArgumentException("Высота не может быть отрицательной");
            _height = value;
        }
    }

    public double Perimeter => 2 * (Width +  Height);
    public double Area => Width * Height;

    public Rectangle(double x, double y, double width, double height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Rectangle test = new Rectangle(-10,5,5,3);
        Console.WriteLine($"Площадь: {test.Area}");
        Console.WriteLine($"Периметр: {test.Perimeter}");

        try
        {
            Rectangle bad = new Rectangle(0, 0, -5, 3);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
