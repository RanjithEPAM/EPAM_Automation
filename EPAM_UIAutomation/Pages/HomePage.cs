using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise_Epam.Utility;

namespace Exercise_Epam.POM
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        Helper helper = new Helper();

        private IWebElement Elements => driver.FindElement(By.XPath("//*[@class='card-body']//*[text()='Elements']"));

        public void ElementsOpt()
        {
            helper.clickbutton(Elements);
        }
    }
}