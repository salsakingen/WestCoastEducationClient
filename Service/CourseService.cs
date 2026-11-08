using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.Service
{
    public class CourseService : IService<Course>
    {

        private readonly IHttpService<Course> _httpService = new  HttpService<Course>();
        public async Task<Course?> Get(string id)
        {
            Course? _course = null;

            try
            {

                _course = await _httpService.Get("courses", id);

            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return _course;
        }
        public async Task Put(Course obj)
        {
            string id = obj.Id;
            
            try
            {
                await _httpService.Put("courses", obj, id!);
                
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        public async Task Post(Course obj)
        {
            await _httpService.Post("courses", obj);

        }

        public async Task Delete(string id)
        {
            await _httpService.Delete("courses", id);
        }

        public async Task<List<Course>> GetAll()
        {
            return await _httpService.Get("courses");
        }
    }
}
