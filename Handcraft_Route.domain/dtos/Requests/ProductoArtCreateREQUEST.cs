using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos.Requests
{
    //Aqui declaramos los valores de los cuales el validator usara para asegurarse de que estso existan y pueda validarlos
    public class ProductoArtCreateREQUEST
    {
        
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string MaterialElaborado { get; set; }
        public string Fotografia { get; set; }
    }
}