namespace StockProject
{
    partial class Dividend
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDividend = new System.Windows.Forms.Button();
            this.dgvDividend = new System.Windows.Forms.DataGridView();
            this.dividendEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendYieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDividend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividendEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDividend
            // 
            this.btnDividend.Location = new System.Drawing.Point(12, 12);
            this.btnDividend.Name = "btnDividend";
            this.btnDividend.Size = new System.Drawing.Size(146, 39);
            this.btnDividend.TabIndex = 0;
            this.btnDividend.Text = "配当再取得";
            this.btnDividend.UseVisualStyleBackColor = true;
            this.btnDividend.Click += new System.EventHandler(this.btnDividend_Click);
            // 
            // dgvDividend
            // 
            this.dgvDividend.AutoGenerateColumns = false;
            this.dgvDividend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDividend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNoDataGridViewTextBoxColumn,
            this.stockCodeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn,
            this.dividendDataGridViewTextBoxColumn,
            this.dividendYieldDataGridViewTextBoxColumn,
            this.detailUrlDataGridViewTextBoxColumn});
            this.dgvDividend.DataSource = this.dividendEntityBindingSource;
            this.dgvDividend.Location = new System.Drawing.Point(12, 57);
            this.dgvDividend.Name = "dgvDividend";
            this.dgvDividend.RowTemplate.Height = 24;
            this.dgvDividend.Size = new System.Drawing.Size(1113, 444);
            this.dgvDividend.TabIndex = 1;
            // 
            // dividendEntityBindingSource
            // 
            this.dividendEntityBindingSource.DataSource = typeof(Utility.DividendEntity);
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            this.orderNoDataGridViewTextBoxColumn.DataPropertyName = "OrderNo";
            this.orderNoDataGridViewTextBoxColumn.HeaderText = "順位";
            this.orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            this.orderNoDataGridViewTextBoxColumn.Width = 50;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "コード";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = "Market";
            this.marketDataGridViewTextBoxColumn.HeaderText = "市場";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            this.companyNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // dividendDataGridViewTextBoxColumn
            // 
            this.dividendDataGridViewTextBoxColumn.DataPropertyName = "Dividend";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dividendDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dividendDataGridViewTextBoxColumn.HeaderText = "1株配当";
            this.dividendDataGridViewTextBoxColumn.Name = "dividendDataGridViewTextBoxColumn";
            // 
            // dividendYieldDataGridViewTextBoxColumn
            // 
            this.dividendYieldDataGridViewTextBoxColumn.DataPropertyName = "DividendYield";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dividendYieldDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dividendYieldDataGridViewTextBoxColumn.HeaderText = "配当利回り";
            this.dividendYieldDataGridViewTextBoxColumn.Name = "dividendYieldDataGridViewTextBoxColumn";
            // 
            // detailUrlDataGridViewTextBoxColumn
            // 
            this.detailUrlDataGridViewTextBoxColumn.DataPropertyName = "DetailUrl";
            this.detailUrlDataGridViewTextBoxColumn.HeaderText = "URL";
            this.detailUrlDataGridViewTextBoxColumn.Name = "detailUrlDataGridViewTextBoxColumn";
            this.detailUrlDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Dividend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 513);
            this.Controls.Add(this.dgvDividend);
            this.Controls.Add(this.btnDividend);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Dividend";
            this.Text = "Dividend";
            this.Load += new System.EventHandler(this.Dividend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDividend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividendEntityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDividend;
        private System.Windows.Forms.DataGridView dgvDividend;
        private System.Windows.Forms.BindingSource dividendEntityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendYieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailUrlDataGridViewTextBoxColumn;
    }
}