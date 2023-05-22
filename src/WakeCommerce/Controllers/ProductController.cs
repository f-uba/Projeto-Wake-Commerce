using Application.Commands;
using Domain.Entities.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WakeCommerce.Controllers
{
    [ApiController]
    [Route("Product")]
    public sealed class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ProductDTO>> PostAsync([FromBody] CreateProductCommand command)
        {
            try
            {
                if (command is not null)
                {
                    var response = await _mediator.Send(command);

                    return response is not null ? (ActionResult<ProductDTO>)Ok(response)
                        : throw new Exception("Unable to create a new product.");
                }
                return BadRequest("Sended a empty body object or 'Value' field is negative.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetAsync()
        {
            try
            {
                var command = new GetProductListCommand();
                var response = await _mediator.Send(command);

                if (response is null) return NoContent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Get/OrderBy")]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetAsync([FromQuery] GetProductListOrderByPropertyCommand command)
        {
            try
            {
                if (command is not null)
                {
                    var response = await _mediator.Send(command);

                    if (response is null) return NoContent();
                    return Ok(response);
                }

                return BadRequest("Sended a empty query object");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Get/ById")]
        public async Task<ActionResult<ProductDTO>> GetAsync([FromQuery] GetProductByIdCommand command)
        {
            try
            {
                if (command is not null)
                {
                    var response = await _mediator.Send(command);

                    if (response is null) return NotFound();
                    return Ok(response);
                }

                return BadRequest("Sended a empty query object");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProductDTO>> PutAsync([FromBody] UpdateProductCommand command)
        {
            try
            {
                if (command is not null)
                {
                    var response = await _mediator.Send(command);

                    return response is not null ? (ActionResult<ProductDTO>)Ok(command)
                        : throw new Exception("Unable to update the product.");
                }

                return BadRequest("Sended a empty body object");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/ById")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteProductByIdCommand command)
        {
            try
            {
                if (command is not null)
                {
                    var response = await _mediator.Send(command);
                    return response ? Ok() : NotFound();
                }

                return BadRequest("Sended a empty query object");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
