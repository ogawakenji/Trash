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

namespace StockProject
{
    public partial class DisplayChartForm : Form
    {
        private List<Utility.StockPriceProfile> _ListData;
        private List<Utility.NikkeiAverageEntity> _ListNikkei;
        private List<Utility.DollarYenEntity> _ListDY;
        private List<Utility.StockPriceProfile> _List1Year;

        private int _currentPageNum;

        public DisplayChartForm()
        {
            InitializeComponent();
        }

        private void DisplayChartForm_Load(object sender, EventArgs e)
        {
            _ListData = new List<Utility.StockPriceProfile>();
            _ListNikkei = new List<Utility.NikkeiAverageEntity>();
            _ListDY = new List<Utility.DollarYenEntity>();

            _List1Year = new List<Utility.StockPriceProfile>();
            Utility.StockPriceUtil util = new Utility.StockPriceUtil();
            _List1Year = util.GetListStockPriceProfile(DateTime.Now.AddMonths(-3).Date, DateTime.Now.Date);


        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Utility.StockPriceUtil util = new Utility.StockPriceUtil();
            _ListData = util.GetListStockPriceProfile(DateTime.Now.AddMonths(-3).Date, DateTime.Now.Date);
            _ListNikkei = util.GetListNikkeiAverage(DateTime.Now.AddMonths(-3).Date, DateTime.Now.Date);
            _ListDY = util.GetListDollarYenEntity(DateTime.Now.AddMonths(-3).Date, DateTime.Now.Date);

            _currentPageNum = 1;
            // 1ページ目を表示
            this.Paging(_currentPageNum);

            this.CreateNikkeiChart(this.chartNikkei);
            this.CreateDollarYenChart (this.chartDollarYen);


        }

        private void Paging(int pageNum)
        {
            int pageSize = 50;

            var query = (from q in _ListData
                         orderby q.StockCode ascending
                         select q.StockCode).Distinct().Skip(pageSize * (pageNum - 1)).Take(pageSize);


            decimal cnt = 1;

            if (query.Count() == 0) return;

            Chart chart;
            for (int i = 1; i < 51; i++)
            {
                chart = (Chart)this.Controls.Find("chart" + i, true)[0];
                chart.Series.Clear();
                chart.Legends.Clear();
                chart.ChartAreas.Clear();
                chart.Titles.Clear();
            }


            foreach (decimal code in query)
            {
                if (cnt == 51)
                {
                    break;
                }
                this.CreateChart((Chart)this.Controls.Find("chart" + cnt, true)[0], code);
                cnt++;
            }


        }



