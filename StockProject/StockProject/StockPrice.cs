using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utility;

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


                // チャート生成
                CreateStockChart(stockprice);


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

            // チャート生成
            CreateDollarYenChart(list);


        }


        #region 株価チャート作成
        private void CreateStockChart(List<StockPriceEntity> list)
        {
            this.chtStock.Series.Clear();
            this.chtStock.Legends.Clear();
            this.chtStock.ChartAreas.Clear();

            Series series = new Series();
            series.Name = "株価チャート";

            Legend legend = new Legend();
            legend.Name = this.txtStockCode.Text;

            series.ChartType = SeriesChartType.Candlestick;     //ローソク足チャート
            series.XValueType = ChartValueType.Date;
            series.YValueType = ChartValueType.Int64;
            series.IsVisibleInLegend = false;
            series.SetCustomProperty("PriceUpColor", "Orange");
            series.SetCustomProperty("PriceDownColor", "SkyBlue");

            ChartArea area = new ChartArea();
            area.Name = "エリア";
            area.Visible = true;
            var minPrice = (from q in list
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;

            this.chtStock.Series.Add(series);
            this.chtStock.ChartAreas.Add(area);
            this.chtStock.Legends.Add(legend);

            var query = from q in list
                        select q;

            DataPoint dp;
            StringBuilder sb;
            foreach (var r in query)
            {
                dp = new DataPoint();
                dp.SetValueXY(r.StockDate, r.HighPrice, r.LowPrice, r.OpeningPrice, r.ClosingPrice);
                dp.IsValueShownAsLabel = false;
                sb = new StringBuilder();
                sb.AppendLine(string.Format("日付：{0}", r.StockDate.ToString("yyyy/MM/dd")));
                sb.AppendLine(string.Format("始値：{0:N0}", r.OpeningPrice));
                sb.AppendLine(string.Format("安値：{0:N0}", r.LowPrice));
                sb.AppendLine(string.Format("高値：{0:N0}", r.HighPrice));
                sb.AppendLine(string.Format("終値：{0:N0}", r.ClosingPrice));

                dp.LabelToolTip = "";
                dp.ToolTip = sb.ToString();

                this.chtStock.Series[0].Points.Add(dp);

            }


        }
        #endregion

        #region ドル円チャート作成
        private void CreateDollarYenChart(List<DollarYenEntity> list)
        {
            this.chtDollarYen.Series.Clear();
            this.chtDollarYen.Legends.Clear();
            this.chtDollarYen.ChartAreas.Clear();

            Series series = new Series();
            series.Name = "ドル円チャート";

            Legend legend = new Legend();
            legend.Name = this.txtStockCode.Text;

            series.ChartType = SeriesChartType.Candlestick;     //ローソク足チャート
            series.XValueType = ChartValueType.Date;
            series.YValueType = ChartValueType.Int64;
            series.IsVisibleInLegend = false;
            series.SetCustomProperty("PriceUpColor", "Orange");
            series.SetCustomProperty("PriceDownColor", "SkyBlue");

            ChartArea area = new ChartArea();
            area.Name = "エリア";
            area.Visible = true;
            var minPrice = (from q in list
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;

            this.chtDollarYen.Series.Add(series);
            this.chtDollarYen.ChartAreas.Add(area);
            this.chtDollarYen.Legends.Add(legend);

            var query = from q in list
                        select q;

            DataPoint dp;
            StringBuilder sb;

            foreach (var r in query)
            {
                dp = new DataPoint();
                dp.SetValueXY(r.ExchangeDate, r.HighPrice, r.LowPrice, r.OpeningPrice, r.ClosingPrice);
                dp.IsValueShownAsLabel = false;
                sb = new StringBuilder();
                sb.AppendLine(string.Format("日付：{0}", r.ExchangeDate.ToString("yyyy/MM/dd")));
                sb.AppendLine(string.Format("始値：{0:N2}", r.OpeningPrice));
                sb.AppendLine(string.Format("安値：{0:N2}", r.LowPrice));
                sb.AppendLine(string.Format("高値：{0:N2}", r.HighPrice));
                sb.AppendLine(string.Format("終値：{0:N2}", r.ClosingPrice));
                dp.LabelToolTip = "";
                dp.ToolTip = sb.ToString();

                this.chtDollarYen.Series[0].Points.Add(dp);
            }


        }
        #endregion

    }

}
