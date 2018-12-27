using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationMeneger meneger) : base(meneger)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            meneger.Navigator.GoToHomePage();
            meneger.Navigator.GoToAddNewContact();
            FillContactForm(contact);
            SubmitAccountCreation();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newDataC)
        {
            meneger.Navigator.GoToHomePage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contactForMod = new ContactData("For del");
                Create(contactForMod);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            InitContactModification(v);
            FillContactForm(newDataC);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove()
        {
            meneger.Navigator.GoToHomePage();

            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contactForMod = new ContactData("For del");
                Create(contactForMod);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            SelectContact();
            Delete();
            AcceptAllert();
            return this;
        }

        public ContactHelper Delete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id="+id+"']")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Select(By.Name("bday"),contact.Bday);
            Select(By.Name("bmonth"), contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            Select(By.Name("aday"), contact.Aday);
            Select(By.Name("amonth"), contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Select(By.Name("new_group"), contact.Newgroup);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }


        public ContactHelper SubmitAccountCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])")).Click();
            return this;
        }
    }
}
