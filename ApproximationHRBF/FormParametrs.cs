using System;
using System.Windows.Forms;

namespace ApproximationHRBF
{
    public partial class FormParametrs : Form
    {
        public FormParametrs(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void comboBoxDistribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
            buttonOK.Visible = true;
            switch (comboBoxDistribution.SelectedItem.ToString())
            {
                case "Арксинус":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Экспоненциальное":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент лямбда";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Лаплас":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент лямбда";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент мю";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Нормальное":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Математическое ожидание";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Диперсия";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Релей":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент Сигма";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Симпсон":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент b";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private FormMain formMain;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                int count;
                textBox1.Text = textBox1.Text.Replace('.', ',');
                textBox2.Text = textBox2.Text.Replace('.', ',');
                if (Int64.Parse(textBoxCount.Text) < 2000) textBoxCount.Text = "2000";
                if ((count = Int32.Parse(textBoxCountCloset.Text)) < 10) { textBoxCountCloset.Text = "10"; count = 10; }
                switch (comboBoxDistribution.SelectedItem.ToString())
                {
                    case "Арксинус":
                        {
                            formMain.Generate(new Arcsinus(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                    case "Экспоненциальное":
                        {
                            formMain.Generate(new ExponentialOneway(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                    case "Лаплас":
                        {
                            formMain.Generate(new Laplas(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                    case "Нормальное":
                        {
                            formMain.Generate(new Normal(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                    case "Релей":
                        {
                            formMain.Generate(new Relei(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                    case "Симпсон":
                        {
                            formMain.Generate(new Simpson(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)), count);
                            closeForm();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void closeForm()
        {
            this.Dispose();
        }
    }
}
