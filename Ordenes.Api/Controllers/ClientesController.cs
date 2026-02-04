using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordenes.Application.Clients.Mappers;
using Ordenes.Application.DTOS;
using Ordenes.Application.Services;
using Ordenes.Domain.Entities;
using System.Collections.Generic;

namespace Ordenes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<ClienteDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            IEnumerable<EClientes> ECliente = _service.ObtenerClientePorId(id);
            IEnumerable<ClienteDTO> DtoCliente = ClientMapper.ToListDto(ECliente);
            if (DtoCliente.Count() == 0)
                return NotFound("No se encontró ningun cliente durante la búsqueda.");

            return Ok(DtoCliente);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteDTO>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            int? all = null;
            IEnumerable<ClienteDTO> DtoClientes = ClientMapper.ToListDto(_service.ObtenerClientePorId(all));
            if (DtoClientes.Count() == 0)
                return NotFound("No se encontrarón clientes durante la búsqueda.");

            return Ok(DtoClientes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteDTO),StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] EClientes request)
        {
            bool existClient = _service.ExisteElCliente(request);
            if (existClient) return Conflict(new
            {
                mensaje = "El cliente ya existe"
            });

            var idCliente = _service.CrearCliente(request.Nombre, request.Email);
            if (idCliente <= 0) return BadRequest("No se pudo crear cliente capturado.");
            var cliente = ClientMapper.ToListDto(_service.ObtenerClientePorId(idCliente));
            return Ok(cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put([FromBody] EClientes request)
        {
            IEnumerable<EClientes> ECliente = _service.ObtenerClientePorId(request.ClienteId);
            if (ECliente.Count() == 0) return BadRequest("No se encontró ningún cliente para el cual se deba actualizar información.");
            var idCliente = _service.ActualizarCliente(request.ClienteId, request.Nombre, request.Email);
            var cliente = ClientMapper.ToListDto(_service.ObtenerClientePorId(idCliente));
            return Ok(cliente);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            IEnumerable<EClientes> ECliente = _service.ObtenerClientePorId(id);
            if (ECliente.Count() == 0) return BadRequest("No se encontró ningún cliente el cual se deba eliminar.");
            var result = _service.EliminarCliente(id);
            return Ok(result);
        }
    }
}
