using FluentValidation;
using gamelib_backend.Business.Dtos;

namespace gamelib_backend.Infrastructure.Business.Validators {
    public class CreateGenreDtoValidator : AbstractValidator<CreateGenreDto> {
        public CreateGenreDtoValidator() {
            ApplyRules();
        }

        private void ApplyRules() {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
