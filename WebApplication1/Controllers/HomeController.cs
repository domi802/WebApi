using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;



namespace WebApplication1.Controllers { 
    [Route("api/[controller]")]
    [ApiController]


    public class MoviesController : ControllerBase
    {
        private readonly DvdrentalContext _context;

        public MoviesController(DvdrentalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Films.ToList();
            return Ok(movies);
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] FilmDto film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Film movie = new Film { Title = film.Title, Length = film.Length, LanguageId = film.LanguageId };
            _context.Films.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }
    }
}

