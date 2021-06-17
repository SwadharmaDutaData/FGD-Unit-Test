using System;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Itefaces;

namespace WebApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDataContext _context;
        public ItemRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = await _context.Items
                .SingleOrDefaultAsync(x => x.Id == id);
            
            return item;
        }

        public async Task<bool> PostItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            if(await _context.SaveChangesAsync() > 0)
                return true;
            return false;
        }
    }
}