
using System;
using System.Collections.Generic;
namespace ApproximationHRBF
{
    class Network
    {
        public int LayersCount { get; set; }
        public static Layer[] Layers { get; set; }


        public Network(int countHideNeurons)
        {
            this.LayersCount = 3;
            Layers = new Layer[LayersCount];
            Layers[0] = new Layer(1, 0);
            Layers[1] = new Layer(countHideNeurons, countHideNeurons);
            Layers[2] = new Layer(1, 1);
        }

        public static double MaximumRadius()
        {
            double max = Layers[1].Neurons[1].Center - Layers[1].Neurons[0].Center;
            double val;
            for (int i = 1; i < Layers[1].CountNeurons; i++)
                if ((val = Layers[1].Neurons[i].Center - Layers[1].Neurons[i-1].Center) > max)
                    max = val;
            /*double max = array[1] - array[0];
            double val;
            for (int i = 1; i < array.Length; i++)
                if ((val = array[i] - array[i - 1]) > max)
                    max = val;*/
            return max;
        }

        public void InitializeHideNeurons(double[] arrayOfX)
        {
            double radius = MaximumRadius() / System.Math.Sqrt(2 * arrayOfX.Length);
            //double radius = MaximumRadius(arrayOfX);
            for (int i = 0; i < arrayOfX.Length; i++)
                //Layers[1].InitNeuron(i, 0.5 * (new System.Random().NextDouble() * 2 - 1), radius, arrayOfX[i]);
                Layers[1].InitNeuron(i, new System.Random().NextDouble(), radius, arrayOfX[i]);
        }

        public double outputValue(double inputX)
        {
            double sum = 0;
            for (int i = 0; i < Layers[1].CountNeurons; i++)
                sum += Layers[1].Neurons[i].Weight * Layers[1].Compute(i, inputX, Layers[1].CountNeurons);
            return sum;
        }

        private double calculateError(double[] inputX, double[] arrayOfY)
        {
            double sum = 0;
            for (int i = 0; i < Layers[1].CountNeurons; i++)
                sum += Layers[1].Neurons[i].Weight * Layers[1].Compute(i, inputX[i], Layers[1].CountNeurons) - arrayOfY[i];
            sum = Math.Pow(sum, 2);
            sum /= 2;
            return sum;
        }

        public void Learning(int countItterations, double learningCoefficient, double error, double momentum, double[] arrayOfX, double[] arrayOfY)
        {
            int j = 0;
            double err = Double.MaxValue;
            while (j < countItterations && err > error)
            {
                err = 0;
                for (int i = 0; i < arrayOfX.Length; i++)
                {
                    double gaussian = Layers[1].Compute(i, arrayOfX[i], Layers[1].CountNeurons);
                    double value = outputValue(arrayOfX[i]);

                    Layers[1].RecalculateWeight(i, arrayOfX, arrayOfY[i], gaussian, learningCoefficient);
                    Layers[1].RecalculateCenter(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);
                    Layers[1].RecalculateRadius(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);
                }
                j++;
                err = calculateError(arrayOfX, arrayOfY);
            }
        }
    }
}
