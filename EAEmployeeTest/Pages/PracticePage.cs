using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAEmployeeTest.Pages
{
   public class PracticePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "product")]
        IWebElement tblCourses { get; set; }


        public IWebElement GetCourses()
        {
            return tblCourses;
        }
    }
}
