using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            WebUtil wu = new WebUtil();
            wu.OpenSite("http://wenzhaizhongwen.zazhi.com/");
            wu.CollectDataForItems();
            //var s = WebUtil.GetPageContent("http://wenzhaizhongwen.zazhi.com/");
            //var r1 = WebUtil.Filter1(s);
            //r1.ForEach(x => Console.WriteLine(x));
        }
    }
}
