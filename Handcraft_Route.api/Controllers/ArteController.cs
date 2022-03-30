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

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre del Proyecto: Handcraft Ruoute
Integrantes:
- Carlos M Mezquita Alvarado
- Fabian F Aguilar Rivero
- Pedro V Ruvalcaba Novelo
Cuatrimestre: 4
Grupo: B
Parcial: 3
*/

namespace Handcraft_Route.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArteController : ControllerBase
    {
        //Constructores
        private readonly IArtesanosREPOSITORY _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IArtesanosSERVICE _service;
        private readonly IValidator<ArtesanoCreateREQUEST> _createValidator;

        public ArteController(IArtesanosREPOSITORY repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        IArtesanosSERVICE service, 
        IValidator<ArtesanoCreateREQUEST> createValidator)
        
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }

        //TODOS LOS DATOS DE LA TABLA ARTESANOS 
        [HttpGet]
        [Route("Todos_los_datos")]
        public async Task<IActionResult> HCRdatos()
        {
            var query = await _repository.HCRdatos();
            //var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            // var Respuestaquery = _mapper.Map<IEnumerable<Artesano>,IEnumerable<ArtesanoRESPONSES>>(query);
            return Ok(query);
        }

        //BUSCAR POR ID EN ARTESANO 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarID(int id)
        {
            var query = await _repository.BuscarID(id);

            if(query == null)
                return NotFound("Lo sentimos, registro no encontrado.");

            // var respuestaid = _mapper.Map<Artesano, ArtesanoRESPONSES>(query);

            return Ok(query);
        }

        //ACTUALIZACION DE DATOS EN LA TABLA DE ARTESANOS 
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Artesano artesano)
        {
            if(id <= 0)
                return NotFound("No se encontro el regsitro.");
            
            artesano.IdArtesanos = id;

            var Validate = _service.ValidateUpdateArtesano(artesano);

            if(!Validate)
                UnprocessableEntity("No es posible actualizar la informacion.");
            
            var updated = await _repository.Update(id, artesano);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el registro.");
            
            return Ok(artesano);
        }

        //CREACION O REGISTRO E DATOS EN LA TABLA DE ARTESANOS 
        [HttpPost]
        
        public async Task<IActionResult> create(ArtesanoCreateREQUEST artesanoCreateREQUEST)
        {
            
            var Validate = await _createValidator.ValidateAsync(artesanoCreateREQUEST);

            if(!Validate.IsValid)
                return UnprocessableEntity (Validate.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<ArtesanoCreateREQUEST, Artesano>(artesanoCreateREQUEST);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el al intentar registrar, Por Favor intente de nuevo.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/ArteCoop/{id}";
            return Ok(artesanoCreateREQUEST);
        }

        [HttpDelete]
        [Route("EliminarArte/{id:int}")]
        public IActionResult EliminarArte(int id)
        {
            _repository.EliminarArtesano(id);

            return NoContent();
        }
    }
}
