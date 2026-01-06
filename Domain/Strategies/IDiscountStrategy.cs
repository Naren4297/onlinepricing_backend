using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Domain.Strategies
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal unitPrice, int quantity, Discount discount);
    }


}
