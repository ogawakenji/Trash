﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {

            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                #region stockpriceテーブル

                // テーブルを作成
                List<decimal> tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'stockprice'");

                if (tblLst[0] >= 0){ db.DBExecuteSQL("DROP TABLE stockprice "); }

                string sql = @"create table stockprice
                                  (
                                    StockCode                NUMERIC
                                    ,CompanyName             TEXT
                                    ,StockDate               TEXT
                                    ,OpeningPrice            NUMERIC
                                    ,HighPrice               NUMERIC
                                    ,LowPrice                NUMERIC
                                    ,ClosingPrice            NUMERIC
                                    ,TradeVolume             NUMERIC
                                    ,AdjustmentClosingPrice  NUMERIC
                                  ) ";

                db.DBExecuteSQL(sql);

                #endregion

                #region dividendテーブル

                // テーブルを作成
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'dividend'");

                if (tblLst[0] > 0) {db.DBExecuteSQL("DROP TABLE dividend ");}

                sql = @"CREATE TABLE dividend
                                  (
                                     OrderNo                 NUMERIC
                                    ,StockCode               NUMERIC
                                    ,Market                  TEXT
                                    ,CompanyName             TEXT
                                    ,Dividend                NUMERIC
                                    ,DividendYield           NUMERIC
                                    ,DetailUrl               TEXT
                                  ) ";

                db.DBExecuteSQL(sql);

                #endregion

                #region profileテーブル

                // テーブルを作成
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'profile'");

                if (tblLst[0] > 0) { db.DBExecuteSQL("DROP TABLE profile "); }

                sql = @"CREATE TABLE profile
                        (
                           StockCode                   NUMERIC
                          ,CompanyName                 TEXT
                          ,Feature                     TEXT
                          ,ConcatenationBusiness       TEXT
                          ,HeadquartersLocation        TEXT
                          ,IndustriesCategory          TEXT
                          ,FoundationDate              TEXT
                          ,MarketName                  TEXT
                          ,ListedDate                  TEXT
                          ,ClosingMonth                NUMERIC
                          ,UnitShares                  NUMERIC
                          ,EmployeeNumberSingle        NUMERIC
                          ,EmployeeNumberConcatenation NUMERIC
                          ,AvarageAnnualIncome         NUMERIC
                        ) ";

                db.DBExecuteSQL(sql);

                #endregion

            }

            MessageBox.Show("テーブル作成完了");

        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            SampleAsync();
        }

        private async void SampleAsync()
        {
            // 非同期処理参考URL
            // http://qiita.com/Temarin_PITA/items/ff74d39ae1cfed89d1c5
            // http://qiita.com/shundroid/items/cd6764f2ed510377df2a
            // https://tocsworld.wordpress.com/2014/07/16/c-task%E3%81%AE%E3%82%AD%E3%82%BD/
            // ↓イメージは以下が一番つかみやすい？ 一旦UIスレッドでReturnして、別スレッドで処理してまたUIに戻る。コンパイラ頑張ってる！！
            // http://www.atmarkit.co.jp/fdotnet/chushin/masterasync_02/masterasync_02_01.html
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 


            this.btnTask.Text = "実行中";

            List<Utility.StockPriceEntity > list = new List<Utility.StockPriceEntity>();



            await Task.Run(() =>
            {
                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                list = finance.GetStockPriceEntityList(6178);
            });



            this.btnTask.Text = "完了";

            foreach (Utility.StockPriceEntity r in list)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(2000);
                });
                this.btnTask.Text = r.HighPrice.ToString();
            }

        }

    }
}
