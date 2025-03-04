using FirstAPI.DTOs;
using FirstAPPWithAPI.Data;
using FirstAPPWithAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppdbContext _dbcontext;

        public GenreController(AppdbContext context)
        {
            this._dbcontext = context;
        }
        [HttpPost]
        [Route("")]
        public async Task <IActionResult> AddAsync(GenreDto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name
            };
            await _dbcontext.AddAsync(genre);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result=await _dbcontext.Set<Genre>().OrderBy(or=>or.Name).ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateAsync(int id, [FromBody] GenreDto dto)
        {
            var genre =await _dbcontext.genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genre == null)
                return NotFound($"Genre Not Found With ID {id} ");
            genre.Name = dto.Name;
            await _dbcontext.SaveChangesAsync();
            return Ok(genre);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre =await _dbcontext.genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genre == null)
                return NotFound($"Genre Not Found With ID {id} ");
             _dbcontext.genres.Remove(genre);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
    }
}
