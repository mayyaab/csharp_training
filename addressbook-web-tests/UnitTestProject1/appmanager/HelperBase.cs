using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationMeneger meneger;
        protected IWebDriver driver;

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Select(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                new SelectElement(driver.FindElement(locator)).SelectByText(text);
                driver.FindElement(locator).Click();
            }
        }

        public HelperBase(ApplicationMeneger meneger)
        {
            this.meneger = meneger;
            driver = meneger.Driver;
        }
    }
}