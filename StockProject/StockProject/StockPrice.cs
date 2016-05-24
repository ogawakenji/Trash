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
                List<CntClass> tblLst = db.DBSelect<CntClass>("SELECT COUNT(*) CNT FROM sqlite_master WHERE type = 'table' AND name = 'stockprice'");

                if (tblLst[0].CNT  ==  0)
                {
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
         
                }

                db.DBExecuteSQL("DELETE FROM stockprice ");


                List<Utility.StockPriceEntity> stockprice = db.DBSelect<Utility.StockPriceEntity>("SELECT * FROM stockprice ");

                this.dgvStockPrice.DataSource = stockprice;



            }






            List<Utility.StockPriceEntity> list = new List<Utility.StockPriceEntity>();

            Utility.FinanceUtil finance = new Utility.FinanceUtil();
            list = finance.GetStockPriceEntityList(Convert.ToInt32(txtStockCode.Text));




        }
    }

    public class CntClass
    {
        public decimal CNT { get; set; }
    }
}
