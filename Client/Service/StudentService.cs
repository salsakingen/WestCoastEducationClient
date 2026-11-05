using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.InterFace;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service;

public class StudentService : IStudentService
{
    public async Task Add(Student student)
    {
        var httpService = new HttpService<Student>();
        await httpService.Post("students", student);
    }
    public async Task Delete(string id)
    {
        var httpService = new HttpService<Student>();
        await httpService.Delete("students", id);
    }
    public async Task<List<Student>> List()
    {
        var httpService = new HttpService<Student>();
        var students = await httpService.Get("students");
        return students;
    }
}
