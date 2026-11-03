using System;

namespace WestCoastEducation2.Models;

public class Student : Person
{
    // Aggregation: en student har kurser, men kurserna finns kvar
    // som egna objekt även om studenten tas bort.
    public List<Course> Courses { get; } = [];

    public Student(
        string firstName,
        string lastName,
        string phone,
        string personalNumber,
        string address,
        string postalCode,
        string city
    )
    : base(firstName, lastName, phone, personalNumber, address, postalCode, city)
    {
    }

    public bool AddCourse(Course course)
    {
        return AddCourseTo(Courses, course);
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Number of Courses: {Courses.Count}";
    }
}
