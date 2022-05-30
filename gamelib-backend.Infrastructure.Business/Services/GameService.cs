using AutoMapper;
using FluentValidation;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces.Repositories;
using System.Reflection.Metadata;

namespace gamelib_backend.Infrastructure.Business.Services {
    public class GameService : IGameService {

        private readonly ICompanyRepository companyRepository;
        private readonly IGenreRepository genreRepository;
        private readonly IGameRepository gameRepository;
        private readonly IValidator<CreateGameDto> createValidator;
        private readonly IValidator<UpdateGameDto> updateValidator;
        private readonly IMapper mapper;

        public GameService(
            ICompanyRepository companyRepository,
            IGenreRepository genreRepository,
            IGameRepository gameRepository,
            IValidator<CreateGameDto> createValidator,
            IValidator<UpdateGameDto> updateValidator,
            IMapper mapper
        ) {
            this.companyRepository = companyRepository;
            this.genreRepository = genreRepository;
            this.gameRepository = gameRepository;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
            this.mapper = mapper;
        }

        public async Task<GameOutDto> CreateAsync(CreateGameDto createDto) {
            await createValidator.ValidateAndThrowAsync(createDto);
            var game = mapper.Map<Game>(createDto);
            if (createDto.CompanyId.HasValue) {
                game.Company = await companyRepository.GetByIdAsync(createDto.CompanyId.Value);
            }
            if (createDto.GenreIds != null && createDto.GenreIds.Count > 0) {
                game.Genres = await genreRepository.GetByIdsAsync(createDto.GenreIds.ToArray());
            }
            await gameRepository.CreateAsync(game);
            var outDto = mapper.Map<GameOutDto>(game);
            return outDto;
        }

        public async Task DeleteAsync(int id) {
            var game = await gameRepository.GetByIdAsync(id);
            game.Company = null;
            game.Genres.Clear();
            game.IsDeleted = true;
            await gameRepository.UpdateAsync(game);
        }

        public async Task<IList<GameOutDto>> GetAllByAsync(RequestGameDto requestDto) {
            var games = await gameRepository.GetAllAsync();
            var result = games
                .Where(x => !x.IsDeleted)
                .Where(x => requestDto.Id != null
                    ? x.Id == requestDto.Id
                    : true)
                .Where(x => requestDto.CompanyId != null
                    ? x.Company.Id == requestDto.CompanyId
                    : true)
                .Where(x => requestDto.GenreIds != null && requestDto.GenreIds.Count > 0
                    ? requestDto.GenreIds.Except(x.Genres.Select(genre => genre.Id)).Count() == 0
                    : true)
                .Where(x => !string.IsNullOrEmpty(requestDto.Name)
                    ? requestDto.Name.ToLower().Contains(x.Name.ToLower())
                    : true);
            var outDtos = mapper.Map<IList<GameOutDto>>(result);
            return outDtos;
        }

        public Task<GameOutDto> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<GameOutDto> UpdateAsync(UpdateGameDto updateDto) {
            await updateValidator.ValidateAndThrowAsync(updateDto);
            var game = await gameRepository.GetByIdAsync(updateDto.Id);
            mapper.Map(updateDto, game);
            if (game.Company.Id != updateDto.CompanyId) {
                game.Company = await companyRepository.GetByIdAsync(updateDto.CompanyId);
            }
            if (!game.Genres.Select(x => x.Id).ToList().OrderBy(x => x).SequenceEqual(updateDto.GenreIds.OrderBy(x => x))) {
                game.Genres.Clear();
                game.Genres = await genreRepository.GetByIdsAsync(updateDto.GenreIds.ToArray());
            }
            await gameRepository.UpdateAsync(game);
            var outDto = mapper.Map<GameOutDto>(game);
            return outDto;
        }
    }
}
