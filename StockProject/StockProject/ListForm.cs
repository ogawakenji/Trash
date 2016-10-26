using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;


namespace StockProject
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private List<ListEntity> _ListDetail;


        private void ListForm_Load(object sender, EventArgs e)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" WITH PRICE AS ( ");
                sb.AppendLine(" SELECT stockprice.*  ");
                sb.AppendLine(" FROM  ");
                sb.AppendLine("     stockprice  ");
                sb.AppendLine(" INNER JOIN  ( ");
                sb.AppendLine("       SELECT ");
                sb.AppendLine("           StockCode ");
                sb.AppendLine("          ,MAX(StockDate) StockDate ");
                sb.AppendLine("       FROM ");
                sb.AppendLine("            stockprice ");
                sb.AppendLine("       GROUP BY  ");
                sb.AppendLine("                StockCode ");
                sb.AppendLine("       ) stockmax  ");
                sb.AppendLine("    ON stockmax.StockCode = stockprice.StockCode ");
                sb.AppendLine("   AND stockmax.StockDate = stockprice.StockDate ");
                sb.AppendLine(" ) ");
                sb.AppendLine(" SELECT ");
                sb.AppendLine("      profile.StockCode ");
                sb.AppendLine("     ,profile.CompanyName ");
                sb.AppendLine("     ,profile.Feature ");
                sb.AppendLine("     ,profile.ConcatenationBusiness ");
                sb.AppendLine("     ,profile.HeadquartersLocation ");
                sb.AppendLine("     ,profile.IndustriesCategory ");
                sb.AppendLine("     ,profile.FoundationDate ");
                sb.AppendLine("     ,profile.MarketName ");
                sb.AppendLine("     ,profile.ListedDate ");
                sb.AppendLine("     ,profile.ClosingMonth ");
                sb.AppendLine("     ,profile.UnitShares ");
                sb.AppendLine("     ,profile.EmployeeNumberSingle ");
                sb.AppendLine("     ,profile.EmployeeNumberConcatenation ");
                sb.AppendLine("     ,profile.AvarageAnnualIncome ");
                sb.AppendLine("     ,dividend.Dividend ");
                sb.AppendLine("     ,round(cast(dividend.Dividend as real) / PRICE.ClosingPrice * 100,2) DividendYield ");
                sb.AppendLine("     ,PRICE.ClosingPrice ");
                sb.AppendLine("     ,PRICE.TradeVolume ");
                sb.AppendLine(" FROM  ");
                sb.AppendLine("       profile ");
                sb.AppendLine(" LEFT JOIN PRICE  ");
                sb.AppendLine("   ON PRICE.StockCode = profile.StockCode ");
                sb.AppendLine(" LEFT JOIN dividend ");
                sb.AppendLine("   ON dividend.StockCode = profile.StockCode ");
                sb.AppendLine(" ORDER BY profile.StockCode ");



                _ListDetail = db.DBSelect<ListEntity>(sb.ToString());



            }

            this.listEntityBindingSource.DataSource = _ListDetail;


            var query = (from q in _ListDetail
                         orderby q.IndustriesCategory 
                        select q.IndustriesCategory).Distinct();

            foreach ( string s in query)
            {
                this.cboCategory.Items.Add(s);
            }

            var q2 = (from q in _ListDetail
                         orderby q.MarketName 
                         select q.MarketName).Distinct();

            foreach (string s in q2)
            {
                this.cboMarketName.Items.Add(s);
            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //using (Utility.DbUtil db = new Utility.DbUtil())
            //{

            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine(" WITH PRICE AS ( ");
            //    sb.AppendLine(" SELECT stockprice.*  ");
            //    sb.AppendLine(" FROM  ");
            //    sb.AppendLine("     stockprice  ");
            //    sb.AppendLine(" INNER JOIN  ( ");
            //    sb.AppendLine("       SELECT ");
            //    sb.AppendLine("           StockCode ");
            //    sb.AppendLine("          ,MAX(StockDate) StockDate ");
            //    sb.AppendLine("       FROM ");
            //    sb.AppendLine("            stockprice ");
            //    sb.AppendLine("       GROUP BY  ");
            //    sb.AppendLine("                StockCode ");
            //    sb.AppendLine("       ) stockmax  ");
            //    sb.AppendLine("    ON stockmax.StockCode = stockprice.StockCode ");
            //    sb.AppendLine("   AND stockmax.StockDate = stockprice.StockDate ");
            //    sb.AppendLine(" ) ");
            //    sb.AppendLine(" SELECT ");
            //    sb.AppendLine("      profile.StockCode ");
            //    sb.AppendLine("     ,profile.CompanyName ");
            //    sb.AppendLine("     ,profile.Feature ");
            //    sb.AppendLine("     ,profile.ConcatenationBusiness ");
            //    sb.AppendLine("     ,profile.HeadquartersLocation ");
            //    sb.AppendLine("     ,profile.IndustriesCategory ");
            //    sb.AppendLine("     ,profile.FoundationDate ");
            //    sb.AppendLine("     ,profile.MarketName ");
            //    sb.AppendLine("     ,profile.ListedDate ");
            //    sb.AppendLine("     ,profile.ClosingMonth ");
            //    sb.AppendLine("     ,profile.UnitShares ");
            //    sb.AppendLine("     ,profile.EmployeeNumberSingle ");
            //    sb.AppendLine("     ,profile.EmployeeNumberConcatenation ");
            //    sb.AppendLine("     ,profile.AvarageAnnualIncome ");
            //    sb.AppendLine("     ,dividend.Dividend ");
            //    sb.AppendLine("     ,round(cast(dividend.Dividend as real) / PRICE.ClosingPrice * 100,2) DividendYield ");
            //    sb.AppendLine("     ,PRICE.ClosingPrice ");
            //    sb.AppendLine("     ,PRICE.TradeVolume ");
            //    sb.AppendLine(" FROM  ");
            //    sb.AppendLine("       profile ");
            //    sb.AppendLine(" LEFT JOIN PRICE  ");
            //    sb.AppendLine("   ON PRICE.StockCode = profile.StockCode ");
            //    sb.AppendLine(" LEFT JOIN dividend ");
            //    sb.AppendLine("   ON dividend.StockCode = profile.StockCode ");


            //    _ListDetail = db.DBSelect<ListEntity>(sb.ToString());



            //}

            //this.listEntityBindingSource.DataSource = _ListDetail;

            filterData();

        }

        private void btnUpDown_Click(object sender, EventArgs e)
        {
            List<ListEntity> listDetail = new List<ListEntity>();


            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("      profile.StockCode ");
                sb.AppendLine("     ,profile.CompanyName ");
                sb.AppendLine("     ,profile.Feature ");
                sb.AppendLine("     ,profile.ConcatenationBusiness ");
                sb.AppendLine("     ,profile.HeadquartersLocation ");
                sb.AppendLine("     ,profile.IndustriesCategory ");
                sb.AppendLine("     ,profile.FoundationDate ");
                sb.AppendLine("     ,profile.MarketName ");
                sb.AppendLine("     ,profile.ListedDate ");
                sb.AppendLine("     ,profile.ClosingMonth ");
                sb.AppendLine("     ,profile.UnitShares ");
                sb.AppendLine("     ,profile.EmployeeNumberSingle ");
                sb.AppendLine("     ,profile.EmployeeNumberConcatenation ");
                sb.AppendLine("     ,profile.AvarageAnnualIncome ");
                sb.AppendLine("     ,dividend.Dividend ");
                sb.AppendLine("     ,round(cast(dividend.Dividend as real) / PRICE.AdjustmentClosingPrice * 100,2) DividendYield ");
                sb.AppendLine("     ,PRICE.AdjustmentClosingPrice AS ClosingPrice ");
                sb.AppendLine("     ,PRICE.TradeVolume ");
                sb.AppendLine(" FROM  ");
                sb.AppendLine("       profile ");
                sb.AppendLine(" LEFT JOIN stockprice PRICE  ");
                sb.AppendLine("   ON PRICE.StockCode = profile.StockCode ");
                sb.AppendLine(" LEFT JOIN dividend ");
                sb.AppendLine("   ON dividend.StockCode = profile.StockCode ");
                sb.AppendLine(" WHERE PRICE.StockDate BETWEEN :BeginDate AND :EndDate ORDER BY profile.StockCode,PRICE.StockDate ");
                sb.AppendLine(" ORDER BY profile.StockCode ");


                listDetail = db.DBSelect<ListEntity>(sb.ToString(),new { BeginDate = DateTime.Now.AddMonths(-3), EndDate = DateTime.Now.Date });

                int breakStockCode = 0;
                decimal previousPrice = 0;

                if (listDetail.Count != 0)
                {
                    breakStockCode = listDetail[0].StockCode;
                    previousPrice = listDetail[0].ClosingPrice;
                }

                Dictionary<string,int> dic = new Dictionary<string, int>();


                foreach (ListEntity list in listDetail)
                {
                    if (breakStockCode == list.StockCode)
                    {
                        // 同一証券コード
                        if (list.ClosingPrice >= previousPrice * 1.05m )
                        {
                            // 5%上昇
                            if (dic.ContainsKey("5%上昇" + list.MarketName ))
                            {
                                dic["5%上昇" + list.MarketName] = dic["5%上昇" + list.MarketName] + 1;
                            }
                            else
                            {
                                dic.Add("5%上昇" + list.MarketName, 1);
                            }
                        }
                        else if (list.ClosingPrice <= previousPrice * 0.95m)
                        {
                            // 5%下落
                            if (dic.ContainsKey("5%下落" + list.MarketName))
                            {
                                dic["5%下落" + list.MarketName] = dic["5%下落" + list.MarketName] + 1;
                            }
                            else
                            {
                                dic.Add("5%下落" + list.MarketName, 1);
                            }
                        }


                    }
                    else
                    {
                        // 証券コードブレイク
                        breakStockCode = list.StockCode;

                    }

                    // 前回株価
                    previousPrice = list.ClosingPrice;


                }

                this.dataGridView2.DataSource = dic;


            }

        }

        private void btn5UpDown_Click(object sender, EventArgs e)
        {
            List<StockPriceEntity> listDetail = new List<StockPriceEntity>();
            List<StockPriceEntity> listUp = new List<StockPriceEntity>();
            List<StockPriceEntity> listDown = new List<StockPriceEntity>();
            List<PriceUpDownEntity> listUpDown = new List<PriceUpDownEntity>();

            StockPriceEntity previousPrice = new StockPriceEntity();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {

                StringBuilder sb = new StringBuilder();

                sb.Length = 0;
                sb.AppendLine(" SELECT");
                sb.AppendLine("     StockCode");
                sb.AppendLine("    ,0 AS UpCnt3M ");
                sb.AppendLine("    ,0 AS DownCnt3M ");
                sb.AppendLine("    ,0 AS UpCnt2M ");
                sb.AppendLine("    ,0 AS DownCnt2M ");
                sb.AppendLine("    ,0 AS UpCnt1M ");
                sb.AppendLine("    ,0 AS DownCnt1M ");
                sb.AppendLine(" FROM");
                sb.AppendLine("     stockprice ");
                sb.AppendLine(" GROUP BY StockCode ");
                listUpDown = db.DBSelect<PriceUpDownEntity>(sb.ToString());

                // 一旦削除
                db.DBUpdate("DELETE FROM priceupdown ");


                sb.Length = 0;
                sb.AppendLine(" SELECT ");
                sb.AppendLine("      stockprice.* ");
                sb.AppendLine(" FROM  ");
                sb.AppendLine("       stockprice ");
                sb.AppendLine(" WHERE stockprice.StockDate BETWEEN :BeginDate AND :EndDate ");
                sb.AppendLine(" ORDER BY stockprice.StockCode,stockprice.StockDate ");

                listDetail = db.DBSelect<StockPriceEntity>(sb.ToString(), new { BeginDate = DateTime.Now.AddMonths(-3), EndDate = DateTime.Now.Date });


                int breakStockCode = 0;

                if (listDetail.Count != 0)
                {
                    previousPrice = listDetail[0];
                }

                Dictionary<string, int> dic = new Dictionary<string, int>();


                foreach (StockPriceEntity list in listDetail)
                {
                    if (breakStockCode == list.StockCode)
                    {
                        // 同一証券コード
                        if (list.ClosingPrice >= previousPrice.ClosingPrice * 1.05m)
                        {
                            // 5%上昇(前後データ追加)
                            var priceup = from up in listUpDown
                                          where up.StockCode == previousPrice.StockCode
                                          select up;

                            foreach(PriceUpDownEntity up in priceup)
                            {
                                up.UpCnt3M = up.UpCnt3M + 1;

                                if (DateTime.Now.AddMonths(-2) <  previousPrice.StockDate)
                                {
                                    up.UpCnt2M = up.UpCnt2M + 1;
                                }

                                if (DateTime.Now.AddMonths(-1) < previousPrice.StockDate)
                                {
                                    up.UpCnt1M = up.UpCnt1M + 1;
                                }

                            }
                        }
                        else if (list.ClosingPrice <= previousPrice.ClosingPrice * 0.95m)
                        {
                            // 5%下落(前後データ追加)
                            var pricedown = from down in listUpDown
                                          where down.StockCode == previousPrice.StockCode
                                          select down;

                            foreach (PriceUpDownEntity down in pricedown)
                            {
                                down.DownCnt3M  = down.DownCnt3M + 1;

                                if (DateTime.Now.AddMonths(-2) < previousPrice.StockDate)
                                {
                                    down.DownCnt2M = down.DownCnt2M + 1;
                                }

                                if (DateTime.Now.AddMonths(-1) < previousPrice.StockDate)
                                {
                                    down.DownCnt1M = down.DownCnt1M + 1;
                                }

                            }

                        }


                    }
                    else
                    {
                        // 証券コードブレイク
                        breakStockCode = list.StockCode;

                    }

                    // 前回株価
                    previousPrice = list;


                }

                this.dataGridView2.DataSource = listUpDown;
                //this.dataGridView3.DataSource = listDown;


            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void filterData()
        {
            //証券コード
            string stockCode = "";

            //企業名
            string companyName = "";

            //業種分類
            string industriesCategory = "";

            //市場名
            string marketName = "";

            //決算月
            string closingMonth = "";

            //特色
            string feature = "";

            //
            decimal dividendYield = 0;

            stockCode = this.txtStockCode.Text;
            companyName = this.txtCompanyName.Text;
            industriesCategory = this.cboCategory.Text;
            marketName = this.cboMarketName.Text;
            closingMonth = this.txtClosingMonth.Text;
            feature = this.txtFeature.Text;
            if (decimal.TryParse(this.txtDividendYield .Text ,out dividendYield ) == false)
            {
                dividendYield = 0;
            }



            var q = _ListDetail.AsQueryable();
            if (!string.IsNullOrEmpty(stockCode))
            {
                q = q.Where(c => c.StockCode.ToString().Contains(stockCode));
            }

            if(!string.IsNullOrEmpty(companyName))
            {
                q = q.Where(c => c.CompanyName.Contains(companyName));
            }

            if (!string.IsNullOrEmpty(industriesCategory))
            {
                q = q.Where(c => c.IndustriesCategory.ToString().Contains(industriesCategory));
            }

            if (!string.IsNullOrEmpty(marketName))
            {
                q = q.Where(c => c.MarketName.ToString().Contains(marketName));
            }

            if (!string.IsNullOrEmpty(closingMonth))
            {
                q = q.Where(c => c.ClosingMonth.ToString() == closingMonth);
            }

            if (!string.IsNullOrEmpty(feature))
            {
                q = q.Where(c => c.Feature.Contains(feature));
            }

            if (!string.IsNullOrEmpty(this.txtDividendYield .Text  ))
            {
                q = q.Where(c => c.DividendYield >= dividendYield);
            }


            if (q.Count() == 0)
            {
                this.listEntityBindingSource.DataSource = new List<ListEntity>();
                return;
            }
            this.listEntityBindingSource.DataSource = q;


        }

        private void txtStockCode_Validated(object sender, EventArgs e)
        {
            this.filterData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FinanceUtil finance = new FinanceUtil();
            finance.GetStockCodeList();



            Utility.StockPriceUtil util = new Utility.StockPriceUtil();

            

            List<StockPriceProfile> stockData = util.GetListStockPriceProfile(DateTime.Now.AddMonths(-3).Date, DateTime.Now.Date);


            List<int> lstStock = (from q in _ListDetail
                         orderby q.StockCode
                         select q.StockCode).Distinct().ToList();


            List<ListEntity> lstDisplay = new List<ListEntity>();

            foreach (int code in lstStock)
            {
                var query = (from q in stockData
                            where q.StockCode == code
                            orderby q.StockDate descending
                            select q).Take(11);

                // ルールに合致するか？
                // 出来高が3日間連続増加？
                decimal tradevolume = -1;
                if (query.Count() > 0)
                {
                    tradevolume = query.FirstOrDefault().TradeVolume;
                }

                int volumeCount = 0;

                foreach (StockPriceProfile sp in query.Skip(1) )
                {
                    if (tradevolume > sp.TradeVolume )
                    {
                        volumeCount++;
                    }
                    else
                    {
                        break ;
                    }
                    tradevolume = sp.TradeVolume;

                    if (volumeCount==5)
                    {
                        // 3日連続で出来高増加
                        lstDisplay.Add((from q in _ListDetail
                                        where q.StockCode == code
                                        select q).FirstOrDefault());
                    }
                }



            }


            dataGridView2.DataSource = lstDisplay;




        }

        private void txtDividendYield_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDividendYield_Validated(object sender, EventArgs e)
        {
            this.filterData();
        }

        private void btnNumbering_Click(object sender, EventArgs e)
        {

            // 情報の取得
            List<Utility.StockPriceEntity> listStock = new List<Utility.StockPriceEntity>();
            List<Utility.NumberingPriceEntity > listNum = new List<Utility.NumberingPriceEntity>();
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                listStock = db.DBSelect<StockPriceEntity>(@"SELECT 
                                                                  stockcode.StockCode
                                                                 ,ifnull(profile.CompanyName,'') CompanyName 
                                                            FROM stockcode 
                                                            LEFT JOIN profile ON stockcode.StockCode = profile.StockCode
                                                            ORDER BY stockcode.StockCode ");

                db.DBExecuteSQL("DELETE FROM pricenumbering");

            }

            StringBuilder sb = new StringBuilder();
            sb.Length = 0;
            sb.AppendLine(" SELECT ");
            sb.AppendLine("     StockCode ");
            sb.AppendLine("    ,CompanyName ");
            sb.AppendLine("    ,StockDate ");
            sb.AppendLine("    ,OpeningPrice ");
            sb.AppendLine("    ,HighPrice ");
            sb.AppendLine("    ,LowPrice ");
            sb.AppendLine("    ,ClosingPrice ");
            sb.AppendLine("    ,TradeVolume ");
            sb.AppendLine("    ,AdjustmentClosingPrice ");
            sb.AppendLine("    ,(SELECT COUNT(*) + 1 ");
            sb.AppendLine("        FROM stockprice ");
            sb.AppendLine("       WHERE StockCode = :StockCode ");
            sb.AppendLine("         AND StockDate >= :StockDate ");
            sb.AppendLine("         AND (StockDate < t.StockDate OR (StockDate = t.StockDate AND StockCode < t.StockCode )) ");
            sb.AppendLine("     ) AS RowNum ");
            sb.AppendLine(" FROM stockprice t ");
            sb.AppendLine("WHERE t.StockCode = :StockCode ");
            sb.AppendLine("  AND t.StockDate >= :StockDate ");

            foreach (StockPriceEntity r in listStock)
            {
                using (Utility.DbUtil db = new Utility.DbUtil())
                {

                    listNum = db.DBSelect<NumberingPriceEntity>(sb.ToString(), new { StockCode = r.StockCode, StockDate = DateTime.Now.AddMonths(-3).Date });

                    string insertSql = @"INSERT INTO pricenumbering
                                    ( 
                                        StockCode             
                                        ,CompanyName           
                                        ,StockDate
                                        ,RowNum             
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
                                        ,:RowNum             
                                        ,:OpeningPrice          
                                        ,:HighPrice             
                                        ,:LowPrice              
                                        ,:ClosingPrice          
                                        ,:TradeVolume           
                                        ,:AdjustmentClosingPrice
                                    )";

                    if (listNum.Count() > 0 )
                    {
                        db.DBInsert(insertSql, listNum);
                    }

                }

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            StockPriceUtil util = new StockPriceUtil();
            // 20日前から今日までの株価情報を取得
            List<StockPriceProfile> lst = util.GetListStockPriceProfile(DateTime.Now.AddDays(-20), DateTime.Now);

            // 証券コードのDISTINCTを取得
            var stockCodes = (from q in lst
                             select q.StockCode).Distinct();

            
            foreach (decimal code in stockCodes )
            {
                // 証券コードでループ処理
                // 11件以上データが無い場合は飛ばす
                var cnt = (from t in lst
                           where t.StockCode == code
                           select t).Count();

                if (cnt < 11)
                {
                    continue ;
                }

                // 1) 日付の降順に並べ3件スキップした10件分のデータの出来高の平均値を取得
                var average = (from t in lst
                             where t.StockCode == code
                             orderby t.StockDate descending
                             select t.TradeVolume).Skip(3).Take(10).Average();

                // 2) 日付の降順に並べ3件分のデータを取得 
                var query2 = (from t in lst
                              where t.StockCode == code 
                              orderby t.StockDate descending
                              select t).Take(3);

                // 3) 3日間の出来高が平均の1.5倍以上であるものを抽出
                var query3 = from t in query2
                             where t.TradeVolume >= (average * 1.5m)
                             orderby t.StockDate ascending 
                             select t;


                if (query3.Count() == 3)
                {
                    int up = 0;
                    int down = 0;
                    decimal price = query3.FirstOrDefault().AdjustmentClosingPrice;
                    decimal volume = query3.FirstOrDefault().TradeVolume;
                    // 4) 3日間の株価の終値が連続して上昇
                    foreach (StockPriceProfile q in query3 )
                    {
                       if (q.AdjustmentClosingPrice > price && q.TradeVolume > volume )
                       {
                            // 上昇
                            up++;
                       } 

                       if (q.AdjustmentClosingPrice < price && q.TradeVolume < volume)
                       {
                            // 下落
                            down++;
                       }

                        price = q.AdjustmentClosingPrice;
                        volume = q.TradeVolume;
                    }

                    if (up==2)
                    {
                        Console.WriteLine(String.Format("【上昇】{0} {1}", query2.FirstOrDefault().StockCode, query2.FirstOrDefault().CompanyName));
                    }

                    if (down==2)
                    {
                        Console.WriteLine(String.Format("【下落】{0} {1}", query2.FirstOrDefault().StockCode, query2.FirstOrDefault().CompanyName));
                    }

                    //if (up != 2 && down != 2)
                    //{
                    //    Console.WriteLine(String.Format("【どっちでもない】{0} {1}", query2.FirstOrDefault().StockCode, query2.FirstOrDefault().CompanyName));
                    //}

                }



            }

        }
    }
}
