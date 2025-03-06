using AutoMapper;
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
        private readonly IGenresServiece genresServiece;
        private readonly IMapper _mapper;

        public MoviesController(IMovieServiece movieServiece, IGenresServiece genresServiece, IMapper mapper)
        {
            this._movieServiece = movieServiece;
            this.genresServiece = genresServiece;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var movie = await _movieServiece.GetAll();
            var dto = _mapper.Map<IEnumerable<MoviesDto>>(movie);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var movie = await _movieServiece.GetByID(id);
            if (movie == null)
                return NotFound("Movie Not Found!");
            var dto = _mapper.Map<MoviesDto>(movie);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{genreid}")]
        public async Task<IActionResult> GetMovieByGenreIDAsync(byte genreid)
        {

            var movies = await _movieServiece.GetAll(genreid);
            //If you want to exclue the GenreID use include exMethod
            //otherwise you can use select method to select the fields you want
            if(movies == null)
                return NotFound("No Movies Found!");
            var dto =  _mapper.Map<IEnumerable<MoviesDto>>(movies);
            return Ok(dto);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAsync([FromForm] MoviesDto dto)
        {
            if (allowed_Extensions.Contains(Path.GetExtension(dto.Poster.FileName).ToUpper()))
                return BadRequest("Invalid Poster Extension!");
            if (dto.Poster.Length > _maxPosterSize)
                return BadRequest("Poster Size is too large!");
            var isvalidGenre = await genresServiece.IsValidGenre(dto.GenreId);
            if (!isvalidGenre)
                return BadRequest("Invalid Genre!");
            using var datastream = new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);
            var movie = _mapper.Map<Movie>(dto);
            movie.Poster = datastream.ToArray();
            await _movieServiece.Add(movie);
            return Ok();
        }
    }
}   
