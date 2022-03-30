using System;
using System.Collections.Generic;

#nullable disable

namespace Handcraft_Route.domain.Entities
{
    public partial class ProductosArtesano
    {
        public int IdProductos { get; set; }
        public string NombreProducto { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string MaterialElaborado { get; set; }
        public string Fotografia { get; set; }
    }
}
