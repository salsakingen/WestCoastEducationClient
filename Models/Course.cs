using System;
using System.Text.Json.Serialization;


namespace WestCoastEducationClient.Models;

public class Course
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }
    public string? CourseNumber { get; set; }
    public string? Title { get; set; }
    public int DurationDays { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}