using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    class Student : Person
    {
        // ID группы, к которой принадлежить студент
        public int GroupID
        {
            get;
            set;
        }

        // Номер зачётной книжки
        public int RecordBookNumber
        {
            get;
            set;
        }
    }
}
