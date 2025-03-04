namespace FirstAPI.Serviece
{
    using FirstAPPWithAPI.Data.Models;
    using System.Collections;

    public interface IMovieServiece
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetByID(int id);
        Task<IEnumerable<Movie>> GetMovieByGenreID(byte genreid);
        Task<Movie> Add(Movie movie);
    }
}
