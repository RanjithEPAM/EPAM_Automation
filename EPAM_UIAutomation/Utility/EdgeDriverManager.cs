using EPAMTraining.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_UIAutomation.Utility
{
    public class EdgeDriverManager : DriverManager
    {
        public IWebDriver driver;
        protected override IWebDriver createdriver()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
