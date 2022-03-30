using System;
using System.Collections.Generic;

#nullable disable

namespace Handcraft_Route.domain.Entities
{
    public partial class ArtesanosCooperativa
    {
        public int IdCooperativa { get; set; }
        public string NombreComercio { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string Platillo1 { get; set; }
        public string Platillo2 { get; set; }
        public string Platillo3 { get; set; }
        public string Ubicacion { get; set; }
        public string GeoUbicacion { get; set; }
    }
}
