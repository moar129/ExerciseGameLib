using GameLib;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Game> Post([FromBody] Game value)
        {
            try
            {
                Game game = ConvertDTOToGame(value);
                Game addedGame = _repo.Add(game);
                return Created($"api/Games/{addedGame.Id}", addedGame);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<GamesController>/5
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public ActionResult<Game> Put(int id, [FromBody]Game value)
        {
            try
            {
                Game game = ConvertDTOToGame(value);
                Game? updatedGame = _repo.Update(id, game);
                if (updatedGame == null)
                {
                    return NotFound($"Item with id {id} not found.");
                }
                return Created($"api/Games/{updatedGame.Id}", updatedGame);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<GamesController>/5
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult<Game> Delete(int id)
        {
            try 
            { 
                Game? deletedGame = _repo.Delete(id);
                if (deletedGame == null)
                {
                    NotFound($"Item with id {id} not found.");
                }
                return Accepted($"api/Games/{deletedGame.Id}", deletedGame);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private Game ConvertDTOToGame(Game dto)
        {
            if (dto.Title == null) throw new ArgumentNullException("Title cannot be null");
            if (dto.Genre == null ) throw new ArgumentNullException("Genre cannot be null");

            Game game = new Game() { Title = dto.Title, Genre = dto.Genre, ReleaseYear = dto.ReleaseYear };
            return game;
        }
    }
}
