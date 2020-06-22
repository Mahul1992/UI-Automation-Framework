using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static void SelectDropdownList(this IWebElement element, string Value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(Value);
        }
        public static String GetSelectedDropdown(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            return select.AllSelectedOptions.First().ToString();
        }
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            return select.AllSelectedOptions;
        }
        public static void AssertElementPresent(this IWebElement element, string Value)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception("Element not Present: " + element);
            }
        }

        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Build().Perform();
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
