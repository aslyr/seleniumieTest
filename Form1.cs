using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using AslyrHelper;
namespace ie自动化处理
{
    public partial class Form1 : Form
    {
        private static IFreeSql freeSql;
        private static IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   InternetExplorerOptions internetExplorerOptions=new InternetExplorerOptions();
            Proxy proxy = new Proxy()
            {
                HttpProxy = "117.159.12.214",
                
                
            };

            internetExplorerOptions.Proxy = proxy;
            
            driver=new InternetExplorerDriver(internetExplorerOptions);
            
            driver.Navigate().GoToUrl("http://10.232.0.7:8888/index.do");
            freeSql= FreeSqlHelper.GetIFreeSql(@"E:\AllCodeProject\WpfSeasonUpload\WpfSeasonUpload\bin\x64\Release\病历记录.db");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                driver.SwitchTo().Frame( Convert.ToInt32(frameNum.Text));
                textBox2.AppendText(driver.PageSource);
            }
            catch (Exception exception)
            {
                textBox2.AppendText(exception.Message);
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            driver.Close();
            driver.Quit();
        }
    }
}
