
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

        public void Learning(FormMain form, int countItterations, double learningCoefficient, double momentum, double coefficientT, double[] arrayOfX, double[] arrayOfY)
        {
            for (int j = 0; j < countItterations; j++)
            {
                for (int i = 0; i < arrayOfX.Length; i++)
                {
                    double gaussian = Layers[1].Compute(i, arrayOfX[i]);
                    double value = gaussian * Layers[1].Neurons[i].Weight;
                    double error = System.Math.Pow(value - arrayOfY[i], 2) / 2;
                    form.SetNewValue(i, value);
                    Layers[1].RecalculateWeight(i, arrayOfX[i], value, arrayOfY[i], gaussian, learningCoefficient, momentum);
                    Layers[1].RecalculateCenter(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);
                    Layers[1].RecalculateRadius(i, learningCoefficient, value, arrayOfY[i], Layers[1].Neurons[i].Weight, arrayOfX[i], Layers[1].Neurons[i].Center, Layers[1].Neurons[i].Radius);
                }
            }
        }
    }
}
