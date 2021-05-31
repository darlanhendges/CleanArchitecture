using FluentValidation;
using System;

namespace Webmotors.Domain.Validators.AnuncioWebmotors
{
    public class GenericValidator : AbstractValidator<Entities.AnuncioWebmotors>
    {
        public GenericValidator()
        {
            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("Marca não pode ser vazia.")
                .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para a Marca é de 45.");

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("Modelo não pode ser vazia.")
                .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para o Modelo é de 45.");

            RuleFor(x => x.Versao)
               .NotEmpty().WithMessage("Versão não pode ser vazia.")
               .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para a Versão é da 45.");

            RuleFor(x => x.Ano)
               .ExclusiveBetween(1950, DateTime.Now.Year).WithMessage($"O ano deve estar entre 1950 e {DateTime.Now.Year}.");


            RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Observação não pode ser vazia.");
        }
    }
}
