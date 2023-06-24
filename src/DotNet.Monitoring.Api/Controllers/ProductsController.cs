using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using DotNet.Monitoring.Common.Errors;
using DotNet.Monitoring.Contracts.Entities;
using DotNet.Monitoring.Contracts.Services.Dtos;
using DotNet.Monitoring.Infrastructure.Persistence;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet.Monitoring.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly ProductContext _context;
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _mapper;

    public ProductsController(ProductContext context, ILogger<ProductsController> logger, IMapper mapper)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
      _logger = logger;
      _mapper = mapper;
    }

    // GET: api/<ProductsController>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
      var products = await _context.Products.ToListAsync();
      var result = _mapper.Map<IEnumerable<ProductDto>>(products);

      return Ok(result);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
      var result = await _context.Products.FindAsync(id);
      if (result == null)
      {
        var exception = ServerSide.RecordNotFound();
        _logger.LogError(exception, exception.Message);
        return NotFound(exception);
      }
      var productDto = _mapper.Map<ProductDto>(result);
      return Ok(productDto);
    }

    // POST api/<ProductsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ProductsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
