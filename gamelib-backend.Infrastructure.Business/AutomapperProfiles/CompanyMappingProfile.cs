using AutoMapper;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Infrastructure.Business.AutomapperProfiles {
    public class CompanyMappingProfile : Profile  {
        public CompanyMappingProfile() {
            CreateMap<Company, CompanyOutDto>()
                .ForMember(
                    x => x.GameIds,
                    opt => opt.MapFrom(company => company.Games.Select(game => game.Id)));
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();
        }
    }
}
