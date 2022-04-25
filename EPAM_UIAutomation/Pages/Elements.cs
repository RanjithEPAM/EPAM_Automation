using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise_Epam.Utility;
using System.Threading;
using EPAMTraining;
using EPAMTraining.Utility;

namespace EPAMTraining.POM
{
    public class Elements
    {
        IWebDriver driver;
        public Elements(IWebDriver driver) 
        {
            this.driver = driver;
        }
        Helper helper = new Helper();
       
        private IWebElement ElementsHeader => driver.FindElement(By.XPath("//*[@class='main-header' and text()='Elements']"));

        public IWebElement TextBoxButton => driver.FindElement(By.XPath("//span[@class='text' and text()='Text Box']"));

        public IWebElement UserName => driver.FindElement(By.XPath("//input[@id='userName']"));

        public IWebElement UserEmail => driver.FindElement(By.XPath("//input[@id='userEmail']"));

        public IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));

        public IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));

        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));

        public IWebElement OutputScreen => driver.FindElement(By.XPath("//*[@class='border col-md-12 col-sm-12']"));

        public IWebElement Adclose => driver.FindElement(By.XPath("//*[@id='close-fixedban']"));

        public IWebElement Disp_UserName => driver.FindElement(By.XPath("//p[@id='name']"));
        public IWebElement Disp_UserEmail => driver.FindElement(By.XPath("//p[@id='email']"));
        public IWebElement Disp_CurrentAddress => driver.FindElement(By.XPath("//p[@id='currentAddress']"));
        public IWebElement Disp_PermanentAddress => driver.FindElement(By.XPath("//p[@id='permanentAddress']"));

        public void VerifyElementHeader()
        {
            helper.VerifyElementPresence(ElementsHeader);
        }

        public void NavigateToRegisterScreen()
        {
            helper.clickbutton(TextBoxButton);
        }

        public void EnterRegistrationDetails(string user, string email, string currAddress, string PermAddress)
        {
            helper.EnterGivenText(UserName, user);
            helper.EnterGivenText(UserEmail, email);
            helper.EnterGivenText(CurrentAddress, currAddress);
            helper.EnterGivenText(PermanentAddress, PermAddress);
            helper.clickbutton(Adclose);
            BrowserMethods.Scroll();
            helper.clickbutton(SubmitButton);
        }
        public void VerifyRegisteredSection()
        {
            helper.VerifyElementPresence(OutputScreen);
        }

        public void VerifySubmittedData(string name, string email, string currAddress, string PermAddress)
        {
            helper.VerifyContainsText(Disp_UserName, name);
            helper.VerifyContainsText(Disp_UserEmail, email);
            helper.VerifyContainsText(Disp_CurrentAddress, currAddress);
            helper.VerifyContainsText(Disp_PermanentAddress, PermAddress);
        }

        public void CloseAds()
        {
            helper.clickbutton(Adclose);
        }

        public void CaptureAllLinks()
        {
            IList<IWebElement> links = driver.FindElements(By.XPath("//a"));
            foreach (IWebElement link in links)
            {
                Console.WriteLine("link - "+ link.GetAttribute("href"));
            }
        }
    }
}