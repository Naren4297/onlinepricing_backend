namespace online_pricing_calculator_api.Models.Responses
{
    public class PricingResponse
    {
        public List<PricingItemResponse> Items { get; set; } = new();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
