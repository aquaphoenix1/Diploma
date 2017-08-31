
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
                if ((val = Layers[1].Neurons[i].Center - Layers[1].Neurons[i - 1].Center) > max)
                    max = val;
            return max;
        }

        public void InitializeHideNeurons(double[] arrayOfX)
        {
            for (int i = 0; i < arrayOfX.Length; i++)
                //Layers[1].InitNeuron(i, new System.Random().NextDouble(), arrayOfX[i]);
                Layers[1].InitNeuron(i, 0.5 * (new System.Random().NextDouble() * 2 - 1), arrayOfX[i]);
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
            //double sum = 0;
            /*for (int j = 0; j < Layers[1].CountNeurons; j++)
                sum += Layers[1].Neurons[j].Weight * Layers[1].Neurons[j].Compute(inputX);*/
            return Math.Pow(outputValue(inputX) - inputY, 2) / 2;
        }

        private bool Epoch(double[] arrayOfX, double[] arrayOfY, double error, double learningCoefficient, out double err)
        {
            err = 0;
            //
            double[] mas = new double[arrayOfX.Length];
            //

            for (int i = 0; i < arrayOfX.Length; i++)
            {
                double y = outputValue(arrayOfX[i]);

                //
                mas[i] = y;
                //

                err += calculateError(arrayOfX[i], arrayOfY[i]);

                double difference = y - arrayOfY[i];

                Layers[1].Neurons[i].RecalculateWeight(learningCoefficient, difference, arrayOfX[i]);
                Layers[1].Neurons[i].RecalculateCenter(learningCoefficient, difference, arrayOfX[i]);
                Layers[1].Neurons[i].RecalculateRadius(learningCoefficient, difference, arrayOfX[i]);
            }
            FormMain.Set(arrayOfX, mas);
            return (err <= error);
        }

        public void Learning(int countItterations, double learningCoefficient, double error, double momentum, double[] arrayOfX, double[] arrayOfY, FormMain form)
        {
            List<double> errorsList = new List<double>();
            List<int> XList = new List<int>();
            int j = 0;
            double err;
            while (j++ < countItterations)
            {
                if (Epoch(arrayOfX, arrayOfY, error, learningCoefficient, out err))
                    break;
                form.SetCurrentIteration(j);
                form.SetCurrentError(err);
                errorsList.Add(err);
                XList.Add(j);
            }
            form.SwitchButtons(true);
            form.ChangeTextBoxCurrentIterationAndError(false);
            form.DrawError(errorsList.ToArray(), XList.ToArray());
        }
    }
}
