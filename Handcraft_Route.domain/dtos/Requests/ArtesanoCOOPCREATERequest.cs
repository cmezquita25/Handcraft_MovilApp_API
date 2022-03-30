using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Requests
{
    public class ArtesanoCOOPCREATERequest
    {
        //Aqui declaramos los valores de los cuales el validator usara para asegurarse de que estso existan y pueda validarlos
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