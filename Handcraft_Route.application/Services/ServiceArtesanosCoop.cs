using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.Interfaces;
using Handcraft_Route.infrastructure.Repositories;

namespace Handcraft_Route.application.Services
{
    public class ServiceArtesanosCoop : IArtesanoCOOPService
    {
        //Aqui implementamos la validacion del Create
        public bool ValidateArtesanoCoop (ArtesanosCooperativa artesanosCooperativa)
        {
            if(string.IsNullOrEmpty(artesanosCooperativa.NombreComercio))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Telefono))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Descripcion))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo1))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo2))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo3))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.GeoUbicacion))
                return false;

            return true;
        }

        public bool ValidateUpdateArtesanosCoop (ArtesanosCooperativa artesanosCooperativa)
        {
            //Aqui implementamos la validacion del Update
            
            if(artesanosCooperativa.IdCooperativa <= 0)
                return false;
                
            if(string.IsNullOrEmpty(artesanosCooperativa.NombreComercio))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Telefono))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Descripcion))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo1))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo2))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Platillo3))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(artesanosCooperativa.GeoUbicacion))
                return false;

            return true;
        }
    }
}