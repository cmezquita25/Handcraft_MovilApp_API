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
    public class AutoMapperProfileArtesonos : Profile
    {
        public AutoMapperProfileArtesonos()
        {
            //Aqui creamos en mapper para nuestros artesanos cooperativa, con la informacion que mostrara al usuario segun el ArtesanoResponses
            CreateMap<Artesano, ArtesanoRESPONSES>()

            .ForMember(dest => dest.InformacionGeneralArtesano, opt => opt.MapFrom(src => $"El Artesano: {src.NombreArtesano} es dueño del taller: {src.TallerNegocio} con el logotipo: {src.LogotipoNegocio}"))
            .ForMember(dest => dest.LugarArtesano, opt  => opt.MapFrom(src => $"Ubicado en: {src.Ubicacion} actualmente en el municipio: {src.MunicipioLocalidad}"))
            .ForMember(dest => dest.MasInfo, opt => opt.MapFrom(src => $"Para mas informacion del artesano consultar: -  */ -Redes sociales: {src.RedesSociales}"));

            CreateMap<ArtesanoCreateREQUEST, Artesano>();
        }
    }
}