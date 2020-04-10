using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAEmployeeTest.Pages
{
    public class CoursesPage:BasePage
    {
        [FindsBy(How = How.PartialLinkText, Using = "Courses")]
        public IWebElement lnk { get; set; }

        public CoursesPage ClickCoursePage()
        {
            lnk.Click();
            return new CoursesPage();
        }
    }


}
