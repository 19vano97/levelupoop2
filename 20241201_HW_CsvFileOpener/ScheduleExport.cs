using System;

namespace _20241201_HW_CsvFileOpener;

public class ScheduleExport
{
    private string _fileName;
    private string _extenstion;
    private List<Schedule> _schedules;

    public ScheduleExport(string fileName, string extenstion, List<Schedule> schedules)
    {
        _fileName = fileName;
        _extenstion = extenstion;
        _schedules = schedules;
    }

    public string fileName
    {
        get => string.Concat(_fileName + '.' + _extenstion);
    }

    public void Export()
    {
        if (_extenstion == "bin")
        {
            using (var fs = new FileStream(string.Concat(_fileName + '.' + _extenstion), FileMode.Create, FileAccess.Write))
            {
                BinaryWriter bw = new BinaryWriter(fs);

                foreach (var schedule in _schedules)
                {
                    bw.Write(schedule.ToString());
                }
            }

            return;
        }

        using (var fs = new FileStream(string.Concat(_fileName + '.' + _extenstion), FileMode.Create))
        {
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Student First Name;Student Last Name;Group Name;Teacher First Name;Teacher Last Name;Subject;Room");

            foreach (var schedule in _schedules)
            {
                sw.WriteLine(schedule);
            }
        }
    }
}
