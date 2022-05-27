using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Controllers {
    public class GameController
            : BaseCrudController<Game, int, RequestGameDto, GameOutDto, CreateGameDto, UpdateGameDto> {
        public GameController(IGameService service) : base(service) {
        }
    }
}
