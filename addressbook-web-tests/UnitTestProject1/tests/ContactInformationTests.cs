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
    public class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void TestContactInformaion()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Lastname, fromForm.Lastname);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

            // verifications

        }

        [Test]
        public void TestContactInformaionFromViewForm()
        {
            ContactData fromView = app.Contacts.GetContactInformationFromViewForm(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromView, fromForm);
            Assert.AreEqual(fromView.FML, fromForm.FML);
            Assert.AreEqual(fromView.Address, fromForm.Address);
            Assert.AreEqual(fromView.Home, fromForm.Home);
            Assert.AreEqual(fromView.Mobile, fromForm.Mobile);
            Assert.AreEqual(fromView.Work, fromForm.Company);
            // verifications

        }
    }
}
