using BLL;
using Microsoft.AspNetCore.Mvc;

namespace lab7webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolverController : ControllerBase
    {
        private ISolver _solver;

        public SolverController(ISolver solver)
        {
            _solver = solver;
        }

        [HttpPost(Name = "calc")]
        public double[] Calc(Task task)
        {
            var row = new List<String>();

            row.AddRange(task.Flows.Select(f => f.From).ToList());
            row.AddRange(task.Flows.Select(f => f.To).ToList());

            row = new HashSet<string>(row).ToList();

            row.Remove("none");

            var matrixA = new double[row.Count + task.SecConditions.Count, task.Flows.Count];

            foreach (var item in task.Flows)
            {
                if (item.From != "none")
                {
                    matrixA[row.IndexOf(item.From), task.Flows.IndexOf(item)] = -1;
                }
                if (item.To != "none")
                {
                    matrixA[row.IndexOf(item.To), task.Flows.IndexOf(item)] = 1;
                }
            }

            for (int i = 0; i < task.SecConditions.Count; i++)
            {
                var condition = task.SecConditions[i];
                matrixA[row.Count + i, condition.FirstFlow - 1] = 1;
                matrixA[row.Count + i, condition.SecondFlow - 1] = -condition.TimesMore;
            }

            var data = new DataEntity()
            {
                MatrixA = matrixA,
                VectorY = new double[row.Count + task.SecConditions.Count],
                Tolerance = task.Flows.Select(f => f.Tolerance).ToArray(),
                VectorI = task.Flows.Select(f => f.IsEnabled ? 1.0 : 0.0).ToArray(),
                VectorX0 = task.Flows.Select(f => f.Weight).ToArray()
            };

            return _solver.Solve(data);
        }
    }
}