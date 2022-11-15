using BLL;
using Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var solver = new Solver();
        Console.WriteLine("Тестовая дата");
        PrintData(solver.Solve(Data.Test));

        Console.WriteLine("Тестовая дата с доп. условием");
        PrintData(solver.Solve(Data.TestWithSpecialCodition));

        Console.WriteLine("V1");
        PrintData(solver.Solve(Data.V1));

        Console.WriteLine("V1 с доп. условием");
        PrintData(solver.Solve(Data.V1WithSpecialCodition));
    }

    private static void PrintData(double[] result)
    {
        Console.WriteLine(string.Join("; ", result));
        Console.WriteLine();
    }
}