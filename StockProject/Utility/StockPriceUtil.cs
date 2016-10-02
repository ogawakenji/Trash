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



    }
}
