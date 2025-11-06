using GameLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGaming<Game> _repo;
        public GamesController(IGaming<Game> repo)
        {
            _repo = repo;
        }
        // GET: api/<GamesController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            var teams = _repo.Get();
            if (teams.Count() == 0)
            {
                return NotFound("No gaming teams found.");
            }
            return Ok(teams);
        }

        // GET api/<GamesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<IGaming<Game>> Get(int id)
        {
            var team = _repo.Get(id);
            if (team == null)
            {
                return NotFound($"Item with id {id} not found.");
            }
            return Ok(team);
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<GamesController>/5
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
