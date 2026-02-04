using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ordenes.Application.DTOS;
using Ordenes.Domain.Entities;
using Ordenes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public int AddNewClient(string nombre, string email)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Orders.sp_cliente_AddNewClient", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int UpdateClientById(int clienteId, string nombre, string email)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Orders.sp_cliente_UpdateClientById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClienteId", clienteId);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int DeleteClientById(int clienteId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Orders.sp_cliente_DeleteClientById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClienteId", clienteId);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public IEnumerable<EClientes> GetClientById(int? clienteId = null)
        {
            var result = new List<EClientes>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Orders.sp_cliente_GetClientById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClienteId", clienteId ?? (object)DBNull.Value);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int clienteIdx = reader["ClienteId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClienteId"]);
                string email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                string nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                DateTime fechaRegistro = reader["FechaRegistro"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(reader["FechaRegistro"]);

                var cliente = new EClientes
                {
                    ClienteId = clienteIdx,
                    Nombre = nombre,
                    Email = email,
                    FechaDeRegistro = fechaRegistro
                };

                result.Add(cliente);
            }

            return result;
        }

        public bool ExistClient(EClientes cliente)
        {
            Boolean respuesta = false;
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Orders.sp_cliente_Exist", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
            SqlParameter ouputValue =  new SqlParameter("@ENCONTRADO",SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(ouputValue);

            conn.Open();
            cmd.ExecuteNonQuery();
            respuesta = ouputValue.Value != DBNull.Value ? Convert.ToBoolean(ouputValue.Value) : false;

            return respuesta;
        }
    }
}
