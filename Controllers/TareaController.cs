using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;
using WebApiSample.Services;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareasService _services;

        public TareaController(ITareasService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            await _services.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Tarea tarea)
        {
            await _services.Update(id, tarea);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.Delete(id);
            return Ok();
        }
    }
}