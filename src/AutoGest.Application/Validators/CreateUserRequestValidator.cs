using AutoGest.Application.DTOs;
using FluentValidation;

namespace AutoGest.Application.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Nome completo é obrigatório.")
            .MaximumLength(150).WithMessage("Nome completo deve ter no máximo 150 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.")
            .MaximumLength(100).WithMessage("E-mail deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.")
            .Matches(@"[0-9]").WithMessage("Senha deve conter ao menos um número.")
            .Matches(@"[^a-zA-Z0-9]").WithMessage("Senha deve conter ao menos um caractere especial.");

        RuleFor(x => x.TenantId)
            .NotEmpty().WithMessage("TenantId é obrigatório.");
    }
}
