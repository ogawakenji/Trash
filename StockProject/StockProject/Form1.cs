using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Sgml;
using System.Xml.Linq;

namespace StockProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int getHoge()
        {
            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Utility.HtmlUtil htmlUtil = new Utility.HtmlUtil();
            this.textBox1.Text = htmlUtil.GetHtml(this.textBox2.Text);


         




        }


        static async Task<string> GetWebPageAsync(Uri uri)
        {
            using (HttpClient client = new HttpClient())
            {
                // ユーザーエージェント文字列をセット（オプション）
                client.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");

                // 受け入れ言語をセット（オプション）
                client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");

                // タイムアウトをセット（オプション）
                client.Timeout = TimeSpan.FromSeconds(10.0);

                try
                {
                    // Webページを取得するのは、事実上この1行だけ
                    return await client.GetStringAsync(uri);
                }
                catch (HttpRequestException e)
                {
                    // 404エラーや、名前解決失敗など
                    Console.WriteLine("\n例外発生!");
                    // InnerExceptionも含めて、再帰的に例外メッセージを表示する
                    Exception ex = e;
                    while (ex != null)
                    {
                        Console.WriteLine("例外メッセージ: {0} ", ex.Message);
                        ex = ex.InnerException;
                    }
                }
                catch (TaskCanceledException e)
                {
                    // タスクがキャンセルされたとき（一般的にタイムアウト）
                    Console.WriteLine("\nタイムアウト!");
                    Console.WriteLine("例外メッセージ: {0} ", e.Message);
                }
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xml;
            using (var sgml = new SgmlReader() { Href = this.textBox2.Text ,IgnoreDtd = true  })
            {
                xml = XDocument.Load(sgml); // たった3行でHtml to Xml
            }

            var ns = xml.Root.Name.Namespace;
            var query = xml.Descendants(ns + "table")
                .Last()
                .Descendants(ns + "tr")
                .Skip(1) // テーブル一行目は項目説明なので飛ばす
                .Select(el => el.Elements(ns + "td").ToList())
                .Select(es => new
                {
                    Title = es.First().Value,
                    ReleaseDate = es.Last().Value
                });

            // 書き出し
            foreach (var item in query)
            {
                Console.WriteLine(item.Title + " - " + item.ReleaseDate);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            XDocument xml;

            try
            {
                Utility.HtmlUtil htmlUtil = new Utility.HtmlUtil();
                xml = htmlUtil.ParseHtml(this.textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var ns = xml.Root.Name.Namespace;

            var q =
                from s in xml.Descendants(ns + "tr")
                select s;

            foreach (var s in q )
            {
                //Console.WriteLine(s.Value );
                foreach (var s2 in s.Descendants())
                {
                    Console.WriteLine(s2.Value );
                }

            }


            Utility.FinanceUtil finance = new Utility.FinanceUtil();
            dividendEntityBindingSource.DataSource = finance.GetDividendEntityList();



        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            var keyCode = (Keys)(msg.WParam.ToInt32() &
                                  Convert.ToInt32(Keys.KeyCode));
            if ((msg.Msg == WM_KEYDOWN && keyCode == Keys.A)
                && (ModifierKeys == Keys.Control)
                && textBox1.Focused)
            {
                textBox1.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Utility.FinanceUtil finance = new Utility.FinanceUtil();
            stockPriceEntityBindingSource.DataSource = finance.GetStockPriceEntityList(Convert.ToInt32(txtStockCode.Text)) ;

            profileEntityBindingSource .DataSource = finance.GetProfileEntityList(Convert.ToInt32(txtStockCode.Text));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Utility.DbUtil db = new Utility.DbUtil())
            {
                db.DBUpdate("create table personal(id integer, name text);", null);


            }
        }
    }



}
