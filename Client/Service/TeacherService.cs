using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.InterFace;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service;

public class TeacherService : ITeacherService
{
    public async Task Add(Teacher teacher)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Post("teachers", teacher);
    }
    public async Task Delete(string id)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Delete("teachers", id);
    }
    public async Task Update(Teacher teacher, string _objectId)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Put("teachers", teacher, _objectId);
    }
    public async Task<List<Teacher>> List()
    {
        var httpService = new HttpService<Teacher>();
        var teachers = await httpService.Get("teachers");
        return teachers;
    }
}


