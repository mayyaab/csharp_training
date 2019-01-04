using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("990");
            newDataC.Lastname = "765";
            newDataC.Middlename = "ccc";
            newDataC.Nickname = "ddd";
            newDataC.Title = "eee";
            newDataC.Company = "qqq";
            newDataC.Address = "www";
            newDataC.Home = "eee";
            newDataC.Mobile = "mobile";
            newDataC.Work = "222";
            newDataC.Fax = "333";
            newDataC.Email = "444";
            newDataC.Email2 = "555";
            newDataC.Email3 = "666";
            newDataC.Homepage = null;
            newDataC.Bday = "1";
            newDataC.Bmonth = "June";
            newDataC.Byear = "1990";
            newDataC.Aday = "1";
            newDataC.Amonth = "June";
            newDataC.Ayear = "2000";
            newDataC.Newgroup = null;
            newDataC.Address2 = "34";
            newDataC.Phone2 = "65";
            newDataC.Notes = "234";

            List<ContactData> oldContact = app.Contacts.GetContactsList();

            app.Contacts.Modify(newDataC);

            List<ContactData> newContact = app.Contacts.GetContactsList();

            oldContact[0].Firstname = newDataC.Firstname;
            oldContact[0].Lastname = newDataC.Lastname;

            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
