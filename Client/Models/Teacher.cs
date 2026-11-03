using System;
using System.Security.Cryptography;

namespace WestCoastEducation2.Models;

public class Teacher : Person
{
    public string KnowledgeArea { get; set; }

    //aggregation läraren är ansvarig för kurser, men kurserna kan finnas utan läraren och kan tilldelas en annan lärare. 

    public List<Course> ResponsibleCourses { get; } = [];

    public Teacher(
        string firstName,
        string lastName,
        string phone,
        string personalNumber,
        string address,
        string postalCode,
        string city,
        string knowledgeArea
    )
    : base(firstName, lastName, phone, personalNumber, address, postalCode, city)
    {
        KnowledgeArea = knowledgeArea;
    }

    public bool AddCourse(Course course)
    {
        return AddCourseTo(ResponsibleCourses, course);
    }

    public override string GetInfo()
    {
        string courses = "";
        
        if (ResponsibleCourses.Count== 0)
        {
            courses ="none";

        }
        else
        {
            foreach (Course course in ResponsibleCourses)
            {
                if (courses != "")
                {
                    courses += ", ";
                }
                courses += course.Title;
            }
        }
        return base.GetInfo() + $", KnowledgeArea: {KnowledgeArea}, ResponsibleCourses: {courses}";
    }
}

