using FirstAPI.DTOs;
using FirstAPI.Serviece;
using FirstAPPWithAPI.Data;
using FirstAPPWithAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenresServiece _genresServiece;

        public GenreController(IGenresServiece genresServiece)
        {
            this._genresServiece = genresServiece;
        }
        [HttpPost]
        [Route("")]
        public async Task <IActionResult> AddAsync(Genre dto)
        {
            var genre = new Genre{ Name = dto.Name};
            await _genresServiece.Add(genre);
            return Ok(genre);
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var record= await _genresServiece.GetAll();
            return Ok(record);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(byte Id)
        { 
            await _genresServiece.GetByID(Id);
            if (_genresServiece.GetByID(Id)==null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateAsync(byte id, [FromBody] GenreDto dto)
        {
            var genre = await _genresServiece.GetByID(id);
            if (genre == null)
                return NotFound($"Genre Not Found With ID {id} ");
            genre.Name = dto.Name;
            return Ok(genre);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresServiece.GetByID(id);
            if (genre == null)
                return NotFound($"Genre Not Found With ID {id} ");

            return Ok();
        }
    }
}
