using Arner.DataAccess.IRepository;
using Arner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess
{
    public class ItemRepository : IItemRepository 
    {
        private readonly ArnerDbContext _context;
        public ItemRepository(ArnerDbContext context) 
        {
            _context = context;
        }

        public async Task<Item> Add(Item t)
        {
            await _context.Items.AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<Item> Delete(Item t)
        {
            _context.Items.Remove(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<Item?> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> Update(Item t)
        {
            _context.Items.Update(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<Item?> GetByNameAndOwner(string name, int ownerId)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Name == name && i.UserId == ownerId);  
        }
    }
}
