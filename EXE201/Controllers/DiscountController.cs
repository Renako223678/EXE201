using System.Collections.Generic;
using System.Threading.Tasks;
using EXE201.Controllers.DTO;
using EXE201.DTO;
using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/discounts")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await _discountService.GetAllDiscountsAsync();
            return Ok(discounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound("Discount not found.");
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DiscountDTO discountDto)
        {
            if (discountDto == null) return BadRequest("Invalid discount data.");

            var discount = new Discount
            {   Id  = discountDto.Id,
                Code = discountDto.Code,
                Percentage = discountDto.Percentage,
                ExpiryDate = discountDto.ExpiryDate,
                IsActive = discountDto.IsActive
            };

            await _discountService.AddDiscountAsync(discount);
            return CreatedAtAction(nameof(GetById), new { id = discount.Id }, discountDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] DiscountDTO discountDto)
        {
            if (discountDto == null || id != discountDto.Id) return BadRequest("Invalid discount data.");

            var existingDiscount = await _discountService.GetDiscountByIdAsync(id);
            if (existingDiscount == null) return NotFound("Discount not found.");

            var discount = new Discount
            {
                Id = discountDto.Id,
                Code = discountDto.Code,
                Percentage = discountDto.Percentage,
                ExpiryDate = discountDto.ExpiryDate,
                IsActive = discountDto.IsActive
            };

            await _discountService.UpdateDiscountAsync(discount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingDiscount = await _discountService.GetDiscountByIdAsync(id);
            if (existingDiscount == null) return NotFound("Discount not found.");

            await _discountService.DeleteDiscountAsync(id);
            return NoContent();
        }
    }
}
