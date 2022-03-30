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
    public class ArtesanosCoopSQLrepositorys : IArtesanosCOOPRespository
    {
        //Conexion de datos
        private readonly CFPHandcraftRouteContext _context;

        public ArtesanosCoopSQLrepositorys(CFPHandcraftRouteContext context)
        {
            _context = context;
        }

        //Aqui mandamos a buscar todos los datos existentes en nuestra base de datos de Artesanos Cooperativa
        public async Task<IEnumerable<ArtesanosCooperativa>> HCRdatos() 
        {
            var artesanosCooperativas = _context.ArtesanosCooperativas.Select(All => All);
            return await artesanosCooperativas.ToListAsync();
        }

        //Aqui mandamos a buscar nuestros datos existentes en nuestra base de datos de Artesanos Cooperativa por medio e una ID
        public async Task<ArtesanosCooperativa> BuscarID(int id)
        {
            var query = await _context.ArtesanosCooperativas.FirstOrDefaultAsync(co => co.IdCooperativa == id);
            return query;
        }

        //Aqui asignamos los metodos para un create de datos en la Base de datos para Artesanos Cooperativa
        public async Task<int> create(ArtesanosCooperativa artesanosCooperativa)
        {
            var entity = artesanosCooperativa;
            await _context.ArtesanosCooperativas.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdCooperativa;
        }

        //Aqui asignamos los metodos para un update a un dato en especifico por medio de la ID en la Base de datos para Artesanos Cooperativa
        public async Task<bool> Update(int id, ArtesanosCooperativa artesanosCooperativa)
        {
            if(id <= 0 || artesanosCooperativa == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await BuscarID(id);

            entity.NombreComercio = artesanosCooperativa.NombreComercio;
            entity.Telefono = artesanosCooperativa.Telefono;
            entity.Descripcion = artesanosCooperativa.Descripcion;
            entity.Platillo1 = artesanosCooperativa.Platillo1;
            entity.Platillo2 = artesanosCooperativa.Platillo2;
            entity.Platillo3 = artesanosCooperativa.Platillo3;
            entity.Ubicacion = artesanosCooperativa.Ubicacion;
            entity.GeoUbicacion = artesanosCooperativa.GeoUbicacion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public void EliminarArtesano(int id)
        {
            var Eliminar = _context.ArtesanosCooperativas.FirstOrDefault(i => i.IdCooperativa == id);

            if(Eliminar!=null)
            {
                _context.ArtesanosCooperativas.Remove(Eliminar);
                _context.SaveChanges();
            }
        }

    }
}