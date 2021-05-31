using System.Collections.Generic;
using System.Threading.Tasks;
using OC = Webmotors.Domain.ValueObjects.OnlineChallenge;

namespace Webmotors.Domain.Interfaces.Gateway
{
    public interface IGatewayOnlineChallenge
    {
        Task<IEnumerable<OC.Make.Response>> Make();
        Task<IEnumerable<OC.Model.Response>> Model(int makeID);
        Task<IEnumerable<OC.Version.Response>> Version(int modelID);
        Task<IEnumerable<OC.Vehicles.Response>> Vehicles(int page);
    }
}
