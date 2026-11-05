using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.InterFace;

public interface IStudentService
{
    Task Add(Student student);
    Task Delete(string id);
    Task<List<Student>> List();
}
