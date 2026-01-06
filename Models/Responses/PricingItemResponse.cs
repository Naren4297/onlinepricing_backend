namespace online_pricing_calculator_api.Models.Responses
{
    public class PricingItemResponse
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }

        public string? DiscountDescription { get; set; }
    }
}
