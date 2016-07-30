﻿namespace StockProject
{
    partial class ListForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn5UpDown = new System.Windows.Forms.Button();
            this.btnUpDown = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concatenationBusinessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headquartersLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.industriesCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foundationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingMonthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitSharesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNumberSingleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNumberConcatenationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avarageAnnualIncomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendYieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeVolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1292, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1202, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 36);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 347);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.concatenationBusinessDataGridViewTextBoxColumn,
            this.headquartersLocationDataGridViewTextBoxColumn,
            this.industriesCategoryDataGridViewTextBoxColumn,
            this.foundationDateDataGridViewTextBoxColumn,
            this.marketNameDataGridViewTextBoxColumn,
            this.listedDateDataGridViewTextBoxColumn,
            this.closingMonthDataGridViewTextBoxColumn,
            this.unitSharesDataGridViewTextBoxColumn,
            this.employeeNumberSingleDataGridViewTextBoxColumn,
            this.employeeNumberConcatenationDataGridViewTextBoxColumn,
            this.avarageAnnualIncomeDataGridViewTextBoxColumn,
            this.dividendDataGridViewTextBoxColumn,
            this.dividendYieldDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.tradeVolumeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listEntityBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1261, 341);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1292, 398);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1284, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一覧";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn5UpDown);
            this.tabPage2.Controls.Add(this.btnUpDown);
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1284, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn5UpDown
            // 
            this.btn5UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn5UpDown.Location = new System.Drawing.Point(6, 6);
            this.btn5UpDown.Name = "btn5UpDown";
            this.btn5UpDown.Size = new System.Drawing.Size(250, 36);
            this.btn5UpDown.TabIndex = 2;
            this.btn5UpDown.Text = "株価5%上昇下降件数更新";
            this.btn5UpDown.UseVisualStyleBackColor = true;
            this.btn5UpDown.Click += new System.EventHandler(this.btn5UpDown_Click);
            // 
            // btnUpDown
            // 
            this.btnUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpDown.Location = new System.Drawing.Point(1147, 3);
            this.btnUpDown.Name = "btnUpDown";
            this.btnUpDown.Size = new System.Drawing.Size(101, 36);
            this.btnUpDown.TabIndex = 1;
            this.btnUpDown.Text = "5%上下";
            this.btnUpDown.UseVisualStyleBackColor = true;
            this.btnUpDown.Click += new System.EventHandler(this.btnUpDown_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(568, 76);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(556, 279);
            this.dataGridView3.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 76);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(556, 282);
            this.dataGridView2.TabIndex = 0;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Feature";
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            // 
            // concatenationBusinessDataGridViewTextBoxColumn
            // 
            this.concatenationBusinessDataGridViewTextBoxColumn.DataPropertyName = "ConcatenationBusiness";
            this.concatenationBusinessDataGridViewTextBoxColumn.HeaderText = "ConcatenationBusiness";
            this.concatenationBusinessDataGridViewTextBoxColumn.Name = "concatenationBusinessDataGridViewTextBoxColumn";
            // 
            // headquartersLocationDataGridViewTextBoxColumn
            // 
            this.headquartersLocationDataGridViewTextBoxColumn.DataPropertyName = "HeadquartersLocation";
            this.headquartersLocationDataGridViewTextBoxColumn.HeaderText = "HeadquartersLocation";
            this.headquartersLocationDataGridViewTextBoxColumn.Name = "headquartersLocationDataGridViewTextBoxColumn";
            // 
            // industriesCategoryDataGridViewTextBoxColumn
            // 
            this.industriesCategoryDataGridViewTextBoxColumn.DataPropertyName = "IndustriesCategory";
            this.industriesCategoryDataGridViewTextBoxColumn.HeaderText = "IndustriesCategory";
            this.industriesCategoryDataGridViewTextBoxColumn.Name = "industriesCategoryDataGridViewTextBoxColumn";
            // 
            // foundationDateDataGridViewTextBoxColumn
            // 
            this.foundationDateDataGridViewTextBoxColumn.DataPropertyName = "FoundationDate";
            this.foundationDateDataGridViewTextBoxColumn.HeaderText = "FoundationDate";
            this.foundationDateDataGridViewTextBoxColumn.Name = "foundationDateDataGridViewTextBoxColumn";
            // 
            // marketNameDataGridViewTextBoxColumn
            // 
            this.marketNameDataGridViewTextBoxColumn.DataPropertyName = "MarketName";
            this.marketNameDataGridViewTextBoxColumn.HeaderText = "MarketName";
            this.marketNameDataGridViewTextBoxColumn.Name = "marketNameDataGridViewTextBoxColumn";
            // 
            // listedDateDataGridViewTextBoxColumn
            // 
            this.listedDateDataGridViewTextBoxColumn.DataPropertyName = "ListedDate";
            this.listedDateDataGridViewTextBoxColumn.HeaderText = "ListedDate";
            this.listedDateDataGridViewTextBoxColumn.Name = "listedDateDataGridViewTextBoxColumn";
            // 
            // closingMonthDataGridViewTextBoxColumn
            // 
            this.closingMonthDataGridViewTextBoxColumn.DataPropertyName = "ClosingMonth";
            this.closingMonthDataGridViewTextBoxColumn.HeaderText = "ClosingMonth";
            this.closingMonthDataGridViewTextBoxColumn.Name = "closingMonthDataGridViewTextBoxColumn";
            // 
            // unitSharesDataGridViewTextBoxColumn
            // 
            this.unitSharesDataGridViewTextBoxColumn.DataPropertyName = "UnitShares";
            this.unitSharesDataGridViewTextBoxColumn.HeaderText = "UnitShares";
            this.unitSharesDataGridViewTextBoxColumn.Name = "unitSharesDataGridViewTextBoxColumn";
            // 
            // employeeNumberSingleDataGridViewTextBoxColumn
            // 
            this.employeeNumberSingleDataGridViewTextBoxColumn.DataPropertyName = "EmployeeNumberSingle";
            this.employeeNumberSingleDataGridViewTextBoxColumn.HeaderText = "EmployeeNumberSingle";
            this.employeeNumberSingleDataGridViewTextBoxColumn.Name = "employeeNumberSingleDataGridViewTextBoxColumn";
            // 
            // employeeNumberConcatenationDataGridViewTextBoxColumn
            // 
            this.employeeNumberConcatenationDataGridViewTextBoxColumn.DataPropertyName = "EmployeeNumberConcatenation";
            this.employeeNumberConcatenationDataGridViewTextBoxColumn.HeaderText = "EmployeeNumberConcatenation";
            this.employeeNumberConcatenationDataGridViewTextBoxColumn.Name = "employeeNumberConcatenationDataGridViewTextBoxColumn";
            // 
            // avarageAnnualIncomeDataGridViewTextBoxColumn
            // 
            this.avarageAnnualIncomeDataGridViewTextBoxColumn.DataPropertyName = "AvarageAnnualIncome";
            this.avarageAnnualIncomeDataGridViewTextBoxColumn.HeaderText = "AvarageAnnualIncome";
            this.avarageAnnualIncomeDataGridViewTextBoxColumn.Name = "avarageAnnualIncomeDataGridViewTextBoxColumn";
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
            // listEntityBindingSource
            // 
            this.listEntityBindingSource.DataSource = typeof(Utility.ListEntity);
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 524);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListForm";
            this.Text = "一覧";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEntityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource listEntityBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn concatenationBusinessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn headquartersLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn industriesCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foundationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn listedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingMonthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitSharesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNumberSingleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNumberConcatenationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avarageAnnualIncomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendYieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeVolumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnUpDown;
        private System.Windows.Forms.Button btn5UpDown;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}