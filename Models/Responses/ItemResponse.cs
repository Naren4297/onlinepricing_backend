namespace online_pricing_calculator_api.Models.Responses
{
    public class ItemResponse
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
    }
}
