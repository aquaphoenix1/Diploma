using System;
using System.Windows.Forms;

namespace ApproximationHRBF
{
    public partial class FormNetwork : Form
    {
        public FormNetwork(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            formMain.Show();
            this.Dispose();
        }

        private FormMain formMain;

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            try
            {
                textBoxError.Text = textBoxError.Text.Replace('.', ',');
                textBoxCoefficient.Text = textBoxCoefficient.Text.Replace('.', ',');
                textBoxMoment.Text = textBoxMoment.Text.Replace('.', ',');
                textBoxCoefT.Text = textBoxCoefT.Text.Replace('.', ',');
                this.Hide();
                formMain.InitializeNetwork(Int32.Parse(textBoxCountItterations.Text), 
                    Double.Parse(textBoxCoefficient.Text),
                    Double.Parse(textBoxMoment.Text),
                    Double.Parse(textBoxCoefT.Text),
                    Double.Parse(textBoxError.Text));
                buttonCancel_Click(sender, e);
            }
            catch
            {
                this.Show();
                formMain.Hide();
                MessageBox.Show("Проверьте правильность параметров");
            }
        }
    }
}
