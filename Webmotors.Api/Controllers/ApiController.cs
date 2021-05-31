using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Commands.AnunciosWebmotors;
using Webmotors.Application.Interfaces;

namespace Webmotors.Api.Controllers
{

    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IAnunciosWebmotorsService _serviceAnuncios;

        public ApiController(IAnunciosWebmotorsService serviceAnuncios)
        {
            _serviceAnuncios = serviceAnuncios;
        }


        [HttpGet]
        [Route("api/make")]
        [SwaggerResponse(200, Type = typeof(List<GetMakeResponse>))]
        public async Task<IActionResult> GetMake() => Ok(await _serviceAnuncios.GetMake());

        [HttpGet]
        [Route("api/model/{makeID}")]
        [SwaggerResponse(200, Type = typeof(List<GetModelResponse>))]
        public async Task<IActionResult> GetModel(int makeID) => Ok(await _serviceAnuncios.GetModel(makeID));

        [HttpGet]
        [Route("api/version/{modalID}")]
        [SwaggerResponse(200, Type = typeof(List<GetVersionResponse>))]
        public async Task<IActionResult> GetVersion(int modelID) => Ok(await _serviceAnuncios.GetVersion(modelID));

        [HttpGet]
        [Route("api/vehicle/{page}")]
        [SwaggerResponse(200, Type = typeof(List<GetVehiclesResponse>))]
        public async Task<IActionResult> GetVehicles(int page) => Ok(await _serviceAnuncios.GetVehicles(page));

        [HttpPost]
        [Route("api/anuncio")]
        [Consumes("application/json")]
        [SwaggerResponse(200, Type = typeof(CreateAnuncioResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAnuncio([FromBody] CreateAnuncioCommand command) => Ok(await _serviceAnuncios.Create(command));

        [HttpPut]
        [Route("api/anuncio")]
        [Consumes("application/json")]
        [SwaggerResponse(200, Type = typeof(CreateAnuncioResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task UpdateAnuncio([FromBody] UpdateAnuncioCommand command) => await _serviceAnuncios.Update(command);

        [HttpGet]
        [Route("api/anuncios")]
        [SwaggerResponse(200, Type = typeof(List<GetVehiclesResponse>))]
        public async Task<IActionResult> GetAllAnuncios() => Ok(await _serviceAnuncios.GetAllAnuncios());

        [HttpDelete]
        [Route("api/anuncio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task DeleteAnuncio(int id) => await _serviceAnuncios.Delete(id);
    }
}
