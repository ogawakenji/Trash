namespace StockProject
{
    partial class MenuForm
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
            this.btnList = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(16, 97);
            this.btnList.Margin = new System.Windows.Forms.Padding(7);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(206, 67);
            this.btnList.TabIndex = 0;
            this.btnList.Text = "一覧";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(16, 178);
            this.btnChart.Margin = new System.Windows.Forms.Padding(7);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(206, 67);
            this.btnChart.TabIndex = 1;
            this.btnChart.Text = "チャート";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(16, 16);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(206, 67);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 417);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(206, 67);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 500);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnList);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "MenuForm";
            this.Text = "メニュー";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.Shown += new System.EventHandler(this.MenuForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
    }
}