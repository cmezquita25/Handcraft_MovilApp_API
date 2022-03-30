using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.infraestructure.Data;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handcraft_Route.infrastructure.Repositories
{
    public class ProductosArtSQLrepositorys : IProductosArtREPOSITORY
    {
        //Conexion de datos
        private readonly CFPHandcraftRouteContext _context;

        public ProductosArtSQLrepositorys(CFPHandcraftRouteContext context)
        {
            _context = context;
        }
        //Aqui mandamos a buscar todos los datos existentes en nuestra base de datos de Productos
        public async Task<IEnumerable<ProductosArtesano>> HCRdatos() 
        {
            var productosArtesanos = _context.ProductosArtesanos.Select(All => All);
            return await productosArtesanos.ToListAsync();
        }

        //Aqui mandamos a buscar nuestros datos existentes en nuestra base de datos de Productos por medio e una ID
        public async Task<ProductosArtesano> BuscarID(int id)
        {
            var query = await _context.ProductosArtesanos.FirstOrDefaultAsync(co => co.IdProductos == id);
            return query;
        }

        //Aqui asignamos los metodos para un create de datos en la Base de datos para Productos
        public async Task<int> create(ProductosArtesano productosArtesano)
        {
            var entity = productosArtesano;
            await _context.ProductosArtesanos.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdProductos;
        }

        //Aqui asignamos los metodos para un update a un dato en especifico por medio de la ID en la Base de datos para Productos
        public async Task<bool> Update(int id, ProductosArtesano productosArtesano)
        {
            if(id <= 0 || productosArtesano == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await BuscarID(id);

            entity.NombreProducto = productosArtesano.NombreProducto;
            entity.Descripcion = productosArtesano.Descripcion;
            entity.MaterialElaborado = productosArtesano.MaterialElaborado;
            entity.Fotografia = productosArtesano.Fotografia;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public void EliminarArtesano(int id)
        {
            var Eliminar = _context.ProductosArtesanos.FirstOrDefault(i => i.IdProductos == id);

            if(Eliminar!=null)
            {
                _context.ProductosArtesanos.Remove(Eliminar);
                _context.SaveChanges();
            }
        }
    }
}