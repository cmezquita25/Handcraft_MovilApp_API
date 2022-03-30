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
    public class ArtesanosSQLrepositorys  : IArtesanosREPOSITORY
    {

        //Conexion de datos
        private readonly CFPHandcraftRouteContext _context;

        public ArtesanosSQLrepositorys(CFPHandcraftRouteContext context)
        {
            _context = context;
        }
        //Aqui mandamos a buscar todos los datos existentes en nuestra base de datos de Artesanos 
        public async Task<IEnumerable<Artesano>> HCRdatos() 
        {
            var artesanos = _context.Artesanos.Select(All => All);
            return await artesanos.ToListAsync();
        }

        //Aqui mandamos a buscar nuestros datos existentes en nuestra base de datos de Artesanos por medio e una ID
        public async Task<Artesano> BuscarID(int id)
        {
            var query = await _context.Artesanos.FirstOrDefaultAsync(co => co.IdArtesanos == id);
            return query;
        }

        //Aqui asignamos los metodos para un create de datos en la Base de datos para Artesanos
        public async Task<int> create(Artesano artesano)
        {
            var entity = artesano;
            await _context.Artesanos.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdArtesanos;
        }

        //Aqui asignamos los metodos para un update a un dato en especifico por medio de la ID en la Base de datos para Artesanos
        public async Task<bool> Update(int id, Artesano artesano)
        {
            if(id <= 0 || artesano == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await BuscarID(id);

            entity.NombreArtesano = artesano.NombreArtesano;
            entity.MunicipioLocalidad = artesano.MunicipioLocalidad;
            entity.TallerNegocio = artesano.TallerNegocio;
            entity.LogotipoNegocio = artesano.LogotipoNegocio;
            //entity.Correo = artesano.Correo;
            entity.RedesSociales = artesano.RedesSociales;
            entity.Ubicacion = artesano.Ubicacion;
            entity.GeoUbicacion = artesano.GeoUbicacion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public void EliminarArtesano(int id)
        {
            var Eliminar = _context.Artesanos.FirstOrDefault(i => i.IdArtesanos == id);

            if(Eliminar!=null)
            {
                _context.Artesanos.Remove(Eliminar);
                _context.SaveChanges();
            }
        }
    }
}