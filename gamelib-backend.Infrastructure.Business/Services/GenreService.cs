using AutoMapper;
using FluentValidation;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces.Repositories;
namespace gamelib_backend.Infrastructure.Business.Services {
    public class GenreService : IGenreService {

        private readonly IGenreRepository genreRepository;
        private readonly IGameRepository gameRepository;
        private readonly IValidator<CreateGenreDto> createValidator;
        private readonly IValidator<UpdateGenreDto> updateValidator;
        private readonly IMapper mapper;

        public GenreService(
            IGenreRepository genreRepository,
            IGameRepository gameRepository,
            IValidator<CreateGenreDto> createValidator,
            IValidator<UpdateGenreDto> updateValidator,
            IMapper mapper
        ) {
            this.genreRepository = genreRepository;
            this.gameRepository = gameRepository;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
            this.mapper = mapper;
        }

        public async Task<GenreOutDto> CreateAsync(CreateGenreDto createDto) {
            await createValidator.ValidateAndThrowAsync(createDto);
            var genre = mapper.Map<Genre>(createDto);
            if (createDto.GameIds != null && createDto.GameIds.Count > 0) {
                genre.Games = await gameRepository.GetByIdsAsync(createDto.GameIds.ToArray());
            }
            await genreRepository.CreateAsync(genre);
            var outDto = mapper.Map<GenreOutDto>(genre);
            return outDto;
        }

        public async Task DeleteAsync(int id) {
            var genre = await genreRepository.GetByIdAsync(id);
            genre.Games.Clear();
            genre.IsDeleted = true;
            await genreRepository.UpdateAsync(genre);
        }

        public async Task<IList<GenreOutDto>> GetAllByAsync(RequestGenreDto requestDto) {
            var genres = await genreRepository.GetAllAsync();
            var result = genres
                .Where(x => requestDto.Id.HasValue ? x.Id == requestDto.Id : true)
                .Where(x => !string.IsNullOrEmpty(requestDto.Name)
                    ? requestDto.Name.ToLower().Contains(x.Name.ToLower())
                    : true)
                .Where(x => requestDto.GameIds != null && requestDto.GameIds.Count > 0
                    ? requestDto.GameIds.Except(x.Games.Select(game => game.Id)).Count() == 0
                    : true);
            var outDtos = mapper.Map<IList<GenreOutDto>>(result);
            return outDtos;
        }

        public Task<GenreOutDto> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<GenreOutDto> UpdateAsync(UpdateGenreDto updateDto) {
            await updateValidator.ValidateAndThrowAsync(updateDto);
            var genre = await genreRepository.GetByIdAsync(updateDto.Id);
            mapper.Map(updateDto, genre);

            if (!updateDto.GameIds.Equals(genre.Games.Select(x => x.Id))) {
                genre.Games.Clear();
                genre.Games = await gameRepository.GetByIdsAsync(updateDto.GameIds.ToArray());
            }

            await genreRepository.UpdateAsync(genre);
            var outDto = mapper.Map<GenreOutDto>(genre);
            return outDto;
        }
    }
}
