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
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.btnStockPrice = new System.Windows.Forms.Button();
            this.dgvStockPrice = new System.Windows.Forms.DataGridView();
            this.btnDividend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).BeginInit();
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
            this.dgvStockPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockPrice.Location = new System.Drawing.Point(13, 59);
            this.dgvStockPrice.Name = "dgvStockPrice";
            this.dgvStockPrice.RowTemplate.Height = 24;
            this.dgvStockPrice.Size = new System.Drawing.Size(1038, 567);
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
            // StockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 638);
            this.Controls.Add(this.btnDividend);
            this.Controls.Add(this.dgvStockPrice);
            this.Controls.Add(this.btnStockPrice);
            this.Controls.Add(this.txtStockCode);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StockPrice";
            this.Text = "StockPrice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button btnStockPrice;
        private System.Windows.Forms.DataGridView dgvStockPrice;
        private System.Windows.Forms.Button btnDividend;
    }
}