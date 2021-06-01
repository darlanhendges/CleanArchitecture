using FluentValidation;
using System.Threading.Tasks;
using Webmotors.Domain.Interfaces.Repository;

namespace Webmotors.Domain.Validators.AnuncioWebmotors
{
    public class UpdateAnuncioWebmotorValidator : AnuncioWebmotorValidator
    {
        private readonly IAnuncioWebmotorsRepository _repository;

        public UpdateAnuncioWebmotorValidator(IAnuncioWebmotorsRepository repository)
        {
            _repository = repository;

            ValidateIfExists();
            ValidateObservacao();
        }

        private void ValidateIfExists()
        {
            RuleFor(x => x).MustAsync((x, cancellation) => ValidateIfExistsValidator(x)).WithMessage("Não foi encontrado anuncio com esse identificador");
        }

        private async Task<bool> ValidateIfExistsValidator(Entities.AnuncioWebmotors entity)
        {
            var anuncio = await _repository.FindAsync(a => a.ID == entity.ID);
            return anuncio != null;
        }

    }
}
