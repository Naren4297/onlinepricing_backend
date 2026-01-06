using Microsoft.EntityFrameworkCore;
using online_pricing_calculator_api.Domain.Interfaces;
using online_pricing_calculator_api.Infrastructure.Data;
using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Infrastructure.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly AppDbContext _context;

    public DiscountRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<int, Discount>> GetDiscountsByItemIdsAsync(List<int> itemIds)
    {
        return await _context.Itemdiscounts
            .Where(id => itemIds.Contains(id.Itemid) && id.Discount.Isactive)
            .Include(id => id.Discount)                  // load Discount
                .ThenInclude(d => d.Discounttype)        // load Discounttype ✅
            .ToDictionaryAsync(
                id => id.Itemid,
                id => id.Discount
            );
    }
}
