namespace FirstAPI.Serviece
{
    using FirstAPPWithAPI.Data;
    using FirstAPPWithAPI.Data.Models;
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

        public Task<Movie> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenreID(byte genreid)
        {
            var movies = await _dbcontext.movies.Where(g => g.GenreId == genreid).Include(i => i.Genre).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _dbcontext.movies
                .Include(i => i.Genre)
                .OrderByDescending(or => or.Rate).ToListAsync();
            return movies;
        }
    }
}
