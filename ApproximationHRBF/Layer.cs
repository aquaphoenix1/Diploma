
using System;
namespace ApproximationHRBF
{
    class Layer
    {
        public Neuron[] Neurons { get; set; }

        public int CountNeurons { get; set; }

        public Layer(int countNeurons, int countLinks)
        {
            this.CountNeurons = countNeurons;
            this.Neurons = new Neuron[countNeurons];
            for (int i = 0; i < countNeurons; i++)
                Neurons[i] = new Neuron();

            //this.output = new double[countNeurons];
        }

        public void InitNeuron(int index, double weight, double radius, double center)
        {
            Neurons[index].Weight = weight;
            Neurons[index].Radius = radius;
            Neurons[index].Center = center;
        }

        public double Compute(int index, double inputX, int countNeurons)
        {
            return Neurons[index].Compute(inputX, countNeurons);
        }

        private double sumGaussian(double[] inputX, int countNeurons)
        {
            double sum = 0;
            for (int i = 0; i < inputX.Length; i++)
                sum += Neurons[i].Weight * Compute(i, inputX[i], countNeurons);
            return sum;
        }

        public void RecalculateWeight(int index, double[] inputX, double inputY, double gaussian, double learningCoefficient)
        {
            this.Neurons[index].Weight += -learningCoefficient * (sumGaussian(inputX, CountNeurons) - inputY) * gaussian;
        }

        public void RecalculateCenter(int index, double learningCoefficient, double value, double inputY, double weight, double inputX, double center, double radius)
        {
            this.Neurons[index].Center += -learningCoefficient * (value - inputY) * weight * Math.Exp(-0.5 * Math.Pow((inputX - center) / radius, 2)) * (inputX - center) / Math.Pow(radius, 2);
        }

        public void RecalculateRadius(int index, double learningCoefficient, double value, double inputY, double weight, double inputX, double center, double radius)
        {
            this.Neurons[index].Radius += -learningCoefficient * (value - inputY) * weight * Math.Exp(-0.5 * Math.Pow((inputX - center) / radius, 2)) * Math.Pow(inputX - center, 2) / Math.Pow(radius, 3);
        }
    }
}
