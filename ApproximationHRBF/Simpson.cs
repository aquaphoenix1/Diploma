using System;

namespace ApproximationHRBF
{
    sealed class Simpson : Distribution
    {
        private double a, b;
        private int count;
        
        /// <summary>
        /// Консутрктор инициализации параметров распределения
        /// a,                          y = 0
        /// (b-a)*sqrt(y/2) + a,        0 < y < 1/2
        /// b - sqrt((1-y)/2)*(b-a),    1/2 < y < 
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="count">Количество элементов выборки</param>
        public Simpson(double a, double b, int count)
        {
            this.a = a;
            this.b = b;
            this.count = count;
        }

        public double[] Generate()
        {
            Random rand = new Random();
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();
                if (y > 0.97) y = 1;
                array[i] = (y == 0) ? a : (y < 0.5) ? ((b - a) * Math.Sqrt(y / 2) + a) : (y < 1) ? (b - Math.Sqrt((1 - y) / 2) * (b - a)) : b;
            }
            return array;
        }

        public double[] GenerateBad()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double plusMinus = rand.NextDouble();
                double y = (plusMinus < 0.5) ? rand.NextDouble() - rand.NextDouble() : rand.NextDouble();
                if (y < 0) y = 0;
                if (y > 0.97) y = 1;
                array[i] = (y == 0) ? a : (y < 0.5) ? ((b - a) * Math.Sqrt(y / 2) + a) : (y < 1) ? (b - Math.Sqrt((1 - y) / 2) * (b - a)) : b;
            }
            return array;
        }
    }
}
