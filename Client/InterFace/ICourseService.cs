using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.InterFace;

public interface ICourseService
{
    Task Add(Course course);
    Task Delete(string id);
    Task<List<Course>> List();
}
