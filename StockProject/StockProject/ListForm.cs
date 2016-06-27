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


                _ListDetail = db.DBSelect<ListEntity>(sb.ToString());



            }

            this.listEntityBindingSource.DataSource = _ListDetail;




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
        }
    }
}
