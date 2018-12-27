using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests

{
    public class ApplicationMeneger
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationMeneger> app = new ThreadLocal<ApplicationMeneger>();

        private ApplicationMeneger()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationMeneger() //диструктор
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        //для создания одновременного запуска тестов без постоянного запуска браузера и могутзапускаться параллельно
        public static ApplicationMeneger GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationMeneger newInstance = new ApplicationMeneger();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
         
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigator
        {
            get { return navigator; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }


    }
}
