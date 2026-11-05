using System;
using WestCoastEducationClient.Client.InterFace;

namespace WestCoastEducationClient.Client.Models;

public abstract class Course
{
    public string? CourseNumber { get; set; }
    public string? Title { get; set; }
    public int DurationDays { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}