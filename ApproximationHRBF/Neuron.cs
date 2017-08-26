
using System;
namespace ApproximationHRBF
{
    [Serializable]
    class Neuron
    {
        public double Weight { get; set; }

        public double Radius { get; set; }

        public double Center { get; set; }

        public Neuron(double weight, double radius, double center)
        {
            this.Weight = weight;
            this.Radius = radius;
            this.Center = center;
        }

        public Neuron()
        {
            this.Center = new Random().NextDouble();
            this.Weight = new Random().NextDouble();
        }

        public double Compute(double x)
        {
            //return Math.Exp(-2 * Math.Pow(((x - this.Center) / this.Radius), 2));
            return Math.Exp(-Math.Pow(x - this.Center, 2) / (2 * Math.Pow(this.Radius, 2)));
        }

        public void RecalculateWeight(double learningCoefficient, double difference, double inputX)
        {
            this.Weight -= learningCoefficient * difference * Compute(inputX);
        }

        public void RecalculateCenter(double learningCoefficient, double difference, double inputX)
        {
            this.Center -= learningCoefficient * difference * this.Weight * Math.Exp(-0.5 * Math.Pow((inputX - this.Center) / this.Radius, 2)) * (inputX - this.Center) / Math.Pow(this.Radius, 2);
        }

        public void RecalculateRadius(double learningCoefficient, double difference, double inputX)
        {
            this.Radius -= learningCoefficient * difference * this.Weight * Math.Exp(-0.5 * Math.Pow((inputX - this.Center) / this.Radius, 2)) * Math.Pow(inputX - this.Center, 2) / Math.Pow(this.Radius, 3);
        }
    }
}
