namespace Lab6
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var solver = new Solver();

            Console.WriteLine("Тестовая дата");
            var testResult = solver.Solve(Data.Test);
            Printer.PrintData(testResult, Data.ExpectedTest);

            Console.WriteLine("Тестовая дата с доп. условием");
            var testResultWithCondition = solver.Solve(Data.Test, true);
            Printer.PrintData(testResultWithCondition);

            Console.WriteLine("V1");
            var v1Result = solver.Solve(Data.V1);
            Printer.PrintData(v1Result, Data.ExpectedV1);

            Console.WriteLine("V1 с доп. условием");
            solver.Solve(Data.V1, true);
            var v1ResultWithCondition = solver.Solve(Data.V1, true);
            Printer.PrintData(v1ResultWithCondition);

            Console.WriteLine("V2");
            var v2Result = solver.Solve(Data.V2);
            Printer.PrintData(v2Result, Data.ExpectedV2);

            Console.WriteLine("V2 с доп. условием");
            var v2ResultWithCondition = solver.Solve(Data.V2, true);
            Printer.PrintData(v2ResultWithCondition);
        }
    }
}