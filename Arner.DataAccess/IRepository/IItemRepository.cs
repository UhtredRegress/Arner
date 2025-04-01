using Arner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item?> GetById(int id);
    }
}
