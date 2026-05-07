using ChaChaClub.API.Filters;
using ChaChaClub.Domains.Models.Dish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaChaClub.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly BusinessLogic.BusinessLogic _bl;

        public CategoriesController(BusinessLogic.BusinessLogic bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _bl.Categories().GetAll();
                return Ok(categories);
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
                var category = await _bl.Categories().GetById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            try
            {
                await _bl.Categories().Create(dto);
                return Ok(new { message = "Category created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCategoryDto dto)
        {
            try
            {
                await _bl.Categories().Update(id, dto);
                return Ok(new { message = "Category updated" });
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
                await _bl.Categories().Delete(id);
                return Ok(new { message = "Category deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}