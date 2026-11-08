using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.Service;

public class TeacherService : IService<Teacher>
{

    private readonly IHttpService<Teacher> _httpService = new HttpService<Teacher>();
    public async Task<Teacher?> Get(string id)
    {
        Teacher? _teacher = null;

        try
        {

            _teacher = await _httpService.Get("teachers", id);

        }
        catch (System.Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        return _teacher;
    }
    public async Task Put(Teacher obj)
    {
        string id = obj.Id;

        try
        {
            await _httpService.Put("teachers", obj, id!);
        }
        catch (System.Exception ex)
        {

            Console.WriteLine(ex.Message);
        }


    }

    public async Task Post(Teacher obj)
    {
        await _httpService.Post("teachers", obj);

    }

    public async Task Delete(string id)
    {
        await _httpService.Delete("teachers", id);
    }

    public async Task<List<Teacher>> GetAll()
    {
        return await _httpService.Get("teachers");
    }
}


