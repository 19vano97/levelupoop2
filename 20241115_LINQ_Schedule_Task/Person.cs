using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    class Person
    {
        // порядковый номер персоны (~INN)
        public int ID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("[{0,2}] - {1} {2}", ID, FirstName, LastName);
        }
    }
}
