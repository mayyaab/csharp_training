using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;


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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contact = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contact.Add(new ContactData(parts[0])
                {

                    Lastname = parts[1],
                    Middlename = parts[2],
                    Address = parts[3],
                    Home = parts[4],
                    Mobile = parts[5],
                    Work = parts[6],
                    Email = parts[7], 
                    Email2 = parts[8],
                    Email3 = parts[9]
                });
            }
            return contact;
        }


        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            //List<GroupData> groups = new List<GroupData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contact.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contact.json"));
        }

        [Test, TestCaseSource("ContactDataFromXMLFile")]
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
