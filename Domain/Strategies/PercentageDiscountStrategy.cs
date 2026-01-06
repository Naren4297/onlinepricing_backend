using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Domain.Strategies
{
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal unitPrice, int quantity, Discount discount)
        {
            if (!discount.Percentagevalue.HasValue)
                return 0;

            decimal totalPrice = unitPrice * quantity;
            decimal discountAmount = totalPrice * (discount.Percentagevalue.Value / 100);

            return discountAmount;
        }
    }

}
