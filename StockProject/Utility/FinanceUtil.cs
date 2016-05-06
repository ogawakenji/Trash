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
        public List<DividendEntity > GetDividendEntityList()
        {
            List<DividendEntity> list = new List<DividendEntity>() ;

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
                            if (q2.Value =="順位")
                            {
                                exitFor = true;
                                break;
                            }
                            divEntity.Order = Convert.ToInt32(q2.Value);
                            break;
                        case 2:
                            divEntity .StockCode = Convert.ToInt32(q2.Value);
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

                    Console.WriteLine(q2.Value);
                }

                if (divEntity .Order != 0 )
                {
                    list.Add(divEntity);
                }

            }

            if (nextUrl == "")
            {
                return;
            }
            else
            {
                SetDividendEntityList(nextUrl, list);
            }


        }




    }

    public class DividendEntity
    {
        public int Order { get; set; }
        public int StockCode { get; set; }
        public string Market { get; set; }
        public string CompanyName { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendYield { get; set; }
    }


}
