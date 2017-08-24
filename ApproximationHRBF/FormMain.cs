using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ApproximationHRBF
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            chartHystogram.Series["Выборка"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["После обучения"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Исходное значение"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Полученное значение"].ChartType = SeriesChartType.Line;
        }

        private void generatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParametrs form = new FormParametrs(this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            if (arrayDistribution != null)
            {
                networkParametrsToolStripMenuItem.Enabled = true;
                networkParametrsToolStripMenuItem.Visible = true;
            }
        }

        private double[] arrayDistribution = null;

        private double[] arrayOfX,
            arrayOfY;
        private int countIntervals;

        public void Generate(Distribution distribution, int countIntervals)
        {
            arrayDistribution = distribution.Generate();
            this.countIntervals = countIntervals;
            Array.Sort(arrayDistribution);
            arrayOfX = new double[countIntervals];
            arrayOfY = new double[countIntervals];
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
                        arrayOfY[j]++;
                        sum++;
                        break;
                    }
            arrayOfY[arrayOfY.Length - 1] = arrayDistribution.Length - sum;
            for (int i = 0; i < countIntervals; i++)
                arrayOfY[i] /= arrayDistribution.Length;

            chartHystogram.Series["Выборка"].Points.DataBindXY(arrayOfX, arrayOfY);
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
            Download();
        }

        public bool Download()
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
                    return true;
                }
            }
            catch { arrayDistribution = null; }
            return false;
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

            learnNetworkToolStripMenuItem.Enabled = true;
            learnNetworkToolStripMenuItem.Visible = true;
        }

        private void SetNewValue(double[] arrayX, double[] arrayY)
        {
            //chartHystogram.Invoke((MethodInvoker)delegate { chartHystogram.Series["После обучения"].Points.DataBindXY(arrayX, arrayY); });
        }

        private void SetNewValue(double[] arrayX, double[] arrayY, double[] arrayOfValues)
        {
            chartHystogram.Invoke((MethodInvoker)delegate { chartHystogram.Series["Исходное значение"].Points.DataBindXY(arrayX, arrayY); });
            chartHystogram.Invoke((MethodInvoker)delegate { chartHystogram.Series["Полученное значение"].Points.DataBindXY(arrayX, arrayOfValues); });
        }

        /*double gaussian = network.Layers[1].Compute(i, arrayOfX[i]);
                    double value = gaussian * network.Layers[1].Neurons[i].Weight;
                    err += System.Math.Pow(value - arrayOfY[i], 2) / (countIntervals - 1);
                    network.Layers[1].one(i, learningCoefficient, this.network.Layers[1].CalculateSumOfFunctions(arrayOfX, i), arrayOfY[i], value);
                    network.Layers[1].two(i, learningCoefficient, arrayOfY[i], value, this.network.Layers[1].CalculateSumOfFunctions(arrayOfX, i), arrayOfX[i]);
                    network.Layers[1].three(i, learningCoefficient, arrayOfY[i], value, this.network.Layers[1].CalculateSumOfFunctions(arrayOfX, i), arrayOfX[i]);
                    gaussian = network.Layers[1].Compute(i, arrayOfX[i]);
                    value = gaussian * network.Layers[1].Neurons[i].Weight;
                    arrayOfY[i] = value;*/

        Task learningThread;

        private void Learn()
        {
            network.Learning(countLearningItterations, learningCoefficient, error, momentum, arrayOfX, arrayOfY);
            switchButtons(true);
        }

        private double[] DistributeLoad(out double[] arrayOfDistributedX)
        {
            double[] arrayOfBadX = new double[countIntervals];
            int sum = 0;
            Array.Sort(arrayDistribution);
            double[] arrayOfYBad = new double[countIntervals];
            double minX = arrayDistribution[0];
            double maxX = arrayDistribution[arrayDistribution.Length - 1];
            double step = (maxX - minX) / countIntervals;
            arrayOfBadX[0] = minX;
            for (int i = 1; i < countIntervals; i++)
                arrayOfBadX[i] = arrayOfBadX[i - 1] + step;
            for (int i = 0; i < arrayDistribution.Length; i++)
                for (int j = 0; j < countIntervals - 1; j++)
                    if (arrayDistribution[i] >= arrayOfBadX[j] && arrayDistribution[i] < arrayOfBadX[j + 1])
                    {
                        arrayOfYBad[j]++;
                        sum++;
                        break;
                    }
            arrayOfYBad[arrayOfYBad.Length - 1] = arrayDistribution.Length - sum;
            for (int i = 0; i < countIntervals; i++)
                arrayOfYBad[i] /= arrayDistribution.Length;
            arrayOfDistributedX = arrayOfBadX;
            return arrayOfYBad;
        }

        private void Compute()
        {
            List<double> errors = new List<double>();
                double[] arrayOfLoadX,
                arrayOfLoadY, 
                values;
                int j = 0;
                double error;
                bool isLoad;

            while(true)
            {
                error = 0;
                isLoad = Download();
                if (isLoad)
                {
                    arrayOfLoadY = DistributeLoad(out arrayOfLoadX);
                    values = new double[arrayOfLoadX.Length];
                    for (int i = 0; i < arrayOfLoadX.Length; i++)
                    {
                        double value = network.outputValue(arrayOfLoadX[i]);
                        values[i] = value;
                        error += System.Math.Pow(value - arrayOfY[i], 2) / (countIntervals - 1);
                    }
                    errors.Add(Math.Sqrt(error));
                    SetNewValue(arrayOfLoadX, arrayOfLoadY, values);
                    var result = MessageBox.Show("Загрузить следующий?", "Работоспособность сети", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        break;
                }
                else break;
            }

            if (errors.Count > 0)
            {
                errors.Sort();
                try
                {
                    textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = errors.ToArray()[errors.Count - 1].ToString(); });
                }
                catch { }
            }
        }

        private void обучитьСетьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*switchButtons(false);
            learningThread = new Task(Learn);
            learningThread.Start();*/
            Learn();
        }

        private void switchButtons(bool switcher)
        {
            stopLearningToolStripMenuItem.Enabled = !switcher;
            stopLearningToolStripMenuItem.Visible = !switcher;

            learnNetworkToolStripMenuItem.Enabled = switcher;
            learnNetworkToolStripMenuItem.Visible = switcher;

            fileToolStripMenuItem.Enabled = switcher;
            fileToolStripMenuItem.Visible = switcher;

            generatorToolStripMenuItem.Enabled = switcher;
            generatorToolStripMenuItem.Visible = switcher;

            networkParametrsToolStripMenuItem.Enabled = switcher;
            networkParametrsToolStripMenuItem.Visible = switcher;

            testNetworkToolStripMenuItem.Enabled = switcher;
            testNetworkToolStripMenuItem.Visible = switcher;
        }

        private void остановитьОбучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learningThread.Dispose();
            switchButtons(true);
        }

        private void тестСетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Thread(() => Compute()).Start();
            Compute();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            stopLearningToolStripMenuItem.Enabled = false;
            stopLearningToolStripMenuItem.Visible = false;

            learnNetworkToolStripMenuItem.Enabled = false;
            learnNetworkToolStripMenuItem.Visible = false;

            stopLearningToolStripMenuItem.Enabled = false;
            stopLearningToolStripMenuItem.Visible = false;

            networkParametrsToolStripMenuItem.Enabled = false;
            networkParametrsToolStripMenuItem.Visible = false;

            testNetworkToolStripMenuItem.Enabled = false;
            testNetworkToolStripMenuItem.Visible = false;
        }
    }
}
