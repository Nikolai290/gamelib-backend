using AutoMapper;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Infrastructure.Business.AutomapperProfiles {
    public class GenreMappingProfile : Profile {
        public GenreMappingProfile() {
            CreateMap<Genre, GenreOutDto>()
                .ForMember(
                    x => x.GameIds,
                    opt => opt.MapFrom(genre => genre.Games.Select(game => game.Id)));
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();
        }
    }
}
