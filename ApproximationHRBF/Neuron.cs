
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

        public double Compute(double x, int countNeurons)
        {
            //return Math.Exp(-2 * Math.Pow(((x - this.Center) / this.Radius), 2));
            double deltaCMax = Network.MaximumRadius();
            return Math.Exp(-Math.Pow(x, 2) / (Math.Pow(deltaCMax, 2) / countNeurons));
        }
    }
}
