using Arner.DataAccess.IRepository;
using Arner.DataAccess.Models;
using Arner.Helper.Exceptions;
using Arner.Service.IService;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;

        public ItemService(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public async Task<Item> Add(Item entity)
        {
            var tempItem = await _itemRepo.GetByNameAndOwner(entity.Name, entity.UserId);
            
            if (tempItem != null)
            {
                throw new DuplicateDataException();
            }
        
            return await _itemRepo.Add(entity); ;
        }

        public Task<Item> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Update(int id, Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
