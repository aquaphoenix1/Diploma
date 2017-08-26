
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
            return max;
        }

        public void InitializeHideNeurons(double[] arrayOfX)
        {
            for (int i = 0; i < arrayOfX.Length; i++)
                Layers[1].InitNeuron(i, new System.Random().NextDouble(), arrayOfX[i]);
            Layers[1].InitRadius(MaximumRadius() / System.Math.Sqrt(2 * arrayOfX.Length));
        }

        public double outputValue(double inputX)
        {
            double sum = 0;
                for (int j = 0; j < Layers[1].CountNeurons; j++)
                    sum += Layers[1].Neurons[j].Weight * Layers[1].Neurons[j].Compute(inputX);
            return sum;
        }

        private double calculateError(double inputX, double inputY)
        {
            double sum = 0;
                for (int j = 0; j < Layers[1].CountNeurons; j++)
                    sum += Layers[1].Neurons[j].Weight * Layers[1].Neurons[j].Compute(inputX);
                sum = Math.Pow(sum - inputY, 2) / 2;
            return sum;
        }

        private bool Epoch(double[] arrayOfX, double[] arrayOfY, double error, double learningCoefficient)
        {
            double err;
            for (int i = 0; i < arrayOfX.Length; i++)
                {
                    double y = outputValue(arrayOfX[i]);
                    err = calculateError(arrayOfX[i], arrayOfY[i]);

                    double difference = y - arrayOfY[i];

                    Layers[1].Neurons[i].RecalculateWeight(learningCoefficient, difference, arrayOfX[i]);
                    Layers[1].Neurons[i].RecalculateCenter(learningCoefficient, difference, arrayOfX[i]);
                    Layers[1].Neurons[i].RecalculateRadius(learningCoefficient, difference, arrayOfX[i]);
                    if (err <= error)
                        return true;
                }
            return false;
        }

        public void Learning(int countItterations, double learningCoefficient, double error, double momentum, double[] arrayOfX, double[] arrayOfY)
        {
            int j = 0;
            while (j++ < countItterations)
                if (Epoch(arrayOfX, arrayOfY, error, learningCoefficient))
                    break;
        }
    }
}
