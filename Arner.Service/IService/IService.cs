using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service.IService
{
    public interface IService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id); 
    }
}
