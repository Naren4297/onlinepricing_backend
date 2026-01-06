using online_pricing_calculator_api.Domain.Models;

namespace online_pricing_calculator_api.Models.Requests
{
    public class PricingRequest
    {
        public List<BasketItem> Items { get; set; } = new();
    }

}
