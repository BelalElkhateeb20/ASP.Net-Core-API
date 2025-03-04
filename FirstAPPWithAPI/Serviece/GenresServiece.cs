namespace FirstAPI.Serviece
{
    using FirstAPI.DTOs;
    using FirstAPPWithAPI.Data;
    using FirstAPPWithAPI.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenresServiece : IGenresServiece
    {
        private readonly AppdbContext _dbcontext;

        public GenresServiece(AppdbContext context)
        {
            _dbcontext = context ;
        }
        public async Task<Genre> Add(Genre dto)
        {
            await _dbcontext.AddAsync(dto);
            await _dbcontext.SaveChangesAsync();
            return dto;
        }

        public Genre Delete(Genre genre)
        {
            _dbcontext.Remove(genre);
             _dbcontext.SaveChangesAsync();
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _dbcontext.genres.OrderBy(or => or.Name).ToListAsync();
            
        }

        public async Task<Genre> GetByID(byte id)
        {
            var record = await _dbcontext.genres.FindAsync(id);
            return record!;
        }

        public  Genre Update(Genre genre)
        {
            _dbcontext.genres.Update(genre);
             _dbcontext.SaveChangesAsync();
            return genre;
        }
    }
}
