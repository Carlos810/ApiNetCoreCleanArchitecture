using Ordenes.Application.DTOS;
using Ordenes.Domain.Entities;
using Ordenes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.Services
{
    public class ClienteService
    {
        private readonly IClientRepository _repository;

        public ClienteService(IClientRepository repository)
        {
            _repository = repository;
        }

        public int CrearCliente(string nombre, string email)
            => _repository.AddNewClient(nombre, email);

        public int ActualizarCliente(int clienteId, string nombre, string email)
            => _repository.UpdateClientById(clienteId, nombre, email);

        public int EliminarCliente(int clienteId)
            => _repository.DeleteClientById(clienteId);

        public IEnumerable<EClientes> ObtenerClientePorId(int? clienteId = null)
            => _repository.GetClientById(clienteId);
        public bool ExisteElCliente(EClientes cliente)
            => _repository.ExistClient(cliente);
    }
}
