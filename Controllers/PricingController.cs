using Microsoft.AspNetCore.Mvc;
using online_pricing_calculator_api.Application.Services;
using online_pricing_calculator_api.Domain.Interfaces;
using online_pricing_calculator_api.Models.Requests;

namespace online_pricing_calculator_api.Controllers;

[ApiController]
[Route("api/pricing")]
public class PricingController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly PricingService _pricingService;

    public PricingController(
        IItemRepository itemRepository,
        IDiscountRepository discountRepository,
        PricingService pricingService)
    {
        _itemRepository = itemRepository;
        _discountRepository = discountRepository;
        _pricingService = pricingService;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate(PricingRequest request)
    {
        var itemIds = request.Items.Select(i => i.ItemId).ToList();

        var items = await _itemRepository.GetActiveItemsAsync();
        var discounts = await _discountRepository.GetDiscountsByItemIdsAsync(itemIds);

        var result = _pricingService.CalculatePrice(
            request.Items,
            items,
            discounts
        );

        return Ok(result);
    }

}
