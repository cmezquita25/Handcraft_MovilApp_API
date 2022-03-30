using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;

namespace Handcraft_Route.domain.Interfaces
{
    public interface IProductoArtSERVICE
    {
        bool ValidateProductosArt (ProductosArtesano productosArtesano);
        bool ValidateUpdateProductosArt (ProductosArtesano productosArtesano);
    }
}