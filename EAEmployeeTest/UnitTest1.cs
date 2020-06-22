using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using EATestProject.Base;
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
    class UnitTest1: HookInitialize
    {
        //string url = "https://rahulshettyacademy.com/#/index";
        string practiceURL = "https://rahulshettyacademy.com/AutomationPractice/";
        [Test]
        public void Login()
        {
           
            string fileName = Environment.CurrentDirectory.ToString() + "/Data/Login.xls";
            ExcelHelpers.PopulateInCollection(fileName);
            
            //DriverContext.Driver = new ChromeDriver(driverPath);
            // DriverContext.Driver.Url = "https://rahulshettyacademy.com/#/index";


            
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(0,"UserName"), ExcelHelpers.ReadData(0, "Password"));
        }

        
       
        [TearDown]
        public void TearDown()
        {
            DriverContext.Driver.Quit();
        }

        [Test]
        public void TableOperation()
        {
            LogHelpers.CreateLogFile();            
          
            LogHelpers.Write("Open the Browser.");
            DriverContext.Browser.GoToURL(practiceURL);
            LogHelpers.Write("Navigated to URL.");
            CurrentPage = GetInstance<PracticePage>();
            var coursesList = CurrentPage.As<PracticePage>().GetCourses();
            HtmlTableHelper.ReadTable(coursesList);
            // HtmlTableHelper.PerformActionOnCell("2", "Price", "0");
            var TableValues = HtmlTableHelper.GetAllTableValues();                    

        }
    }
}
