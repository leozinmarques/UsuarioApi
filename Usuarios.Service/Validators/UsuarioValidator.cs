using FluentValidation;
using Domain.Entities;
using System;

namespace Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor digite seu nome.")
                .NotNull().WithMessage("Por favor digite seu nome.");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor digite seu sobrenome.")
                .NotNull().WithMessage("Por favor digite seu sobrenome.");

            RuleFor(c => c.Email).NotEmpty().WithMessage("Por favor digite seu email")
                     .EmailAddress().WithMessage("Um email valido é necessário");

            RuleFor(c => c.DataNascimento)
                .LessThan(p => DateTime.Now).WithMessage("Por favor digite uma Data de Nascimento válida")
                .NotEmpty().WithMessage("Por favor digite sua Data de Nascimento.")
                .NotNull().WithMessage("Por favor digite sua Data de Nascimento.");

            RuleFor(c => c.Escolaridade)
                .NotNull().WithMessage("Por favor selecione uma escolaridade")
                .InclusiveBetween(1, 4).WithMessage("Selecione uma escolaridade válida");
        }
    }
}