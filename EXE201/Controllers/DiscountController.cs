using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound();
            return Ok(discount);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await _discountService.GetAllDiscountsAsync();
            return Ok(discounts);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var discount = await _discountService.GetDiscountByCodeAsync(code);
            if (discount == null) return NotFound();
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discount discount)
        {
            await _discountService.AddDiscountAsync(discount);
            return CreatedAtAction(nameof(GetById), new { id = discount.Id }, discount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Discount discount)
        {
            if (id != discount.Id) return BadRequest();
            await _discountService.UpdateDiscountAsync(discount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return NoContent();
        }
    }
}
