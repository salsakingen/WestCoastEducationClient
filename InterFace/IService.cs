using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WestCoastEducationClient.InterFace;

public interface IService<T>
{

    Task<T> Get(string id);
    Task Put(T obj);
    Task Post(T obj);
    Task Delete(string id);
    Task<List<T>> GetAll();
}
