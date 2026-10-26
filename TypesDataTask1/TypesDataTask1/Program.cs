using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        double initialDeposit = 1000;
        int years = 3;
        double interestRate = 10;
        string result = CalculateCompoundInterest(initialDeposit, years, interestRate);
        Console.WriteLine(result);
    }
    public static string CalculateCompoundInterest(double initialDeposit, int years, double interestRate)
    {
        if (initialDeposit <= 0)
            throw new ArgumentException("Вклад должен быть положительным.");
        if (years <= 0)
            throw new ArgumentException("Количество лет должно быть положительным.");
        if (interestRate <= 0)
            throw new ArgumentException("Ставка должна быть положительной.");
        double currentAmount = initialDeposit;
        var result = new StringBuilder();
        for (var year = 1; year <= years; year++)
        {
            currentAmount = currentAmount * (1 + interestRate / 100);
            result.AppendLine($"Год {year}: {currentAmount:F2} руб.");
        }
        return result.ToString();
    }
}
