using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos
{
    public record ArtesanoRequest (int IdArtesanos, 
    string NombreArtesano, 
    string MunicipioLocalidad, 
    string TallerNegocio, 
    string LogotipoNegocio, 
    string Correo, 
    string RedesSociales, 
    string Ubicacion, 
    string GeoUbicacion);
}