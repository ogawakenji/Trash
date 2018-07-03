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
            this.txtStockCodes = new System.Windows.Forms.TextBox();
            this.btnStockPriceUpdateTarget = new System.Windows.Forms.Button();
            this.btnPrice10 = new System.Windows.Forms.Button();
            this.btnPriceMinDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUpdateStatus
            // 
            this.txtUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateStatus.Location = new System.Drawing.Point(12, 82);
            this.txtUpdateStatus.MaxLength = 0;
            this.txtUpdateStatus.Multiline = true;
            this.txtUpdateStatus.Name = "txtUpdateStatus";
            this.txtUpdateStatus.ReadOnly = true;
            this.txtUpdateStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateStatus.Size = new System.Drawing.Size(1126, 253);
            this.txtUpdateStatus.TabIndex = 1;
            // 
            // btnStockPriceUpdate
            // 
            this.btnStockPriceUpdate.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStockPriceUpdate.Location = new System.Drawing.Point(533, 5);
            this.btnStockPriceUpdate.Name = "btnStockPriceUpdate";
            this.btnStockPriceUpdate.Size = new System.Drawing.Size(136, 41);
            this.btnStockPriceUpdate.TabIndex = 2;
            this.btnStockPriceUpdate.Text = "株価更新";
            this.btnStockPriceUpdate.UseVisualStyleBackColor = true;
            this.btnStockPriceUpdate.Click += new System.EventHandler(this.btnStockPriceUpdate_Click);
            // 
            // btnDividend
            // 
            this.btnDividend.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDividend.Location = new System.Drawing.Point(157, 12);
            this.btnDividend.Name = "btnDividend";
            this.btnDividend.Size = new System.Drawing.Size(108, 27);
            this.btnDividend.TabIndex = 3;
            this.btnDividend.Text = "配当更新";
            this.btnDividend.UseVisualStyleBackColor = true;
            this.btnDividend.Click += new System.EventHandler(this.btnDividend_Click);
            // 
            // btnStockCode
            // 
            this.btnStockCode.Location = new System.Drawing.Point(904, 12);
            this.btnStockCode.Name = "btnStockCode";
            this.btnStockCode.Size = new System.Drawing.Size(178, 41);
            this.btnStockCode.TabIndex = 4;
            this.btnStockCode.Text = "証券コード更新";
            this.btnStockCode.UseVisualStyleBackColor = true;
            this.btnStockCode.Click += new System.EventHandler(this.btnStockCode_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnProfile.Location = new System.Drawing.Point(12, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(139, 27);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "企業情報更新";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // txtStockCodes
            // 
            this.txtStockCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStockCodes.Location = new System.Drawing.Point(1144, 59);
            this.txtStockCodes.Multiline = true;
            this.txtStockCodes.Name = "txtStockCodes";
            this.txtStockCodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStockCodes.Size = new System.Drawing.Size(109, 276);
            this.txtStockCodes.TabIndex = 6;
            // 
            // btnStockPriceUpdateTarget
            // 
            this.btnStockPriceUpdateTarget.Location = new System.Drawing.Point(725, 12);
            this.btnStockPriceUpdateTarget.Name = "btnStockPriceUpdateTarget";
            this.btnStockPriceUpdateTarget.Size = new System.Drawing.Size(173, 41);
            this.btnStockPriceUpdateTarget.TabIndex = 7;
            this.btnStockPriceUpdateTarget.Text = "株価更新(個別)";
            this.btnStockPriceUpdateTarget.UseVisualStyleBackColor = true;
            this.btnStockPriceUpdateTarget.Click += new System.EventHandler(this.btnStockPriceUpdateTarget_Click);
            // 
            // btnPrice10
            // 
            this.btnPrice10.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrice10.Location = new System.Drawing.Point(12, 45);
            this.btnPrice10.Name = "btnPrice10";
            this.btnPrice10.Size = new System.Drawing.Size(154, 27);
            this.btnPrice10.TabIndex = 2;
            this.btnPrice10.Text = "株価更新(5年)";
            this.btnPrice10.UseVisualStyleBackColor = true;
            this.btnPrice10.Click += new System.EventHandler(this.btnPrice10_Click);
            // 
            // btnPriceMinDate
            // 
            this.btnPriceMinDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPriceMinDate.Location = new System.Drawing.Point(271, 12);
            this.btnPriceMinDate.Name = "btnPriceMinDate";
            this.btnPriceMinDate.Size = new System.Drawing.Size(229, 27);
            this.btnPriceMinDate.TabIndex = 8;
            this.btnPriceMinDate.Text = "株価更新(最小日付以降)";
            this.btnPriceMinDate.UseVisualStyleBackColor = true;
            this.btnPriceMinDate.Click += new System.EventHandler(this.btnPriceMinDate_Click);
            // 
            // DefaultUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 347);
            this.Controls.Add(this.btnPriceMinDate);
            this.Controls.Add(this.btnStockPriceUpdateTarget);
            this.Controls.Add(this.txtStockCodes);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnStockCode);
            this.Controls.Add(this.btnDividend);
            this.Controls.Add(this.btnPrice10);
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
        private System.Windows.Forms.TextBox txtStockCodes;
        private System.Windows.Forms.Button btnStockPriceUpdateTarget;
        private System.Windows.Forms.Button btnPrice10;
        private System.Windows.Forms.Button btnPriceMinDate;
    }
}