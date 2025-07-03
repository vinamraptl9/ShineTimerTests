using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineTimerTests
{
    public static class ExtendedCustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
    }
}
