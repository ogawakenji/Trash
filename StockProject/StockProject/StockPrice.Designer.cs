namespace StockProject
{
    partial class StockPrice
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.btnStockPrice = new System.Windows.Forms.Button();
            this.dgvStockPrice = new System.Windows.Forms.DataGridView();
            this.btnDividend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chtStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtDollarYen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtDollarYen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStockCode
            // 
            this.txtStockCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStockCode.Location = new System.Drawing.Point(13, 13);
            this.txtStockCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockCode.MaxLength = 4;
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(82, 37);
            this.txtStockCode.TabIndex = 0;
            this.txtStockCode.Text = "6178";
            // 
            // btnStockPrice
            // 
            this.btnStockPrice.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStockPrice.Location = new System.Drawing.Point(103, 10);
            this.btnStockPrice.Margin = new System.Windows.Forms.Padding(4);
            this.btnStockPrice.Name = "btnStockPrice";
            this.btnStockPrice.Size = new System.Drawing.Size(102, 42);
            this.btnStockPrice.TabIndex = 1;
            this.btnStockPrice.Text = "株価";
            this.btnStockPrice.UseVisualStyleBackColor = true;
            this.btnStockPrice.Click += new System.EventHandler(this.btnStockPrice_Click);
            // 
            // dgvStockPrice
            // 
            this.dgvStockPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockPrice.Location = new System.Drawing.Point(13, 59);
            this.dgvStockPrice.Name = "dgvStockPrice";
            this.dgvStockPrice.RowTemplate.Height = 24;
            this.dgvStockPrice.Size = new System.Drawing.Size(302, 567);
            this.dgvStockPrice.TabIndex = 2;
            // 
            // btnDividend
            // 
            this.btnDividend.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDividend.Location = new System.Drawing.Point(213, 10);
            this.btnDividend.Margin = new System.Windows.Forms.Padding(4);
            this.btnDividend.Name = "btnDividend";
            this.btnDividend.Size = new System.Drawing.Size(102, 42);
            this.btnDividend.TabIndex = 3;
            this.btnDividend.Text = "配当";
            this.btnDividend.UseVisualStyleBackColor = true;
            this.btnDividend.Click += new System.EventHandler(this.btnDividend_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(323, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "ドル/円";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chtStock
            // 
            this.chtStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtStock.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtStock.Legends.Add(legend1);
            this.chtStock.Location = new System.Drawing.Point(323, 59);
            this.chtStock.Name = "chtStock";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtStock.Series.Add(series1);
            this.chtStock.Size = new System.Drawing.Size(728, 325);
            this.chtStock.TabIndex = 5;
            this.chtStock.Text = "chart1";
            // 
            // chtDollarYen
            // 
            this.chtDollarYen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chtDollarYen.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtDollarYen.Legends.Add(legend2);
            this.chtDollarYen.Location = new System.Drawing.Point(323, 390);
            this.chtDollarYen.Name = "chtDollarYen";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtDollarYen.Series.Add(series2);
            this.chtDollarYen.Size = new System.Drawing.Size(728, 236);
            this.chtDollarYen.TabIndex = 5;
            this.chtDollarYen.Text = "chart1";
            // 
            // StockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 638);
            this.Controls.Add(this.chtDollarYen);
            this.Controls.Add(this.chtStock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDividend);
            this.Controls.Add(this.dgvStockPrice);
            this.Controls.Add(this.btnStockPrice);
            this.Controls.Add(this.txtStockCode);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StockPrice";
            this.Text = "StockPrice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtDollarYen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button btnStockPrice;
        private System.Windows.Forms.DataGridView dgvStockPrice;
        private System.Windows.Forms.Button btnDividend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtStock;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDollarYen;
    }
}