using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContact = app.Contacts.GetContactsList();

            app.Contacts.Remove(0);

            List<ContactData> newContact = app.Contacts.GetContactsList();

            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
