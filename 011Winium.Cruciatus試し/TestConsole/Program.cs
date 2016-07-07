using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Winium.Cruciatus.Application(@"C:\Windows\System32\calc.exe");
            calc.Start();
            var winFinder = By.Name("電卓").AndType(ControlType.Window);
            var win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);

            //電卓の'5','6','7'ボタンクリック
            //AutomationId指定
            win.FindElementByUid("num5Button").Click();
            win.FindElementByUid("num6Button").Click();
            win.FindElementByUid("num7Button").Click();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
