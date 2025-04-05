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
  
            return await _itemRepo.Add(entity); 
        }

        public async Task<Item> Delete(int id)
        {
            var tempData = await _itemRepo.GetById(id);
            
            if (tempData == null)
            {
                throw new NotFoundException();
            }

            return await _itemRepo.Delete(tempData);
        }

        public async Task<Item?> GetById(int id)
        {
            return await _itemRepo.GetById(id);
        }

        public async Task<Item> Update(int id, Item entity)
        {
            var foundItem =  _itemRepo.GetById(id);
            if (foundItem == null)
            {
                throw new NotFoundException();
            }
            if (foundItem.Id != entity.Id)
            {
                throw new InvalidOperationException();
            }
            return await _itemRepo.Update(entity);
        }
    }
}
