using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Requests
{
    //Aqui declaramos los valores de los cuales el validator usara para asegurarse de que estso existan y pueda validarlos
    public class ArtesanoCreateREQUEST
    {

        public string NombreArtesano { get; set; }
        public string MunicipioLocalidad { get; set; }
        public string TallerNegocio { get; set; }
        public string LogotipoNegocio { get; set; }
        public string Correo { get; set; }
        public string RedesSociales { get; set; }
        public string Ubicacion { get; set; }
        public string GeoUbicacion { get; set; }
    }
}