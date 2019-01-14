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
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData newDataC)
        {
            meneger.Navigator.GoToHomePage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contactForMod = new ContactData("For del");
                Create(contactForMod);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            InitContactModification();
            FillContactForm(newDataC);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            meneger.Navigator.GoToHomePage();

            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contactForMod = new ContactData("For del");
                Create(contactForMod);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            SelectContact(p);
            Delete();
            AcceptAllert();
            ReturnToHomePage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return this;
        }


        public ContactHelper Delete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[4]/form[2]/table[1]/tbody[1]/tr[2]/td[8]/a[1]")).Click();
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
            contactCache = null;
            return this;
        }
        public ContactHelper AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                meneger.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table//tbody//tr//td[text()][position()=1 or position()=2]"));

                var arrayElements = elements.AsEnumerable().ToArray();

                for (int index = 0; index < arrayElements.Length; index += 2)
                {
                    var FirstLast = new ContactData(arrayElements[index + 1].Text);
                    FirstLast.Lastname = arrayElements[index].Text;
                    contactCache.Add(FirstLast);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table//tbody//tr//td[text()][1]")).Count;
        }
    }
}
