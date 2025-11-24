using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

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
                if (_connection is null)
                    throw new Exception("_connection is NUll");

                var films = new List<object>();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM film;", (NpgsqlConnection)_connection))
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var film = new
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Titre = reader.GetString(reader.GetOrdinal("titre")),
                                TitreCA = reader.GetString(reader.GetOrdinal("titreca")),
                                Annee = reader.GetDateTime(reader.GetOrdinal("annee"))
                            };

                            films.Add(film);
                        }
                        return Ok(films);
                    }
                }
            }

            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
    }
}
