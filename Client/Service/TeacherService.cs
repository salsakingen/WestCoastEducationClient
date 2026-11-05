using System;
using System.Collections.Generic;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service;

public class TeacherService
{

    private readonly List<Teacher> _teachers = [];
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
    public bool AddTeacher(Teacher teacher) => AddUnique(_teachers, teacher);

}
