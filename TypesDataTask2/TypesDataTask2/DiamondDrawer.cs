using System;
using System.Text;

/// <summary>
/// Генератор геометрических фигур.
/// </summary>
public class DiamondDrawer
{
    /// <summary>
    /// Генерирует строковое представление ромба из символов 'X'.
    /// </summary>
    /// <param name="n">Длина диагонали (положительное нечётное число).</param>
    /// <returns>Строка с ромбом.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если N не является положительным нечётным числом.</exception>
    public static string GenerateDiamond(int n)
    {
        if ((n % 2 == 0) || (n < 1))
        {
            throw new ArgumentException("Число N должно быть положительным нечётным.");
        }

        int mid = n / 2;
        var result = new StringBuilder();

        for (int row = 0; row < n; row++)
        {
            int dist = Math.Abs(row - mid);

            for (int index = 0; index < n; index++)
            {
                if ((index == dist) || (index == n - dist - 1))
                    result.Append("x");
                else
                    result.Append(" ");
            }

            result.AppendLine();
        }

        // Возвращаем готовую строку, НЕ печатаем её здесь!
        return result.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = 5;

        // 1. Получаем готовую строку с ромбом
        string diamond = DiamondDrawer.GenerateDiamond(n);

        // 2. Выводим её на экран (только здесь!)
        Console.WriteLine(diamond);
    }
}