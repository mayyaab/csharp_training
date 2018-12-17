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

        public HelperBase(ApplicationMeneger meneger)
        {
            this.meneger = meneger;
            driver = meneger.Driver;
        }
    }
}