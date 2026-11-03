using System;

namespace WestCoastEducation2.Models;

public class ClassroomCourse : Course
{
    public string Classroom {get; set;}

    public ClassroomCourse(
        string courseNumber,
        string title,
        int durationDays,
        DateTime startDate,
        DateTime endDate,
        string classroom)
        :base (courseNumber, title, durationDays, startDate, endDate)
    {
        Classroom=classroom;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Classroom: {Classroom}";
    }
}
