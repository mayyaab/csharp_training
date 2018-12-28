using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    //для этих объектов определена функция сравнения
    //клас GroupData наследует IEquatable (его можно сравнивать с другими объектами типо GroupData)
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        //функиция сравнения. стандартный метод
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            //проверка по смыслу
            return Name == other.Name;
        }

        //этот метод преднозначен - для оптимизации сравнения
        public int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public String Name
        {
            get
            {
                return name;

            }
            set
            {
                name = value;

            }
        }

        public string Header
        {
            get
            {
                return header;

            }
            set
            {
                header = value;

            }
        }

        public String Footer
        {
            get
            {
                return footer;

            }
            set
            {
                footer = value;

            }
        }
    }
}
