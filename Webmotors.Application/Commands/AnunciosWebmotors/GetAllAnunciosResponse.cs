using System.Collections.Generic;

namespace Webmotors.Application.Commands.AnunciosWebmotors
{
    public class GetAllAnunciosResponse
    {
        public List<AnuncioCommand> Anuncios { get; set; } = new List<AnuncioCommand>();
    }
}
