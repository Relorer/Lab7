namespace Lab6
{
    using System;

    public static class Printer
    {
        public static void PrintData(double[] result)
        {
            Console.WriteLine(string.Join("; ", result) + " (Результат)");
            Console.WriteLine();
        }

        public static void PrintData(double[] result, double[] expectedResult)
        {
            Console.WriteLine(string.Join("; ", expectedResult) + " (Ожидаемый результат)");
            Console.WriteLine(string.Join("; ", result) + " (Результат)");
            Console.WriteLine();
        }
    }
}
