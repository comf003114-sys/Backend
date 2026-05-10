using ChaChaClub.Domains.Models.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChaChaClub.API.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly BusinessLogic.BusinessLogic _bl;

        public ReviewsController(BusinessLogic.BusinessLogic bl)
        {
            _bl = bl;
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetByDish(int dishId)
        {
            try
            {
                var reviews = await _bl.Reviews().GetByDish(dishId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                await _bl.Reviews().Create(dto, userId);
                return Ok(new { message = "Review created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bl.Reviews().Delete(id);
                return Ok(new { message = "Review deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}