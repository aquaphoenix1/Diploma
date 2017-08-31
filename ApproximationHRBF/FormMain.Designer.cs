namespace ApproximationHRBF
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkParametrsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learnNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartHystogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxCurrentIteration = new System.Windows.Forms.TextBox();
            this.labelCurrentIteration = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHystogram)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.networkParametrsToolStripMenuItem,
            this.learnNetworkToolStripMenuItem,
            this.stopLearningToolStripMenuItem,
            this.testNetworkToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(669, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.downloadToolStripMenuItem.Text = "Загрузить выборку";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveToolStripMenuItem.Text = "Сохранить выборку";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.generatorToolStripMenuItem.Text = "Генератор";
            this.generatorToolStripMenuItem.Click += new System.EventHandler(this.generatorToolStripMenuItem_Click);
            // 
            // networkParametrsToolStripMenuItem
            // 
            this.networkParametrsToolStripMenuItem.Name = "networkParametrsToolStripMenuItem";
            this.networkParametrsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.networkParametrsToolStripMenuItem.Text = "Параметры сети";
            this.networkParametrsToolStripMenuItem.Click += new System.EventHandler(this.networkParametrsToolStripMenuItem_Click);
            // 
            // learnNetworkToolStripMenuItem
            // 
            this.learnNetworkToolStripMenuItem.Name = "learnNetworkToolStripMenuItem";
            this.learnNetworkToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.learnNetworkToolStripMenuItem.Text = "Обучить сеть";
            this.learnNetworkToolStripMenuItem.Click += new System.EventHandler(this.обучитьСетьToolStripMenuItem_Click);
            // 
            // stopLearningToolStripMenuItem
            // 
            this.stopLearningToolStripMenuItem.Name = "stopLearningToolStripMenuItem";
            this.stopLearningToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.stopLearningToolStripMenuItem.Text = "Остановить обучение";
            this.stopLearningToolStripMenuItem.Click += new System.EventHandler(this.остановитьОбучениеToolStripMenuItem_Click);
            // 
            // testNetworkToolStripMenuItem
            // 
            this.testNetworkToolStripMenuItem.Name = "testNetworkToolStripMenuItem";
            this.testNetworkToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.testNetworkToolStripMenuItem.Text = "Тест сети";
            this.testNetworkToolStripMenuItem.Click += new System.EventHandler(this.тестСетиToolStripMenuItem_Click);
            // 
            // chartHystogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHystogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHystogram.Legends.Add(legend1);
            this.chartHystogram.Location = new System.Drawing.Point(13, 28);
            this.chartHystogram.Name = "chartHystogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Выборка";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Исходное значение";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Полученное значение";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "После обучения";
            this.chartHystogram.Series.Add(series1);
            this.chartHystogram.Series.Add(series2);
            this.chartHystogram.Series.Add(series3);
            this.chartHystogram.Series.Add(series4);
            this.chartHystogram.Size = new System.Drawing.Size(563, 474);
            this.chartHystogram.TabIndex = 1;
            this.chartHystogram.Text = "Гистограмма";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(582, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBoxCurrentIteration
            // 
            this.textBoxCurrentIteration.Location = new System.Drawing.Point(402, 139);
            this.textBoxCurrentIteration.Name = "textBoxCurrentIteration";
            this.textBoxCurrentIteration.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentIteration.TabIndex = 4;
            // 
            // labelCurrentIteration
            // 
            this.labelCurrentIteration.AutoSize = true;
            this.labelCurrentIteration.BackColor = System.Drawing.Color.White;
            this.labelCurrentIteration.Location = new System.Drawing.Point(400, 123);
            this.labelCurrentIteration.Name = "labelCurrentIteration";
            this.labelCurrentIteration.Size = new System.Drawing.Size(102, 13);
            this.labelCurrentIteration.TabIndex = 5;
            this.labelCurrentIteration.Text = "Текущая итерация";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 502);
            this.Controls.Add(this.labelCurrentIteration);
            this.Controls.Add(this.textBoxCurrentIteration);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chartHystogram);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аппроксимация";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHystogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHystogram;
        private System.Windows.Forms.ToolStripMenuItem networkParametrsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem learnNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopLearningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testNetworkToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxCurrentIteration;
        private System.Windows.Forms.Label labelCurrentIteration;
    }
}

