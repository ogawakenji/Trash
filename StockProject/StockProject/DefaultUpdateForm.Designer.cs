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
            this.btnDefaultUpdate = new System.Windows.Forms.Button();
            this.txtUpdateStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDefaultUpdate
            // 
            this.btnDefaultUpdate.Location = new System.Drawing.Point(12, 12);
            this.btnDefaultUpdate.Name = "btnDefaultUpdate";
            this.btnDefaultUpdate.Size = new System.Drawing.Size(246, 41);
            this.btnDefaultUpdate.TabIndex = 0;
            this.btnDefaultUpdate.Text = "初期データ更新";
            this.btnDefaultUpdate.UseVisualStyleBackColor = true;
            this.btnDefaultUpdate.Click += new System.EventHandler(this.btnDefaultUpdate_Click);
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
            // DefaultUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 347);
            this.Controls.Add(this.txtUpdateStatus);
            this.Controls.Add(this.btnDefaultUpdate);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DefaultUpdateForm";
            this.Text = "初期データ更新画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDefaultUpdate;
        private System.Windows.Forms.TextBox txtUpdateStatus;
    }
}