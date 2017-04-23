﻿using System;

namespace ApproximationHRBF
{
    sealed class Relei : Distribution
    {
        private double sigma;
        private int count;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// 0,                           y = 0
        /// sqrt(-2*sigma^2 * ln(1-y)),  0 < y < 1
        /// </summary>
        /// <param name="sigma">Коэффициент сигма</param>
        /// <param name="count">Количество элементов выборки</param>
        public Relei(double sigma, int count)
        {
            this.sigma = sigma;
            this.count = count;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();
                array[i] = (y == 0) ? 0 : Math.Sqrt(-2 * Math.Pow(sigma, 2) * Math.Log(1 - y));
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
                array[i] = (y == 0) ? 0 : Math.Sqrt(-2 * Math.Pow(sigma, 2) * Math.Log(1 - y));
            }
            return array;
        }
    }
}
