using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;
using System.Windows.Automation;
using OpenQA.Selenium.Winium;



namespace _011Winium.Cruciatus試し
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var calc = new Winium.Cruciatus.Application(@"C:\dev\svn\trunk\Trash\Trash\011Winium.Cruciatus試し\TestForm\bin\Debug\TestForm.exe");
            //calc.Start();
            //var winFinder = By.Name("Form1").AndType(ControlType.Window);
            //var win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);


            ////電卓の'5','6','7'ボタンクリック
            ////AutomationId指定
            ////win.FindElementByName("button1").Click();

            //win.FindElementByUid("button1").Click();
            //win.FindElementByUid("button2").Click();
            //win.FindElementByUid("button3").Click();

            ////Console.Write("Press any key to continue . . . ");
            ////Console.ReadKey(true);

            var calc = new Winium.Cruciatus.Application("C:/windows/system32/calc.exe");
            calc.Start();

            var winFinder = By.Name("電卓").AndType(ControlType.Window);
            var win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);
            //var menu = win.FindElementByUid("Menubar").ToMenu();

            //menu.SelectItem("関数電卓");
            //menu.SelectItem("履歴");

            win.FindElementByUid("132").Click(); // 2
            //win.FindElementByUid("93").Click(); // +
            //win.FindElementByUid("134").Click(); // 4
            //win.FindElementByUid("97").Click(); // ^
            //win.FindElementByUid("138").Click(); // 8
            //win.FindElementByUid("121").Click(); // =

            //calc.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var options = new DesktopOptions();
            options.ApplicationPath = @"C:\Windows\System32\notepad.exe";
            //Winium.Desktop.Driver.exeの場所指定
            WiniumDriver driver = new WiniumDriver(@"C:\dev\svn\trunk\Trash\Trash\011Winium.Cruciatus試し\Winium.Desktop.Driver", options);
            driver.FindElementByClassName("Edit").SendKeys("Hello World.");




        }
    }
}
