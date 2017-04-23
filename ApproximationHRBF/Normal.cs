using System;

namespace ApproximationHRBF
{
    sealed class Normal : Distribution
    {
        private int count;
        private double mu, xi;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// </summary>
        /// <param name="count">Количество элементов выборки</param>
        /// <param name="mu">Математическое ожидание</param>
        /// <param name="xi">Дисперсия</param>
        public Normal(double mu, double xi, int count)
        {
            this.count = count;
            this.mu = mu;
            this.xi = xi;
        }

        public double[] Generate()
        {
            /*Random rand1 = new Random();
            Random rand2 = new Random();
            double sko = Math.Sqrt(xi);
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
                array[i] = mu + sko * Math.Cos(2 * Math.PI * rand1.NextDouble()) * Math.Sqrt(-2 * Math.Log(rand2.NextDouble()));
            return array;*/
            Random rand = new Random();
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
            {
                double sum = 0;
                for (int j = 0; j < 12; j++)
                    sum += rand.NextDouble();
                array[i] = mu + xi * (sum - 6);
            }
            return array;
        }

        public double[] GenerateBad()
        {
            xi = 5;
            mu = 2;
            Random rand = new Random();
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
            {
                double sum = 0;
                for (int j = 0; j < 12; j++)
                    sum += rand.NextDouble();
                array[i] = mu + xi * (sum - 6);
            }
            return array;
        }
    }
}
