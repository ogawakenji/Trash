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
    public partial class ChartForm : Form
    {

        private List<Utility.StockPriceProfile> _listStockData;
         


        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("       p.StockCode ");
            sb.AppendLine("     , p.CompanyName ");
            sb.AppendLine("     , p.IndustriesCategory ");
            sb.AppendLine("     , p.MarketName ");
            sb.AppendLine("     , p.ClosingMonth ");
            sb.AppendLine("     , s.StockDate ");
            sb.AppendLine("     , s.OpeningPrice ");
            sb.AppendLine("     , s.LowPrice ");
            sb.AppendLine("     , s.HighPrice ");
            sb.AppendLine("     , s.ClosingPrice ");
            sb.AppendLine("     , s.TradeVolume ");
            sb.AppendLine("  FROM  ");
            sb.AppendLine("       stockprice s ");
            sb.AppendLine(" INNER JOIN profile p ");
            sb.AppendLine("    ON s.StockCode = p.StockCode ");
            sb.AppendLine(" WHERE s.StockDate >= :BeginDate ");
            sb.AppendLine(" ORDER BY  ");
            sb.AppendLine("       s.StockCode ");
            sb.AppendLine("     , s.StockDate ");


            _listStockData = new List<Utility.StockPriceProfile>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // データを取得してインスタンス変数に保持
                _listStockData = db.DBSelect<Utility.StockPriceProfile>(sb.ToString(), new { BeginDate = DateTime.Now.AddMonths(-3) });
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            //CreateStockChart(GetStockPriceList(int.Parse(txtStockCode.Text)));

        }


        #region 株価チャート作成
        private void CreateStockChart(List<StockPriceEntity> list)
        {
            this.chartStock1.Series.Clear();
            this.chartStock1.Legends.Clear();
            this.chartStock1.ChartAreas.Clear();

            // データ無い場合は処理終了
            if (list.Count == 0) return;

            // ----------------------------------------------------------------------
            Series series = new Series();
            series.Name = "株価チャート";

            Legend legend = new Legend();
            //legend.Name = this.txtStockCode.Text;
            legend.Alignment = StringAlignment.Near;


            // Seriesの設定
            series.ChartType = SeriesChartType.Candlestick;     //ローソク足チャート
            series.XValueType = ChartValueType.Date;
            series.YValueType = ChartValueType.Int64;
            series.IsVisibleInLegend = false;
            series.SetCustomProperty("PriceUpColor", "Orange");
            series.SetCustomProperty("PriceDownColor", "SkyBlue");

            // ----------------------------------------------------------------------
            ChartArea area = new ChartArea();
            area.Name = "ChartArea1";
            area.Visible = true;
            var minPrice = (from q in list
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;


            this.chartStock1.Series.Add(series);
            this.chartStock1.ChartAreas.Add(area);
            this.chartStock1.Legends.Add(legend);

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

                dp.LabelToolTip = sb.ToString();
                dp.ToolTip = sb.ToString();

                this.chartStock1.Series[0].Points.Add(dp);

            }


            // 出来高チャート追加
            Series series2 = new Series();
            series2.Name = "出来高チャート";
            series2.ChartType = SeriesChartType.Column;     //縦棒グラフ
            series2.XValueType = ChartValueType.Date;
            series2.YValueType = ChartValueType.Int64;
            series2.IsVisibleInLegend = false;
            series2.ChartArea = "ChartArea1";
            series2.YAxisType = AxisType.Secondary;


            ChartArea area2 = new ChartArea();
            area2.Name = "ChartArea2";
            //area2.Name = "ChartArea1";
            area2.Visible = true;

            foreach (var r in query)
            {
                dp = new DataPoint();
                dp.SetValueXY(r.StockDate,r.TradeVolume);
                dp.IsValueShownAsLabel = false;
                sb = new StringBuilder();
                sb.AppendLine(string.Format("日付：{0}", r.StockDate.ToString("yyyy/MM/dd")));
                sb.AppendLine(string.Format("出来高：{0:N0}", r.TradeVolume));
                dp.LabelToolTip = sb.ToString();
                dp.ToolTip = sb.ToString();

                series2.Points.Add(dp);

            }

            this.chartStock1.Series.Add(series2);
            this.chartStock1.ChartAreas.Add(area2);

            //chartStock.ChartAreas["ChartArea1"].AlignWithChartArea = "ChartArea2";

            chartStock1.ChartAreas["ChartArea2"].AlignWithChartArea = "ChartArea1";



        }
        #endregion

        private List<StockPriceEntity> GetStockPriceList(int stockCode)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                return db.DBSelect<Utility.StockPriceEntity>("SELECT * FROM stockprice WHERE StockCode = :StockCode",new { StockCode = stockCode });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart chart;
            for (int i = 1;i>20;i++)
            {
                chart = (Chart)this.Controls.Find("chartStock" + i, true)[0];
                chart.Series.Clear();
                chart.Legends.Clear();
                chart.ChartAreas.Clear();
                chart.Titles.Clear();
            }

            var query = (from q in _listStockData
                        select q.StockCode).Distinct();

            decimal cnt = 1;

            foreach (decimal code in query)
            {
                if (cnt == 21)
                {
                    break ;
                }
                this.CreateChart((Chart)this.Controls.Find("chartStock" + cnt, true)[0], code);
                cnt++;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chart chart;
            for (int i = 1; i > 20; i++)
            {
                chart = (Chart)this.Controls.Find("chartStock" + i, true)[0];
                chart.Series.Clear();
                chart.Legends.Clear();
                chart.ChartAreas.Clear();
                chart.Titles.Clear();
            }

            decimal stockCode = 0;
            if (decimal.TryParse(chartStock20.Titles[0].Text.PadLeft(4,'0').Substring(0,4), out stockCode))     
            {

            }

            var query = (from q in _listStockData
                         where q.StockCode > stockCode
                         select q.StockCode).Distinct();

            decimal cnt = 1;

            foreach (decimal code in query)
            {
                if (cnt == 21)
                {
                    break;
                }
                this.CreateChart((Chart)this.Controls.Find("chartStock" + cnt, true)[0], code);
                cnt++;
            }
        }

        private void CreateChart(Chart ch,decimal stockCode)
        {
            ch.Series.Clear();
            ch.Legends.Clear();
            ch.ChartAreas.Clear();
            ch.Titles.Clear();

            string company = "";
            // データ無い場合は処理終了
            var query = from q in _listStockData
                        where q.StockCode == stockCode
                        select q;


            if (query.Count() == 0) return;

            // ----------------------------------------------------------------------
            Series series = new Series();
            series.Name = stockCode.ToString();

            Legend legend = new Legend();
            //legend.Name = stockCode.ToString() ;
            legend.Alignment = StringAlignment.Near;
            //legend.Title = stockCode.ToString();

            // Seriesの設定
            series.ChartType = SeriesChartType.Candlestick;     //ローソク足チャート
            series.XValueType = ChartValueType.Date;
            series.YValueType = ChartValueType.Int64;
            series.IsVisibleInLegend = false;
            series.SetCustomProperty("PriceUpColor", "Orange");
            series.SetCustomProperty("PriceDownColor", "SkyBlue");

            

            // ----------------------------------------------------------------------
            ChartArea area = new ChartArea();
            area.Name = "ChartArea1";
            area.Visible = true;
            var minPrice = (from q in _listStockData
                            where q.StockCode == stockCode
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;


            ch.Series.Add(series);
            ch.ChartAreas.Add(area);
            ch.Legends.Add(legend);

            var price = from q in _listStockData
                        where q.StockCode == stockCode
                        select q;

            DataPoint dp;
            StringBuilder sb;
            foreach (var r in price)
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

                dp.LabelToolTip = sb.ToString();
                dp.ToolTip = sb.ToString();

                ch.Series[0].Points.Add(dp);
                company = r.CompanyName;
            }

            ch.Titles.Add(stockCode.ToString() + company);



            //// 出来高チャート追加
            //Series series2 = new Series();
            //series2.Name = "出来高チャート";
            //series2.ChartType = SeriesChartType.Column;     //縦棒グラフ
            //series2.XValueType = ChartValueType.Date;
            //series2.YValueType = ChartValueType.Int64;
            //series2.IsVisibleInLegend = false;
            //series2.ChartArea = "ChartArea1";
            //series2.YAxisType = AxisType.Secondary;


            //ChartArea area2 = new ChartArea();
            //area2.Name = "ChartArea2";
            ////area2.Name = "ChartArea1";
            //area2.Visible = true;

            //foreach (var r in price)
            //{
            //    dp = new DataPoint();
            //    dp.SetValueXY(r.StockDate, r.TradeVolume);
            //    dp.IsValueShownAsLabel = false;
            //    sb = new StringBuilder();
            //    sb.AppendLine(string.Format("日付：{0}", r.StockDate.ToString("yyyy/MM/dd")));
            //    sb.AppendLine(string.Format("出来高：{0:N0}", r.TradeVolume));
            //    dp.LabelToolTip = sb.ToString();
            //    dp.ToolTip = sb.ToString();

            //    series2.Points.Add(dp);

            //}

            //ch.Series.Add(series2);
            //ch.ChartAreas.Add(area2);

            ////chartStock.ChartAreas["ChartArea1"].AlignWithChartArea = "ChartArea2";

            //chartStock1.ChartAreas["ChartArea2"].AlignWithChartArea = "ChartArea1";
        }

        
    }
}
