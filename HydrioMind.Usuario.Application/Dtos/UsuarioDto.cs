using HydrioMind.Usuario.Domain.Interfaces.Dtos;
using HydrioMind.Usuario.Domain;

using FluentValidation;

namespace HydrioMind.Usuario.Application.Dtos
{
    public class UsuarioDto : IUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Razao_Social { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;  // Alterado para string

        public void Validate()
        {
            var validateResult = new UsuarioDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class UsuarioDtoValidation : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3).WithMessage(x => $"O campo {nameof(x.Nome)}, deve ter no minimo 3 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)}, não pode ser vazio");
            
            RuleFor(x => x.Razao_Social)
                .MinimumLength(3).WithMessage(x => $"O campo {nameof(x.Razao_Social)}, deve ter no minimo 3 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Razao_Social)}, não pode ser vazio");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(x => $"O {nameof(x.Email)}, não é valido")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)}, não pode ser vazio");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CNPJ)}, não pode ser vazio");
        }
    }
}
