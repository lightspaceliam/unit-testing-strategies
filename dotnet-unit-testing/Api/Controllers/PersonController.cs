using DataService.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IDataService<Person> _personDataService;

        public PersonController(
            ILogger<PersonController> logger,
            IDataService<Person> personDataService)
        {
            _logger = logger;
            _personDataService = personDataService;
        }

        [HttpGet("find/{id}")]
        public ActionResult Find(string id)
        {
            var response = _personDataService.Find(p => p.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            if (!response.Any())
            {
                _logger.LogInformation($"Person: {id} not found.");
                return NotFound();
            }

            var person = response
                .First();

            return Ok(person);
        }
    }
}