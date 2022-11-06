using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNet.Monitoring.Common.Errors;
using DotNet.Monitoring.Contracts.Entities;
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

    public ProductsController(ProductContext context, ILogger<ProductsController> logger)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
      _logger = logger;
    }

    // GET: api/<ProductsController>

    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
    {
      var result = await _context.Products.ToListAsync();
      _logger.LogInformation($"Get: count - {result.Count}");
      _logger.LogTrace($"Get: count - {result.Count}");
      _logger.LogDebug($"Get: count - {result.Count}");
      var exception = ServerSide.RecordNotFound();
      _logger.LogError(exception, exception.Message);
      return result;
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
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
