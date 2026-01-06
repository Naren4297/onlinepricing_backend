using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Domain.Strategies
{
    public class BuyXGetYDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal unitPrice, int quantity, Discount discount)
        {
            if (!discount.Buyquantity.HasValue || !discount.Freequantity.HasValue)
                return 0;

            int buy = discount.Buyquantity.Value;
            int free = discount.Freequantity.Value;

            int groupSize = buy + free;
            int freeItems = (quantity / groupSize) * free;

            return freeItems * unitPrice;
        }
    }

}
