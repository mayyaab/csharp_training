using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("aaa");
            contact.Lastname = "bbb";
            contact.Middlename ="ccc";
            contact.Nickname = "ddd";
            contact.Title = "eee";
            contact.Company = "qqq";
            contact.Address = "www";
            contact.Home = "eee";
            contact.Mobile = "111";
            contact.Work = "222";
            contact.Fax = "333";
            contact.Email = "444";
            contact.Email2 = "555";
            contact.Email3 = "666";
            contact.Homepage = "123";
            contact.Bday = "1";
            contact.Bmonth = "June";
            contact.Byear = "1990";
            contact.Aday = "1";
            contact.Amonth = "June";
            contact.Ayear = "2000";
            contact.Newgroup = "aaa";
            contact.Address2 = "34";
            contact.Phone2 = "65";
            contact.Notes = "234";

//            List<ContactData> oldContact = app.Contacts.GetContactList();

            app.Contacts.Create(contact);


        }
    }
}
