using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    class TeacherStudentsDataModel
    {
        #region         
        
        private List<Group> _groups = new List<Group>();
        private List<Teacher> _teachers = new List<Teacher>();
        private List<Student> _students = new List<Student>();
        //private List<Schedule> _schedule = new List<Schedule>();
        private List<Schedule> _schedule = new List<Schedule>();
        
        #endregion

        public TeacherStudentsDataModel()
        {
            _teachers.Add(new Teacher() { ID = 1, FirstName = "Николай", LastName = "Иванов", Specialty = "Prog" });
            _teachers.Add(new Teacher() { ID = 2, FirstName = "Василий", LastName = "Петров", Specialty = "Test" });
            _teachers.Add(new Teacher() { ID = 2, FirstName = "Дмитний", LastName = "Сидоров", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 12, FirstName = "Алексей", LastName = "Симонов", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 15, FirstName = "Александр", LastName = "Иванов", Specialty = "Prog" });

            _teachers.Add(new Teacher() { ID = 19, FirstName = "Александр", LastName = "Гордиенко", Specialty = "Тест" });

            _groups.Add(new Group() { ID = 1, GroupName = "Gr_1", TeacherID = 2 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_2", TeacherID = 3 });
            _groups.Add(new Group() { ID = 3, GroupName = "Gr_3", TeacherID = 1 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_4", TeacherID = 3 });
            _groups.Add(new Group() { ID = 4, GroupName = "Gr_7", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_8", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_9", TeacherID = 15 });

            _students.Add(new Student() { ID = 4, FirstName = "Алексей", LastName = "Симонов", GroupID = 1, RecordBookNumber = 10201 });
            _students.Add(new Student() { ID = 4, FirstName = "Александр", LastName = "Александров", GroupID = 4, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 6, FirstName = "Геннадий", LastName = "Беляев", GroupID = 1, RecordBookNumber = 10203 });

            _students.Add(new Student() { ID = 7, FirstName = "Алексей", LastName = "Коваль", GroupID = 2, RecordBookNumber = 10204 });
            _students.Add(new Student() { ID = 3, FirstName = "Станислав", LastName = "Алексеенко", GroupID = 2, RecordBookNumber = 10205 });
            _students.Add(new Student() { ID = 9, FirstName = "Валентина", LastName = "Белкина", GroupID = 3, RecordBookNumber = 10206 });
            _students.Add(new Student() { ID = 9, FirstName = "Александр", LastName = "Мирошниченко", GroupID = 3, RecordBookNumber = 10207 });
            _students.Add(new Student() { ID = 10, FirstName = "Марат", LastName = "Иващенко", GroupID = 2, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 11, FirstName = "Василий", LastName = "Петров", GroupID = 3, RecordBookNumber = 10208 });

            _schedule.Add(new Schedule() { TeacherId = 1, Room = 101, Subject = "Programming", LessonNumber = 1, groupId = 1, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 102, Subject = "Testing", LessonNumber = 2, groupId = 1, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 103, Subject = "Management", LessonNumber = 3, groupId = 1, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 104, Subject = "Programming", LessonNumber = 4, groupId = 1, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 105, Subject = "Management", LessonNumber = 5, groupId = 1, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 106, Subject = "Testing", LessonNumber = 6, groupId = 1, Day = DayOfWeek.Monday });
            
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 107, Subject = "Programming", LessonNumber = 1, groupId = 2, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 108, Subject = "Testing", LessonNumber = 2, groupId = 2, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 109, Subject = "Management", LessonNumber = 3, groupId = 2, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 110, Subject = "Programming", LessonNumber = 4, groupId = 2, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 111, Subject = "Management", LessonNumber = 5, groupId = 2, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 112, Subject = "Testing", LessonNumber = 6, groupId = 2, Day = DayOfWeek.Monday });
            
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 113, Subject = "Programming", LessonNumber = 1, groupId = 3, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 114, Subject = "Testing", LessonNumber = 2, groupId = 3, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 115, Subject = "Management", LessonNumber = 3, groupId = 3, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 116, Subject = "Programming", LessonNumber = 4, groupId = 3, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 117, Subject = "Management", LessonNumber = 5, groupId = 3, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 118, Subject = "Testing", LessonNumber = 6, groupId = 3, Day = DayOfWeek.Tuesday });
            
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 119, Subject = "Programming", LessonNumber = 1, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 120, Subject = "Testing", LessonNumber = 2, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 121, Subject = "Management", LessonNumber = 3, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 122, Subject = "Programming", LessonNumber = 4, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 123, Subject = "Management", LessonNumber = 5, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 124, Subject = "Testing", LessonNumber = 6, groupId = 4, Day = DayOfWeek.Tuesday });
            
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 125, Subject = "Programming", LessonNumber = 1, groupId = 6, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 126, Subject = "Testing", LessonNumber = 2, groupId = 6, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 127, Subject = "Management", LessonNumber = 3, groupId = 6, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 128, Subject = "Programming", LessonNumber = 4, groupId = 6, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 129, Subject = "Management", LessonNumber = 5, groupId = 6, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 130, Subject = "Testing", LessonNumber = 6, groupId = 6, Day = DayOfWeek.Wednesday });
            
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 131, Subject = "Programming", LessonNumber = 1, groupId = 2, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 132, Subject = "Testing", LessonNumber = 2, groupId = 2, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 133, Subject = "Management", LessonNumber = 3, groupId = 2, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 134, Subject = "Programming", LessonNumber = 4, groupId = 2, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 135, Subject = "Management", LessonNumber = 5, groupId = 2, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 136, Subject = "Testing", LessonNumber = 6, groupId = 2, Day = DayOfWeek.Thursday });

            _schedule.Add(new Schedule() { TeacherId = 2, Room = 101, Subject = "Testing", LessonNumber = 1, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 102, Subject = "Management", LessonNumber = 2, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 103, Subject = "Programming", LessonNumber = 3, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 104, Subject = "Management", LessonNumber = 4, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 105, Subject = "Testing", LessonNumber = 5, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 106, Subject = "Programming", LessonNumber = 6, groupId = 1, Day = DayOfWeek.Thursday });
            
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 107, Subject = "Testing", LessonNumber = 1, groupId = 3, Day = DayOfWeek.Friday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 108, Subject = "Management", LessonNumber = 2, groupId = 3, Day = DayOfWeek.Friday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 109, Subject = "Programming", LessonNumber = 3, groupId = 3, Day = DayOfWeek.Friday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 110, Subject = "Management", LessonNumber = 4, groupId = 3, Day = DayOfWeek.Friday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 111, Subject = "Testing", LessonNumber = 5, groupId = 3, Day = DayOfWeek.Friday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 112, Subject = "Programming", LessonNumber = 6, groupId = 3, Day = DayOfWeek.Friday });
            
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 113, Subject = "Testing", LessonNumber = 1, groupId = 6, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 114, Subject = "Management", LessonNumber = 2, groupId = 6, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 115, Subject = "Programming", LessonNumber = 3, groupId = 6, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 116, Subject = "Management", LessonNumber = 4, groupId = 6, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 117, Subject = "Testing", LessonNumber = 5, groupId = 6, Day = DayOfWeek.Monday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 118, Subject = "Programming", LessonNumber = 6, groupId = 6, Day = DayOfWeek.Monday });
            
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 119, Subject = "Testing", LessonNumber = 1, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 120, Subject = "Management", LessonNumber = 2, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 121, Subject = "Programming", LessonNumber = 3, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 122, Subject = "Management", LessonNumber = 4, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 123, Subject = "Testing", LessonNumber = 5, groupId = 4, Day = DayOfWeek.Tuesday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 124, Subject = "Programming", LessonNumber = 6, groupId = 4, Day = DayOfWeek.Tuesday });
            
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 125, Subject = "Testing", LessonNumber = 1, groupId = 2, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 126, Subject = "Management", LessonNumber = 2, groupId = 2, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 127, Subject = "Programming", LessonNumber = 3, groupId = 2, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 128, Subject = "Management", LessonNumber = 4, groupId = 2, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 129, Subject = "Testing", LessonNumber = 5, groupId = 2, Day = DayOfWeek.Wednesday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 130, Subject = "Programming", LessonNumber = 6, groupId = 2, Day = DayOfWeek.Wednesday });
            
            _schedule.Add(new Schedule() { TeacherId = 2, Room = 131, Subject = "Testing", LessonNumber = 1, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 3, Room = 132, Subject = "Management", LessonNumber = 2, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 15, Room = 133, Subject = "Programming", LessonNumber = 3, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 12, Room = 134, Subject = "Management", LessonNumber = 4, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 19, Room = 135, Subject = "Testing", LessonNumber = 5, groupId = 1, Day = DayOfWeek.Thursday });
            _schedule.Add(new Schedule() { TeacherId = 1, Room = 136, Subject = "Programming", LessonNumber = 6, groupId = 1, Day = DayOfWeek.Thursday });

        }

        public IEnumerable<Teacher> Teachers
        {
            get
            {
                return _teachers;
            }
        }

        public IEnumerable <Student> Students
        {
            get => _students;
        }

        public IEnumerable<Group> Groups
        {
            get => _groups;
        }

        #region InvalidIDs

        public IEnumerable<Person> GetInvalidPeople()
            {
                return GetPeople().GroupBy(p => p.ID)
                                  .Where(p => p.Count() > 1)
                                  .SelectMany(p => p);
            }

            public IEnumerable<Student> GetInvalidStudent()
            {
                return GetInvalidIDs(_students);
            }

            public IEnumerable<Teacher> GetInvalidTeachers()
            {
                return GetInvalidIDs(_teachers);
            }

            public IEnumerable<Group> GetInvalidGroups()
            {
                return GetInvalidIDs(_groups);
            }

            private IEnumerable<Person> GetInvalidIDs(List<Person> people)
            {
            //return from person in people
            //       group person by person.ID into g
            //       let count = g.Count()
            //       orderby count descending
            //       where count > 1
            //       from personWithRepeatedIDs in g.Cast<Person>()
            //       select personWithRepeatedIDs;

                return people.GroupBy(p => p.ID)
                             .Where(p => p.Count() > 1)
                             .SelectMany(p => p);
            }

            private IEnumerable<Student> GetInvalidIDs(List<Student> people)
            {
                return from person in people
                       group person by person.ID into g
                       let count = g.Count()
                       orderby count descending
                       where count > 1
                       from personWithRepeatedIDs in g.Cast<Student>()
                       select personWithRepeatedIDs;
            }

            private IEnumerable<Teacher> GetInvalidIDs(List<Teacher> people)
            {
                return from person in people
                       group person by person.ID into g
                       let count = g.Count()
                       orderby count descending
                       where count > 1
                       from personWithRepeatedIDs in g.Cast<Teacher>()
                       select personWithRepeatedIDs;
            }

            private IEnumerable<Group> GetInvalidIDs(List<Group> groups)
            {
                return from @group in groups
                       group @group by @group.ID into g
                       let count = g.Count()
                       orderby count descending
                       where count > 1
                       from personWithRepeatedIDs in g.Cast<Group>()
                       select personWithRepeatedIDs;
            }

        #endregion

        #region NoRepeatedNames

            public IEnumerable<Person> GetPeopleWithUniqueNames()
            {
                var people = GetPeople();
                var peopleWithUniqueFirstName = GetPeopleWithUniqueFirstNames(people);
                var peopleWithUniqueLastName = GetPeopleWithUniqueLastNames(peopleWithUniqueFirstName);

                return peopleWithUniqueLastName;
            }

            private IEnumerable<Person> GetPeopleWithUniqueFirstNames(IEnumerable<Person> people)
            {
                return people.GroupBy(p => p.FirstName)
                             .Select(p => p.FirstOrDefault());
            }

            private IEnumerable<Person> GetPeopleWithUniqueLastNames(IEnumerable<Person> people)
            {
                return people.GroupBy(p => p.LastName)
                             .Select(p => p.FirstOrDefault());
            }

        #endregion

        public IEnumerable<Person> GetPeopleWithUniqueID()
        {
            return GetPeople().GroupBy(p => p.ID).Select(p => p.FirstOrDefault());
        }

        private IEnumerable<Person> GetPeople()
        {
            return (_students.Cast<Person>()).Concat(_teachers.Cast<Person>());
        }

        public IEnumerable<Student> GetStudentsByTeacher(Teacher teacher)
        {
            var teachersGroups = _groups.Where(g => g.TeacherID == teacher.ID).Select(g => g.ID);

            return _students.Where(s => teachersGroups.Contains(s.GroupID));
        }

        public IEnumerable<FullInfoOfPerson> GetFullInfoOfAllPeople()
        {
            return _groups.GroupJoin(_teachers, g => g.TeacherID, t=> t.ID, (g, t) => new { group = g, teachers = t.FirstOrDefault() })
                          .Join(_students, g => g.group.ID, s => s.GroupID, (g, s) => new { group = g, student = s })
                          .Select(g => new FullInfoOfPerson()
                          {
                              groupName = g.group.group.GroupName,
                              recordBookNubmber = g.student.RecordBookNumber,
                              studentFirstName = g.student.FirstName,
                              studentLastName = g.student.LastName,
                              teacherFirstName = g.group.teachers == null ? "No teacher" : g.group.teachers.FirstName,
                              teacherLastName = g.group.teachers == null ? "No teacher" : g.group.teachers.LastName
                          });
        }

        public IEnumerable<(string, int)> GetCountStudentsByGroups()
        {
            return _groups.Where(g => _students.Select(s => s.GroupID).Contains(g.ID))
                          .Select(g => (g.GroupName, _students.Where(s => s.GroupID == g.ID).Count()));
        }

        public IEnumerable<(Teacher, int)> GetNumberOfStudentsByTeacher()
        {
            return _teachers.GroupBy(t => (t, GetStudentsByTeacher(t).Count())).Select(t => (t.Key.t, t.Key.Item2));
        }

        #region min/max students

            public (Teacher, int) GetMaxOfStudentsByTeacher()
            {
                return GetNumberOfStudentsByTeacher().OrderByDescending(t => t.Item2).FirstOrDefault();
            }

            public (Teacher, int) GetMinOfStudentsByTeacher()
            {
                return GetNumberOfStudentsByTeacher().OrderBy(t => t.Item2).FirstOrDefault();
            }

        #endregion

        public IEnumerable<(string, int)> GetRepeatedNames()
        {
            return GetPeople().Select(p => p.FirstName)
                              .GroupBy(p => p)
                              .Select(p => (p.First(), p.Count()))
                              .OrderByDescending(p => p.Item2);
        }

        public IEnumerable<ScheduleFEFormat> GetGroupSchedule(Group group)
        {
            return _schedule.Where(s => s.groupId == group.ID)
                            .Select(s => new ScheduleFEFormat()
                            {
                                groupName = group.GroupName,
                                lessonNum = s.LessonNumber,
                                room = s.Room,
                                teacherName = _teachers
                                  .Where(t => t.ID == s.TeacherId)
                                  .Select(t => string.Concat(t.FirstName + ' ' + t.LastName))
                                  .FirstOrDefault(),
                                day = s.Day
                            });
        }

        public IEnumerable<ScheduleFEFormat> GetInformationByRoom(int room)
        {
            return _schedule.Where(r => r.Room == room)
                            .Select(s => new ScheduleFEFormat()
                            {
                                groupName = _groups.Where(g => g.ID == s.groupId)
                                                   .Select(g => g.GroupName).FirstOrDefault(),
                                lessonNum = s.LessonNumber,
                                room = s.Room,
                                teacherName = _teachers
                                  .Where(t => t.ID == s.TeacherId)
                                  .Select(t => string.Concat(t.FirstName + ' ' + t.LastName))
                                  .FirstOrDefault(),
                                day = s.Day
                            });
        }

        public IEnumerable<IEnumerable<ScheduleFEFormat>> GetInformationByAllRooms()
        {
            return _schedule.Select(s => GetInformationByRoom(s.Room));
        }


        //public IEnumerable<(Teacher, int)> GetAverageOfStudentsByTeacher()
        //{
        //    return GetNumberOfStudentsByTeacher().;
        //}
    }
}
