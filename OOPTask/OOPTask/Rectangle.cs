using System;

/// <summary>
/// Представляет прямоугольник с координатами левого верхнего угла, шириной и высотой.
/// </summary>
public class Rectangle
{
    private double _x;
    private double _y;
    private double _width;
    private double _height;

    /// <summary>
    /// Координата X левого верхнего угла.
    /// </summary>
    public double X
    {
        get => _x;
        set => _x = value;
    }

    /// <summary>
    /// Координата Y левого верхнего угла.
    /// </summary>
    public double Y
    {
        get => _y;
        set => _y = value;
    }

    /// <summary>
    /// Ширина прямоугольника. Не может быть отрицательной.
    /// </summary>
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

    /// <summary>
    /// Высота прямоугольника. Не может быть отрицательной.
    /// </summary>
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

    /// <summary>
    /// Периметр прямоугольника.
    /// </summary>
    public double Perimeter => 2 * (Width + Height);

    /// <summary>
    /// Площадь прямоугольника.
    /// </summary>
    public double Area => Width * Height;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Rectangle"/>.
    /// </summary>
    /// <param name="x">Координата X.</param>
    /// <param name="y">Координата Y.</param>
    /// <param name="width">Ширина (неотрицательная).</param>
    /// <param name="height">Высота (неотрицательная).</param>
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
        // Демонстрация корректного прямоугольника
        Rectangle test = new Rectangle(-10, 5, 5, 3);
        Console.WriteLine($"Площадь: {test.Area}");
        Console.WriteLine($"Периметр: {test.Perimeter}");

        // Демонстрация защиты от некорректного состояния
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