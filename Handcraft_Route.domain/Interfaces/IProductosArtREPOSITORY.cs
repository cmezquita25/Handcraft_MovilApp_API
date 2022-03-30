using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handcraft_Route.domain.Interfaces
{
    public interface IProductosArtREPOSITORY
    {
        Task<IEnumerable<ProductosArtesano>> HCRdatos();
        Task<ProductosArtesano> BuscarID(int id);
        Task<int> create(ProductosArtesano productosArtesano);
        Task<bool> Update(int id, ProductosArtesano productosArtesano);

        void EliminarArtesano(int id);
    }
}