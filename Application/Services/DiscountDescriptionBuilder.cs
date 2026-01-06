using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Application.Services;

public static class DiscountDescriptionBuilder
{
    public static string? Build(Discount discount)
    {
        if (discount.Discounttype == null)
            return null;

        return discount.Discounttype.Code switch
        {
            "PERCENTAGE" =>
                $"{discount.Percentagevalue}% Off",

            "BUY_X_GET_Y" =>
                $"Buy {discount.Buyquantity} Get {discount.Freequantity} Free",

            _ => null
        };
    }
}
