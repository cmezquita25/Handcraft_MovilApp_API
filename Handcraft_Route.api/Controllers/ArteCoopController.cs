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
    [Route("[controller]")]
    public class ArteCoopController : ControllerBase
    {
        //Constructores
        private readonly IArtesanosCOOPRespository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IArtesanoCOOPService _service;
        private readonly IValidator<ArtesanoCOOPCREATERequest> _createValidator;

        public ArteCoopController(IArtesanosCOOPRespository repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        IArtesanoCOOPService service, 
        IValidator<ArtesanoCOOPCREATERequest> createValidator)
        
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }

        //TODOS LOS DATOS DE LA TABLA ARTESANOS COOPERATIVA
        [HttpGet]
        [Route("Todos_los_datos")]
        public async Task<IActionResult> HCRdatos()
        {
            var query = await _repository.HCRdatos();
            //var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            // var Respuestaquery = _mapper.Map<IEnumerable<ArtesanosCooperativa>,IEnumerable<ArtesanoCOOPResponses>>(query);
            return Ok(query);
        }

        //BUSCAR POR ID EN ARTESANO COOPERATIVA
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarID(int id)
        {
            var query = await _repository.BuscarID(id);

            if(query == null)
                return NotFound("Lo sentimos, registro no encontrado.");

            // var respuestaid = _mapper.Map<ArtesanosCooperativa, ArtesanoCOOPResponses>(query);

            return Ok(query);
        }

        //ACTUALIZACION DE DATOS EN LA TABLA DE ARTESANOS COOPERATIVA
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]ArtesanosCooperativa artesanosCooperativa)
        {
            if(id <= 0)
                return NotFound("No se encontro el regsitro.");
            
            artesanosCooperativa.IdCooperativa = id;

            var Validate = _service.ValidateUpdateArtesanosCoop(artesanosCooperativa);

            if(!Validate)
                UnprocessableEntity("No es posible actualizar la informacion.");
            
            var updated = await _repository.Update(id, artesanosCooperativa);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el registro.");
            
            return Ok(artesanosCooperativa);
        }

        //CREACION O REGISTRO E DATOS EN LA TABLA DE ARTESANOS COOPERATIVA
        [HttpPost]
        
        public async Task<IActionResult> create(ArtesanoCOOPCREATERequest artesanoCOOPCREATERequest)
        {
            
            var Validate = await _createValidator.ValidateAsync(artesanoCOOPCREATERequest);

            if(!Validate.IsValid)
                return UnprocessableEntity (Validate.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<ArtesanoCOOPCREATERequest, ArtesanosCooperativa>(artesanoCOOPCREATERequest);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el al intentar registrar, Por Favor intente de nuevo.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/ArteCoop/{id}";
            return Ok(artesanoCOOPCREATERequest);
        }


        [HttpDelete]
        [Route("EliminarArteCoop/{id:int}")]
        public IActionResult EliminarArteCoop(int id)
        {
            _repository.EliminarArtesano(id);

            return NoContent();
        }
    }
}
