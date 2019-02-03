using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            InitContactModification(0);
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

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            //driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[4]/form[2]/table[1]/tbody[1]/tr[2]/td[8]/a[1]")).Click();
            //return this;
        }

        public void InitContactView(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
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
            Select(By.Name("bday"), contact.Bday);
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

        private const string NameToFind = "//select[@name='amonth']";
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                meneger.Navigator.GoToHomePage();
                ICollection<IWebElement> elements =
                    driver.FindElements(By.XPath("//table//tbody//tr//td[text()][position()=1 or position()=2]"));

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

        public ContactData GetContactInformationFromEditForm(int index)
        {
            meneger.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthdayDay = driver.FindElement(By.XPath("//select[@name='bday']")).GetAttribute("value");
            string birthdayMonth = driver.FindElement(By.Name("//select[@name='bmonth']")).GetAttribute("value");
            string birthdayYear = driver.FindElement(By.Name("//*[@id='content']//input[19]")).GetAttribute("value");
            string anniversaryDay = driver.FindElement(By.XPath("//select[@name='aday']")).GetAttribute("value");
            string anniversaryMonth = driver.FindElement(By.Name("//select[@name='amonth']")).GetAttribute("value");
            string anniversaryYear = driver.FindElement(By.Name("//*[@id='content']//input[20]")).GetAttribute("value");



            return new ContactData(firstName)
            {
                Lastname = lastName,
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Homepage = homepage,
                Bday = birthdayDay,
                Bmonth = birthdayMonth,
                Byear = birthdayYear,
                Aday = anniversaryDay,
                Amonth = anniversaryMonth,
                Ayear = anniversaryYear,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }



        public ContactData GetContactInformationFromTable(int index)
        {
            meneger.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName)
            {
                Lastname = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

            };
        }

        public ContactData GetContactInformationFromViewForm(int index)
        {
            meneger.Navigator.GoToHomePage();
            InitContactView(0);
            string fml = driver.FindElement(By.XPath("//*[@id='content']/b")).Text;//done
            string nickname = driver.FindElement(By.XPath("//*[@id='content']/text()[2]")).Text;//done
            string title = driver.FindElement(By.XPath("//*[@id='content']/i[1]")).Text; //done
            string company = driver.FindElement(By.XPath("//*[@id='content']/text()[3]")).Text; //done
            string address = driver.FindElement(By.XPath("//*[@id='content']/text()[4]")).Text;
            string homePhone = driver.FindElement(By.XPath("//*[@id='content']/text()[6]")).Text;
            string mobilePhone = driver.FindElement(By.XPath("//*[@id='content']/text()[7]")).Text;
            string workPhone = driver.FindElement(By.XPath("//*[@id='content']/text()[8]")).Text;
            string fax = driver.FindElement(By.XPath("//*[@id='content']/text()[9]")).Text;
            string email = driver.FindElement(By.XPath("//*[@id='content']/a[1]]")).Text;
            string email2 = driver.FindElement(By.XPath("//*[@id='content']/a[2]")).Text;
            string email3 = driver.FindElement(By.XPath("//*[@id='content']/a[2]")).Text;
           

            return new ContactData()
            {
                FML = fml,
                Nickname = nickname,
                Title = title,
                Company = company,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public int GetNumberOfSearchResult()
        {
            meneger.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }


    }
}
