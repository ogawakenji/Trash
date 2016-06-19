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


            if (listStockPrice.Count == 0)
            {
                this.lblStatus.Text = "データが取得できません。中断しました。";
                this.btnDownLoad.Enabled = true;
                this.btnDownLoad.Focus();
                return;
            }


            this.lblStatus.Text = "企業情報開始・・・";

            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                listProfile = finance.GetProfileEntityList (stockCode);
            });

            this.lblStatus.Text = "企業情報終了・・・";

            await Task.Delay(1000);

            this.lblStatus.Text = "データ取得終了・・・";


            // stockprice登録
            registerStockPrice(listStockPrice);

            // profile登録
            registerProfile(listProfile);

            this.btnDownLoad.Enabled = true;
            this.btnDownLoad.Focus();


        }

        #region 登録stockprice
        private void registerStockPrice(List<Utility.StockPriceEntity> listStockPrice)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                string deleteSql = @"DELETE FROM stockprice 
                                     WHERE StockCode = :StockCode 
                                       AND StockDate BETWEEN :StockDateFrom AND :StockDateTo 
                                    ";


                DateTime StockDateFrom = listStockPrice.Min(stock => stock.StockDate);
                DateTime StockDateTo = listStockPrice.Max(stock => stock.StockDate);


                db.DBInsert(deleteSql, new { StockCode = listStockPrice.Min(stock => stock.StockCode), StockDateFrom = StockDateFrom, StockDateTo = StockDateTo });

                string insertSql = @"INSERT INTO stockprice
                                    ( 
                                      StockCode             
                                     ,CompanyName           
                                     ,StockDate             
                                     ,OpeningPrice          
                                     ,HighPrice             
                                     ,LowPrice              
                                     ,ClosingPrice          
                                     ,TradeVolume           
                                     ,AdjustmentClosingPrice
                                    ) VALUES (
                                      :StockCode             
                                     ,:CompanyName           
                                     ,:StockDate             
                                     ,:OpeningPrice          
                                     ,:HighPrice             
                                     ,:LowPrice              
                                     ,:ClosingPrice          
                                     ,:TradeVolume           
                                     ,:AdjustmentClosingPrice
                                    )";

                db.DBInsert(insertSql, listStockPrice);

            }

        }
        #endregion

        #region 登録profile
        private void registerProfile(List<Utility.ProfileEntity> listProfile)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                string deleteSql = @"DELETE FROM profile 
                                     WHERE StockCode = :StockCode 
                                    ";


                db.DBInsert(deleteSql, new { StockCode = listProfile.Min(stock => stock.StockCode) });

                string insertSql = @"INSERT INTO profile
                                    ( 
                                      StockCode
                                     ,CompanyName
                                     ,Feature
                                     ,ConcatenationBusiness
                                     ,HeadquartersLocation
                                     ,IndustriesCategory
                                     ,FoundationDate
                                     ,MarketName
                                     ,ListedDate
                                     ,ClosingMonth
                                     ,UnitShares 
                                     ,EmployeeNumberSingle
                                     ,EmployeeNumberConcatenation
                                     ,AvarageAnnualIncome
                                    ) VALUES (
                                      :StockCode
                                     ,:CompanyName
                                     ,:Feature
                                     ,:ConcatenationBusiness
                                     ,:HeadquartersLocation
                                     ,:IndustriesCategory
                                     ,:FoundationDate
                                     ,:MarketName
                                     ,:ListedDate
                                     ,:ClosingMonth
                                     ,:UnitShares 
                                     ,:EmployeeNumberSingle
                                     ,:EmployeeNumberConcatenation
                                     ,:AvarageAnnualIncome
                                    )";

                db.DBInsert(insertSql, listProfile);

            }

        }
        #endregion



    }
}
