using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos
{
    public record ArtesanoRespond (string NombreArtesano, 
    string MunicipioLocalidad, 
    string TallerNegocio, 
    string Correo, 
    string RedesSociales 
    );
}