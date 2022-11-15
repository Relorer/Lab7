namespace Lab6
{
    public static class Data
    {
        public static double[] ExpectedTest => new double[] { 10.056, 3.014, 7.041, 1.982, 5.059, 4.067, 0.992 };

        public static DataEntity Test => new DataEntity()
        {
            MatrixA = new double[,] {
                    { 1, -1, -1, 0, 0, 0, 0 },
                    { 0, 0, 1, -1, -1, 0, 0 },
                    { 0, 0, 0, 0, 1, -1, -1 },
                },
            VectorY = new double[] { 0, 0, 0 },
            Tolerance = new double[] { 0.200, 0.121, 0.683, 0.040, 0.102, 0.081, 0.020 },
            VectorI = new double[] { 1, 1, 1, 1, 1, 1, 1 },
            VectorX0 = new double[] { 10.005, 3.033, 6.831, 1.985, 5.093, 4.057, 0.991 }
        };

        public static double[] ExpectedV1 => new double[] { 10.540, 2.836, 6.973, 1.963, 5.009, 4.020, 0.989, 0.731 };

        public static DataEntity V1 => new DataEntity()
        {
            MatrixA = new double[,] {
                    { 1, -1, -1, 0, 0, 0, 0, -1 },
                    { 0, 0, 1, -1, -1, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, -1, -1, 0 },
                },
            VectorY = new double[] { 0, 0, 0 },
            Tolerance = new double[] { 0.200, 0.121, 0.683, 0.040, 0.102, 0.081, 0.020, 0.667 },
            VectorI = new double[] { 1, 1, 1, 1, 1, 1, 1, 1 },
            VectorX0 = new double[] { 10.005, 3.033, 6.831, 1.985, 5.093, 4.057, 0.991, 6.667 }
        };
    }
}