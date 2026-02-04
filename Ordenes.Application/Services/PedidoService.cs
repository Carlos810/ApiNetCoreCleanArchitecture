using Ordenes.Application.DTOS;
using Ordenes.Domain.Entities;
using Ordenes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public PedidoDTO CrearPedido(int clienteId, IEnumerable<PedidoDetalleDTO> detalles)
        {
            var pedido = new EPedido(clienteId, "CREADO");

            foreach (var d in detalles)
                pedido.AgregarDetalle(d.ProductoId, d.Cantidad, d.PrecioUnitario);

            var creado = _repository.Crear(pedido);

            return new PedidoDTO(
                creado.PedidoId,
                creado.ClienteId,
                creado.FechaPedido,
                creado.Estado,
                creado.Detalles.Select(x =>
                    new PedidoDetalleDTO(x.ProductoId, x.Cantidad, x.PrecioUnitario))
            );
        }

        public IEnumerable<PedidoDTO> ObtenerPedidos()
        {
            return _repository.ObtenerTodos().Select(p =>
                new PedidoDTO(
                    p.PedidoId,
                    p.ClienteId,
                    p.FechaPedido,
                    p.Estado,
                    p.Detalles.Select(d =>
                        new PedidoDetalleDTO(d.ProductoId, d.Cantidad, d.PrecioUnitario)
                )
            ));
        }
    }
}
