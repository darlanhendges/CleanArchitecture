
using FluentValidation;

namespace Webmotors.Domain.Entities
{

    public class AnuncioWebmotors : Entity
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public int Quilometragem { get; internal set; }
        public string Observacao { get; internal set; }


        public AnuncioWebmotors(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public void Update(string observacao, int quilometragem)
        {
            this.Quilometragem = quilometragem;
            this.Observacao = observacao;
        }


        public override void IsSatisfied()
        {
            var validator = new Validators.AnuncioWebmotors.GenericValidator();
            DefaultValidatorExtensions.ValidateAndThrow(validator, this);
        }
    }
}
