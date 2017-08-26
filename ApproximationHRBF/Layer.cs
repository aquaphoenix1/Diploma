
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

        public void InitNeuron(int index, double weight, double center)
        {
            Neurons[index].Weight = weight;
            Neurons[index].Center = center;
        }

        public void InitRadius(double radius)
        {
            for (int i = 0; i < CountNeurons; i++)
                Neurons[i].Radius = radius;
        }
    }
}
