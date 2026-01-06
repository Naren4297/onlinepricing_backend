using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetActiveItemsAsync();
    }

}
