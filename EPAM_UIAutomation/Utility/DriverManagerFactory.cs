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
        public static DriverManager getManager(DriverType type)
        {
            DriverManager driverManager = null;

            switch (type)
            {
                case DriverType.CHROME:
                    driverManager = new ChromeDriverManager();
                    break;

                case DriverType.IE:
                    //driverManager = new InternetExplorerDriver();
                    break;

                default:
                    driverManager = null;
                    break;
            }
            return driverManager;
        }
    }
}