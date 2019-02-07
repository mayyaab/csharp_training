using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace addressbook_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();

            List<ContactData> contact = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

            for (int i = 0; i < count; i++)
            {
                contact.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    Lastname = TestBase.GenerateRandomString(50),
                    Middlename = TestBase.GenerateRandomString(50),
                    Address = TestBase.GenerateRandomString(50),
                    Home = TestBase.GenerateRandomString(50),
                    Mobile = TestBase.GenerateRandomString(50),
                    Work = TestBase.GenerateRandomString(50),
                    Email = TestBase.GenerateRandomString(50),
                    Email2 = TestBase.GenerateRandomString(50),
                    Email3 = TestBase.GenerateRandomString(50)

                });
            }

            if (dataType == "groups")
            {

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }

                else if (format == "xml")
                {
                    writeGroupsToXMLFile(groups, writer);
                }

                else if (format == "json")
                {
                    writeGroupsToJSONFile(groups, writer);
                }

                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }

              
            }


            else if (dataType == "contact")
            {
                if (format == "csv")
                {
                    writeContactToCsvFile(contact, writer);
                }

                else if (format == "xml")
                {
                    writeContactToXMLFile(contact, writer);
                }

                else if (format == "json")
                {
                    writeContactToJSONFile(contact, writer);
                }

                else
                {
                    //System.Console.Out.Write("Unrecognized format" + format);
                }

            }
            writer.Close();

        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {  
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9}",
                    contact.Firstname, contact.Lastname, contact.Middlename, contact.Address, contact.Home, contact.Mobile, contact.Work, contact.Email, contact.Email2, contact.Email3));
            }
        }

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
