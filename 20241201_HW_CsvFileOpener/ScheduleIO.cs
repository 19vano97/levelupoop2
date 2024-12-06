using System;
using System.Threading.Tasks.Dataflow;

namespace _20241201_HW_CsvFileOpener;

public static class ScheduleIO
{
    public static void Write(this BinaryWriter bw, Schedule schedule)
    {
        bw.Write(schedule.student.firstName);
        bw.Write(schedule.student.lastName);
        bw.Write(schedule.student.group.name);
        bw.Write(schedule.teacher.firstName);
        bw.Write(schedule.teacher.lastName);
        bw.Write(schedule.subject);
        bw.Write(schedule.room);
    }

    public static Schedule Read(this BinaryReader bw)
    {
        return new Schedule() { student = new Student(bw.ReadString(), bw.ReadString()) { group = new Group() { name = bw.ReadString()} }, 
                                teacher = new Teacher(bw.ReadString(), bw.ReadString()), 
                                subject = bw.ReadString(),
                                room = bw.ReadInt32() };
    }
}
