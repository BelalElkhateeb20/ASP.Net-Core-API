namespace FirstAPI.Serviece
{
    using FirstAPI.DTOs;
    using FirstAPPWithAPI.Data.Models;
    using System.Collections;

    public interface IMovieServiece
    {
        Task<IEnumerable<Movie>> GetAll(byte genreId= 0);
        Task<Movie> GetByID(int id);

        //Task<IEnumerable<Movie>> GetMovieByGenreID(byte genreid);
        Task<Movie> Add(Movie movie);
        Task<Movie> Update(int id, MovieDetailsDto detailsDto);



    }
}
