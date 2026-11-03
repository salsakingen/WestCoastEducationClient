using System;

namespace WestCoastEducation2.Models;

public class DistanceCourse : Course
{
    public string MeetingLink {get; set;}

    public DistanceCourse(
        string courseNumber,
        string title,
        int durationDays,
        DateTime startDate,
        DateTime endDate,
        string meetingLink)
        :base (courseNumber, title, durationDays, startDate, endDate)
    {
        MeetingLink=meetingLink;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Distance, Link: {MeetingLink}";
    }
}
