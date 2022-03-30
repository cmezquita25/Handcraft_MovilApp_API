using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.Interfaces;
using Handcraft_Route.infrastructure.Repositories;

namespace Handcraft_Route.application.Services
{
    public class ServiceProductosArt : IProductoArtSERVICE
    {
        //Aqui implementamos la validacion del Create
        public bool ValidateProductosArt (ProductosArtesano productosArtesano)
        {
            if(string.IsNullOrEmpty(productosArtesano.NombreProducto))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.Descripcion))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.MaterialElaborado))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.Fotografia))
                return false;

            return true;
        }

        public bool ValidateUpdateProductosArt(ProductosArtesano productosArtesano)
        {
            //Aqui implementamos la validacion del Update
            
            if(productosArtesano.IdProductos <= 0)
                return false;
                
            if(string.IsNullOrEmpty(productosArtesano.NombreProducto))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.Descripcion))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.MaterialElaborado))
                return false;

            if(string.IsNullOrEmpty(productosArtesano.Fotografia))
                return false;

            return true;
        }
    }
}