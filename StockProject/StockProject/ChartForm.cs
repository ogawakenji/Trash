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
        public ChartForm()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            CreateStockChart(GetStockPriceList(int.Parse(txtStockCode.Text)));

        }


        #region 株価チャート作成
        private void CreateStockChart(List<StockPriceEntity> list)
        {
            this.chartStock.Series.Clear();
            this.chartStock.Legends.Clear();
            this.chartStock.ChartAreas.Clear();

            // データ無い場合は処理終了
            if (list.Count == 0) return;

            // ----------------------------------------------------------------------
            Series series = new Series();
            series.Name = "株価チャート";

            Legend legend = new Legend();
            legend.Name = this.txtStockCode.Text;
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


            this.chartStock.Series.Add(series);
            this.chartStock.ChartAreas.Add(area);
            this.chartStock.Legends.Add(legend);

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

                this.chartStock.Series[0].Points.Add(dp);

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

            this.chartStock.Series.Add(series2);
            this.chartStock.ChartAreas.Add(area2);

            //chartStock.ChartAreas["ChartArea1"].AlignWithChartArea = "ChartArea2";

            chartStock.ChartAreas["ChartArea2"].AlignWithChartArea = "ChartArea1";



        }
        #endregion

        private List<StockPriceEntity> GetStockPriceList(int stockCode)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                return db.DBSelect<Utility.StockPriceEntity>("SELECT * FROM stockprice WHERE StockCode = :StockCode",new { StockCode = stockCode });
            }
        }





    }
}