        private void CreateChart(Chart ch, decimal stockCode)
        {
            ch.Series.Clear();
            ch.Legends.Clear();
            ch.ChartAreas.Clear();
            ch.Titles.Clear();
            //ch.MinimumSize = new Size(250, 190);
            //ch.Width = 250;
            //ch.Height = 190;

            string company = "";
            // データ無い場合は処理終了
            var query = from q in _ListData 
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
            var minPrice = (from q in _ListData
                            where q.StockCode == stockCode
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;
            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition.Width = 100;
            area.InnerPlotPosition.Height = 82;
            area.InnerPlotPosition.X = 10;
            area.InnerPlotPosition.Y = 1;
            area.AxisX.LabelStyle.Format = "MM/dd";
            //area.AxisX.LabelStyle.Font = new Font("MSゴシック", 8);



            ch.Series.Add(series);
            ch.ChartAreas.Add(area);
            ch.Legends.Add(legend);

            var price = from q in _ListData
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

        private void CreateNikkeiChart(Chart ch)
        {
            ch.Series.Clear();
            ch.Legends.Clear();
            ch.ChartAreas.Clear();
            ch.Titles.Clear();

            string company = "";
            // データ無い場合は処理終了
            var query = from q in _ListNikkei
                        select q;


            if (query.Count() == 0) return;

            // ----------------------------------------------------------------------
            Series series = new Series();
            series.Name = "日経平均";

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
            var minPrice = (from q in _ListNikkei
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;
            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition.Width = 100;
            area.InnerPlotPosition.Height = 80;
            area.InnerPlotPosition.X = 15;
            area.InnerPlotPosition.Y = 0;


            ch.Series.Add(series);
            ch.ChartAreas.Add(area);
            ch.Legends.Add(legend);

            var price = from q in _ListNikkei
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
            }

            ch.Titles.Add("日経平均");
        }

        private void CreateDollarYenChart(Chart ch)
        {
            ch.Series.Clear();
            ch.Legends.Clear();
            ch.ChartAreas.Clear();
            ch.Titles.Clear();

            string company = "";
            // データ無い場合は処理終了
            var query = from q in _ListDY
                        select q;


            if (query.Count() == 0) return;

            // ----------------------------------------------------------------------
            Series series = new Series();
            series.Name = "ドル／円";

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
            var minPrice = (from q in _ListDY
                            select q.LowPrice).Min();

            area.AxisY.Minimum = (double)minPrice;
            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition.Width = 100;
            area.InnerPlotPosition.Height = 80;
            area.InnerPlotPosition.X = 15;
            area.InnerPlotPosition.Y = 0;


            ch.Series.Add(series);
            ch.ChartAreas.Add(area);
            ch.Legends.Add(legend);

            var price = from q in _ListDY
                        select q;

            DataPoint dp;
            StringBuilder sb;
            foreach (var r in price)
            {
                dp = new DataPoint();
                dp.SetValueXY(r.ExchangeDate, r.HighPrice, r.LowPrice, r.OpeningPrice, r.ClosingPrice);
                dp.IsValueShownAsLabel = false;

                sb = new StringBuilder();
                sb.AppendLine(string.Format("日付：{0}", r.ExchangeDate.ToString("yyyy/MM/dd")));
                sb.AppendLine(string.Format("始値：{0:N0}", r.OpeningPrice));
                sb.AppendLine(string.Format("安値：{0:N0}", r.LowPrice));
                sb.AppendLine(string.Format("高値：{0:N0}", r.HighPrice));
                sb.AppendLine(string.Format("終値：{0:N0}", r.ClosingPrice));

                dp.LabelToolTip = sb.ToString();
                dp.ToolTip = sb.ToString();

                ch.Series[0].Points.Add(dp);
            }

            ch.Titles.Add("ドル／円");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPageNum = _currentPageNum + 1;
            // 1ページ目を表示
            this.Paging(_currentPageNum);

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentPageNum = _currentPageNum - 1;
            if (_currentPageNum < 0 )
            {
                _currentPageNum = 1;
            }
            // 1ページ目を表示
            this.Paging(_currentPageNum);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Utility.StockPriceProfile> lstDetail = new List<Utility.StockPriceProfile>();

            List<int> lstCode = (from q in _List1Year
                                 orderby q.StockCode 
                                     select q.StockCode).Distinct().ToList();



            foreach (int code in lstCode )
            {

                var query = from q in _List1Year
                            where q.StockCode == code
                            select q;

                foreach (Utility.StockPriceProfile r in query)
                {
                    // 前日データを検索
                    Utility.StockPriceProfile prev = (from p in _List1Year
                               where p.StockCode == code
                               && p.StockDate < r.StockDate
                               orderby p.StockDate descending 
                               select p).FirstOrDefault() ;

                    if (prev != null)
                    {
                        if (prev.AdjustmentClosingPrice * 1.05m < r.AdjustmentClosingPrice)
                        {
                            lstDetail.Add(r);
                        }
                    }
                }

            }

            dgvTest.DataSource = lstDetail;



        }

        private void btnDisplay12_Click(object sender, EventArgs e)
        {
            Utility.StockPriceUtil util = new Utility.StockPriceUtil();
            _ListData = util.GetListStockPriceProfile(DateTime.Now.AddMonths(-12).Date, DateTime.Now.Date);
            _ListNikkei = util.GetListNikkeiAverage(DateTime.Now.AddMonths(-12).Date, DateTime.Now.Date);
            _ListDY = util.GetListDollarYenEntity(DateTime.Now.AddMonths(-12).Date, DateTime.Now.Date);

            _currentPageNum = 1;
            // 1ページ目を表示
            this.Paging(_currentPageNum);

            this.CreateNikkeiChart(this.chartNikkei);
            this.CreateDollarYenChart(this.chartDollarYen);
        }
    }
}
