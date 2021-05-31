using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Domain.Interfaces.Gateway;
using OC = Webmotors.Domain.ValueObjects.OnlineChallenge;

namespace Webmotors.Gateway
{
    public class GatewayOnlineChallenge : IGatewayOnlineChallenge
    {
        private const string  _url = "https://desafioonline.webmotors.com.br/api/OnlineChallenge/";
        private readonly RestClient _client;

        public GatewayOnlineChallenge()
        {
            _client = new RestClient(_url);
        }

        public async Task<IEnumerable<OC.Make.Response>> Make()
        {
            var request = new RestRequest("Make", DataFormat.Json);
            var response = await _client.GetAsync<IEnumerable<OC.Make.Response>>(request);

            return response;
        }

        public async Task<IEnumerable<OC.Model.Response>> Model(int makeID)
        {
            var request = new RestRequest($"Model?MakeID={makeID}", DataFormat.Json);
            var response = await _client.GetAsync<IEnumerable<OC.Model.Response>>(request);

            return response;
        }

        public async Task<IEnumerable<OC.Vehicles.Response>> Vehicles(int page)
        {
            var request = new RestRequest($"Vehicles?Page={page}", DataFormat.Json);
            var response = await _client.GetAsync<IEnumerable<OC.Vehicles.Response>>(request);
             return response;
        }

        public async Task<IEnumerable<OC.Version.Response>> Version(int modelID)
        {
            var request = new RestRequest($"Version?ModelID={modelID}", DataFormat.Json);
            var response = await _client.GetAsync<IEnumerable<OC.Version.Response>>(request);

            return response;
        }
    }
}
