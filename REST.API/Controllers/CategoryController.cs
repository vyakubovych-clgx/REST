using Microsoft.AspNetCore.Mvc;
using REST.Services.DTOs;
using REST.Services.Exceptions;
using REST.Services.Interfaces;

namespace REST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CategoryDto>> GetAll()
            => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var model = await _service.GetByIdAsync(id).ConfigureAwait(false);
            return model is null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] AddUpdateCategoryDto model)
        {
            var newModel = await _service.AddAsync(model).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetById), new {newModel.Id}, newModel);
        }
            

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] AddUpdateCategoryDto model)
        {
            try
            {
                await _service.UpdateAsync(id, model).ConfigureAwait(false);
                return Ok();
            }
            catch (CategoryNotExistsException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id).ConfigureAwait(false);
                return Ok();
            }
            catch (CategoryNotExistsException)
            {
                return NotFound();
            }
        }
    }
}
