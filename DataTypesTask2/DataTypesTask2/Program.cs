using System.Text;
public class Program2
{
    public static void Main(string[] args)
    {
        int n = 5;
        DrawDiamond(n);
    }
    public static void DrawDiamond(int n)
    {
        if ((n % 2 == 0) || (n < 1))
            throw new ArgumentException("Число N должно быть положительным нечётным.");
        var mid = n / 2;
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
        Console.WriteLine(result);
    }
}