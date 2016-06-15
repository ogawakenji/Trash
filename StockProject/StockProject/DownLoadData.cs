using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject
{
    public partial class DownLoadData : Form
    {
        public DownLoadData()
        {
            InitializeComponent();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            int stockCode = int.Parse(txtStockCode.Text);
             
            this.GetData(stockCode );

        }

        private async void GetData(int stockCode )
        {
            this.btnDownLoad.Enabled = false;
            this.lblStatus.Text = "データ取得開始・・・";


            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();
            List<Utility.ProfileEntity > listProfile = new List<Utility.ProfileEntity>();

            await Task.Delay(1000);

            this.lblStatus.Text = "株価取得開始・・・";

            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                listStockPrice = finance.GetStockPriceEntityList(stockCode);
            });

            this.lblStatus.Text = "株価取得終了・・・";

            await Task.Delay(1000);

            this.lblStatus.Text = "企業情報開始・・・";

            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                listProfile = finance.GetProfileEntityList (stockCode);
            });

            this.lblStatus.Text = "企業情報終了・・・";

            await Task.Delay(1000);

            this.lblStatus.Text = "データ取得終了・・・";

            this.btnDownLoad.Enabled = true;
            this.btnDownLoad.Focus();


        }

    }
}
