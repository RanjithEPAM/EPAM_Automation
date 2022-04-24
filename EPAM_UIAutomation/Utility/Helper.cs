using Microsoft;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_Epam.Utility
{
    interface IHelper
    {
        public void selectDropDown(IWebElement element, int index);
        public void selectDropDown(IWebElement element, string drpOption);
        public void EnterGivenText(IWebElement element, string text);
        public void clickbutton(IWebElement Element);
        public void VerifyElementPresence(IWebElement element);
        public void VerifyContainsText(IWebElement element, string text);
    }

    public class Helper : IHelper
    {
        public void selectDropDown(IWebElement element, int index)
        {
            var sel = new SelectElement(element);
            sel.SelectByIndex(index);
        }
        public void selectDropDown(IWebElement element, string drpOption)
        {
            var sel = new SelectElement(element);
            sel.SelectByText(drpOption);
        }

        public void EnterGivenText(IWebElement element, string text)
        {
            try
            {
                Assert.IsTrue(element.Enabled);
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                throw new Exception("Exception is - " + e);
            }
        }

        public void clickbutton(IWebElement Element)
        {
            try
            {
                Element.Click();
            }
            catch (Exception e)
            {
                throw new Exception("Exception is - " + e);
            }
        }

        public void VerifyElementPresence(IWebElement element)
        {
            try
            {
                Assert.IsTrue(element.Displayed);
            }
            catch (Exception e)
            {
                throw new Exception("Exception is - " + e);
            }
        }

        public void VerifyContainsText(IWebElement element, string text)
        {
            string ss = element.Text;
            Assert.IsTrue(ss.Contains(text));
        }
    }
}