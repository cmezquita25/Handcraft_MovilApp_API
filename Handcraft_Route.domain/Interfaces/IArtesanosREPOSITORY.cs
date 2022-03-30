using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handcraft_Route.domain.Interfaces
{
    public interface IArtesanosREPOSITORY
    {
                //Aqui ponemos nuestros metodos async los cuales no serviran para dar funcionalidad al controller
        Task<IEnumerable<Artesano>> HCRdatos();
        Task<Artesano> BuscarID(int id);
        Task<int> create(Artesano artesano);
        Task<bool> Update(int id, Artesano artesano);

        void EliminarArtesano(int id);
    }
}