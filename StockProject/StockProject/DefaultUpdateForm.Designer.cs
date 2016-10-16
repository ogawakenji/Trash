namespace StockProject
{
    partial class DefaultUpdateForm
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
            this.txtUpdateStatus = new System.Windows.Forms.TextBox();
            this.btnStockPriceUpdate = new System.Windows.Forms.Button();
            this.btnDividend = new System.Windows.Forms.Button();
            this.btnStockCode = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUpdateStatus
            // 
            this.txtUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateStatus.Location = new System.Drawing.Point(12, 59);
            this.txtUpdateStatus.MaxLength = 0;
            this.txtUpdateStatus.Multiline = true;
            this.txtUpdateStatus.Name = "txtUpdateStatus";
            this.txtUpdateStatus.ReadOnly = true;
            this.txtUpdateStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateStatus.Size = new System.Drawing.Size(690, 276);
            this.txtUpdateStatus.TabIndex = 1;
            // 
            // btnStockPriceUpdate
            // 
            this.btnStockPriceUpdate.Location = new System.Drawing.Point(12, 12);
            this.btnStockPriceUpdate.Name = "btnStockPriceUpdate";
            this.btnStockPriceUpdate.Size = new System.Drawing.Size(136, 41);
            this.btnStockPriceUpdate.TabIndex = 2;
            this.btnStockPriceUpdate.Text = "株価更新";
            this.btnStockPriceUpdate.UseVisualStyleBackColor = true;
            this.btnStockPriceUpdate.Click += new System.EventHandler(this.btnStockPriceUpdate_Click);
            // 
            // btnDividend
            // 
            this.btnDividend.Location = new System.Drawing.Point(154, 12);
            this.btnDividend.Name = "btnDividend";
            this.btnDividend.Size = new System.Drawing.Size(136, 41);
            this.btnDividend.TabIndex = 3;
            this.btnDividend.Text = "配当更新";
            this.btnDividend.UseVisualStyleBackColor = true;
            this.btnDividend.Click += new System.EventHandler(this.btnDividend_Click);
            // 
            // btnStockCode
            // 
            this.btnStockCode.Location = new System.Drawing.Point(524, 12);
            this.btnStockCode.Name = "btnStockCode";
            this.btnStockCode.Size = new System.Drawing.Size(178, 41);
            this.btnStockCode.TabIndex = 4;
            this.btnStockCode.Text = "証券コード更新";
            this.btnStockCode.UseVisualStyleBackColor = true;
            this.btnStockCode.Click += new System.EventHandler(this.btnStockCode_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(358, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(160, 41);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "企業情報更新";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // DefaultUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 347);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnStockCode);
            this.Controls.Add(this.btnDividend);
            this.Controls.Add(this.btnStockPriceUpdate);
            this.Controls.Add(this.txtUpdateStatus);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefaultUpdateForm";
            this.Text = "データ更新画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUpdateStatus;
        private System.Windows.Forms.Button btnStockPriceUpdate;
        private System.Windows.Forms.Button btnDividend;
        private System.Windows.Forms.Button btnStockCode;
        private System.Windows.Forms.Button btnProfile;
    }
}