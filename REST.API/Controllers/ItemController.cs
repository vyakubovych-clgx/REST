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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemDto>> GetAll([FromQuery] ItemFilterDto filter)
            => Ok(_service.GetByFilter(filter));

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ItemDto>> GetById(int id)
        {
            var model = await _service.GetByIdAsync(id).ConfigureAwait(false);
            return model is null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ItemDto>> Post([FromBody] AddUpdateItemDto model)
        {
            try
            {
                var newModel = await _service.AddAsync(model).ConfigureAwait(false);
                return CreatedAtAction(nameof(GetById), new {newModel.Id}, newModel);
            }
            catch (CategoryNotExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
            

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] AddUpdateItemDto model)
        {
            try
            {
                await _service.UpdateAsync(id, model).ConfigureAwait(false);
                return Ok();
            }
            catch (ItemNotExistsException)
            {
                return NotFound();
            }
            catch (CategoryNotExistsException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ItemNotExistsException)
            {
                return NotFound();
            }
        }
    }
}
