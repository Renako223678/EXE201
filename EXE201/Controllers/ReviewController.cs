using System.Collections.Generic;
using System.Threading.Tasks;
using EXE201.Controllers.DTO;
using EXE201.DTO;
using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null) return NotFound("Review not found.");
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewDTO reviewDto)
        {
            if (reviewDto == null) return BadRequest("Invalid review data.");

            var review = new Review
            {
                AccountId = reviewDto.AccountId,
                PackageId = reviewDto.PackageId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                CreateDate = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = reviewDto.IsActive
            };

            await _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, reviewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ReviewDTO reviewDto)
        {
            if (reviewDto == null || id != reviewDto.Id) return BadRequest("Invalid review data.");

            var existingReview = await _reviewService.GetReviewByIdAsync(id);
            if (existingReview == null) return NotFound("Review not found.");

            var review = new Review
            {
                Id = reviewDto.Id,
                AccountId = reviewDto.AccountId,
                PackageId = reviewDto.PackageId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                CreateDate = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = reviewDto.IsActive
            };

            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingReview = await _reviewService.GetReviewByIdAsync(id);
            if (existingReview == null) return NotFound("Review not found.");

            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
