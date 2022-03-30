using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Responses
{
    public class ArtesanoRESPONSES
    {
        //Aqui declaramos los valores que mostraremos al usuario cuando haga una consulta
        public int IdArtesanos {get; set;}
        public string InformacionGeneralArtesano {get; set;}
        public string MasInfo {get; set;}
        public string LugarArtesano {get; set;}
        public string GeoUbicacion {get; set;}

    }
}