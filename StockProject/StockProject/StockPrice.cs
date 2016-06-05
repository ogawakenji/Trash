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
    public partial class StockPrice : Form
    {
        public StockPrice()
        {
            InitializeComponent();
        }

        private void btnStockPrice_Click(object sender, EventArgs e)
        {

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // テーブルを作成
                List<decimal> tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'stockprice'");

                if (tblLst[0] >= 0)
                {

                    db.DBExecuteSQL("DROP TABLE stockprice ");

                }

                string sql = @"create table stockprice
                                  (
                                    StockCode               NUMERIC
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


                List<Utility.StockPriceEntity> list = new List<Utility.StockPriceEntity>();

                Utility.FinanceUtil finance = new Utility.FinanceUtil();
                list = finance.GetStockPriceEntityList(Convert.ToInt32(txtStockCode.Text), DateTime.Now.AddMonths(-3), DateTime.Now);

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

                db.DBInsert(insertSql, list);

                List<Utility.StockPriceEntity> stockprice = db.DBSelect<Utility.StockPriceEntity>("SELECT * FROM stockprice ");

                this.dgvStockPrice.DataSource = stockprice;



            }


        }

        private void btnDividend_Click(object sender, EventArgs e)
        {


            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // テーブルを作成
                List<decimal> tblLst = db.DBSelect<decimal>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'dividend'");

                if (tblLst[0] > 0)
                {

                    db.DBExecuteSQL("DROP TABLE dividend ");

                }

                string sql = @"CREATE TABLE dividend
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


                List<Utility.DividendEntity> list = new List<Utility.DividendEntity>();

                Utility.FinanceUtil finance = new Utility.FinanceUtil();

                list = finance.GetDividendEntityList();

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

                List<Utility.DividendEntity> dividend = db.DBSelect<Utility.DividendEntity>("SELECT * FROM dividend ");

                this.dgvStockPrice.DataSource = dividend;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Utility.DollarYenEntity> list = new List<Utility.DollarYenEntity>();

            Utility.FinanceUtil finance = new Utility.FinanceUtil();

            list = finance.GetDollarYenEntityList();

        }
    }

}
