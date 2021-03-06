﻿using System;
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

            //this.btnDefaultUpdate.Enabled = false;

            await UpdateDividend();

            await UpdateStockPriceAndProfile();

            //this.btnDefaultUpdate.Enabled = true;

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

                    db.DBExecuteSQL("DELETE FROM dividend WHERE StockCode NOT IN (SELECT TargetStockCode From targetcode) ");

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

            List<Utility.TargetEntity> targetCode;
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                targetCode = db.DBSelect<Utility.TargetEntity>("SELECT * FROM targetcode ORDER BY TargetStockCode ");

                db.DBUpdate("DELETE FROM profile ");
            }


            foreach (TargetEntity r in targetCode)
            {

                sw.Restart();

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listProfile = finance.GetProfileEntityList(r.TargetStockCode);
                });

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listStockPrice = finance.GetStockPriceEntityList(r.TargetStockCode);
                });

                await Task.Run(() =>
                {
                    using (Utility.DbUtil db = new Utility.DbUtil())
                    {
                        // 削除
                        db.DBUpdate("DELETE FROM profile WHERE StockCode = :StockCode ",new { StockCode = r.TargetStockCode });

                        var query = from q in listStockPrice
                                    where q.StockCode == r.TargetStockCode
                                    select q;

                        db.DBUpdate("DELETE FROM stockprice WHERE StockCode = :StockCode AND StockDate BETWEEN :BeginDate AND :EndDate ",
                                    new { StockCode = r.TargetStockCode, BeginDate = query.Min(stock => stock.StockDate) ,EndDate = query.Max(stock =>stock.StockDate )  });

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
                this.txtUpdateStatus.Text += r.TargetStockCode.ToString().PadLeft(4, '0')  + " データ更新 " + sw.Elapsed.ToString() + Environment.NewLine;
                this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
                this.txtUpdateStatus.ScrollToCaret();

            }

            this.txtUpdateStatus.Text += "企業情報取得・更新終了" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        private async Task UpdateStockCode()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            this.txtUpdateStatus.Text = "";
            this.txtUpdateStatus.Text += "証券コード取得開始" + Environment.NewLine;
            // 情報の取得
            List<StockPriceEntity> list = new List<StockPriceEntity>();
            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                list = finance.GetStockCodeList();
            });
            sw.Stop();
            this.txtUpdateStatus.Text += "証券コード取得終了 " + sw.Elapsed.ToString() + Environment.NewLine;

            sw.Restart();
            this.txtUpdateStatus.Text += "証券コード更新開始" + Environment.NewLine;
            await Task.Run(() =>
            {
                using (Utility.DbUtil db = new Utility.DbUtil())
                {
                    // 削除
                    db.DBExecuteSQL("DELETE FROM stockcode");
                    // 登録
                    string insertSql = @"INSERT INTO stockcode
                                    ( 
                                      StockCode           
                                    ) VALUES (            
                                      :StockCode           
                                    )";

                    db.DBInsert(insertSql, list);
                }
            });
            sw.Stop();
            this.txtUpdateStatus.Text += "証券コード更新終了 " + sw.Elapsed.ToString() + Environment.NewLine;

        }

        private async Task UpdateProfile()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "企業情報取得・更新開始" + Environment.NewLine;
            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();

            List<Utility.TargetEntity> targetCode;
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                targetCode = db.DBSelect<Utility.TargetEntity>("SELECT * FROM targetcode ORDER BY TargetStockCode ");

                db.DBUpdate("DELETE FROM profile ");
            }

            await Task.Run(() =>
            {
                using (Utility.DbUtil db = new Utility.DbUtil())
                {
                    // 全削除する
                    db.DBUpdate("DELETE FROM profile ");
                }
            });

            foreach (TargetEntity r in targetCode)
            {

                sw.Restart();
                await Task.Delay(1000);

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listProfile = finance.GetProfileEntityList(r.TargetStockCode);
                });

                await Task.Run(() =>
                {
                    using (Utility.DbUtil db = new Utility.DbUtil())
                    {

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

                    }
                });

                sw.Stop();
                this.txtUpdateStatus.Text += r.TargetStockCode.ToString().PadLeft(4, '0') + " データ更新 " + sw.Elapsed.ToString() + Environment.NewLine;
                this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
                this.txtUpdateStatus.ScrollToCaret();

            }

            this.txtUpdateStatus.Text += "企業情報取得・更新終了" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

            await Task.Run(() =>
            {
                using (Utility.DbUtil db = new Utility.DbUtil())
                {
                    // 全削除する
                    db.DBUpdate("DELETE FROM stockcode WHERE stockcode.StockCode NOT IN (SELECT StockCode FROM profile)");
                }
            });

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

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                db.DBUpdate("DELETE FROM stockcode ");
                db.DBUpdate("INSERT INTO stockcode (StockCode) SELECT TargetStockCode FROM targetcode ");
                db.DBUpdate("DELETE FROM stockprice ");

                listProfile = db.DBSelect<Utility.ProfileEntity>("SELECT * FROM profile ");

                listStock = db.DBSelect<StockPriceEntity>(@"SELECT 
                                                                  stockcode.StockCode
                                                                 ,ifnull(profile.CompanyName,'') CompanyName 
                                                            FROM stockcode 
                                                            LEFT JOIN profile ON stockcode.StockCode = profile.StockCode
                                                            ORDER BY stockcode.StockCode ");


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

        private async Task UpdateStockPrice(int months)
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "株価更新開始" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();
            List<Utility.StockPriceEntity> listStock = new List<Utility.StockPriceEntity>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                db.DBUpdate("DELETE FROM stockcode ");
                db.DBUpdate("INSERT INTO stockcode (StockCode) SELECT TargetStockCode FROM targetcode ");

                listProfile = db.DBSelect<Utility.ProfileEntity>("SELECT * FROM profile ");

                listStock = db.DBSelect<StockPriceEntity>(@"SELECT 
                                                                  stockcode.StockCode
                                                                 ,ifnull(profile.CompanyName,'') CompanyName 
                                                            FROM stockcode 
                                                            LEFT JOIN profile ON stockcode.StockCode = profile.StockCode
                                                            ORDER BY stockcode.StockCode ");


            }

            foreach (StockPriceEntity r in listStock)
            {

                sw.Restart();

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listStockPrice = finance.GetStockPriceEntityList(r.StockCode, months);
                });

                await Task.Run(() =>
                {
                    if (listStockPrice.Count == 0)
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

        }

        private async Task UpdateStockPriceTarget()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "株価更新開始" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();
            List<Utility.StockPriceEntity> listStock = new List<Utility.StockPriceEntity>();

            Utility.StockPriceEntity sp;
            int code;

            for (int line = 0; line < this.txtStockCodes.Lines.Length; line++)
            {
                if (int.TryParse(this.txtStockCodes.Lines[line], out code))
                {
                    sp = new Utility.StockPriceEntity();
                    sp.StockCode = code;
                    listStock.Add(sp);
                }
            }



            foreach (StockPriceEntity r in listStock)
            {

                sw.Restart();


                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    //listStockPrice = finance.GetStockPriceEntityList(r.StockCode,DateTime.Now.AddYears(-10).Date,DateTime.Now.Date);
                    listStockPrice = finance.GetStockPriceEntityList(r.StockCode, DateTime.Now.AddMonths(-60).Date, DateTime.Now.Date);
                });


                await Task.Run(() =>
                {
                    if (listStockPrice.Count == 0)
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
                this.txtUpdateStatus.Text += r.StockCode.ToString().PadLeft(4, '0')  + " データ更新 " + sw.Elapsed.ToString() + Environment.NewLine;
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


            this.txtUpdateStatus.Text += "日経平均・ドル／円更新終了" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


        }

        private async void btnDividend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("配当データ更新を実行しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnDividend.Enabled = false;

            await UpdateDividend();

            this.btnDividend.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        private async void btnStockCode_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("証券コード更新を実行しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnStockCode.Enabled = false;

            await UpdateStockCode();

            this.btnStockCode.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();

        }

        private async void btnProfile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("企業情報更新を実行しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnProfile.Enabled = false;

            await UpdateProfile();

            this.btnProfile.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();
        }

        private async void btnStockPriceUpdateTarget_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("株価を更新しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnStockPriceUpdateTarget.Enabled = false;

            // 株価更新
            await UpdateStockPriceTarget();

            this.btnStockPriceUpdateTarget.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();
        }

        private async void btnPrice10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("株価5年分を更新しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnStockPriceUpdate.Enabled = false;

            // 株価更新
            await UpdateStockPrice(60);

            this.btnStockPriceUpdate.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();
        }

        private async void btnPriceMinDate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("最小日付以降の株価を更新しますか？", "更新確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            this.btnStockPriceUpdate.Enabled = false;

            // 株価更新
            await UpdateStockPriceMinDate();

            this.btnStockPriceUpdate.Enabled = true;

            this.txtUpdateStatus.Text += "■■処理時間合計■■：" + sw.Elapsed.ToString() + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();
        }

        private async Task UpdateStockPriceMinDate()
        {
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            this.txtUpdateStatus.Text += "株価更新開始" + Environment.NewLine;
            this.txtUpdateStatus.SelectionStart = this.txtUpdateStatus.TextLength;
            this.txtUpdateStatus.ScrollToCaret();


            // 情報の取得
            List<Utility.ProfileEntity> listProfile = new List<Utility.ProfileEntity>();
            List<Utility.StockPriceEntity> listStockPrice = new List<Utility.StockPriceEntity>();
            List<Utility.StockPriceEntity> listStock = new List<Utility.StockPriceEntity>();
            List<Utility.StockPriceEntity> listTargetStockPrice = new List<Utility.StockPriceEntity>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                db.DBUpdate("DELETE FROM stockcode ");
                db.DBUpdate("INSERT INTO stockcode (StockCode) SELECT TargetStockCode FROM targetcode ");


                listTargetStockPrice = db.DBSelect<StockPriceEntity>(@"SELECT MIN(StockDate) StockDate FROM (
                                                                       SELECT StockCode,MAX(stockprice.StockDate) StockDate 
                                                                       FROM stockprice
                                                                       GROUP BY StockCode
                                                                       ) ");

                listStock = db.DBSelect<StockPriceEntity>(@"SELECT 
                                                                  stockcode.StockCode
                                                                 ,ifnull(profile.CompanyName,'') CompanyName 
                                                            FROM stockcode 
                                                            LEFT JOIN profile ON stockcode.StockCode = profile.StockCode
                                                            ORDER BY stockcode.StockCode ");


            }

            foreach (StockPriceEntity r in listStock)
            {

                sw.Restart();

                await Task.Run(() =>
                {
                    Utility.FinanceUtil finance = new Utility.FinanceUtil();
                    listStockPrice = finance.GetStockPriceEntityList(r.StockCode, listTargetStockPrice.First().StockDate ,DateTime.Now .Date);
                });

                await Task.Run(() =>
                {
                    if (listStockPrice.Count == 0)
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

        }

    }
}
