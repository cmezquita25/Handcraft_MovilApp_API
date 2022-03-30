using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handcraft_Route.domain.Interfaces
{
    public interface IArtesanosCOOPRespository
    {
        //Aqui ponemos nuestros metodos async los cuales nos serviran para dar funcionalidad al controller
        Task<IEnumerable<ArtesanosCooperativa>> HCRdatos();
        Task<ArtesanosCooperativa> BuscarID(int id);
        Task<int> create(ArtesanosCooperativa artesanosCooperativa);
        Task<bool> Update(int id, ArtesanosCooperativa artesanosCooperativa);

        void EliminarArtesano(int id);
    }
}
