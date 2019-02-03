﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 7; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(20),
                    Middlename = GenerateRandomString(20)
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("aaa");
            //contact.Lastname = "bbb";
            //contact.Middlename ="ccc";
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

            List<ContactData> oldContact = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContact.Count+1, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactsList();

            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
