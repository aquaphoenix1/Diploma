using System;
using System.Collections.Generic;
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
            chartHystogram.Series["Выборка"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["После обучения"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Исходное значение"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Полученное значение"].ChartType = SeriesChartType.Line;
            form = this;
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

        private double FindMinAndMax(double[] array, out double max)
        {
            double min = array[0];
            max = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > max)
                    max = array[i];
                else if (array[i] < min)
                    min = array[i];
            return min;
        }

        private void MiniMax(double[] array)
        {
            double max;
            double min = FindMinAndMax(array, out max);
            double difference = max - min;
            for (int i = 0; i < array.Length; i++)
                array[i] = (array[i] - min) / difference;
        }

        private double middleOfXForCenter = 0;
        
        private bool CorrectingArray(double[] arrX, double[] arrY, out List<double> XList, out List<double> YList, double step)
        {
            bool isEnd = true;
            XList = new List<double>();
            YList = new List<double>();
            for (int i = 0; i < arrY.Length - 2; )
                if (arrY[i] > 0.01)
                {
                    XList.Add(arrX[i]);
                    YList.Add(arrY[i]);
                    i++;
                }
                else
                {
                    isEnd = false;
                    XList.Add(arrX[i] + step);
                    YList.Add(arrY[i] + arrY[i + 1]);
                    i += 2;
                }

            /*if (arrY[arrY.Length - 1] < 0.01)
            {
                XList[XList.Count - 1] += step;
                YList[YList.Count - 1] += arrY[arrY.Length - 1];
            }
            else*/
            {
                XList.Add(arrX[arrX.Length - 1]);
                YList.Add(arrY[arrY.Length - 1]);
            }

            return isEnd;
        }

        public void Generate(Distribution distribution, int countIntervals)
        {
            arrayDistribution = distribution.Generate();
            Array.Sort(arrayDistribution);
            arrayOfX = new double[countIntervals];
            arrayOfY = new double[countIntervals];
            double minX = arrayDistribution[0];
            double maxX = arrayDistribution[arrayDistribution.Length - 1];
            double step = (maxX - minX) / countIntervals;
            middleOfXForCenter = step / 2.0;
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

            List<double> newArrX, newArrY;
            while(!CorrectingArray(arrayOfX, arrayOfY, out newArrX, out newArrY, step))
            {
                arrayOfX = newArrX.ToArray();
                arrayOfY = newArrY.ToArray();
            }

            arrayOfX = newArrX.ToArray();
            arrayOfY = newArrY.ToArray();

            this.countIntervals = arrayOfX.Length;
            for (int i = 0; i < arrayOfY.Length; i++)
                arrayOfY[i] /= step;

            MiniMax(arrayOfY);
            //chartHystogram.Series["Выборка"].Points.DataBindXY(arrayOfX, arrayOfY);
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

        static FormMain form;
        public static void Set(double[] arrayX, double[] arrayY)
        {
            form.Invoke((MethodInvoker)delegate {
                form.chartHystogram.Series["После обучения"].Points.DataBindXY(arrayX, arrayY);
            });
        }

        public void SetCurrentIteration(int iteration)
        {
            form.Invoke((MethodInvoker)delegate
            {
                textBoxCurrentIteration.Text = iteration.ToString();
            });
        }

        public void SetCurrentError(double error)
        {
            form.Invoke((MethodInvoker)delegate
            {
                textBoxCurrentError.Text = error.ToString();
            });
        }

        public void DrawError(double[] errors, int[] massX)
        {
            if (MessageBox.Show("Показать график ошибки обучения?", "Ошибка обучения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new FormError(errors, massX).ShowDialog();
            }
        }
        private void SetNewValue(double[] arrayX, double[] arrayY, double[] arrayOfValues)
        {
            chartHystogram.Series["Исходное значение"].Points.DataBindXY(arrayX, arrayY);
            chartHystogram.Series["Полученное значение"].Points.DataBindXY(arrayX, arrayOfValues);
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
                arrayOfYBad[i] /= (arrayDistribution.Length * step);
            MiniMax(arrayOfYBad);
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

            while (true)
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
                        error += Math.Pow(value - arrayOfY[i], 2) / (countIntervals - 1);
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

        public void ChangeTextBoxCurrentIterationAndError(bool switcher)
        {
            form.Invoke((MethodInvoker)delegate ()
            {
                textBoxCurrentIteration.Visible = switcher;
                textBoxCurrentIteration.Text = "0";
                textBoxCurrentIteration.Enabled = switcher;

                labelCurrentIteration.Enabled = switcher;
                labelCurrentIteration.Visible = switcher;

                labelCurrentError.Enabled = switcher;
                labelCurrentError.Visible = switcher;

                textBoxCurrentError.Enabled = switcher;
                textBoxCurrentError.Text = "0";
                textBoxCurrentError.Visible = switcher;
            });
        }

        private Thread learningThread;

        private void обучитьСетьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learningThread = new Thread(() =>
            {
                network.Learning(countLearningItterations, learningCoefficient, error, momentum, arrayOfX, arrayOfY, this);
            }
            );

            SwitchButtons(false);
            ChangeTextBoxCurrentIterationAndError(true);
            learningThread.Start();
        }

        public void SwitchButtons(bool switcher)
        {
            form.Invoke((MethodInvoker)delegate ()
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
            });
        }

        private void остановитьОбучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchButtons(true);
            ChangeTextBoxCurrentIterationAndError(false);
            learningThread.Abort();
        }

        private void тестСетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Thread(() => Compute()).Start();
            chartHystogram.Series[4].Points.Clear();
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

            labelCurrentIteration.Enabled = false;
            labelCurrentIteration.Visible = false;

            textBoxCurrentIteration.Enabled = false;
            textBoxCurrentIteration.Visible = false;

            labelCurrentError.Enabled = false;
            labelCurrentError.Visible = false;

            textBoxCurrentError.Enabled = false;
            textBoxCurrentError.Visible = false;
        }
    }
}
