namespace FirstAPI.Mappings
{
    using AutoMapper;
    using FirstAPI.DTOs;
    using FirstAPPWithAPI.Data.Models;

    public class MappingForMovieDto:Profile
    {
        public MappingForMovieDto()
        {
            CreateMap<Movie, MoviesDto>();
        }
    }
}
