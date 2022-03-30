using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcraft_Route.domain.dtos
{
    public record ArtesanoProdcutosRespond ( string NombreProducto, 
    string Descripcion, 
    string MaterialElaborado
    );
}