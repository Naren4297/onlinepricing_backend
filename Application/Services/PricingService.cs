using online_pricing_calculator_api.Application.Services;
using online_pricing_calculator_api.Domain.Models;
using online_pricing_calculator_api.Infrastructure.Data.Entities;
using online_pricing_calculator_api.Models.Responses;

namespace online_pricing_calculator_api.Application.Services;

public class PricingService
{
    private readonly DiscountEngine _discountEngine;

    public PricingService(DiscountEngine discountEngine)
    {
        _discountEngine = discountEngine;
    }

    public PricingResponse CalculatePrice(
        List<BasketItem> basket,
        List<Item> items,
        Dictionary<int, Discount> discounts)
    {
        var response = new PricingResponse();

        foreach (var basketItem in basket)
        {
            var item = items.First(i => i.Itemid == basketItem.ItemId);

            decimal subTotal = item.Unitprice * basketItem.Quantity;
            decimal discountAmount = 0;
            string? discountDescription = null;

            if (discounts.TryGetValue(item.Itemid, out var discount))
            {
                discountAmount = _discountEngine.ApplyDiscount(
                    item.Unitprice,
                    basketItem.Quantity,
                    discount
                );

                discountDescription = DiscountDescriptionBuilder.Build(discount);
            }

            response.Items.Add(new PricingItemResponse
            {
                ItemId = item.Itemid,
                ItemName = item.Name,
                Quantity = basketItem.Quantity,
                Rate = item.Unitprice,
                SubTotal = subTotal,
                Discount = discountAmount,
                FinalAmount = subTotal - discountAmount,
                DiscountDescription = discountDescription
            });

            response.SubTotal += subTotal;
            response.Discount += discountAmount;
        }

        response.Total = response.SubTotal - response.Discount;
        return response;
    }
}
