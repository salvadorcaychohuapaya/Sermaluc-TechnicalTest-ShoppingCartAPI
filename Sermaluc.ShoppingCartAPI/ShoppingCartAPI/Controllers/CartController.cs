using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application;
using ShoppingCart.Application.DTOs;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController: Controller
    {
        private readonly CartService _service;

        public CartController(CartService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAsync());

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddToCartRequest req)
        {
            var id = await _service.AddAsync(req);
            return CreatedAtAction(nameof(Get), new { itemId = id }, new { itemId = id });
        }

        [HttpPatch("{itemId:guid}/quantity")]
        public async Task<IActionResult> ChangeQuantity(Guid itemId, [FromQuery] int delta)
        {
            await _service.UpdateQuantityAsync(itemId, delta);
            return NoContent();
        }

        [HttpDelete("{itemId:guid}")]
        public async Task<IActionResult> Delete(Guid itemId)
        {
            await _service.RemoveAsync(itemId);
            return NoContent();
        }
    }
}
