using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise_Epam.Utility;
using EPAMTraining;

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
        Hooks Hooks = new Hooks();

        private IWebElement Elements => driver.FindElement(By.XPath("//*[@class='card-body']//*[text()='Elements']"));

        public void ElementsOpt()
        {
            helper.clickbutton(Elements);
            Hooks.ReportLogs("Clicked on Elements webelement");
        }
    }
}