using FluentValidation;
using gamelib_backend.Business.Dtos;

namespace gamelib_backend.Infrastructure.Business.Validators {
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto> {
        public CreateCompanyDtoValidator() {
            ApplyRules();
        }

        private void ApplyRules() {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
