using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.dtos.Responses;
using Handcraft_Route.domain.dtos.Requests;

namespace Handcraft_Route.application.Mappings
{
    public class AutoMapperProfileArtesanosCoop : Profile
    {
        public AutoMapperProfileArtesanosCoop()
        {
            //Aqui creamos en mapper para nuestros artesanos cooperativa, con la informacion que mostrara al usuario segun el ArtesanoCOOPResponses
            CreateMap<ArtesanosCooperativa, ArtesanoCOOPResponses>()

            .ForMember(dest => dest.InformacionGeneralComercio, opt => opt.MapFrom(src => $"El comercio: {src.NombreComercio} se encarga de: {src.Descripcion}"))
            .ForMember(dest => dest.LugarComercio, opt => opt.MapFrom(src => $"Para mayor informacion llamar al numero: {src.Telefono} o visitinos en nuestro comercio mas cercano: {src.Ubicacion}"));

            CreateMap<ArtesanoCOOPCREATERequest, ArtesanosCooperativa>();
        }
    }
}