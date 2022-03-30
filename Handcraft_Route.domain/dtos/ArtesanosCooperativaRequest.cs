using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos
{
    public record ArtesanosCooperativaResquest (int IdCooperativa, string NombreComercio, string Telefono, string Descripcion, string Platillo1, string Platillo2, string Platillo3, string Ubicacion, string GeoUbicacion);
}