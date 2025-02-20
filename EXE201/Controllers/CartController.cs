using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(long id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetCartsByAccountId(long accountId)
        {
            var carts = await _cartService.GetCartsByAccountIdAsync(accountId);
            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] Cart cart)
        {
            await _cartService.AddCartAsync(cart);
            return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(long id, [FromBody] Cart cart)
        {
            if (id != cart.Id) return BadRequest();
            await _cartService.UpdateCartAsync(cart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            await _cartService.DeleteCartAsync(id);
            return NoContent();
        }
    }

}
