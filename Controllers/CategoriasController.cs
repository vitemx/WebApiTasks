using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;
using WebApiSample.Services;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        ICategoriaService _services;
        TareasContext _dbContext;

        public CategoriasController(ICategoriaService services, TareasContext dbContext)
        {
            _services = services;
            _dbContext = dbContext;
        }
        public IActionResult Get()
        {
            return Ok(_services.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            await _services.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Categoria categoria)
        {
            await _services.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("CreateDb")]
        public IActionResult CreateDatabase()
        {
            _dbContext.Database.EnsureCreated();
            return Ok();
        }
    }
}