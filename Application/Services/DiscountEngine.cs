using online_pricing_calculator_api.Domain.Enums;
using online_pricing_calculator_api.Domain.Strategies;
using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Application.Services
{
    public class DiscountEngine
    {
        private readonly Dictionary<string, IDiscountStrategy> _strategies;

        public DiscountEngine()
        {
            _strategies = new Dictionary<string, IDiscountStrategy>
        {
            { DiscountTypeCode.PERCENTAGE.ToString(), new PercentageDiscountStrategy() },
            { DiscountTypeCode.BUY_X_GET_Y.ToString(), new BuyXGetYDiscountStrategy() }
        };
        }

        public decimal ApplyDiscount(decimal unitPrice, int quantity, Discount discount)
        {
            var discountTypeCode = discount.Discounttype.Code;

            if (!_strategies.TryGetValue(discountTypeCode, out var strategy))
                return 0;

            return strategy.CalculateDiscount(unitPrice, quantity, discount);
        }
    }
}
