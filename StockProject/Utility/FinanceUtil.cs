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
                            divEntity.OrderNo = Convert.ToInt32(q2.Value);
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

                if (divEntity.OrderNo != 0)
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

            // 1ヶ月分の株価
            string url = "";
            DateTime beginDate = DateTime.Now.AddMonths(-1);
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

            // 時系列株価情報を取得する
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

                    decimal d;
                    if (decimal.TryParse(q2.Elements().ElementAt(1).Value,out d) == false)
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

        #region 企業情報
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

            int stockcode;
            if (Int32.TryParse(code.First().Value, out stockcode) == false)
            {
                return new List<ProfileEntity>();
            }

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
                                if (String.IsNullOrEmpty(elm.Parent.Elements("td").ElementAt(0).Value.Replace("-","")))
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

        #region ドル／円
        private string YAHOO_EXCHANGE_HISTORY = "http://info.finance.yahoo.co.jp/history/?code=USDJPY%3DX&sy={0}&sm={1}&sd={2}&ey={3}&em={4}&ed={5}&tm=d&p=1";


        public List<DollarYenEntity> GetDollarYenEntityList()
        {
            List<DollarYenEntity> list = new List<DollarYenEntity>();

            // 3ヶ月分の株価
            string url = "";
            DateTime beginDate = DateTime.Now.AddMonths(-3);
            DateTime endDate = DateTime.Now;
            url = string.Format(YAHOO_EXCHANGE_HISTORY, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetDollarYenEntity(url, list);

            return list;

        }

        public List<DollarYenEntity> GetDollarYenEntityList(DateTime beginDate, DateTime endDate)
        {
            List<DollarYenEntity> list = new List<DollarYenEntity>();

            // 3ヶ月分の株価
            string url = "";
            url = string.Format(YAHOO_EXCHANGE_HISTORY, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetDollarYenEntity(url, list);

            return list;

        }

        private void SetDollarYenEntity(string url, List<DollarYenEntity> list)
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

            // 時系列株価情報を取得する
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


            DollarYenEntity dollarYen;


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

                    dollarYen = new DollarYenEntity();
                    dollarYen.ExchangeDate = Convert.ToDateTime(q2.Elements().ElementAt(0).Value);
                    dollarYen.OpeningPrice = Convert.ToDecimal(q2.Elements().ElementAt(1).Value);
                    dollarYen.HighPrice    = Convert.ToDecimal(q2.Elements().ElementAt(2).Value);
                    dollarYen.LowPrice     = Convert.ToDecimal(q2.Elements().ElementAt(3).Value);
                    dollarYen.ClosingPrice = Convert.ToDecimal(q2.Elements().ElementAt(4).Value);



                    list.Add(dollarYen);

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
                SetDollarYenEntity(nextUrl, list);
            }
        }


        #endregion

        #region 日経平均
        private string YAHOO_NIKKEI_HISTORY = "http://info.finance.yahoo.co.jp/history/?code=998407.O&sy={0}&sm={1}&sd={2}&ey={3}&em={4}&ed={5}&tm=d";


        public List<NikkeiAverageEntity> GetNikkeiAverageEntityList()
        {
            List<NikkeiAverageEntity> list = new List<NikkeiAverageEntity>();

            // 3ヶ月分の日経平均
            string url = "";
            DateTime beginDate = DateTime.Now.AddMonths(-3);
            DateTime endDate = DateTime.Now;
            url = string.Format(YAHOO_NIKKEI_HISTORY, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetNikkeiAvarageEntity(url, list);

            return list;

        }

        public List<NikkeiAverageEntity> SetNikkeiAvarageEntity(DateTime beginDate, DateTime endDate)
        {
            List<NikkeiAverageEntity> list = new List<NikkeiAverageEntity>();

            // 3ヶ月分の株価
            string url = "";
            url = string.Format(YAHOO_EXCHANGE_HISTORY, beginDate.Year, beginDate.Month, beginDate.Day, endDate.Year, endDate.Month, endDate.Day);

            // Yahooファイナンスの株価時系列から情報を取得する
            SetNikkeiAvarageEntity(url, list);

            return list;

        }

        private void SetNikkeiAvarageEntity(string url, List<NikkeiAverageEntity> list)
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

            // 時系列株価情報を取得する
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


            NikkeiAverageEntity nikkeiAverage;


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

                    nikkeiAverage = new NikkeiAverageEntity();
                    nikkeiAverage.StockDate  = Convert.ToDateTime(q2.Elements().ElementAt(0).Value);
                    nikkeiAverage.OpeningPrice = Convert.ToDecimal(q2.Elements().ElementAt(1).Value);
                    nikkeiAverage.HighPrice = Convert.ToDecimal(q2.Elements().ElementAt(2).Value);
                    nikkeiAverage.LowPrice = Convert.ToDecimal(q2.Elements().ElementAt(3).Value);
                    nikkeiAverage.ClosingPrice = Convert.ToDecimal(q2.Elements().ElementAt(4).Value);

                    list.Add(nikkeiAverage);

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
                SetNikkeiAvarageEntity(nextUrl, list);
            }
        }

        #endregion


        #region 証券コード一覧
        private string YAHOO_STOCKCODE1 = "http://info.finance.yahoo.co.jp/ranking/?kd=40&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE2 = "http://info.finance.yahoo.co.jp/ranking/?kd=41&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE3 = "http://info.finance.yahoo.co.jp/ranking/?kd=42&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE4 = "http://info.finance.yahoo.co.jp/ranking/?kd=43&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE5 = "http://info.finance.yahoo.co.jp/ranking/?kd=44&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE6 = "http://info.finance.yahoo.co.jp/ranking/?kd=45&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE7 = "http://info.finance.yahoo.co.jp/ranking/?kd=46&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE8 = "http://info.finance.yahoo.co.jp/ranking/?kd=47&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE9 = "http://info.finance.yahoo.co.jp/ranking/?kd=48&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE10 = "http://info.finance.yahoo.co.jp/ranking/?kd=49&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE11 = "http://info.finance.yahoo.co.jp/ranking/?kd=50&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE12 = "http://info.finance.yahoo.co.jp/ranking/?kd=51&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE13 = "http://info.finance.yahoo.co.jp/ranking/?kd=52&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE14 = "http://info.finance.yahoo.co.jp/ranking/?kd=53&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE15 = "http://info.finance.yahoo.co.jp/ranking/?kd=54&mk=1&tm=d&vl=a";
        private string YAHOO_STOCKCODE16 = "http://info.finance.yahoo.co.jp/ranking/?kd=55&mk=1&tm=d&vl=a";

        public List<StockPriceEntity> GetStockCodeList()
        {
            List<StockPriceEntity> list = new List<StockPriceEntity>();

            // Yahooファイナンスの企業ランキングから証券コードの一覧を取得する
            SetStockCodeList(YAHOO_STOCKCODE1, list);
            //SetStockCodeList(YAHOO_STOCKCODE2, list);
            //SetStockCodeList(YAHOO_STOCKCODE3, list);
            //SetStockCodeList(YAHOO_STOCKCODE4, list);
            //SetStockCodeList(YAHOO_STOCKCODE5, list);
            //SetStockCodeList(YAHOO_STOCKCODE6, list);
            //SetStockCodeList(YAHOO_STOCKCODE7, list);
            //SetStockCodeList(YAHOO_STOCKCODE8, list);
            //SetStockCodeList(YAHOO_STOCKCODE9, list);
            //SetStockCodeList(YAHOO_STOCKCODE10, list);
            //SetStockCodeList(YAHOO_STOCKCODE11, list);
            //SetStockCodeList(YAHOO_STOCKCODE12, list);
            //SetStockCodeList(YAHOO_STOCKCODE13, list);
            //SetStockCodeList(YAHOO_STOCKCODE14, list);
            //SetStockCodeList(YAHOO_STOCKCODE15, list);
            //SetStockCodeList(YAHOO_STOCKCODE16, list);

            return list.Distinct().ToList();

        }

        private void SetStockCodeList(string url, List<StockPriceEntity> list)
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

                StockPriceEntity stock = new StockPriceEntity();
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
                            break;
                        case 2:
                            if (Convert.ToDecimal(q2.Value) < 9999)
                            {
                                stock.StockCode = Convert.ToInt32(q2.Value);
                                list.Add(stock);
                            }
                            exitFor = true;
                            break;
                    }

                    i++;

                    if (exitFor)
                    {
                        break;
                    }

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
                SetStockCodeList(nextUrl, list);
            }
        }


        #endregion


    }

    /// <summary>
    /// 配当利回り
    /// </summary>
    public class DividendEntity
    {
        public int OrderNo { get; set; }
        public int StockCode { get; set; }
        public string Market { get; set; }
        public string CompanyName { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendYield { get; set; }
        public string DetailUrl { get; set; }
    }

    /// <summary>
    /// 株価
    /// </summary>
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

    public class NumberingPriceEntity :StockPriceEntity 
    {
        public decimal RowNum { get; set; }
    }

    /// <summary>
    /// 企業情報
    /// </summary>
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


    /// <summary>
    /// 一覧
    /// </summary>
    public class ListEntity
    {
        public int StockCode { get; set; }                         // 証券コード
        public string CompanyName { get; set; }                    // 企業名
        public string Feature { get; set; }                        // 特色
        public string ConcatenationBusiness { get; set; }          // 連結事業
        public string HeadquartersLocation { get; set; }           // 本社所在地
        public string IndustriesCategory { get; set; }             // 業種分類
        public DateTime? FoundationDate { get; set; }              // 設立年月日
        public string MarketName { get; set; }                     // 市場名
        public DateTime? ListedDate { get; set; }                  // 上場年月日
        public decimal? ClosingMonth { get; set; }                 // 決算
        public decimal? UnitShares { get; set; }                   // 単元株数
        public decimal? EmployeeNumberSingle { get; set; }         // 従業員数（単独）
        public decimal? EmployeeNumberConcatenation { get; set; }  // 従業員数（連結）
        public decimal? AvarageAnnualIncome { get; set; }          // 平均年収
        public decimal Dividend { get; set; }                      // 配当金
        public decimal DividendYield { get; set; }                 // 配当利回り
        public decimal ClosingPrice { get; set; }                  // 終値
        public decimal TradeVolume { get; set; }                   // 出来高
    }


    public class DollarYenEntity
    {
        public DateTime ExchangeDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosingPrice { get; set; }

    }

    public class NikkeiAverageEntity
    {
        public DateTime StockDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosingPrice { get; set; }

    }

    public class PriceUpDownEntity
    {
        public int StockCode { get; set; }                         // 証券コード
        public decimal UpCnt3M { get; set; }
        public decimal DownCnt3M { get; set; }
        public decimal UpCnt2M { get; set; }
        public decimal DownCnt2M { get; set; }
        public decimal UpCnt1M { get; set; }
        public decimal DownCnt1M { get; set; }

    }

    /// <summary>
    /// 株価
    /// </summary>
    public class StockPriceProfile
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
        public DateTime StockDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal TradeVolume { get; set; }
        public decimal AdjustmentClosingPrice { get; set; }
    }

}
