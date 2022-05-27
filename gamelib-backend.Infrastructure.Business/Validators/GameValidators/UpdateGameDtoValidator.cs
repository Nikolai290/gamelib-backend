using FluentValidation;
using gamelib_backend.Business.Dtos;

namespace gamelib_backend.Infrastructure.Business.Validators {
    public class UpdateGameDtoValidator : AbstractValidator<UpdateGameDto> {
        public UpdateGameDtoValidator() {
            ApplyRules();
        }

        private void ApplyRules() {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
