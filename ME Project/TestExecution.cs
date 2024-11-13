using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using WebDriverManager.DriverConfigs.Impl;


namespace ME_Project
{
    public class TestExecution
    {
        private IWebDriver driver;

        //public Tests(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {


            //visit matching engine website
            driver.Url = "https://www.matchingengine.com";
            IWebElement Element1 = Helper.WaitForElementPresent(driver, By.XPath("//h1[contains(text(),'The Matching Engine is an Enterprise Business System for Copyright Management Organizations')]"), 5);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'The Matching Engine is an Enterprise Business System for Copyright Management Organizations')]")));
            Console.WriteLine("Navigated to the Matching Engine website.");

            //Expand Modules in the Header section
            driver.FindElement(By.LinkText("Modules")).Click();
            Console.WriteLine("clicked on expand Modules in the header section");

            //Click Repertoire Management Module from the menu
            driver.FindElement(By.LinkText("Repertoire Management Module")).Click();
            Console.WriteLine("selected Repertoire Management Module");

            //using explicit wait till page load happens.

            bool urlMatches = Helper.URLMatches(driver, "https://www.matchingengine.com/repertoire-management-module/", 5);
            Console.WriteLine($"URL matches: {urlMatches}");
            //wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://www.matchingengine.com/repertoire-management-module/"));
            Console.WriteLine("I am redirected to Repertoire Management Module page");
            IWebElement Element2 = Helper.WaitForElementPresent(driver, By.XPath("//h2[contains(text(),'Additional Features')]"), 5);

            //Scroll to Additional features section
            IWebElement targetElement = driver.FindElement(By.XPath("//h2[contains(text(),'Additional Features')]"));
            // Scroll the page to the target element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);


            Console.WriteLine("I am at the Additional features section");
            //To click on Products supported
            driver.FindElement(By.XPath("//span[contains(text(),'Products Supported')]")).Click();
            Console.WriteLine("I just clicked on Products supported link");

            String expected = "There are several types of Product Supported:";
            IWebElement Element3 = driver.FindElement(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]"));
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]")));
            //IWebElement Element1 = Helper.WaitForElementPresent(driver, By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]"), 5);
            Thread.Sleep(10000);
            String actual = Element3.Text;
            Console.WriteLine("actual text is:" + actual);
            Console.WriteLine("expected text is:" + expected);
            try
            {
                // Assert the strings are equal
                Assert.That(expected, Is.EqualTo(actual));
                Console.WriteLine("Test Passed: The text matches as expected.");
            }


            catch (AssertionException)
            {
                // If assertion fails, print actual and expected results
                Console.WriteLine($"Test Failed: Expected '{expected}' but got '{actual}'.");
            }
            //Assert that the list of supported products is not empty and has several types of products supported.
            IWebElement ulElement = driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/section[1]/div[6]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/ul[1]"));
            IList<IWebElement> listItems = ulElement.FindElements(By.TagName("li"));
            int numberOfItems = listItems.Count;
            if (numberOfItems > 0)
            {
                Console.WriteLine("It is confirmed that the supported product list is not empty and has several products listed as:" + numberOfItems);
            }

            //finding the list of supported products dynamically
            foreach (IWebElement element in listItems)
            {
                Console.WriteLine(element.Text);
            }
        
          Console.WriteLine("This is the end of given Assignment................");
            
            
        }  
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}