using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Commands.AnunciosWebmotors;
using Webmotors.Application.Interfaces;
using Webmotors.Domain.Entities;
using Webmotors.Domain.Interfaces.Gateway;
using Webmotors.Domain.Interfaces.Repository;
using Webmotors.Infraestructure.Interfaces;

namespace Webmotors.Application.Services
{
    public class AnunciosWebmotorsService : IAnunciosWebmotorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnuncioWebmotorsRepository _anuncioRepository;
        private readonly IGatewayOnlineChallenge _gatewayOnlineChallenge;
        private readonly IMapper _mapper;


        public AnunciosWebmotorsService(
            IUnitOfWork unitOfWork,
            IAnuncioWebmotorsRepository anuncioRepository,
            IGatewayOnlineChallenge gatewayOnlineChallenge,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _anuncioRepository = anuncioRepository;
            _gatewayOnlineChallenge = gatewayOnlineChallenge;
            _mapper = mapper;
        }

        public async Task<GetAllAnunciosResponse> GetAllAnuncios()
        {
            var response = new GetAllAnunciosResponse();
            var anuncios = await _anuncioRepository.GetAllAsync();

            foreach (var anuncio in anuncios)
                response.Anuncios.Add(_mapper.Map<AnuncioCommand>(anuncio));

            return response;
        }

        public async Task<CreateAnuncioResponse> Create(CreateAnuncioCommand command)
        {

            var anuncioEntity = new AnuncioWebmotors(
                    command.Marca,
                    command.Modelo,
                    command.Versao,
                    command.Ano,
                    command.Quilometragem,
                    command.Observacao
                );

            anuncioEntity.IsSatisfied();

            using (_unitOfWork)
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var newEntity = await _anuncioRepository.AddAsync(anuncioEntity);
                    await _unitOfWork.CommitAsync();

                    var response = _mapper.Map<CreateAnuncioResponse>(newEntity);
                    return response;
                }
                catch
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task Update(UpdateAnuncioCommand command)
        {
            var anuncio = await _anuncioRepository.FindAsync(a => a.ID == command.ID);

            if (anuncio == null)
                throw new ValidationException("Não foi encontrado anuncio com esse identificador");

            anuncio.Update(command.Observacao, command.Quilometragem);
            anuncio.IsSatisfied();

            using (_unitOfWork)
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var newEntity = await _anuncioRepository.UpdateAsync(anuncio, anuncio.ID);
                    await _unitOfWork.CommitAsync();
                }
                catch
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<GetMakeResponse>> GetMake()
        {

            var response = await _gatewayOnlineChallenge.Make();

            var listMake = _mapper.Map<IEnumerable<GetMakeResponse>>(response);

            return listMake;
        }

        public async Task<IEnumerable<GetModelResponse>> GetModel(int makeID)
        {
            var response = await _gatewayOnlineChallenge.Model(makeID);

            var listMake = _mapper.Map<IEnumerable<GetModelResponse>>(response);

            return listMake;
        }

        public async Task<IEnumerable<GetVehiclesResponse>> GetVehicles(int page)
        {
            var response = await _gatewayOnlineChallenge.Vehicles(page);

            var listMake = _mapper.Map<IEnumerable<GetVehiclesResponse>>(response);

            return listMake;
        }

        public async Task<IEnumerable<GetVersionResponse>> GetVersion(int modelID)
        {
            var response = await _gatewayOnlineChallenge.Version(modelID);

            var listMake = _mapper.Map<IEnumerable<GetVersionResponse>>(response);

            return listMake;
        }

        public async Task Delete(int id)
        {
            var anuncio = await _anuncioRepository.FindAsync(a => a.ID == id);

            if (anuncio == null)
                throw new ValidationException("Não foi encontrado anuncio com esse identificador");

            using (_unitOfWork)
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var newEntity = await _anuncioRepository.DeleteAsync(anuncio);
                    await _unitOfWork.CommitAsync();
                }
                catch
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
