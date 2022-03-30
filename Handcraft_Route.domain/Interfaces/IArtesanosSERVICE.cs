using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;

namespace Handcraft_Route.domain.Interfaces
{
    public interface IArtesanosSERVICE
    {
        //Aqui declaramos los metodos de create y update que se encuentran en los servicios, los cuales validan si los campos estan vacios.
        bool ValidateArtesano (Artesano artesano);
        bool ValidateUpdateArtesano (Artesano artesano);
    }
}