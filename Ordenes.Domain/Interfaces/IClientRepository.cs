using Ordenes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Domain.Interfaces
{
    public interface IClientRepository
    {
        int AddNewClient(string nombre, string email);
        int UpdateClientById(int clienteId, string nombre, string email);
        int DeleteClientById(int clienteId);
        IEnumerable<EClientes> GetClientById(int? clienteId = null);
        bool ExistClient(EClientes cliente);
    }
}
