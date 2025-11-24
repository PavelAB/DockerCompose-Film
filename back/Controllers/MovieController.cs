using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace FilmApiPostgreSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly DbConnection _connection;

        public MovieController(DbConnection connection)
        {
            _connection = connection;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                _connection.Open();
                return Ok(new { message="test"});
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
    }
}
