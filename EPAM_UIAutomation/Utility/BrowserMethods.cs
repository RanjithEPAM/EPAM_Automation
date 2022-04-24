using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTraining
{
    public class BrowserMethods
    {
        public static IWebDriver Driver;
        
        public BrowserMethods(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver NavigateToGivenURL(string url)
        {

            Driver.Navigate().GoToUrl(url);
            return Driver;
        }
        public static void Scroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
        }

        public static void ActionMoveToElement(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public void roughmethod()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            
        }
        public void capturescreenshot()
        {
            
        }

        public string Gettimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static void cleanup()
        {
            Driver.Close();
            Driver.Quit();
        }

        public static void switchToFrame()
        {
            Driver.SwitchTo().Frame("google_ads_iframe_/21849154601,22343295815/Ad.Plus-Anchor_0");
        }

        public static void waitconditionbyxpath(string elemvalue)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));

            Func<IWebDriver, IWebElement> waitforelement = new Func<IWebDriver, IWebElement>((IWebDriver web) =>
            {

                IWebElement element = web.FindElement(By.XPath(elemvalue));
                if (element.Enabled)
                {
                    return element;
                }
                return null;
            });
        }
    }
}