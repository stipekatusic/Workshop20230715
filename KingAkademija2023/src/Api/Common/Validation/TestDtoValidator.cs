using Application.Common.Dtos;
using FluentValidation;

namespace Api.Common.Validation
{
    public class TestDtoValidator : AbstractValidator<TestDto>
    {
        public TestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ime ne smije biti prazno!");
        }
    }
}
