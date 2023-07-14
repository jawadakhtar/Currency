// See https://aka.ms/new-console-template for more information
using Domain;
using Domain.Common;
using System.Diagnostics;

Console.WriteLine("ACCESS GROUP" + Environment.NewLine);

int currenciesToProfile = 2000000;

Console.WriteLine("Profiling " + currenciesToProfile + " Currency in Words ...");

Random random = new Random();
Stopwatch stopwatch = new Stopwatch();
for (int i = 0; i <= currenciesToProfile; i++)
{
    decimal value = (decimal)(random.Next(int.MaxValue) + random.NextDouble());

    stopwatch.Start();

    Currency currency = new Currency(value);
    string inWords = currency.ToString();

    stopwatch.Stop();
}

Console.WriteLine("It took about " + stopwatch.ElapsedMilliseconds + " (ms) to convert 1000000 random currencies in words.\n\n");


while (true)
{
    try
    {
        Console.WriteLine("Enter amount [q to Quit]: ");
        decimal amount;
        string amount_in = Console.ReadLine().Trim();

        if (amount_in.Trim() == "q")
            break;

        if (decimal.TryParse(amount_in, out amount) == false)
            continue;

        Currency curr = new Currency(amount);

        Console.WriteLine(curr.ToString());
        Console.WriteLine(Environment.NewLine);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

