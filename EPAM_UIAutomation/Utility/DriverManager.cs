using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMTraining.Utility
{
    public abstract class DriverManager
    {
        protected IWebDriver driver;
        protected abstract IWebDriver createdriver();

        public void quitdriver()
        {
            if(driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public IWebDriver getdriver()
        {
            if(driver == null)
            {
                driver = createdriver();
            }
            return driver;
        }
    }
}