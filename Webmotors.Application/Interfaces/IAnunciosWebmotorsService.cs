using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Commands.AnunciosWebmotors;


namespace Webmotors.Application.Interfaces
{
    public interface IAnunciosWebmotorsService
    {
        Task<GetAllAnunciosResponse> GetAllAnuncios();
        Task<IEnumerable<GetMakeResponse>> GetMake();
        Task<IEnumerable<GetModelResponse>> GetModel(int makeID);
        Task<IEnumerable<GetVersionResponse>> GetVersion(int modelID);
        Task<IEnumerable<GetVehiclesResponse>> GetVehicles(int page);
        Task<CreateAnuncioResponse> Create(CreateAnuncioCommand command);
        Task Update(UpdateAnuncioCommand command);
        Task Delete(int id);
    }
}
