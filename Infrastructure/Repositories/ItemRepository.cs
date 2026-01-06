using online_pricing_calculator_api.Infrastructure.Data.Entities;
using online_pricing_calculator_api.Domain.Interfaces;
using online_pricing_calculator_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace online_pricing_calculator_api.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetActiveItemsAsync()
        {
            return await _context.Items
                .Where(i => i.Isactive)
                .ToListAsync();
        }
    }

}
