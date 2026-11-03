using System;
using System.Collections.Generic;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service
{
    public class CourseManager
    {
        private readonly List<Course> _courses = new List<Course>();

        public bool AddCourse(Course course)
        {
            foreach (Course existingCourse in _courses)
            {
                if (existingCourse.CourseNumber == course.CourseNumber)
                {
                    return false;
                }
            }

            _courses.Add(course);
            return true;
        }

        public void ListCourses()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("Det finns inga kurser.");
                return;
            }

            foreach (Course course in _courses)
            {
                Console.WriteLine(course.GetInfo());
            }
        }

        public IReadOnlyList<Course> Courses
        {
            get { return _courses.AsReadOnly(); }
        }
    }
}
