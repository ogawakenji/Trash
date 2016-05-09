namespace StockProject
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.orderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendYieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockPriceEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeVolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjustmentClosingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividendEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockPriceEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(376, 116);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1122, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "GetHtml";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(831, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "http://info.finance.yahoo.co.jp/ranking/?kd=8&tm=d&vl=a&mk=1&p=1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1122, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 77);
            this.button2.TabIndex = 3;
            this.button2.Text = "sgmlReader";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1122, 177);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 77);
            this.button3.TabIndex = 4;
            this.button3.Text = "parseHtml";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderDataGridViewTextBoxColumn,
            this.stockCodeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn,
            this.dividendDataGridViewTextBoxColumn,
            this.dividendYieldDataGridViewTextBoxColumn,
            this.detailUrlDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dividendEntityBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(394, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(722, 116);
            this.dataGridView1.TabIndex = 5;
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(12, 178);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(100, 22);
            this.txtStockCode.TabIndex = 6;
            this.txtStockCode.Text = "6178";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(118, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "StockPrice";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeDataGridViewTextBoxColumn1,
            this.companyNameDataGridViewTextBoxColumn1,
            this.stockDateDataGridViewTextBoxColumn,
            this.openingPriceDataGridViewTextBoxColumn,
            this.highPriceDataGridViewTextBoxColumn,
            this.lowPriceDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.tradeVolumeDataGridViewTextBoxColumn,
            this.adjustmentClosingPriceDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.stockPriceEntityBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(12, 206);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(872, 305);
            this.dataGridView2.TabIndex = 8;
            // 
            // orderDataGridViewTextBoxColumn
            // 
            this.orderDataGridViewTextBoxColumn.DataPropertyName = "Order";
            this.orderDataGridViewTextBoxColumn.HeaderText = "Order";
            this.orderDataGridViewTextBoxColumn.Name = "orderDataGridViewTextBoxColumn";
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = "Market";
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            // 
            // dividendDataGridViewTextBoxColumn
            // 
            this.dividendDataGridViewTextBoxColumn.DataPropertyName = "Dividend";
            this.dividendDataGridViewTextBoxColumn.HeaderText = "Dividend";
            this.dividendDataGridViewTextBoxColumn.Name = "dividendDataGridViewTextBoxColumn";
            // 
            // dividendYieldDataGridViewTextBoxColumn
            // 
            this.dividendYieldDataGridViewTextBoxColumn.DataPropertyName = "DividendYield";
            this.dividendYieldDataGridViewTextBoxColumn.HeaderText = "DividendYield";
            this.dividendYieldDataGridViewTextBoxColumn.Name = "dividendYieldDataGridViewTextBoxColumn";
            // 
            // detailUrlDataGridViewTextBoxColumn
            // 
            this.detailUrlDataGridViewTextBoxColumn.DataPropertyName = "DetailUrl";
            this.detailUrlDataGridViewTextBoxColumn.HeaderText = "DetailUrl";
            this.detailUrlDataGridViewTextBoxColumn.Name = "detailUrlDataGridViewTextBoxColumn";
            // 
            // dividendEntityBindingSource
            // 
            this.dividendEntityBindingSource.DataSource = typeof(Utility.DividendEntity);
            // 
            // stockPriceEntityBindingSource
            // 
            this.stockPriceEntityBindingSource.DataSource = typeof(Utility.StockPriceEntity);
            // 
            // stockCodeDataGridViewTextBoxColumn1
            // 
            this.stockCodeDataGridViewTextBoxColumn1.DataPropertyName = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn1.HeaderText = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn1.Name = "stockCodeDataGridViewTextBoxColumn1";
            // 
            // companyNameDataGridViewTextBoxColumn1
            // 
            this.companyNameDataGridViewTextBoxColumn1.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn1.HeaderText = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn1.Name = "companyNameDataGridViewTextBoxColumn1";
            // 
            // stockDateDataGridViewTextBoxColumn
            // 
            this.stockDateDataGridViewTextBoxColumn.DataPropertyName = "StockDate";
            this.stockDateDataGridViewTextBoxColumn.HeaderText = "StockDate";
            this.stockDateDataGridViewTextBoxColumn.Name = "stockDateDataGridViewTextBoxColumn";
            // 
            // openingPriceDataGridViewTextBoxColumn
            // 
            this.openingPriceDataGridViewTextBoxColumn.DataPropertyName = "OpeningPrice";
            this.openingPriceDataGridViewTextBoxColumn.HeaderText = "OpeningPrice";
            this.openingPriceDataGridViewTextBoxColumn.Name = "openingPriceDataGridViewTextBoxColumn";
            // 
            // highPriceDataGridViewTextBoxColumn
            // 
            this.highPriceDataGridViewTextBoxColumn.DataPropertyName = "HighPrice";
            this.highPriceDataGridViewTextBoxColumn.HeaderText = "HighPrice";
            this.highPriceDataGridViewTextBoxColumn.Name = "highPriceDataGridViewTextBoxColumn";
            // 
            // lowPriceDataGridViewTextBoxColumn
            // 
            this.lowPriceDataGridViewTextBoxColumn.DataPropertyName = "LowPrice";
            this.lowPriceDataGridViewTextBoxColumn.HeaderText = "LowPrice";
            this.lowPriceDataGridViewTextBoxColumn.Name = "lowPriceDataGridViewTextBoxColumn";
            // 
            // closingPriceDataGridViewTextBoxColumn
            // 
            this.closingPriceDataGridViewTextBoxColumn.DataPropertyName = "ClosingPrice";
            this.closingPriceDataGridViewTextBoxColumn.HeaderText = "ClosingPrice";
            this.closingPriceDataGridViewTextBoxColumn.Name = "closingPriceDataGridViewTextBoxColumn";
            // 
            // tradeVolumeDataGridViewTextBoxColumn
            // 
            this.tradeVolumeDataGridViewTextBoxColumn.DataPropertyName = "TradeVolume";
            this.tradeVolumeDataGridViewTextBoxColumn.HeaderText = "TradeVolume";
            this.tradeVolumeDataGridViewTextBoxColumn.Name = "tradeVolumeDataGridViewTextBoxColumn";
            // 
            // adjustmentClosingPriceDataGridViewTextBoxColumn
            // 
            this.adjustmentClosingPriceDataGridViewTextBoxColumn.DataPropertyName = "AdjustmentClosingPrice";
            this.adjustmentClosingPriceDataGridViewTextBoxColumn.HeaderText = "AdjustmentClosingPrice";
            this.adjustmentClosingPriceDataGridViewTextBoxColumn.Name = "adjustmentClosingPriceDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 523);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividendEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockPriceEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dividendEntityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendYieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource stockPriceEntityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeVolumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjustmentClosingPriceDataGridViewTextBoxColumn;
    }
}

