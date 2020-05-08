using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace EAEmployeeTest
{
    [TestFixture]
    class UnitTest1:Base
    {
        string url = "https://rahulshettyacademy.com/#/index";
        [Test]
        public void Login()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "/Data/Login.xls";
            ExcelHelpers.PopulateInCollection(fileName);
           //DriverContext.Driver = new ChromeDriver(driverPath);
            // DriverContext.Driver.Url = "https://rahulshettyacademy.com/#/index";
            OpenBrowser(BrowserType.Chrome);
            DriverContext.Browser.GoToURL(url);
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(0,"UserName"), ExcelHelpers.ReadData(0, "Password"));


        }

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
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
        public void Test2()
        {

        }
        [TearDown]
        public void TearDown()
        {
            DriverContext.Driver.Quit();
        }
    }
}
