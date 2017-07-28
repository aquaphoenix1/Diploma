
using System;
using System.Collections.Generic;
namespace ApproximationHRBF
{
    class Network
    {
        public int LayersCount { get; set; }
        public Layer[] Layers { get; set; }


        public Network(int countHideNeurons)
        {
            this.LayersCount = 3;
            this.Layers = new Layer[LayersCount];
            Layers[0] = new Layer(1, 0);
            Layers[1] = new Layer(countHideNeurons, countHideNeurons);
            Layers[2] = new Layer(1, 1);
        }

        private double MaximumRadius(double[] array)
        {
            double max = array[1] - array[0];
            double val;
            for (int i = 1; i < array.Length; i++)
                if ((val = array[i] - array[i - 1]) > max)
                    max = val;
            return max;
        }

        public void InitializeHideNeurons(double[] arrayOfX)
        {
            //double radius = MaximumRadius(arrayOfX)/System.Math.Sqrt(2*arrayOfX.Length);
            double radius = MaximumRadius(arrayOfX);
            for (int i = 0; i < arrayOfX.Length; i++)
                Layers[1].InitNeuron(i, new System.Random().NextDouble(), radius, arrayOfX[i]);
        }

        public void Learning(int countItterations, int countIntervals, double learningCoefficient, double error, double momentum,  double[] arrayOfX, double[] arrayOfY)
        {
            int j = 0;
            double err = Double.MaxValue;
            while (j < countItterations && err > error)
            {
                err = 0;
                for (int i = 0; i < arrayOfX.Length; i++)
                {
                    double gaussian = Layers[1].Compute(i, arrayOfX[i]);
                    double value = gaussian * Layers[1].Neurons[i].Weight;
                    err += System.Math.Pow(value - arrayOfY[i], 2) / (countIntervals - 1);

                    Layers[1].RecalculateWeight(i, arrayOfX[i], value, arrayOfY[i], gaussian, learningCoefficient, momentum);
                    Layers[1].RecalculateCenter(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);
                    Layers[1].RecalculateRadius(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);

                    gaussian = Layers[1].Compute(i, arrayOfX[i]);
                    value = gaussian * Layers[1].Neurons[i].Weight;
                    arrayOfY[i] = value;
                }
                j++;
            }
        }
    }
}
