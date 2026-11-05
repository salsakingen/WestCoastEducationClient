using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.Client.InterFace;
using WestCoastEducationClient.Client.Models;

namespace WestCoastEducationClient.Client.Service
{
    public class CourseService : ICourseService
    {
        public async Task Add(Course course)
        {
            var httpService = new HttpService<Course>();
            await httpService.Post("courses", course);
        }
        public async Task Delete(string id)
        {
            var httpService = new HttpService<Course>();
            await httpService.Delete("courses", id);
        }
        public async Task<List<Course>> List()
        {
            var httpService = new HttpService<Course>();
            var courses = await httpService.Get("courses");
            return courses;
        }
    }
}
