using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.Service;

public class StudentService : IService<Student>
{
    private readonly IHttpService<Student> _httpService = new HttpService<Student>();
    public async Task<Student?> Get(string id)
    {
        Student? _student = null;

        try
        {

            _student = await _httpService.Get("students", id);

        }
        catch (System.Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        return _student;
    }
    public async Task Put(Student obj)
    {
        string id = obj.Id;

        try
        {
            await _httpService.Put("students", obj, id!);
        }
        catch (System.Exception ex)
        {

            Console.WriteLine(ex.Message);
        }


    }

    public async Task Post(Student obj)
    {
        await _httpService.Post("students", obj);

    }

    public async Task Delete(string id)
    {
        await _httpService.Delete("students", id);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _httpService.Get("students");
    }
}
