using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ~~~~~~~~~~~~
//  Task LINQ:
// ~~~~~~~~~~~~
//     1. Создать методы, возвращающие итераторы неправильно введенной информации (по каждой сущности)
//        Comments: a) ID любых сущностей не должны повторяться
//                  b) не должно быть персон с повторяющимися фамилиями и именами
//                  c) поле TeacherID (класс Group) не должно ссылаться на несуществующего преподавателя
//                  d) поле GroupID не должно ссылаться на несуществующую группу
//                  e) поле RecordBookNumber должно быть уникальным
//        Samples:
//        IEnumerable<Student> GetInvalidStudents()
//        {
//            foeach(Student s in _students)
//            {
//                ...
//                if( ... )
//                {
//                    yield return s;
//                }
//                ...
//            }
//        }
//        IEnumerable<Teacher> GetInvalidTeachers()
//        {
//            foeach(Teacher t in _teachers)
//            {
//                ...
//                if( ... )
//                {
//                    yield return t;
//                }
//                ...
//            }
//        }
//        etc.
//     1.*
//        IEnumerable<Person> GetInvalidPersons()
//        {
//            foeach(Person p in _teachers+_Students)
//            {
//                ...
//                if( ... )
//                {
//                    yield return p;
//                }
//                ...
//            }
//        }
//     2. Вывести студентов по куратору группы
//        IEnumerable<Students> GetStudentsOfTeachersGroup(Teacher t)
//        {
//            ...
//        }
//     3. Вывести полную информацию по связке <студент>-<группа>-<куратор>
//        class FullInfo
//        {
//            RecordBookNumber
//            StudentName (LastName+FirstName)
//            GroupName
//            TeacherName (LastName+FirstName)
//        }
//        IEnumerable<FullInfo> GetStudentsTeachers()
//        {
//            ...
//        }
//     4. Статистическая информация
//        a. Подсчёт количества студентов по каждой из групп
//        b. Минимальное / Среднее / Максимальное количество студентов у каждого из кураторов групп
//        c. "тезки" (имена) + количество повторений
//     5. Добавить функциональность для работы с расписанием (аудитории + их занятость)
//        a. добавление ленты группе с проверкой аудитории и преподавателя
//        b. вывод расписания по группе(ам)
//        с. вывод расписания по аудитории(ям)
//        d. поиск "окон в расписании" групп

namespace LINQ_Schedule_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            TeacherStudentsDataModel model = new TeacherStudentsDataModel();

            Console.WriteLine("GetInvalidPeople() : ");
            var invalidPeople = model.GetInvalidPeople();
            var students = model.GetStudentsByTeacher(model.Teachers.Where(t => t.ID == 2).Select(t => t).FirstOrDefault());
            var getFullInfo = model.GetFullInfoOfAllPeople();
            var countStudentsInGroups = model.GetCountStudentsByGroups();
            var maxStudents = model.GetMaxOfStudentsByTeacher();
            var repeatedNames = model.GetRepeatedNames();

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            //foreach (var item in model.GetCountStudentsByGroups())
            //{
            //    Console.WriteLine("В группе {0} есть {1} студентов", item.GroupName, item.SudentCount);
            //}

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            //model.GetCountGroupByTeacher();

            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
