using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ApproximationHRBF
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            chartHystogram.Series["Идеальное значение"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Значение сети"].ChartType = SeriesChartType.Line;
        }

        private void generatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParametrs form = new FormParametrs(this);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private double[] arrayDistribution = null;

        private double[] arrayOfX;
        private double[] arrayOfYGood;
        private double[] arrayOfYBad;
        private double[] arrayOfBadX;
        private int countIntervals;

        public void Generate(Distribution distribution, int countIntervals)
        {
            arrayDistribution = distribution.Generate();
            this.countIntervals = countIntervals;
            Array.Sort(arrayDistribution);
            arrayOfX = new double[countIntervals];
            arrayOfYGood = new double[countIntervals];
            double minX = arrayDistribution[0];
            double maxX = arrayDistribution[arrayDistribution.Length - 1];
            double step = (maxX - minX) / countIntervals;
            arrayOfX[0] = minX;
            int sum = 0;
            for (int i = 1; i < countIntervals; i++)
                arrayOfX[i] = arrayOfX[i - 1] + step;
            for (int i = 0; i < arrayDistribution.Length; i++)
                for (int j = 0; j < countIntervals - 1; j++)
                    if (arrayDistribution[i] >= arrayOfX[j] && arrayDistribution[i] < arrayOfX[j + 1])
                    {
                        arrayOfYGood[j]++;
                        sum++;
                        break;
                    }
            arrayOfYGood[arrayOfYGood.Length - 1] = arrayDistribution.Length - sum;
            for (int i = 0; i < countIntervals; i++)
                arrayOfYGood[i] /= arrayDistribution.Length;

            arrayOfBadX = new double[countIntervals];
            sum = 0;
            double[] arr = distribution.GenerateBad();
            Array.Sort(arr);
            arrayOfYBad = new double[countIntervals];
            minX = arr[0];
            maxX = arr[arr.Length - 1];
            step = (maxX - minX) / countIntervals;
            arrayOfBadX[0] = minX;
            for (int i = 1; i < countIntervals; i++)
                arrayOfBadX[i] = arrayOfBadX[i - 1] + step;
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < countIntervals - 1; j++)
                    if (arr[i] >= arrayOfBadX[j] && arr[i] < arrayOfBadX[j + 1])
                    {
                        arrayOfYBad[j]++;
                        sum++;
                        break;
                    }
            arrayOfYBad[arrayOfYBad.Length - 1] = arr.Length - sum;
            for (int i = 0; i < countIntervals; i++)
                arrayOfYBad[i] /= arr.Length;

            chartHystogram.Series["Идеальное значение"].Points.DataBindXY(arrayOfX, arrayOfYGood);
            chartHystogram.Series["Значение сети"].Points.DataBindXY(arrayOfBadX, arrayOfYBad);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arrayDistribution != null)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Текстовый документ (*.txt)|*.txt";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] array = new string[arrayDistribution.Length];
                    for (int i = 0; i < array.Length; i++)
                        array[i] = arrayDistribution[i].ToString();
                    System.IO.File.WriteAllLines(fileDialog.FileName, array);
                }
            }
            else MessageBox.Show("Выборка не создана");
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Текстовый документ (*.txt)|*.txt";
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] array = System.IO.File.ReadAllLines(fileDialog.FileName);
                    arrayDistribution = new double[array.Length];
                    for (int i = 0; i < array.Length; i++)
                        arrayDistribution[i] = Double.Parse(array[i]);
                }
            }
            catch { arrayDistribution = null; }
        }

        private void networkParametrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNetwork form = new FormNetwork(this);
            this.Hide();
            form.ShowDialog();
        }

        private Network network;
        private int countLearningItterations;
        private double learningCoefficient;
        private double
            momentum,
            coefficientT,
            error;

        public void InitializeNetwork(int countLearningItterations, double learningCoefficient, double momentum, double coefficientT, double error)
        {
            this.countLearningItterations = countLearningItterations;
            this.learningCoefficient = learningCoefficient;
            this.momentum = momentum;
            this.coefficientT = coefficientT;
            this.error = error;
            network = new Network(arrayOfX.Length);
            network.InitializeHideNeurons(arrayOfX);
        }

        public void SetNewValue(int index, double value)
        {
            arrayOfYBad[index] = value;
            chartHystogram.Invoke((MethodInvoker)(delegate() { chartHystogram.Series["Значение сети"].Points.DataBindXY(arrayOfBadX, arrayOfYBad); }));
        }

        private void buttonLearn_Click(object sender, EventArgs e)
        {
            //network.Learning(this, countLearningItterations, learningCoefficient, momentum, coefficientT, arrayOfBadX, arrayOfYGood);
            int j = 0;
            double err = Double.MaxValue;
            while (j < countLearningItterations && err > error)
            {
                err = 0;
                for (int i = 0; i < arrayOfX.Length; i++)
                {
                    double gaussian = network.Layers[1].Compute(i, arrayOfX[i]);
                    double value = gaussian * network.Layers[1].Neurons[i].Weight;
                    err += System.Math.Pow(value - arrayOfYGood[i], 2) / (countIntervals - 1);
                    //double error = System.Math.Pow(value - arrayOfYGood[i], 2) / (countIntervals-1);
                    //SetNewValue(i, value);
                    network.Layers[1].RecalculateWeight(i, arrayOfX[i], value, arrayOfYGood[i], gaussian, learningCoefficient, momentum);
                    network.Layers[1].RecalculateCenter(i, learningCoefficient, value, arrayOfYGood[i], network.Layers[1].Neurons[i].Weight, arrayOfX[i], network.Layers[1].Neurons[i].Center, network.Layers[1].Neurons[i].Radius);
                    network.Layers[1].RecalculateRadius(i, learningCoefficient, value, arrayOfYGood[i], network.Layers[1].Neurons[i].Weight, arrayOfX[i], network.Layers[1].Neurons[i].Center, network.Layers[1].Neurons[i].Radius);
                }
                j++;
            }
           // new Thread(() => Compute()).Start();
        }

        private void Compute()
        {
            //while (true)
            {
                double[] errors = new double[29];

                for (int j = 0; j < 29; j++)
                {
                    for (int i = 0; i < arrayOfBadX.Length; i++)
                    {
                        double gaussian = network.Layers[1].Compute(i, arrayOfBadX[i]);
                        double value = gaussian * network.Layers[1].Neurons[i].Weight;
                        errors[j] += System.Math.Pow(value - arrayOfYGood[i], 2) / (countIntervals - 1);
                        SetNewValue(i, value);
                    }
                }

                Array.Sort(errors);
                textBox1.Invoke((MethodInvoker)(delegate() { textBox1.Text = errors[28].ToString(); }));
                //textBox1.Invoke((MethodInvoker)(delegate() { textBox1.Text = "0"; }));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compute();
        }
    }
}
