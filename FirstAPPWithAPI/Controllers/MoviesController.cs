using FirstAPI.DTOs;
using FirstAPI.Serviece;
using FirstAPPWithAPI.Data;
using FirstAPPWithAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private long _maxPosterSize = 1048576;
        private List<string> allowed_Extensions = new List<string> { ".jpg", ".png", ".jpeg" };
        private readonly IMovieServiece _movieServiece;

        public MoviesController(IMovieServiece movieServiece)
        {
            this._movieServiece = movieServiece;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            await _movieServiece.GetAll();
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var movie = await _movieServiece.GetByID(id);
            if (movie == null)
                return NotFound("Movie Not Found!");
            var dto = new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rate = movie.Rate,
                Storeline = movie.Storeline,
                Poster = movie.Poster,
                GenreId = movie.GenreId,
                GenreName = movie.Genre.Name
            };
            return Ok(dto);
        }

        [HttpGet]
        [Route("{genreid}")]
        public async Task<IActionResult> GetMovieByGenreIDAsync(byte genreid)
        {

          
                //If you want to exclue the GenreID use include exMethod
                //otherwise you can use select method to select the fields you want

                /*.Select(s => new MovieDetailsDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Year = s.Year,
                    Rate = s.Rate,
                    Storeline = s.Storeline,
                    Poster = s.Poster,
                    GenreName = s.Genre.Name
                })*/
                
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAsync([FromForm] MoviesDto dto)
        {
            if (allowed_Extensions.Contains(Path.GetExtension(dto.Poster.FileName).ToUpper()))
                return BadRequest("Invalid Poster Extension!");
            if (dto.Poster.Length > _maxPosterSize)
                return BadRequest("Poster Size is too large!");
            var isvalidGenre = await _dbcontext.movies.AnyAsync(x => x.Id == dto.GenreId);
            if (!isvalidGenre)
                return BadRequest("Invalid Genre!");
            using var datastream = new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);
            var movie = new Movie
            {
                Year = dto.Year,
                Rate = dto.Rate,
                Title = dto.Title,
                Storeline = dto.Storeline,
                Poster = datastream.ToArray(),
                GenreId = dto.GenreId
            };

            return Ok();
        }

    }
}
