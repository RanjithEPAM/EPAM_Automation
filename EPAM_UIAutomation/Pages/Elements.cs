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
        Hooks Hooks = new Hooks();
        public Elements(IWebDriver driver) 
        {
            this.driver = driver;
        }
        Helper helper = new Helper();
       
        private IWebElement ElementsHeader => driver.FindElement(By.XPath("//*[@class='main-header' and text()='Elements']"));

        public IWebElement TextBoxButton => driver.FindElement(By.XPath("//span[@class='text' and text()='Text Box']"));

        public IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));

        public IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));

        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));

        public IWebElement OutputScreen => driver.FindElement(By.XPath("//*[@class='border col-md-12 col-sm-12']"));

        public IWebElement Adclose => driver.FindElement(By.XPath("//*[@id='close-fixedban']"));

        public IWebElement Enter_UserDetails(string val) => driver.FindElement(By.XPath($"//input[@id='{val}']"));
        
        public IWebElement Disp_UserDetails(string address) => driver.FindElement(By.XPath($"//p[@id='{address}']"));

        public void VerifyElementHeader()
        {
            helper.VerifyElementPresence(ElementsHeader);
        }

        public void NavigateToRegisterScreen()
        {
            helper.clickbutton(TextBoxButton);
            Hooks.ReportLogs("Navigated to Register Screen");
        }

        public void EnterRegistrationDetails(string user, string email, string currAddress, string PermAddress)
        {
            helper.EnterGivenText(Enter_UserDetails("userName"), user);
            Hooks.ReportLogs("Entered Username");
            helper.EnterGivenText(Enter_UserDetails("userEmail"), email);
            Hooks.ReportLogs("Entered email");
            helper.EnterGivenText(CurrentAddress, currAddress);
            Hooks.ReportLogs("Entered CurrentAddress");
            helper.EnterGivenText(PermanentAddress, PermAddress);
            Hooks.ReportLogs("Entered PermanentAddress");
            helper.clickbutton(Adclose);
            BrowserMethods.Scroll();
            helper.clickbutton(SubmitButton);
            Hooks.ReportLogs("Clicked submit button");
        }
        public void VerifyRegisteredSection()
        {
            helper.VerifyElementPresence(OutputScreen);
        }

        public void VerifySubmittedData(string name, string email, string currAddress, string PermAddress)
        {
            helper.VerifyContainsText(Disp_UserDetails("name"), name);
            Hooks.ReportLogs("Verified Username displayed in the screen");
            helper.VerifyContainsText(Disp_UserDetails("email"), email);
            Hooks.ReportLogs("Verified Email id displayed in the screen");
            helper.VerifyContainsText(Disp_UserDetails("currentAddress"), currAddress);
            Hooks.ReportLogs("Verified current address displayed in the screen");
            helper.VerifyContainsText(Disp_UserDetails("permanentAddress"), PermAddress);
            Hooks.ReportLogs("Verified permanent address displayed in the screen");
        }

        public void CloseAds()
        {
            helper.clickbutton(Adclose);
            Hooks.ReportLogs("Closed Ads window successfully");
        }

        public void CaptureAllLinks()
        {
            IList<IWebElement> links = driver.FindElements(By.XPath("//a"));
            foreach (IWebElement link in links)
            {
                Console.WriteLine("link - "+ link.GetAttribute("href"));
            }
            helper.LinqExample();
            helper.DelegateExample();
        }
    }
}