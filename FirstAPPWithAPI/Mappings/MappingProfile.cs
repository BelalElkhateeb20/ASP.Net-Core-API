namespace FirstAPI.Mappings
{
    using AutoMapper;
    using FirstAPI.DTOs;
    using FirstAPPWithAPI.Data.Models;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesDto>();
            CreateMap<MoviesDto, Movie>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore())
                .ForMember(dest=>dest.isQualified,op=>op.MapFrom(op=>op.Rate>7.5)); // Assuming Movie has a Poster property that needs special handling
        }
    }

}
