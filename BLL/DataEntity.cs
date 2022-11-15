namespace BLL
{
    public class DataEntity
    {
        public double[,] MatrixA { get; set; }
        public double[] VectorY { get; set; }
        public double[] Tolerance { get; set; }
        public double[] VectorI { get; set; }
        public double[] VectorX0 { get; set; }
    }
}