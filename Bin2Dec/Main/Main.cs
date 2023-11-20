using System.Text;
using System.Text.RegularExpressions;

namespace Bin2Dec.Main;

public class Main
{
    public static void Start()
    {
        while (true)
        {
            Menu();

            Console.Write("\nEnter the option: ");
            var option = Console.ReadLine();

            if (option!.Equals("0"))
                break;

            switch (option)
            {
                case "1":
                    Console.Write("\nEnter your binary value: ");
                    var binary = Console.ReadLine()!;

                    if (int.TryParse(binary, out _) && Regex.IsMatch(binary, "^[01]+$"))
                    {
                        Console.WriteLine(
                            $"Your binary value: \u001B[32m{binary}\u001B[0m " +
                            $"- Result: \u001B[32m{Bin2Dec(binary)}\u001B[0m");
                        break;
                    }

                    Console.WriteLine("Invalid characters, please enter only numbers of type 0 or 1.");
                    break;
                case "2":
                    Console.Write("\nEnter your decimal value: ");
                    binary = Console.ReadLine();

                    if (int.TryParse(binary, out _))
                    {
                        var binaryToDecimal = int.Parse(binary);
                        Console.WriteLine(
                            $"Your decimal value: \u001B[32m{binaryToDecimal}\u001B[0m " +
                            $"- Result: \u001B[32m{Dec2Bin(binaryToDecimal)}\u001B[0m");
                        break;
                    }

                    Console.WriteLine("Invalid characters, please enter only numbers of type 0 or 1.");
                    break;
                default:
                    Console.WriteLine("Invalid option...");
                    break;
            }
        }
    }

    private static string Dec2Bin(int decimalValue)
    {
        var stringBuilder = new StringBuilder();
        while (decimalValue > 0)
        {
            stringBuilder.Append(decimalValue % 2);
            decimalValue /= 2;
        }

        return new string(stringBuilder.ToString().Reverse().ToArray());
    }

    private static double Bin2Dec(string binary)
    {
        double result = 0;
        for (var i = 0; i < binary.Length; i++)
        {
            var bitValue = binary[i] - '0';
            result += bitValue * Math.Pow(2, (binary.Length - i) - 1);
        }

        return result;
    }

    private static void Menu()
    {
        var menuBar = new string('*', 30);

        Console.WriteLine();
        Console.WriteLine(menuBar);
        Console.WriteLine("== Choose your converter ==");
        Console.WriteLine(" 1 - Binary to Decimal");
        Console.WriteLine(" 2 - Decimal to Binary");
        Console.WriteLine(" 0 - Exit");
        Console.WriteLine(menuBar);
    }
}