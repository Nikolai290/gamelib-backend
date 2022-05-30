using AutoMapper;
using FluentValidation;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces.Repositories;
namespace gamelib_backend.Infrastructure.Business.Services {
    public class CompanyService : ICompanyService {

        private readonly ICompanyRepository companyRepository;
        private readonly IGameRepository gameRepository;
        private readonly IValidator<CreateCompanyDto> createValidator;
        private readonly IValidator<UpdateCompanyDto> updateValidator;
        private readonly IMapper mapper;

        public CompanyService(
            ICompanyRepository companyRepository,
            IGameRepository gameRepository,
            IValidator<CreateCompanyDto> createValidator,
            IValidator<UpdateCompanyDto> updateValidator,
            IMapper mapper
        ) {
            this.companyRepository = companyRepository;
            this.gameRepository = gameRepository;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
            this.mapper = mapper;
        }

        public async Task<CompanyOutDto> CreateAsync(CreateCompanyDto createDto) {
            await createValidator.ValidateAndThrowAsync(createDto);
            var company = mapper.Map<Company>(createDto);
            if (createDto.GameIds != null && createDto.GameIds.Count() > 0) {
                company.Games = await gameRepository.GetByIdsAsync(createDto.GameIds.ToArray());
            }
            await companyRepository.CreateAsync(company);
            var outDto = mapper.Map<CompanyOutDto>(company);
            return outDto;
        }

        public async Task DeleteAsync(int id) {
            var company = await companyRepository.GetByIdAsync(id);
            company.Games.Clear();
            company.IsDeleted = true;
            await companyRepository.UpdateAsync(company);
        }

        public async Task<IList<CompanyOutDto>> GetAllByAsync(RequestCompanyDto requestDto) {
            var companies = await companyRepository.GetAllAsync();
            var result = companies
                .Where(x => requestDto.Id.HasValue ? x.Id == requestDto.Id : true)
                .Where(x => !string.IsNullOrEmpty(requestDto.Name)
                    ? requestDto.Name.ToLower().Contains(x.Name.ToLower())
                    : true)
                .Where(x => requestDto.GameIds != null && requestDto.GameIds.Count > 0
                    ? requestDto.GameIds.Except(x.Games.Select(game => game.Id)).Count() == 0
                    : true);
            var outDtos = mapper.Map<IList<CompanyOutDto>>(result);
            return outDtos;
        }

        public Task<CompanyOutDto> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<CompanyOutDto> UpdateAsync(UpdateCompanyDto updateDto) {
            await updateValidator.ValidateAndThrowAsync(updateDto);
            var company = await companyRepository.GetByIdAsync(updateDto.Id);
            mapper.Map(updateDto, company);

            if (!updateDto.GameIds.Equals(company.Games.Select(x => x.Id))) {
                company.Games.Clear();
                company.Games = await gameRepository.GetByIdsAsync(updateDto.GameIds.ToArray());
            }

            await companyRepository.UpdateAsync(company);
            var outDto = mapper.Map<CompanyOutDto>(company);
            return outDto;
        }
    }
}
