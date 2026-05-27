using ChaChaClub.API.Filters;
using ChaChaClub.Domains.Models.Wine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaChaClub.API.Controllers
{
    [ApiController]
    [Route("wines")]
    public class WinesController : ControllerBase
    {
        private readonly BusinessLogic.BusinessLogic _bl;

        public WinesController(BusinessLogic.BusinessLogic bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var wines = await _bl.Wines().GetAll();
                return Ok(wines);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            try
            {
                var wines = await _bl.Wines().GetByCategory(category);
                return Ok(wines);
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
                var wine = await _bl.Wines().GetById(id);
                return Ok(wine);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Create([FromBody] CreateWineDto dto)
        {
            try
            {
                await _bl.Wines().Create(dto);
                return Ok(new { message = "Wine created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        [AdminMod]
        public async Task<IActionResult> Update(int id, [FromBody] CreateWineDto dto)
        {
            try
            {
                await _bl.Wines().Update(id, dto);
                return Ok(new { message = "Wine updated" });
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
                await _bl.Wines().Delete(id);
                return Ok(new { message = "Wine deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}