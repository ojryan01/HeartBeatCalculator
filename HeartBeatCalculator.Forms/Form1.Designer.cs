
namespace HeartBeatCalculator.Forms
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.EKGData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Graph = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EKGData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // EKGData
            // 
            chartArea2.Name = "ChartArea1";
            this.EKGData.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.EKGData.Legends.Add(legend2);
            this.EKGData.Location = new System.Drawing.Point(16, 13);
            this.EKGData.Margin = new System.Windows.Forms.Padding(4);
            this.EKGData.Name = "EKGData";
            this.EKGData.Size = new System.Drawing.Size(697, 233);
            this.EKGData.TabIndex = 0;
            this.EKGData.Text = "EKG Data";
            this.EKGData.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(638, 456);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(75, 23);
            this.Graph.TabIndex = 1;
            this.Graph.Text = "Graph";
            this.Graph.UseVisualStyleBackColor = true;
            this.Graph.Click += new System.EventHandler(this.Graph_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(697, 195);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 487);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.EKGData);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EKGData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart EKGData;
        private System.Windows.Forms.Button Graph;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

