using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    public class Group
    {
        public int ID
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        // ID преподавателя-куратора группы
        public int TeacherID
        {
            get;
            set;
        }
    }
}
