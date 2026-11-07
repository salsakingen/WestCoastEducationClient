using System;

namespace WestCoastEducationClient.Models;

public record ClassroomCourse
{
    public string? Classroom { get; set; }
    public string? CourseNumber { get; set; }
    public string? Title { get; set; }
    public int DurationDays { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
