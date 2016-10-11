﻿using System;
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


                _ListDetail = db.DBSelect<ListEntity>(sb.ToString());



            }

            this.listEntityBindingSource.DataSource = _ListDetail;

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

            //業種分類
            string industriesCategory = "";

            //市場名
            string marketName = "";

            //決算月
            string closingMonth = "";

            stockCode = this.txtStockCode.Text;
            industriesCategory = this.cboCategory.Text;
            marketName = this.cboMarketName.Text;
            closingMonth = this.txtClosingMonth.Text;

            var q = _ListDetail.AsQueryable();
            if (!string.IsNullOrEmpty(stockCode))
            {
                q = q.Where(c => c.StockCode.ToString().Contains(stockCode));
            }

            if (!string.IsNullOrEmpty(industriesCategory))
            {
                q = q.Where(c => c.IndustriesCategory.ToString().Contains(industriesCategory));
            }

            if (!string.IsNullOrEmpty(closingMonth))
            {
                q = q.Where(c => c.ClosingMonth.ToString() == closingMonth);
            }

            this.listEntityBindingSource.DataSource = q;


        }

    }
}
