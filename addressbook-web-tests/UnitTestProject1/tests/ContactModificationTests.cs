using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("zzz");
            newDataC.Lastname = "bbb";
            newDataC.Middlename = "ccc";
            newDataC.Nickname = "ddd";
            newDataC.Title = "eee";
            newDataC.Company = "qqq";
            newDataC.Address = "www";
            newDataC.Home = "eee";
            newDataC.Mobile = "111";
            newDataC.Work = "222";
            newDataC.Fax = "333";
            newDataC.Email = "444";
            newDataC.Email2 = "555";
            newDataC.Email3 = "666";
            newDataC.Homepage = "123";
            newDataC.Bday = "1";
            newDataC.Bmonth = "June";
            newDataC.Byear = "1990";
            newDataC.Aday = "1";
            newDataC.Amonth = "June";
            newDataC.Ayear = "2000";
            newDataC.Address2 = "34";
            newDataC.Phone2 = "65";
            newDataC.Notes = "234";

            app.Contacts.Modify(2, newDataC);
        }
    }
}
