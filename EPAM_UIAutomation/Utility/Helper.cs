using Microsoft;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


        public void LinqExample()
        {
            List<string> names = new List<string>(){ "Training", "Exercise", "Learning", "Coaching"};
            Console.WriteLine("LINQ Example Start");
            IEnumerable result1 = names.Where(x => x.Contains("a")).Select(x => x);
            foreach (string item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
            Console.WriteLine("LINQ Sorting");

            IEnumerable aresult1 = names.OrderBy(x => x);
            foreach (string item in aresult1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("LINQ Example END");
        }


        public delegate void addnum(int a, int b);
        public delegate void subnum(int a, int b);

        public void sum(int a, int b)
        {
            Console.WriteLine("(100 + 40) = {0}", a + b);
        }

        public void subtract(int a, int b)
        {
            Console.WriteLine("(100 - 60) = {0}", a - b);
        }

        public void DelegateExample()
        {
            Helper obj = new Helper();
            addnum del_obj1 = new addnum(obj.sum);
            subnum del_obj2 = new subnum(obj.subtract);
            del_obj1(100, 40);
            del_obj2(100, 60);
        }
    }
}