using Microsoft.AspNetCore.Mvc;
using SalesBuzz.API.DTOs;
using SalesBuzz.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
namespace SalesBuzz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

       
        [HttpGet]
        [EnableQuery]
        public IQueryable<ProductDto> GetAll()
        {
            return _service.GetAll();
        }

        
        [HttpGet("{id}")]
        
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var product = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, PatchProductDto dto)
        {
            var updated = await _service.PatchAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}