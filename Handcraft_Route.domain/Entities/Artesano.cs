using System;
using System.Collections.Generic;

#nullable disable

namespace Handcraft_Route.domain.Entities
{
    public partial class Artesano
    {
        public int IdArtesanos { get; set; }
        public string NombreArtesano { get; set; }
        public string MunicipioLocalidad { get; set; }
        public string TallerNegocio { get; set; }
        public string LogotipoNegocio { get; set; }
        public string RedesSociales { get; set; }
        public string Ubicacion { get; set; }
        public string GeoUbicacion { get; set; }
    }
}
