using System;
using System.Collections.Generic;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service;

public class StudentService
{
    private readonly List<Student> _students = [];

    private static bool AddUnique<T>(List<T> list, T person) where T : Person
    {
        foreach (T existing in list)
        {
            if (existing.PersonalNumber == person.PersonalNumber)
            {
                return false;
            }
        }

        list.Add(person);
        return true;
    }
    public bool AddStudent(Student student) => AddUnique(_students, student);

    public void ListStudents()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("There are no students.");
            return;
        }

        foreach (Student student in _students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }
}
