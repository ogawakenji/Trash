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
    public partial class Dividend : Form
    {
        public Dividend()
        {
            InitializeComponent();
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

            }

            // 配当データをSqliteから取得
            this.dgvDividend.DataSource = GetDividendList();

        }

        private void Dividend_Load(object sender, EventArgs e)
        {
            // 配当データをSqliteから取得
            this.dgvDividend.DataSource = GetDividendList();
        }


        private List<Utility.DividendEntity> GetDividendList()
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                return  db.DBSelect<Utility.DividendEntity>("SELECT * FROM dividend ");
            }
        }

    }
}
