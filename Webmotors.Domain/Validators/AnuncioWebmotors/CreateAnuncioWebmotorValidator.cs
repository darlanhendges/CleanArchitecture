using FluentValidation;
using System.Threading.Tasks;
using Webmotors.Domain.Interfaces.Repository;

namespace Webmotors.Domain.Validators.AnuncioWebmotors
{
    public class CreateAnuncioWebmotorValidator : AnuncioWebmotorValidator
    {
        private readonly IAnuncioWebmotorsRepository _repository;

        public CreateAnuncioWebmotorValidator(IAnuncioWebmotorsRepository repository)
        {
            _repository = repository;

            ValidateAno();
            ValidateMarca();
            ValidateModelo();
            ValidateObservacao();
            ValidateVersao();

            ValidateMarcaModeloAnoTogether();
        }
        
        private void ValidateMarcaModeloAnoTogether()
        {
            RuleFor(x => x).MustAsync((x, cancellation) => ValidateMarcaAndModeloAndAno(x)).WithMessage("Este modelo, ano e marca já estão cadastradas juntas.");
        }

        private async Task<bool> ValidateMarcaAndModeloAndAno(Entities.AnuncioWebmotors entity)
        {
            var result = await _repository.FindAllAsync(a => a.Marca.Equals(entity.Marca) && a.Modelo.Equals(entity.Modelo) && a.Ano.Equals(entity.Ano));
            return result.Count == 0;
        }

    }
}
