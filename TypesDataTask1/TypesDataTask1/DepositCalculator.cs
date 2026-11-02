using System.Collections.Generic;

/// <summary>
/// Калькулятор вкладов.
/// </summary>
public class DepositCalculator
{
    /// <summary>
    /// Вычисляет сложный процент по годам.
    /// </summary>
    /// <param name="initialDeposit">Стартовый размер вклада.</param>
    /// <param name="years">Количество лет.</param>
    /// <param name="interestRate">Годовая процентная ставка.</param>
    /// <returns>Список кортежей с номером года и накопленной суммой.</returns>
    public static List<(int year, double amount)> CalculateCompoundInterest(
        double initialDeposit,
        int years,
        double interestRate)
    {
        CheckIsPositive(initialDeposit, "Стартовый размер вклада должен быть > 0.");
        CheckIsPositive(years, "Количество лет должно быть > 0.");
        CheckIsPositive(interestRate, "Ставка должна быть > 0.");

        double currentAmount = initialDeposit;
        var result = new List<(int year, double amount)>();

        for (var year = 1; year <= years; year++)
        {
            currentAmount = currentAmount * (1 + interestRate / 100);
            result.Add((year, currentAmount));
        }

        return result;
    }

    /// <summary>
    /// Проверяет, что значение положительное.
    /// </summary>
    /// <param name="value">Проверяемое значение.</param>
    /// <param name="errorMessage">Текст ошибки.</param>
    private static void CheckIsPositive(double value, string errorMessage)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), errorMessage);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        double initialDeposit = 1000;
        int years = 3;
        double interestRate = 10;

        // Обращаемся к классу DepositCalculator
        var deposits = DepositCalculator.CalculateCompoundInterest(initialDeposit, years, interestRate);

        foreach (var deposit in deposits)
        {
            Console.WriteLine($"Год {deposit.year}: {deposit.amount:F2} руб.");
        }
    }
}
