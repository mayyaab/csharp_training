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
    public class LoginHelper : HelperBase
    {


    public LoginHelper(ApplicationMeneger meneger)
        :base(meneger)
    {
    }

    public void Login(AccountData account)
    {
        //если залогинены под нужным пользователем то ничего не происходит
        if (IsLoggedIn())
        {
            if (IsLoggedIn(account))
            {
                return;
            }
            //если залогинены, но тот пользователь который не нужен  - 
            Logout();
        }
        //если не были залогинены тогда логинемся
        Type(By.Name("user"), account.Username);
        Type(By.Name("pass"), account.Password);
        driver.FindElement(By.XPath("//input[@value='Login']")).Click();
    }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
            throw new NotImplementedException();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                   && GetLoggetUserName() == account.Username;
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            //вырезаем текст
            return text.Substring(1, text.Length - 2);

        }
    }
}
