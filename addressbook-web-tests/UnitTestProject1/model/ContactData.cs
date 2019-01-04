using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.firstname = firstname;
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

            return Firstname.CompareTo(other.Firstname);
        }

        public String Firstname
        {
            get
            {
                return firstname;

            }
            set
            {
                firstname = value;

            }
        }

        public String Middlename
        {
            get
            {
                return middlename;

            }
            set
            {
                middlename = value;

            }
        }

        public String Lastname
        {
            get
            {
                return lastname;

            }
            set
            {
                lastname = value;

            }
        }

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

        public String Address
        {
            get
            {
                return address;

            }
            set
            {
                address = value;

            }
        }

        public String Home
        {
            get
            {
                return home;

            }
            set
            {
                home = value;

            }
        }

        public String Mobile
        {
            get
            {
                return mobile;

            }
            set
            {
                mobile = value;

            }
        }

        public String Work
        {
            get
            {
                return work;

            }
            set
            {
                work = value;

            }
        }

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



