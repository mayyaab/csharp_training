using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string home;
        private string mobile;
        private string work;
        private string allPhones;
        private string allEmails;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;
        private string newgroup;
        private string address2;
        private string phone2;
        private string notes;

        public ContactData(string firstname)
        {
            Firstname = firstname;
            //Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            var isEqual = Firstname == other.Firstname && Lastname == other.Lastname;
            return isEqual;
            //return Firstname == other.Firstname;
        }



        public override int GetHashCode()
        {
            return 0; 
                   
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Firstname);
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public String Firstname { get; set; }


        public String Middlename { get; set; }


        public String Lastname { get; set; }


        public String Nickname
        {
            get
            {
                return nickname;

            }
            set
            {
                nickname = value;

            }
        }

        public String Title
        {
            get
            {
                return title;

            }
            set
            {
                title = value;

            }
        }

        public String Company
        {
            get
            {
                return company;

            }
            set
            {
                company = value;

            }
        }

        public String Address { get; set; }


        public String Home { get; set; }


        public String Mobile { get; set; }


        public String Work { get; set; }

        public String AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }

            }
            set
            {
                allPhones = value;

            }
        }

        public String AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;

            }
        }

        private string CleanUp(string x)
        {
            if (x == null || x == "" )
            {
                return "";
            }

            //return Regex.Replace(x, "[ -()]", "") + "\r\n";
            return x.Replace(" ", "").Replace("00", "+").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
        }

       /*private string CleanUpP(string phone)
       {
           if (phone == null || phone == "")
           {
               return "";
           }

           //return Regex.Replace(phone, "[ -()]", "") + "\r\n";
           return phone.Replace(" ", "").Replace("00", "+").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
       }

        private string CleanUpE(string emai)
        {
            if (emai == null || emai == "")
            {
                return "";
            }

            return Regex.Replace(emai, "[ -()]", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("00", "+").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
        }*/


        public String Fax
        {
            get
            {
                return fax;

            }
            set
            {
                fax = value;

            }
        }

        public String Email
        {
            get
            {
                return email;

            }
            set
            {
                email = value;

            }
        }

        public String Email2
        {
            get
            {
                return email2;

            }
            set
            {
                email2 = value;

            }
        }

        public String Email3
        {
            get
            {
                return email3;

            }
            set
            {
                email3 = value;

            }
        }

        public String Homepage
        {
            get
            {
                return homepage;

            }
            set
            {
                homepage = value;

            }
        }

        public String Bday
        {
            get
            {
                return bday;

            }
            set
            {
                bday = value;

            }
        }

        public String Bmonth
        {
            get
            {
                return bmonth;

            }
            set
            {
                bmonth = value;

            }
        }

        public String Byear
        {
            get
            {
                return byear;

            }
            set
            {
                byear = value;

            }
        }

        public String Aday
        {
            get
            {
                return aday;

            }
            set
            {
                aday = value;

            }
        }

        public String Amonth
        {
            get
            {
                return amonth;

            }
            set
            {
                amonth = value;

            }
        }

        public String Ayear
        {
            get
            {
                return ayear;

            }
            set
            {
                ayear = value;

            }
        }

        public String Newgroup
        {
            get
            {
                return newgroup;

            }
            set
            {
                newgroup = value;

            }
        }

        public String Address2
        {
            get
            {
                return address2;

            }
            set
            {
                address2 = value;

            }
        }

        public String Phone2
        {
            get
            {
                return phone2;

            }
            set
            {
                phone2 = value;

            }
        }

        public String Notes
        {
            get
            {
                return notes;

            }
            set
            {
                notes = value;

            }
        }
    }
}



