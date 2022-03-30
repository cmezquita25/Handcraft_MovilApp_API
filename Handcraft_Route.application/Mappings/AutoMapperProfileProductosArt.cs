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
    public class AutoMapperProfileProductosArt : Profile
    {
        public AutoMapperProfileProductosArt()
        {
            //Aqui creamos en mapper para nuestros productos de artesanos, con la informacion que mostrara al usuario segun el ProductosArtResponses
            CreateMap<ProductosArtesano, ProductoArtRESPONSES>()

            .ForMember(dest => dest.InformacionGeneralProducto, opt => opt.MapFrom(src => $"El producto: {src.NombreProducto} elaborado con: {src.MaterialElaborado}"))
            .ForMember(dest => dest.DetallesProducto, opt => opt.MapFrom(src => $"Mas informacion: {src.Descripcion} -Fotografia: {src.Fotografia}"));

            CreateMap<ProductoArtCreateREQUEST, ProductosArtesano>();
        }
    }
}