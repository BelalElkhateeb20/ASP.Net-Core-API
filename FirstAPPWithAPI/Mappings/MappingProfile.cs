namespace FirstAPI.Mappings
{
    using AutoMapper;
    using FirstAPI.Data.IdentityMangement;
    using FirstAPI.DTOs;
    using FirstAPPWithAPI.Data.Models;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MoviesDto, Movie>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore())
                .ForMember(dest=>dest.isQualified,op=>op.MapFrom(op=>op.Rate>7.5));
            CreateMap<Movie, MoviesDto>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore());
                
            CreateMap<MovieDetailsDto, Movie>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore())
                .ForMember(dest=>dest.isQualified,op=>op.MapFrom(op=>op.Rate>7.5));

            CreateMap<RegisterDto, ApplicationUser>();
                
        }
    }

}
