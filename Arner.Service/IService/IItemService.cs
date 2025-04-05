using Arner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service.IService
{
    public interface IItemService : IService<Item>
    {
        public Task<Item?> GetById(int id);
    }
}
