using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utility
{
    public class StockPriceUtil
    {
        // 株価チャート用のデータ
        public List<StockPriceProfile> GetListStockPriceProfile(DateTime beginDate ,DateTime endDate)
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
            sb.AppendLine("     , s.AdjustmentClosingPrice ");
            sb.AppendLine("  FROM  ");
            sb.AppendLine("       stockprice s ");
            sb.AppendLine(" INNER JOIN profile p ");
            sb.AppendLine("    ON s.StockCode = p.StockCode ");
            sb.AppendLine(" WHERE s.StockDate BETWEEN :BeginDate AND :EndDate ");
            sb.AppendLine(" ORDER BY  ");
            sb.AppendLine("       s.StockCode ");
            sb.AppendLine("     , s.StockDate ");

            List<StockPriceProfile> ListStockPriceProfile = new List<StockPriceProfile>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // データを取得してインスタンス変数に保持
                ListStockPriceProfile = db.DBSelect<StockPriceProfile>(sb.ToString(), new { BeginDate = beginDate ,EndDate = endDate });
            }

            return ListStockPriceProfile;

        }

        // 株価チャート用のデータ
        public List<StockPriceProfile> GetListStockPriceProfileFilterTempTable(DateTime beginDate, DateTime endDate)
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
            sb.AppendLine("     , s.AdjustmentClosingPrice ");
            sb.AppendLine("  FROM  ");
            sb.AppendLine("       stockprice s ");
            sb.AppendLine(" INNER JOIN profile p ");
            sb.AppendLine("    ON s.StockCode = p.StockCode ");
            sb.AppendLine(" INNER JOIN temptable t ");
            sb.AppendLine("    ON s.StockCode = t.StockCode ");
            sb.AppendLine(" WHERE s.StockDate BETWEEN :BeginDate AND :EndDate ");
            sb.AppendLine(" ORDER BY  ");
            sb.AppendLine("       s.StockCode ");
            sb.AppendLine("     , s.StockDate ");

            List<StockPriceProfile> ListStockPriceProfile = new List<StockPriceProfile>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // データを取得してインスタンス変数に保持
                ListStockPriceProfile = db.DBSelect<StockPriceProfile>(sb.ToString(), new { BeginDate = beginDate, EndDate = endDate });
            }

            return ListStockPriceProfile;

        }


        // 日経平均チャート用データ
        public List<NikkeiAverageEntity> GetListNikkeiAverage(DateTime beginDate, DateTime endDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("       n.StockDate ");
            sb.AppendLine("     , n.OpeningPrice ");
            sb.AppendLine("     , n.LowPrice ");
            sb.AppendLine("     , n.HighPrice ");
            sb.AppendLine("     , n.ClosingPrice ");
            sb.AppendLine("  FROM  ");
            sb.AppendLine("       nikkeiaverage n ");
            sb.AppendLine(" WHERE n.StockDate BETWEEN :BeginDate AND :EndDate ");
            sb.AppendLine(" ORDER BY  ");
            sb.AppendLine("       n.StockDate ");

            List<NikkeiAverageEntity> ListNikkeiAverage = new List<NikkeiAverageEntity>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // データを取得してインスタンス変数に保持
                ListNikkeiAverage = db.DBSelect<NikkeiAverageEntity>(sb.ToString(), new { BeginDate = beginDate, EndDate = endDate });
            }

            return ListNikkeiAverage;
        }

        // 日経平均チャート用データ
        public List<DollarYenEntity> GetListDollarYenEntity(DateTime beginDate, DateTime endDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT  ");
            sb.AppendLine("       d.ExchangeDate ");
            sb.AppendLine("     , d.OpeningPrice ");
            sb.AppendLine("     , d.LowPrice ");
            sb.AppendLine("     , d.HighPrice ");
            sb.AppendLine("     , d.ClosingPrice ");
            sb.AppendLine("  FROM  ");
            sb.AppendLine("       dollaryen d ");
            sb.AppendLine(" WHERE d.ExchangeDate BETWEEN :BeginDate AND :EndDate ");
            sb.AppendLine(" ORDER BY  ");
            sb.AppendLine("       d.ExchangeDate ");

            List<DollarYenEntity> ListDollarYen = new List<DollarYenEntity>();

            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                // データを取得してインスタンス変数に保持
                ListDollarYen = db.DBSelect<DollarYenEntity>(sb.ToString(), new { BeginDate = beginDate, EndDate = endDate });
            }

            return ListDollarYen;
        }

    }
}
