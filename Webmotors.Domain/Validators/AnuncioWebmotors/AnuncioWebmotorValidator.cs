using FluentValidation;
using System;

namespace Webmotors.Domain.Validators.AnuncioWebmotors
{
    public abstract class AnuncioWebmotorValidator: AbstractValidator<Entities.AnuncioWebmotors>
    {

        public AnuncioWebmotorValidator()
        {

        }

        protected void ValidateObservacao()
        {
            RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Observação não pode ser vazia.");
        }

        protected void ValidateAno()
        {
            RuleFor(x => x.Ano)
               .ExclusiveBetween(1950, DateTime.Now.Year).WithMessage($"O ano deve estar entre 1950 e {DateTime.Now.Year}.");
        }

        protected void ValidateVersao()
        {
            RuleFor(x => x.Versao)
               .NotEmpty().WithMessage("Versão não pode ser vazia.")
               .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para a Versão é da 45.");
        }

        protected void ValidateModelo()
        {
            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("Modelo não pode ser vazia.")
                .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para o Modelo é de 45.");
        }

        protected void ValidateMarca()
        {
            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("Marca não pode ser vazia.")
                .MaximumLength(45).WithMessage("Quantidade máxima de caracteres para a Marca é de 45.");
        }
    }
}
