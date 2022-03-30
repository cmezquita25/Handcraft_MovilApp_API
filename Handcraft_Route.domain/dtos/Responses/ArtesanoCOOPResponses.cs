using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Responses
{
    public class ArtesanoCOOPResponses
    {
        //Aqui declaramos los valores que mostraremos al usuario cuando haga una consulta
        public int IdCooperativa {get; set;}
        public string InformacionGeneralComercio {get; set;}
        public string LugarComercio {get; set;}
        public string GeoUbicacion {get; set;}
        public string Platillo1 {get; set;}
        public string Platillo2 {get; set;}
        public string Platillo3 {get; set;}
    }
}