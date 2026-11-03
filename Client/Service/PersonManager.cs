using WestCoastEducation2.Models;

namespace WestCoastEducation2.Services;

public class PersonManager
{
    private readonly List<Student> _students = [];
    private readonly List<Teacher> _teachers = [];
    private readonly List<EducationLeader> _leaders = [];
    private readonly List<Admin> _admins = [];

    // En gemensam kontroll för alla persontyper, så att den inte upprepas.
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
    public bool AddTeacher(Teacher teacher) => AddUnique(_teachers, teacher);
    public bool AddEducationLeader(EducationLeader leader) => AddUnique(_leaders, leader);
    public bool AddAdmin(Admin admin) => AddUnique(_admins, admin);

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