using gamelib_backend.Business.Dtos;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Controllers {
    public class CompanyController
            : BaseCrudController<Company, int, RequestCompanyDto, CompanyOutDto, CreateCompanyDto, UpdateCompanyDto> {
        public CompanyController(ICompanyService service) : base(service) {
        }
    }
}
