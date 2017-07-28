namespace ApproximationHRBF
{
    partial class FormNetwork
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCountEnters = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCountNeurons = new System.Windows.Forms.TextBox();
            this.textBoxCountEnters = new System.Windows.Forms.TextBox();
            this.labelCountItterations = new System.Windows.Forms.Label();
            this.textBoxCountItterations = new System.Windows.Forms.TextBox();
            this.textBoxCoefficient = new System.Windows.Forms.TextBox();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.labelMoment = new System.Windows.Forms.Label();
            this.labelCoefT = new System.Windows.Forms.Label();
            this.textBoxMoment = new System.Windows.Forms.TextBox();
            this.textBoxCoefT = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(23, 291);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(97, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(126, 291);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCountEnters
            // 
            this.labelCountEnters.AutoSize = true;
            this.labelCountEnters.Location = new System.Drawing.Point(20, 9);
            this.labelCountEnters.Name = "labelCountEnters";
            this.labelCountEnters.Size = new System.Drawing.Size(104, 13);
            this.labelCountEnters.TabIndex = 2;
            this.labelCountEnters.Text = "Количество входов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество нейронов скрытого слоя";
            // 
            // textBoxCountNeurons
            // 
            this.textBoxCountNeurons.Enabled = false;
            this.textBoxCountNeurons.Location = new System.Drawing.Point(23, 64);
            this.textBoxCountNeurons.Name = "textBoxCountNeurons";
            this.textBoxCountNeurons.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountNeurons.TabIndex = 4;
            this.textBoxCountNeurons.Text = "20";
            // 
            // textBoxCountEnters
            // 
            this.textBoxCountEnters.Enabled = false;
            this.textBoxCountEnters.Location = new System.Drawing.Point(23, 25);
            this.textBoxCountEnters.Name = "textBoxCountEnters";
            this.textBoxCountEnters.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountEnters.TabIndex = 5;
            this.textBoxCountEnters.Text = "1";
            // 
            // labelCountItterations
            // 
            this.labelCountItterations.AutoSize = true;
            this.labelCountItterations.Location = new System.Drawing.Point(20, 87);
            this.labelCountItterations.Name = "labelCountItterations";
            this.labelCountItterations.Size = new System.Drawing.Size(154, 13);
            this.labelCountItterations.TabIndex = 6;
            this.labelCountItterations.Text = "Количество циклов обучения";
            // 
            // textBoxCountItterations
            // 
            this.textBoxCountItterations.Location = new System.Drawing.Point(23, 103);
            this.textBoxCountItterations.Name = "textBoxCountItterations";
            this.textBoxCountItterations.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountItterations.TabIndex = 7;
            this.textBoxCountItterations.Text = "3000";
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Location = new System.Drawing.Point(23, 146);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoefficient.TabIndex = 8;
            this.textBoxCoefficient.Text = "0.2";
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Location = new System.Drawing.Point(20, 126);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(126, 13);
            this.labelCoefficient.TabIndex = 9;
            this.labelCoefficient.Text = "Коэффициент обучения";
            // 
            // labelMoment
            // 
            this.labelMoment.AutoSize = true;
            this.labelMoment.Location = new System.Drawing.Point(20, 212);
            this.labelMoment.Name = "labelMoment";
            this.labelMoment.Size = new System.Drawing.Size(47, 13);
            this.labelMoment.TabIndex = 10;
            this.labelMoment.Text = "Момент";
            // 
            // labelCoefT
            // 
            this.labelCoefT.AutoSize = true;
            this.labelCoefT.Location = new System.Drawing.Point(20, 249);
            this.labelCoefT.Name = "labelCoefT";
            this.labelCoefT.Size = new System.Drawing.Size(87, 13);
            this.labelCoefT.TabIndex = 11;
            this.labelCoefT.Text = "Коэффициент T";
            // 
            // textBoxMoment
            // 
            this.textBoxMoment.Location = new System.Drawing.Point(23, 228);
            this.textBoxMoment.Name = "textBoxMoment";
            this.textBoxMoment.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoment.TabIndex = 12;
            this.textBoxMoment.Text = "0.03";
            // 
            // textBoxCoefT
            // 
            this.textBoxCoefT.Location = new System.Drawing.Point(23, 265);
            this.textBoxCoefT.Name = "textBoxCoefT";
            this.textBoxCoefT.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoefT.TabIndex = 13;
            this.textBoxCoefT.Text = "100";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(23, 173);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(124, 13);
            this.labelError.TabIndex = 14;
            this.labelError.Text = "Погрешность обучения";
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(23, 189);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(100, 20);
            this.textBoxError.TabIndex = 15;
            this.textBoxError.Text = "0.001";
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 324);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.textBoxCoefT);
            this.Controls.Add(this.textBoxMoment);
            this.Controls.Add(this.labelCoefT);
            this.Controls.Add(this.labelMoment);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.textBoxCountItterations);
            this.Controls.Add(this.labelCountItterations);
            this.Controls.Add(this.textBoxCountEnters);
            this.Controls.Add(this.textBoxCountNeurons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCountEnters);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Name = "FormNetwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNetwork";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCountEnters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCountNeurons;
        private System.Windows.Forms.TextBox textBoxCountEnters;
        private System.Windows.Forms.Label labelCountItterations;
        private System.Windows.Forms.TextBox textBoxCountItterations;
        private System.Windows.Forms.TextBox textBoxCoefficient;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label labelMoment;
        private System.Windows.Forms.Label labelCoefT;
        private System.Windows.Forms.TextBox textBoxMoment;
        private System.Windows.Forms.TextBox textBoxCoefT;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TextBox textBoxError;
    }
}