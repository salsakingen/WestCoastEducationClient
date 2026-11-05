using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.InterFace;

public interface ITeacherService
{
    Task Add(Teacher teacher);
    Task Delete(string id);
    Task<List<Teacher>> List();
    Task Update(Teacher teacher, string _objectId);

}
