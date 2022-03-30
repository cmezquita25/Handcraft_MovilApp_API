using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Handcraft_Route.infrastructure.Repositories;
using Handcraft_Route.domain.Entities;
using Handcraft_Route.domain.dtos;
using Handcraft_Route.domain.dtos.Responses;
using Handcraft_Route.domain.dtos.Requests;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Handcraft_Route.domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace Handcraft_Route.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtesanoProductController : ControllerBase
    {
        //Constructores
        private readonly IProductosArtREPOSITORY _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IProductoArtSERVICE _service;
        private readonly IValidator<ProductoArtCreateREQUEST> _createValidator;

        public ArtesanoProductController(IProductosArtREPOSITORY repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        IProductoArtSERVICE service, 
        IValidator<ProductoArtCreateREQUEST> createValidator)
        
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }

        //TODOS LOS DATOS DE LA TABLA PRODUCTO ARTESANOS 
        [HttpGet]
        [Route("Todos_los_datos")]
        public async Task<IActionResult> HCRdatos()
        {
            var query = await _repository.HCRdatos();
            //var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            var Respuestaquery = _mapper.Map<IEnumerable<ProductosArtesano>,IEnumerable<ProductoArtRESPONSES>>(query);
            return Ok(query);
        }

        //BUSCAR POR ID EN PRODUCTO ARTESANO 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarID(int id)
        {
            var query = await _repository.BuscarID(id);

            if(query == null)
                return NotFound("Lo sentimos, registro no encontrado.");

            var respuestaid = _mapper.Map<ProductosArtesano, ProductoArtRESPONSES>(query);

            return Ok(query);
        }

        //ACTUALIZACION DE DATOS EN LA TABLA DE PRODUCTO ARTESANOS 
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]ProductosArtesano productosArtesano)
        {
            if(id <= 0)
                return NotFound("No se encontro el regsitro.");
            
            productosArtesano.IdProductos = id;

            var Validate = _service.ValidateUpdateProductosArt(productosArtesano);

            if(!Validate)
                UnprocessableEntity("No es posible actualizar la informacion.");
            
            var updated = await _repository.Update(id, productosArtesano);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el registro.");
            
            return Ok(productosArtesano);
        }

        //CREACION O REGISTRO E DATOS EN LA TABLA DE PRODUCTO ARTESANOS 
        [HttpPost]
        
        public async Task<IActionResult> create(ProductoArtCreateREQUEST productoArtCreateREQUEST)
        {
            
            var Validate = await _createValidator.ValidateAsync(productoArtCreateREQUEST);

            if(!Validate.IsValid)
                return UnprocessableEntity (Validate.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<ProductoArtCreateREQUEST, ProductosArtesano>(productoArtCreateREQUEST);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el al intentar registrar, Por Favor intente de nuevo.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/ArteCoop/{id}";
            return Ok(productoArtCreateREQUEST);
        }


        [HttpDelete]
        [Route("EliminarProducto/{id:int}")]
        public IActionResult EliminarProducto(int id)
        {
            _repository.EliminarArtesano(id);

            return NoContent();
        }
    }
}