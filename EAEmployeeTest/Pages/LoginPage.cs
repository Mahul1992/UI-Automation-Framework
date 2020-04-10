using EAAutoFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAEmployeeTest.Pages
{
   public class LoginPage: BasePage
    {
        
        [FindsBy(How = How.XPath, Using = "//a[text()='Login']")]
        IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "user_email")]
        IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "commit")]
        IWebElement btnLogin { get; set; }

        public void Login(string UserName, String Password)
        {
            txtUserName.SendKeys(UserName);
            txtPassword.SendKeys(Password);
            btnLogin.Click();
        }

        public void ClickLoginLink()
        {
            lnkLogin.Click();
        }
    }
}
