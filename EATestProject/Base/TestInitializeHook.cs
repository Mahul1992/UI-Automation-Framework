using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook:Base
    {
        public readonly BrowserType Browser;
        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }
        public void InitializeSetting()
        {
            ConfigReader.SetFrameworkSetting();
            LogHelpers.CreateLogFile();
            OpenBrowser(Browser);
            LogHelpers.Write("Initialized Framework");
        }
        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    //string curreDir = Environment.CurrentDirectory;
                    //string driverPath = @curreDir + "//DriverExe";
                    DriverContext.Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    DriverContext.Driver.Manage().Window.Maximize();
                    break;

            }


        }

        public  virtual void NavigateSite()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.Write("Opened the browser.");
        }
    }
}
