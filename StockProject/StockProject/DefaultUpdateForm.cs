using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Utility;



namespace StockProject
{
    public partial class DefaultUpdateForm : Form
    {
        public DefaultUpdateForm()
        {
            InitializeComponent();
        }

        // 初期データ更新ボタンクリック
        private async void btnDefaultUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("初期データ更新を実行しますか？","更新確認",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnDefaultUpdate.Enabled = false;

            await UpdateDividend();

            await UpdateStockPriceAndProfile();

            this.btnDefaultUpdate.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() +  Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        private  async Task UpdateDividend()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            this.txtUpdateStatus.Text = "";
            this.txtUpdateStatus.Text += "配当利回り取得開始" + Environment.NewLine;
            // 情報の取得
            List<Utility.DividendEntity> list = new List<Utility.DividendEntity>();
            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                list = finance.GetDividendEntityList();
            });
            sw.Stop();
            this.txtUpdateStatus.Text += "配当利回り取得終了 " + sw.Elapsed.ToString() + Environment.NewLine;

            sw.Restart();
            this.txtUpdateStatus.Text += "配当利回り更新開始" + Environment.NewLine ;
            await Task.Run(() =>
            {
                using (Utility.DbUtil db = new Utility.DbUtil())
                {
                    // 削除
                    db.DBExecuteSQL("DELETE FROM dividend");
                    // 登録
                    string insertSql = @"INSERT INTO dividend
                                    ( 
                                      OrderNo             
                                     ,StockCode           
                                     ,Market             
                                     ,CompanyName          
                                     ,Dividend             
                                     ,DividendYield              
                                     ,DetailUrl
                                    ) VALUES (
                                      :OrderNo             
                                     ,:StockCode           
                                     ,:Market             
                                     ,:CompanyName          
                                     ,:Dividend             
                                     ,:DividendYield              
                                     ,:DetailUrl
                                    )";

                    db.DBInsert(insertSql, list);
                }
            });
            sw.Stop();
            this.txtUpdateStatus.Text += "配当利回り更新終了 " + sw.Elapsed.ToString() + Environment.NewLine;

        }

        private async Task UpdateStockPriceAndProfile()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "企業情報取得・更新開始" + Environment.NewLine;
            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();

            List<Utility.DividendEntity> dividend;
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                dividend = db.DBSelect<Utility.DividendEntity>("SELECT * FROM dividend ORDER BY StockCode ");
            }


            foreach (DividendEntity r in dividend)
            {

                sw.Restart();

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listProfile = finance.GetProfileEntityList(r.StockCode);
                });

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listStockPrice = finance.GetStockPriceEntityList(r.StockCode);
                });


                await Task.Run(() =>
                {
                    using (Utility.DbUtil db = new Utility.DbUtil())
                    {
                        // 削除
                        db.DBUpdate("DELETE FROM profile WHERE StockCode = :StockCode ",new { StockCode = r.StockCode });

                        var query = from q in listStockPrice
                                    where q.StockCode == r.StockCode 
                                    select q;

                        db.DBUpdate("DELETE FROM stockprice WHERE StockCode = :StockCode AND StockDate BETWEEN :BeginDate AND :EndDate ",
                                    new { StockCode = r.StockCode, BeginDate = query.Min(stock => stock.StockDate) ,EndDate = query.Max(stock =>stock.StockDate )  });

                        // 登録
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


                        string insertSql2 = @"INSERT INTO stockprice
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

                        db.DBInsert(insertSql2, listStockPrice);

                    }
                });

                sw.Stop();
                this.txtUpdateStatus.Text += r.StockCode.ToString().PadLeft(4, '0') + r.CompanyName + " データ更新 " + sw.Elapsed.ToString() + Environment.NewLine;
                this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
                this.txtUpdateStatus.ScrollToCaret();

            }

            this.txtUpdateStatus.Text += "企業情報取得・更新終了" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        // 株価更新ボタンクリック
        private async void btnStockPriceUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("株価を更新しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnStockPriceUpdate.Enabled = false;

            // 株価更新
            await UpdateStockPrice();

            this.btnStockPriceUpdate.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        private async Task UpdateStockPrice()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "株価更新開始" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();
            List<Utility.StockPriceEntity> listStock = new List<Utility.StockPriceEntity>();

            List<Utility.DividendEntity> dividend;
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                listProfile = db.DBSelect<Utility.ProfileEntity>("SELECT * FROM profile ");

                listStock = db.DBSelect<StockPriceEntity>(@"SELECT 
                                                                  StockCode
                                                                 ,MAX(CompanyName) CompanyName 
                                                                 ,datetime(MAX(StockDate),'+1 days') StockDate
                                                            FROM StockPrice
                                                            GROUP BY StockCode 
                                                            ORDER BY StockCode ");


            }


            foreach (StockPriceEntity r in listStock)
            {

                sw.Restart();

               
                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listStockPrice = finance.GetStockPriceEntityList(r.StockCode);
                });


                await Task.Run(() =>
                {
                    if (listStockPrice .Count == 0 )
                    {
                        // 株価取得できない場合はスルー
                    }
                    else
                    {

                        using (Utility.DbUtil db = new Utility.DbUtil())
                        {
                            // 削除
                            var query = from q in listStockPrice
                                        where q.StockCode == r.StockCode
                                        select q;

                            db.DBUpdate("DELETE FROM stockprice WHERE StockCode = :StockCode AND StockDate BETWEEN :BeginDate AND :EndDate ",
                                        new { StockCode = r.StockCode, BeginDate = query.Min(stock => stock.StockDate), EndDate = query.Max(stock => stock.StockDate) });

                            // 登録
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

                });

                sw.Stop();
                this.txtUpdateStatus.Text += r.StockCode.ToString().PadLeft(4, '0') + r.CompanyName + " データ更新 " + sw.Elapsed.ToString() + Environment.NewLine;
                this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
                this.txtUpdateStatus.ScrollToCaret();

            }

            this.txtUpdateStatus.Text += "株価更新終了" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


            // 日経平均、ドル円
            sw.Restart();

            List<DollarYenEntity> listDY = new List<DollarYenEntity>();
            List<NikkeiAverageEntity> listN = new List<NikkeiAverageEntity>();


            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                listDY = finance.GetDollarYenEntityList();
                listN = finance.GetNikkeiAverageEntityList();
            });


            await Task.Run(() =>
            {
                if (listDY.Count == 0)
                {
                    // ドル円が取得できない場合はスルー
                }
                else
                {

                    using (Utility.DbUtil db = new Utility.DbUtil())
                    {
                        // 削除
                        var query = from q in listDY
                                    select q;

                        db.DBUpdate("DELETE FROM dollaryen WHERE ExchangeDate BETWEEN :BeginDate AND :EndDate ",
                                    new { BeginDate = query.Min(dollerYen => dollerYen.ExchangeDate), EndDate = query.Max(dollerYen => dollerYen.ExchangeDate) });

                        // 登録
                        string insertSql = @"INSERT INTO dollaryen
                                        ( 
                                          ExchangeDate             
                                         ,OpeningPrice           
                                         ,HighPrice             
                                         ,LowPrice          
                                         ,ClosingPrice             
                                        ) VALUES (
                                          :ExchangeDate             
                                         ,:OpeningPrice           
                                         ,:HighPrice             
                                         ,:LowPrice          
                                         ,:ClosingPrice             
                                        )";

                        db.DBInsert(insertSql, listDY);

                    }
                }

                if (listN.Count == 0)
                {
                    // 日経平均が取得できない場合はスルー
                }
                else
                {

                    using (Utility.DbUtil db = new Utility.DbUtil())
                    {
                        // 削除
                        var query = from q in listN
                                    select q;

                        db.DBUpdate("DELETE FROM nikkeiaverage WHERE StockDate BETWEEN :BeginDate AND :EndDate ",
                                    new { BeginDate = query.Min(nikkei => nikkei.StockDate), EndDate = query.Max(nikkei => nikkei.StockDate) });

                        // 登録
                        string insertSql = @"INSERT INTO nikkeiaverage
                                        ( 
                                          StockDate             
                                         ,OpeningPrice           
                                         ,HighPrice             
                                         ,LowPrice          
                                         ,ClosingPrice             
                                        ) VALUES (
                                          :StockDate             
                                         ,:OpeningPrice           
                                         ,:HighPrice             
                                         ,:LowPrice          
                                         ,:ClosingPrice             
                                        )";

                        db.DBInsert(insertSql, listN);

                    }
                }

            });


            this.txtUpdateStatus.Text += "日経平均・ドル／円更新終了"  + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


        }
    }
}
