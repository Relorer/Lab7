using Microsoft.VisualStudio.TestTools.UnitTesting;

using BLL;
using System.Text.Json;

namespace lab7webapi.Controllers.Tests
{
    [TestClass()]
    public class SolverControllerTests
    {
        private double accuracy = 0.1;

        private SolverController solverController = new SolverController(new Solver());

        [TestMethod()]
        public void SolveTest1()
        {
            var task =
                JsonSerializer.Deserialize<Task>(@"
                                    {
                                      ""Flows"": [
                                        {
                                          ""From"": ""none"",
                                          ""To"": ""1"",
                                          ""Weight"": 10.005,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.200
                                        },
                                        {
                                          ""From"": ""1"",
                                          ""To"": ""none"",
                                          ""Weight"": 3.033,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.121
                                        },    {
                                          ""From"": ""1"",
                                          ""To"": ""2"",
                                          ""Weight"": 6.831,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.683
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""none"",
                                          ""Weight"": 1.985,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.040
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""3"",
                                          ""Weight"": 5.093,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.102
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 4.057,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.081
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 0.991,
                                          ""IsEnabled"": true,
                                          ""Tolerance"":0.020
                                        },    {
                                          ""From"": ""1"",
                                          ""To"": ""none"",
                                          ""Weight"": 6.667,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.667
                                        }
                                      ],
                                      ""SecConditions"": [
                                        {
                                          ""FirstFlow"": 1,
                                          ""SecondFlow"": 2,
                                          ""TimesMore"": 10
                                        }
                                      ]
                                    }
                                                ");

            double[] expected = Data.ExpectedV1WithSpecialCodition;

            var result = solverController.Calc(task);

            var sum = 0.0;

            for (int i = 0; i < Data.V1WithSpecialCodition.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.V1WithSpecialCodition.MatrixA.GetLength(1); j++)
                {
                    sum += Data.V1WithSpecialCodition.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }

        [TestMethod()]
        public void SolveTest2()
        {
            var task =
                JsonSerializer.Deserialize<Task>(@"
                                    {
                                      ""Flows"": [
                                        {
                                          ""From"": ""none"",
                                          ""To"": ""1"",
                                          ""Weight"": 10.005,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.200
                                        },
                                        {
                                          ""From"": ""1"",
                                          ""To"": ""none"",
                                          ""Weight"": 3.033,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.121
                                        },    {
                                          ""From"": ""1"",
                                          ""To"": ""2"",
                                          ""Weight"": 6.831,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.683
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""none"",
                                          ""Weight"": 1.985,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.040
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""3"",
                                          ""Weight"": 5.093,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.102
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 4.057,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.081
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 0.991,
                                          ""IsEnabled"": true,
                                          ""Tolerance"":0.020
                                        },    {
                                          ""From"": ""1"",
                                          ""To"": ""none"",
                                          ""Weight"": 6.667,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.667
                                        }
                                      ],
                                      ""SecConditions"": [

                                      ]
                                    }
                                                ");

            double[] expected = Data.ExpectedV1;

            var result = solverController.Calc(task);

            var sum = 0.0;

            for (int i = 0; i < Data.V1.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.V1.MatrixA.GetLength(1); j++)
                {
                    sum += Data.V1.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }

        [TestMethod()]
        public void SolveTest3()
        {
            var task =
                JsonSerializer.Deserialize<Task>(@"
                                    {
                                      ""Flows"": [
                                        {
                                          ""From"": ""none"",
                                          ""To"": ""1"",
                                          ""Weight"": 10.005,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.200
                                        },
                                        {
                                          ""From"": ""1"",
                                          ""To"": ""none"",
                                          ""Weight"": 3.033,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.121
                                        },    {
                                          ""From"": ""1"",
                                          ""To"": ""2"",
                                          ""Weight"": 6.831,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.683
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""none"",
                                          ""Weight"": 1.985,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.040
                                        },    {
                                          ""From"": ""2"",
                                          ""To"": ""3"",
                                          ""Weight"": 5.093,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.102
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 4.057,
                                          ""IsEnabled"": true,
                                          ""Tolerance"": 0.081
                                        },    {
                                          ""From"": ""3"",
                                          ""To"": ""none"",
                                          ""Weight"": 0.991,
                                          ""IsEnabled"": true,
                                          ""Tolerance"":0.020
                                        }
                                      ],
                                      ""SecConditions"": [

                                      ]
                                    }
                                                ");

            double[] expected = Data.ExpectedTest;

            var result = solverController.Calc(task);

            var sum = 0.0;

            for (int i = 0; i < Data.Test.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.Test.MatrixA.GetLength(1); j++)
                {
                    sum += Data.Test.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }
    }
}