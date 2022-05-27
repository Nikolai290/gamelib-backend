using AutoMapper;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Infrastructure.Business.AutomapperProfiles {
    public class GameMappingProfile : Profile {
        public GameMappingProfile() {
            CreateMap<Game, GameOutDto>();
            CreateMap<CreateGameDto, Game>();
            CreateMap<UpdateGameDto, Game>();
        }
    }
}
