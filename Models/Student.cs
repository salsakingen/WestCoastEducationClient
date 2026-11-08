using System;
using System.Collections.Generic;

namespace WestCoastEducationClient.Models;

public class Student : Person
{
    public List<Course> EnrolledCourses = [];
}