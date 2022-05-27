using FluentValidation;
using gamelib_backend.Business.Dtos;

namespace gamelib_backend.Infrastructure.Business.Validators {
    public class UpdateGenreDtoValidator : AbstractValidator<UpdateGenreDto> {
        public UpdateGenreDtoValidator() {
            ApplyRules();
        }

        private void ApplyRules() {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
