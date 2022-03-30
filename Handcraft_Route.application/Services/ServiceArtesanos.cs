using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.Interfaces;
using Handcraft_Route.infrastructure.Repositories;

namespace Handcraft_Route.application.Services
{
    public class ServiceArtesanos : IArtesanosSERVICE
    {
        //Aqui implementamos la validacion del Create
        public bool ValidateArtesano (Artesano artesano)
        {
            if(string.IsNullOrEmpty(artesano.NombreArtesano))
                return false;

            if(string.IsNullOrEmpty(artesano.MunicipioLocalidad))
                return false;

            if(string.IsNullOrEmpty(artesano.TallerNegocio))
                return false;

            if(string.IsNullOrEmpty(artesano.LogotipoNegocio))
                return false;

            if(string.IsNullOrEmpty(artesano.RedesSociales))
                return false;

            if(string.IsNullOrEmpty(artesano.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(artesano.GeoUbicacion))
                return false;

            return true;
        }

        public bool ValidateUpdateArtesano (Artesano artesano)
        {
            //Aqui implementamos la validacion del Update
            
            if(artesano.IdArtesanos <= 0)
                return false;
                
            if(string.IsNullOrEmpty(artesano.NombreArtesano))
                return false;

            if(string.IsNullOrEmpty(artesano.MunicipioLocalidad))
                return false;

            if(string.IsNullOrEmpty(artesano.TallerNegocio))
                return false;

            if(string.IsNullOrEmpty(artesano.LogotipoNegocio))
                return false;


            if(string.IsNullOrEmpty(artesano.RedesSociales))
                return false;

            if(string.IsNullOrEmpty(artesano.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(artesano.GeoUbicacion))
                return false;

            return true;
        }
    }
}