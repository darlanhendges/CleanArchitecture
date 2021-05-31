using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using Webmotors.Application.Commands.AnunciosWebmotors;

namespace Webmotors.Application.Automapper
{
    public class CurrencyMapping : Profile
    {
        public CurrencyMapping()
        {
            RegisterApplicationMappings();
            RegisterDomainMappings();
        }

        public void RegisterApplicationMappings()
        {
            CreateMap<Domain.ValueObjects.OnlineChallenge.Make.Response, Commands.AnunciosWebmotors.GetMakeResponse>();
            CreateMap<Domain.ValueObjects.OnlineChallenge.Model.Response, Commands.AnunciosWebmotors.GetModelResponse>();
            CreateMap<Domain.ValueObjects.OnlineChallenge.Vehicles.Response, Commands.AnunciosWebmotors.GetVehiclesResponse>();
            CreateMap<Domain.ValueObjects.OnlineChallenge.Version.Response, Commands.AnunciosWebmotors.GetVersionResponse>();

            CreateMap<Domain.Entities.AnuncioWebmotors, AnuncioCommand>();
            CreateMap<Domain.Entities.AnuncioWebmotors, CreateAnuncioResponse>();
        }

        public void RegisterDomainMappings()
        {
            
            

        }
    }
}
