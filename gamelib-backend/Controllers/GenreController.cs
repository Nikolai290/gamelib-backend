using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Controllers {
    public class GenreController
            : BaseCrudController<Genre, int, RequestGenreDto, GenreOutDto, CreateGenreDto, UpdateGenreDto> {
        public GenreController(IGenreService service) : base(service) {
        }
    }
}
