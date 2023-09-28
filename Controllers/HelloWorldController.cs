using Microsoft.AspNetCore.Mvc;
using WebApiSample.Services;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService _helloWorldService;
        TareasContext _dbContext;

        public HelloWorldController(IHelloWorldService helloWorld, TareasContext dbContext)
        {
            _helloWorldService = helloWorld;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_helloWorldService.GetHelloWorld());
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