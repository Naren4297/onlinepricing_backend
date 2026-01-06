using Microsoft.AspNetCore.Mvc;
using online_pricing_calculator_api.Domain.Interfaces;
using online_pricing_calculator_api.Models.Responses;

namespace online_pricing_calculator_api.Controllers;

[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemsController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _itemRepository.GetActiveItemsAsync();

        var response = items.Select(i => new ItemResponse
        {
            ItemId = i.Itemid,
            Name = i.Name,
            UnitPrice = i.Unitprice
        });

        return Ok(response);
    }
}
