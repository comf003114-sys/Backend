using ChaChaClub.API.Filters;
using ChaChaClub.Domains.Models.Dish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaChaClub.API.Controllers
{
    [ApiController]
    [Route("dishes")]
    public class DishesController : ControllerBase
    {
        private readonly BusinessLogic.BusinessLogic _bl;

        public DishesController(BusinessLogic.BusinessLogic bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dishes = await _bl.Dishes().GetAll();
                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            try
            {
                var dishes = await _bl.Dishes().GetByCategory(categoryId);
                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("daily-dish")]
        public async Task<IActionResult> GetDailyDish()
        {
            try
            {
                var dish = await _bl.Dishes().GetDailyDish();
                return Ok(dish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var dish = await _bl.Dishes().GetById(id);
                return Ok(dish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Create([FromBody] CreateDishDto dto)
        {
            try
            {
                await _bl.Dishes().Create(dto);
                return Ok(new { message = "Dish created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDishDto dto)
        {
            try
            {
                await _bl.Dishes().Update(id, dto);
                return Ok(new { message = "Dish updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bl.Dishes().Delete(id);
                return Ok(new { message = "Dish deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}