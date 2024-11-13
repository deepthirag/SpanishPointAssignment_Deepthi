using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME_Project
{
    internal class Helper : TestExecution
    {
       // public static IWebDriver driver;

        internal static IWebElement WaitForElementPresent(IWebDriver driver, By by, int timeoutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            //throw new NotImplementedException();
        }

        internal static bool URLMatches(IWebDriver driver, String url, int timeoutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(url));
            //throw new NotImplementedException();
        }
    }
}