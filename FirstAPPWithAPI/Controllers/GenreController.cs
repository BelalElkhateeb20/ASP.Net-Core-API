using FirstAPI.DTOs;
using FirstAPPWithAPI.Data;
using FirstAPPWithAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
            var result=await _dbcontext.Set<Genre>().ToListAsync();
            return Ok(result);
        }
    }
}
