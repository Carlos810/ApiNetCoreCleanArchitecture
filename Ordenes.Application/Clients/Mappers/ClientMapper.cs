using Ordenes.Application.DTOS;
using Ordenes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.Clients.Mappers
{
    public static class ClientMapper
    {
        public static ClienteDTO ToDto( EClientes entity)
        {
            return new ClienteDTO
            {
                Nombre = entity.Nombre,
                Email = entity.Email,
                FechaRegistro = entity.FechaDeRegistro
            };
        }

        public static IEnumerable<ClienteDTO> ToListDto(IEnumerable<EClientes> entityClientes)
        {
            return entityClientes.Select(e => ToDto(e));
        }   

    }
}
