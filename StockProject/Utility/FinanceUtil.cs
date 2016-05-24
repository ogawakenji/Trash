using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sgml;
using System.Net.Http;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace Utility
{
    public class FinanceUtil
    {

        #region 配当利回り

        public List<DividendEntity> GetDividendEntityList()
        {
            List<DividendEntity> list = new List<DividendEntity>();

            // Yahooファイナンスの配当利回り(会社予想)から情報を取得する
            // http://info.finance.yahoo.co.jp/ranking/?kd=8&tm=d&vl=a&mk=1&p=1

            string url = "http://info.finance.yahoo.co.jp/ranking/?kd=8&tm=d&vl=a&mk=1&p=1";
            SetDividendEntityList(url, list);
            return list;
        }

        private void SetDividendEntityList(string url, List<DividendEntity> list)
        {
            HtmlUtil htmlUtil = new HtmlUtil();

            // urlからWebサイトに接続し情報を取得する
            XDocument xdoc = htmlUtil.ParseHtml(htmlUtil.GetHtml(url));
            var ns = xdoc.Root.Name.Namespace;

            // 次へのページが存在するか確認する
            string nextUrl = "";
            var query1 =
                from q1 in xdoc.Descendants(ns + "ul")
                where (string)q1.Attribute("class") == "ymuiPagingBottom clearFix"
                select q1;

            foreach (var q in query1.Descendants("a"))
            {
                if (q.Value == "次へ")
                {
                    nextUrl = q.Attribute("href").Value;
                }
            }

            // 配当利回りを取得する
            var query2 =
                from q2 in xdoc.Descendants(ns + "tr")
                select q2;

            bool first = true;

            foreach (var q1 in query2)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                DividendEntity divEntity = new DividendEntity();
                int i = 1;
                bool exitFor = false;

                foreach (var q2 in q1.Descendants())
                {
                    switch (i)
                    {
                        case 1:
                            if (q2.Value == "順位")
                            {
                                exitFor = true;
                                break;
                            }
                            divEntity.Order = Convert.ToInt32(q2.Value);
                            break;
                        case 2:
                            divEntity.StockCode = Convert.ToInt32(q2.Value);
                            divEntity.DetailUrl = q2.Element("a").FirstAttribute.Value;
                            break;
                        case 3:
                            break;
                        case 4:
                            divEntity.Market = q2.Value;
                            break;
                        case 5:
                            divEntity.CompanyName = q2.Value;
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            divEntity.Dividend = Convert.ToDecimal(q2.Value);
                            break;
                        case 10:
                            divEntity.DividendYield = Convert.ToDecimal(q2.Value.Replace("%", ""));
                            break;
                        case 11:
                            break;
                        default:
                            break;

                    }

                    i++;

                    if (exitFor)
                    {
                        break;
                    }

                }

                if (divEntity.Order != 0)
                {
                    // 配当利回りの情報をリストに追加
                    list.Add(divEntity);
                }

            }

            if (nextUrl == "")
            {
                // 次のURLがなければ処理終了
                return;
            }
            else
            {
                // 次のURLがあれば再帰呼び出し
                SetDividendEntityList(nextUrl, list);
            }
        }

        #endregion

        #region 株価
        private string YAHOO_HISTORY = "http://info.finance.yahoo.co.jp/history/?code={0}&sy={1}&sm={2}&sd={3}&ey={4}&em={5}&ed={6}&tm=d";

        public List<StockPriceEntity> GetStockPriceEntityList(int StockCode )
        {
            List<StockPriceEntity> list = new List<StockPriceEntity>();

            // 3ヶ月分の株価
            string url = "";
            DateTime beginDate = DateTime.Now.AddMonths(-3);
            DateTime endDate = DateTime.Now;
            url = string.Format(YAHOO_HISTORY, StockCode, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetStockPriceEntityList(url, list);

            return list;

        }

        public List<StockPriceEntity> GetStockPriceEntityList(int StockCode ,DateTime beginDate,DateTime endDate)
        {
            List<StockPriceEntity> list = new List<StockPriceEntity>();

            // 3ヶ月分の株価
            string url = "";
            url = string.Format(YAHOO_HISTORY, StockCode, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetStockPriceEntityList(url, list);

            return list;

        }

        private void SetStockPriceEntityList(string url,List<StockPriceEntity> list)
        {
            HtmlUtil htmlUtil = new HtmlUtil();

            // urlからWebサイトに接続し情報を取得する
            XDocument xdoc = htmlUtil.ParseHtml(htmlUtil.GetHtml(url));
            var ns = xdoc.Root.Name.Namespace;

            // 次へのページが存在するか確認する
            string nextUrl = "";
            var query1 =
                from q1 in xdoc.Descendants(ns + "ul")
                where (string)q1.Attribute("class") == "ymuiPagingBottom clearFix"
                select q1;

            foreach (var q in query1.Descendants("a"))
            {
                if (q.Value == "次へ")
                {
                    nextUrl = q.Attribute("href").Value;
                }
            }

            // 配当利回りを取得する
            var query2 =
                from q2 in xdoc.Descendants(ns + "table")
                where (string)q2.Attribute("class") == "boardFin yjSt marB6"
                select q2.Descendants(ns + "tr");

            var company =
                from c in xdoc.Descendants(ns + "h1")
                select c;

            var code =
                from c in xdoc.Descendants(ns + "dt")
                select c;


            StockPriceEntity stockPrice;


            foreach (var q1 in query2)
            {
                foreach (var q2 in q1)
                {
                    if (q2.Elements() == null)
                    {
                        continue;
                    }
                    if (q2.Elements().First().Value == "日付")
                    {
                        continue;
                    }

                    stockPrice = new StockPriceEntity();
                    stockPrice.StockCode              = Convert.ToInt32(code.First().Value);
                    stockPrice.CompanyName            = company.First().Value;
                    stockPrice.StockDate              = Convert.ToDateTime(q2.Elements().ElementAt(0).Value);
                    stockPrice.OpeningPrice           = Convert.ToDecimal(q2.Elements().ElementAt(1).Value);
                    stockPrice.HighPrice              = Convert.ToDecimal(q2.Elements().ElementAt(2).Value);
                    stockPrice.LowPrice               = Convert.ToDecimal(q2.Elements().ElementAt(3).Value);
                    stockPrice.ClosingPrice           = Convert.ToDecimal(q2.Elements().ElementAt(4).Value);
                    stockPrice.TradeVolume            = Convert.ToDecimal(q2.Elements().ElementAt(5).Value);
                    stockPrice.AdjustmentClosingPrice = Convert.ToDecimal(q2.Elements().ElementAt(6).Value);



                    list.Add(stockPrice);

                }



            }

            if (nextUrl == "")
            {
                // 次のURLがなければ処理終了
                return;
            }
            else
            {
                // 次のURLがあれば再帰呼び出し
                SetStockPriceEntityList(nextUrl, list);
            }
        }


        #endregion

        #region 株価
        private string YAHOO_PROFILE = "http://stocks.finance.yahoo.co.jp/stocks/profile/?code={0}";

        public List<ProfileEntity> GetProfileEntityList(int StockCode)
        {
            List<ProfileEntity> list = new List<ProfileEntity>();

            // 3ヶ月分の株価
            string url = "";
            DateTime beginDate = DateTime.Now.AddMonths(-3);
            DateTime endDate = DateTime.Now;
            url = string.Format(YAHOO_PROFILE, StockCode);

            HtmlUtil htmlUtil = new HtmlUtil();

            // urlからWebサイトに接続し情報を取得する
            XDocument xdoc = htmlUtil.ParseHtml(htmlUtil.GetHtml(url));
            var ns = xdoc.Root.Name.Namespace;

            var query1 =
                from q1 in xdoc.Descendants(ns + "tr")
                select q1;

            var company =
                from c in xdoc.Descendants(ns + "h1")
                select c;

            var code =
                from c in xdoc.Descendants(ns + "dt")
                select c;


            ProfileEntity profile = new ProfileEntity();

            profile.StockCode = Convert.ToInt32(code.First().Value);
            profile.CompanyName = company.First().Value;


            foreach (var q1 in query1)
            {
                foreach(var elm in q1.Elements())
                {
                    if (elm.Name == "th")
                    {

                        Console.WriteLine(elm.Value);
                        switch (elm.Value)
                        {
                            case "特色":
                                profile.Feature = elm.Parent.Elements("td").ElementAt(0).Value;
                                break;

                            case "連結事業":
                                profile.ConcatenationBusiness = elm.Parent.Elements("td").ElementAt(0).Value;
                                break;

                            case "本社所在地":
                                profile.HeadquartersLocation = elm.Parent.Elements("td").ElementAt(0).Value;
                                break;

                            case "業種分類":
                                profile.IndustriesCategory = elm.Parent.Elements("td").ElementAt(0).Value;
                                break;

                            case "設立年月日":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value))
                                {
                                    profile.FoundationDate = null;
                                }
                                else
                                {
                                    profile.FoundationDate = Convert.ToDateTime(elm.Parent.Elements("td").ElementAt(0).Value);
                                }
                                break;

                            case "市場名":
                                profile.MarketName = elm.Parent.Elements("td").ElementAt(0).Value;
                                break;

                            case "上場年月日":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value))
                                {
                                    profile.ListedDate = null;
                                }
                                else
                                {
                                    profile.ListedDate = Convert.ToDateTime(elm.Parent.Elements("td").ElementAt(0).Value);
                                }
                                break;

                            case "決算":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value))
                                {
                                    profile.ClosingMonth = null;
                                }
                                else
                                {
                                    profile.ClosingMonth = Convert.ToDecimal(elm.Parent.Elements("td").ElementAt(0).Value.Substring(0,2).Replace("月",""));
                                }
                                break;

                            case "単元株数":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value.Replace("単元株制度なし", "")))
                                {
                                    profile.UnitShares = null;
                                }
                                else
                                {
                                    profile.UnitShares = Convert.ToDecimal(elm.Parent.Elements("td").ElementAt(0).Value.Replace("単元株制度なし", "").Replace("株",""));
                                }
                                break;

                            case "従業員数（単独）":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value.Replace("人", "").Replace("-", "")))
                                {
                                    profile.EmployeeNumberSingle = null;
                                }
                                else
                                {
                                    profile.EmployeeNumberSingle = Convert.ToDecimal(elm.Parent.Elements("td").ElementAt(0).Value.Replace("人", "").Replace("-", ""));
                                }
                                break;

                            case "従業員数（連結）":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(1).Value.Replace("人", "").Replace("-", "")))
                                {
                                    profile.EmployeeNumberConcatenation = null;
                                }
                                else
                                {
                                    profile.EmployeeNumberConcatenation = Convert.ToDecimal(elm.Parent.Elements("td").ElementAt(1).Value.Replace("人", "").Replace("-", ""));
                                }
                                break;

                            case "平均年収":
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(1).Value.Replace("千円", "").Replace("-", "")))
                                {
                                    profile.AvarageAnnualIncome = null;
                                }
                                else
                                {
                                    profile.AvarageAnnualIncome = Convert.ToDecimal(elm.Parent.Elements("td").ElementAt(1).Value.Replace("千円", "").Replace("-", "")) * 1000;
                                }
                                break;

                        }

                    }
                }

            }

            if (string.IsNullOrEmpty(profile.Feature) == false)
            {
                list.Add(profile);
            }

            return list;

        }

       

        #endregion


    }

    /// <summary>
    /// 配当利回り
    /// </summary>
    public class DividendEntity
    {
        public int Order { get; set; }
        public int StockCode { get; set; }
        public string Market { get; set; }
        public string CompanyName { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendYield { get; set; }
        public string DetailUrl { get; set; }
    }

    public class StockPriceEntity
    {
        public int StockCode { get; set; }
        public string CompanyName { get; set; }
        public DateTime  StockDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal TradeVolume { get; set; }
        public decimal AdjustmentClosingPrice { get; set; }

    }

    public class ProfileEntity
    {
        public int StockCode { get; set; }
        public string CompanyName { get; set; }
        public string Feature { get; set; }                        // 特色
        public string ConcatenationBusiness { get; set; }          // 連結事業
        public string HeadquartersLocation { get; set; }           // 本社所在地
        public string IndustriesCategory { get; set; }             // 業種分類
        public DateTime? FoundationDate { get; set; }               // 設立年月日
        public string MarketName { get; set; }                     // 市場名
        public DateTime? ListedDate { get; set; }                   // 上場年月日
        public decimal? ClosingMonth { get; set; }                  // 決算
        public decimal? UnitShares { get; set; }                    // 単元株数
        public decimal? EmployeeNumberSingle { get; set; }          // 従業員数（単独）
        public decimal? EmployeeNumberConcatenation { get; set; }   // 従業員数（連結）
        public decimal? AvarageAnnualIncome { get; set; }           // 平均年収

    }


}
