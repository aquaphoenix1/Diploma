namespace ApproximationHRBF
{
    partial class FormParametrs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxDistribution = new System.Windows.Forms.ComboBox();
            this.labelCountCloset = new System.Windows.Forms.Label();
            this.textBoxCountCloset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(193, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            this.label2.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(8, 149);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(148, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Принять";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(164, 149);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(193, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Visible = false;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(11, 114);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(145, 20);
            this.textBoxCount.TabIndex = 6;
            this.textBoxCount.Text = "5000";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 98);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(146, 13);
            this.labelCount.TabIndex = 7;
            this.labelCount.Text = "Кол-во элементов выборки";
            // 
            // comboBoxDistribution
            // 
            this.comboBoxDistribution.FormattingEnabled = true;
            this.comboBoxDistribution.Items.AddRange(new object[] {
            "Арксинус",
            "Экспоненциальное",
            "Лаплас",
            "Нормальное",
            "Релей",
            "Симпсон"});
            this.comboBoxDistribution.Location = new System.Drawing.Point(13, 13);
            this.comboBoxDistribution.Name = "comboBoxDistribution";
            this.comboBoxDistribution.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDistribution.TabIndex = 8;
            this.comboBoxDistribution.SelectedIndexChanged += new System.EventHandler(this.comboBoxDistribution_SelectedIndexChanged);
            // 
            // labelCountCloset
            // 
            this.labelCountCloset.AutoSize = true;
            this.labelCountCloset.Location = new System.Drawing.Point(162, 98);
            this.labelCountCloset.Name = "labelCountCloset";
            this.labelCountCloset.Size = new System.Drawing.Size(123, 13);
            this.labelCountCloset.TabIndex = 9;
            this.labelCountCloset.Text = "Количество коридоров";
            // 
            // textBoxCountCloset
            // 
            this.textBoxCountCloset.Location = new System.Drawing.Point(162, 114);
            this.textBoxCountCloset.Name = "textBoxCountCloset";
            this.textBoxCountCloset.Size = new System.Drawing.Size(120, 20);
            this.textBoxCountCloset.TabIndex = 10;
            this.textBoxCountCloset.Text = "20";
            // 
            // FormParametrs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 182);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxCountCloset);
            this.Controls.Add(this.labelCountCloset);
            this.Controls.Add(this.comboBoxDistribution);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormParametrs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxDistribution;
        private System.Windows.Forms.Label labelCountCloset;
        private System.Windows.Forms.TextBox textBoxCountCloset;
    }
}