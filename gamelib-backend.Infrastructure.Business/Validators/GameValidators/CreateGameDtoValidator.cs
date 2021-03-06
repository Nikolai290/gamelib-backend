using FluentValidation;
using gamelib_backend.Business.Dtos;

namespace gamelib_backend.Infrastructure.Business.Validators {
    public class CreateGameDtoValidator : AbstractValidator<CreateGameDto> {
        public CreateGameDtoValidator() {
            ApplyRules();
        }

        private void ApplyRules() {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
