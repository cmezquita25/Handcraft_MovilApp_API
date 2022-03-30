using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Responses
{
    public class ProductoArtRESPONSES
    {
        //Aqui declaramos los valores que mostraremos al usuario cuando haga una consulta
        public int IdProductos {get; set;}
        public string InformacionGeneralProducto{get; set;}
        public string DetallesProducto {get; set;}

    }
}