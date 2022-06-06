using EPAM_UIAutomation.Utility;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMTraining.Utility
{
    public class DriverManagerFactory
    {
        public static DriverManager getManager(string browser)
        {
            DriverManager driverManager = null;

            switch (browser)
            {
                case "CHROME":
                    driverManager = new ChromeDriverManager();
                    break;

                case "EDGE":
                    driverManager = new EdgeDriverManager();
                    break;

                case "Firefox":
                    driverManager = new FirefoxDriverManager();
                    break;
            }
            return driverManager;
        }
    }
}