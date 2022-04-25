using EPAMTraining;
using Exercise_Epam.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Exercise_Epam.POM
{
    class SelectMenu
    {
        IWebDriver driver;
        public SelectMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        Helper helper = new Helper();
        private IWebElement Widget => driver.FindElement(By.XPath("//*[text() ='Widgets']"));
        private IWebElement SelMenu => driver.FindElement(By.XPath("//*[@class='text' and text() = 'Select Menu']"));
        private IWebElement Interactions => driver.FindElement(By.XPath("//*[text() ='Interactions']"));
        private IWebElement SelDropDownOld => driver.FindElement(By.XPath("//*[@id='oldSelectMenu']"));
        private IWebElement StandardDropDown => driver.FindElement(By.XPath("//*[@id='cars']"));

        public void NavigateToSelectMenu()
        {
            BrowserMethods.ActionMoveToElement(Interactions);
            helper.clickbutton(Widget);
            Thread.Sleep(3000);
            helper.clickbutton(SelMenu);
        }

        public void waitcondition()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//*[@class='text' and text() = 'Select Menu']")));
        }

        public void SelectValueFromSelectMenu()
        {
            helper.selectDropDown(SelDropDownOld, "Black");
            helper.selectDropDown(StandardDropDown, 3);
        }
    }
}
