
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

        public double Compute(int index, double inputX)
        {
            return Neurons[index].Compute(inputX);
        }

        public void one(int index, double learningCoefficient, double sum, double inputValue, double outputValue)
        {
            this.Neurons[index].Weight += -learningCoefficient * Math.Exp(-0.5 * sum) * (outputValue - inputValue);
        }

        public void two(int index, double learningCoefficient, double inputValue, double outputValue, double sum, double x)
        {
            this.Neurons[index].Center += -learningCoefficient * (outputValue - inputValue) * this.Neurons[index].Weight * Math.Exp(-0.5 * sum) * (x - this.Neurons[index].Center) / Math.Pow(this.Neurons[index].Radius, 2);
        }

        public void three(int index, double learningCoefficient, double inputValue, double outputValue, double sum, double x)
        {
            this.Neurons[index].Radius += -learningCoefficient * (outputValue - inputValue) * this.Neurons[index].Weight * Math.Exp(-0.5 * sum) * (x - this.Neurons[index].Center) / Math.Pow(this.Neurons[index].Radius, 3);
        }

        public void RecalculateWeight(int index, double inputX, double outsideValue, double realValue, double gaussian, double learningCoefficient, double momentum)
        {
            this.Neurons[index].Weight += -learningCoefficient * (this.Neurons[index].Weight * gaussian - realValue) * gaussian;
        }

        public void RecalculateCenter(int index, double learningCoefficient, double value, double real, double weight, double inputX, double center, double radius)
        {
            this.Neurons[index].Center += -learningCoefficient * (value - real) * weight * Math.Exp(-0.5 * Math.Pow((inputX - center) / radius, 2)) * (inputX - center) / Math.Pow(radius, 2);
        }

        public void RecalculateRadius(int index, double learningCoefficient, double value, double real, double weight, double inputX, double center, double radius)
        {
            this.Neurons[index].Radius += -learningCoefficient * (value - real) * weight * Math.Exp(-0.5 * Math.Pow((inputX - center) / radius, 2)) * Math.Pow(inputX - center, 2) / Math.Pow(radius, 3);
        }

        public double CalculateSumOfFunctions(double[] arrayOfX, int index)
        {
            double sum = 0.0;
            for (int j = 0; j < arrayOfX.Length; j++)
                sum += Math.Pow((arrayOfX[j] - this.Neurons[index].Center) / this.Neurons[index].Radius, 2);
            return sum;
        }
    }
}
