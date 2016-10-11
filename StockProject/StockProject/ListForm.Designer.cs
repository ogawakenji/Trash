namespace StockProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboMarketName = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtClosingMonth = new System.Windows.Forms.TextBox();
            this.lblClosingMonth = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.lblStockCode = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn5UpDown = new System.Windows.Forms.Button();
            this.btnUpDown = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEntityBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboMarketName);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.txtClosingMonth);
            this.groupBox1.Controls.Add(this.lblClosingMonth);
            this.groupBox1.Controls.Add(this.txtStockCode);
            this.groupBox1.Controls.Add(this.lblStockCode);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1292, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "市場名";
            // 
            // cboMarketName
            // 
            this.cboMarketName.FormattingEnabled = true;
            this.cboMarketName.Location = new System.Drawing.Point(596, 19);
            this.cboMarketName.Name = "cboMarketName";
            this.cboMarketName.Size = new System.Drawing.Size(204, 28);
            this.cboMarketName.TabIndex = 6;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(297, 19);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(204, 28);
            this.cboCategory.TabIndex = 6;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(202, 23);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(89, 20);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "業種分類";
            // 
            // txtClosingMonth
            // 
            this.txtClosingMonth.Location = new System.Drawing.Point(124, 56);
            this.txtClosingMonth.MaxLength = 2;
            this.txtClosingMonth.Name = "txtClosingMonth";
            this.txtClosingMonth.Size = new System.Drawing.Size(54, 27);
            this.txtClosingMonth.TabIndex = 4;
            // 
            // lblClosingMonth
            // 
            this.lblClosingMonth.AutoSize = true;
            this.lblClosingMonth.Location = new System.Drawing.Point(9, 63);
            this.lblClosingMonth.Name = "lblClosingMonth";
            this.lblClosingMonth.Size = new System.Drawing.Size(69, 20);
            this.lblClosingMonth.TabIndex = 3;
            this.lblClosingMonth.Text = "決算月";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(124, 20);
            this.txtStockCode.MaxLength = 4;
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(54, 27);
            this.txtStockCode.TabIndex = 2;
            // 
            // lblStockCode
            // 
            this.lblStockCode.AutoSize = true;
            this.lblStockCode.Location = new System.Drawing.Point(9, 23);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(109, 20);
            this.lblStockCode.TabIndex = 1;
            this.lblStockCode.Text = "証券コード";
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
            this.panel1.Size = new System.Drawing.Size(1267, 357);
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
            this.dataGridView1.Size = new System.Drawing.Size(1261, 351);
            this.dataGridView1.TabIndex = 1;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "StockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "証券コード";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "企業名";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "特色";
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            // 
            // concatenationBusinessDataGridViewTextBoxColumn
            // 
            this.concatenationBusinessDataGridViewTextBoxColumn.DataPropertyName = "ConcatenationBusiness";
            this.concatenationBusinessDataGridViewTextBoxColumn.HeaderText = "連結事業";
            this.concatenationBusinessDataGridViewTextBoxColumn.Name = "concatenationBusinessDataGridViewTextBoxColumn";
            // 
            // headquartersLocationDataGridViewTextBoxColumn
            // 
            this.headquartersLocationDataGridViewTextBoxColumn.DataPropertyName = "HeadquartersLocation";
            this.headquartersLocationDataGridViewTextBoxColumn.HeaderText = "本社所在地";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1292, 408);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1284, 374);
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
            this.tabPage2.Size = new System.Drawing.Size(1284, 374);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 528);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1292, 134);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "詳細";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(353, 26);
            this.textBox3.MaxLength = 0;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(609, 27);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 26);
            this.textBox2.MaxLength = 0;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(263, 27);
            this.textBox2.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(13, 59);
            this.textBox4.MaxLength = 0;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(94, 27);
            this.textBox4.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 26);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(65, 27);
            this.textBox1.TabIndex = 3;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 674);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListForm";
            this.Text = "一覧";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEntityBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource listEntityBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnUpDown;
        private System.Windows.Forms.Button btn5UpDown;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtClosingMonth;
        private System.Windows.Forms.Label lblClosingMonth;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Label lblStockCode;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMarketName;
    }
}