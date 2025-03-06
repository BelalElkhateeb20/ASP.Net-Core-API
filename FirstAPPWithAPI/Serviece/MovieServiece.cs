namespace FirstAPI.Serviece
{
    using FirstAPPWithAPI.Data;
    using FirstAPPWithAPI.Data.Models;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovieServiece : IMovieServiece
    {
        private readonly AppdbContext _dbcontext;

        public MovieServiece(AppdbContext context)
        {
            this._dbcontext = context;
        }
        public async Task<Movie> Add(Movie movie)
        {
            await _dbcontext.AddAsync(movie);
            await _dbcontext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetByID(int id)
        {
            var movie = await _dbcontext.movies.FindAsync(id);
            return movie!;
        }

        public async Task<IEnumerable<Movie>> GetAll(byte genreId = 0)
        {
            var movies = await _dbcontext.movies
                .Where(w => w.GenreId == genreId || genreId == 0)
                .OrderByDescending(or => or.Rate)
                .Include(i => i.Genre)
                .ToListAsync();
            return movies;
        }


    
    }
}
