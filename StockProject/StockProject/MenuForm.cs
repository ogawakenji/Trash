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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // sqliteのデータベースを確認し、存在しなければテーブルを作成する


        }

        // テーブルを作成する
        private void CreateTables()
        {
            // dividend 配当
            // dollaryen ドル／円
            // nikkeiaverage 日経平均
            // profile プロフィール
            // stockprice 株価
            string sql = "";
            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                // テーブルを検索
                List<decimal> tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'stockprice'");
                if (tblLst[0] == 0)
                {
                    // なければ作成
                    sql = @"CREATE TABLE stockprice
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
                                    ,primary key(StockCode,StockDate)
                                  ) ";
                    db.DBExecuteSQL(sql);
                }

                // テーブルを検索
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'dividend'");

                if (tblLst[0] ==  0)
                {
                    sql = @"CREATE TABLE dividend
                                  (
                                     OrderNo                 NUMERIC
                                    ,StockCode               NUMERIC
                                    ,Market                  TEXT
                                    ,CompanyName             TEXT
                                    ,Dividend                NUMERIC
                                    ,DividendYield           NUMERIC
                                    ,DetailUrl               TEXT
                                    ,primary key(StockCode)
                                  ) ";
                    db.DBExecuteSQL(sql);
                }

                // テーブルを検索
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'profile'");
                if (tblLst[0] == 0) {
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
                          ,primary key(StockCode)
                        ) ";

                    db.DBExecuteSQL(sql);
                }

                // テーブルを検索
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'dollaryen'");
                if (tblLst[0] == 0)
                {
                    sql = @"CREATE TABLE dollaryen
                        (
                           ExchangeDate   TEXT
                          ,OpeningPrice   NUMERIC
                          ,HighPrice      NUMERIC
                          ,LowPrice       NUMERIC
                          ,ClosingPrice   NUMERIC
                          ,primary key(ExchangeDate)
                        ) ";

                    db.DBExecuteSQL(sql);
                }

                // テーブルを検索
                tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'nikkeiaverage'");
                if (tblLst[0] == 0)
                {
                    sql = @"CREATE TABLE nikkeiaverage
                        (
                           StockDate      TEXT
                          ,OpeningPrice   NUMERIC
                          ,HighPrice      NUMERIC
                          ,LowPrice       NUMERIC
                          ,ClosingPrice   NUMERIC
                          ,primary key(StockDate)
                        ) ";
                    db.DBExecuteSQL(sql);
                }
            }

        }
    }
}
