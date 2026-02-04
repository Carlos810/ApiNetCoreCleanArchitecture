using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordenes.Application.DTOS;
using Ordenes.Application.Services;

namespace Ordenes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Obtiene todos los pedidos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var pedidos = _pedidoService.ObtenerPedidos();
            return Ok(pedidos);
        }

        ///// <summary>
        ///// Obtiene un pedido por su id
        ///// </summary>
        //[HttpGet("{pedidoId:int}")]
        //[ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetById(int pedidoId)
        //{
        //    var pedido = _pedidoService.ObtenerPorId(pedidoId);

        //    if (pedido == null)
        //        return NotFound();

        //    return Ok(pedido);
        //}

        ///// <summary>
        ///// Crea un nuevo pedido
        ///// </summary>
        //[HttpPost]
        //[ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Post([FromBody] CrearPedidoRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var detallesDto = request.Detalles.Select(d =>
        //        new PedidoDetalleDTO(
        //            d.ProductoId,
        //            d.Cantidad,
        //            d.PrecioUnitario
        //        )
        //    );

        //    var pedidoCreado = _pedidoService.CrearPedido(
        //        request.ClienteId,
        //        detallesDto
        //    );

        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { pedidoId = pedidoCreado.PedidoId },
        //        pedidoCreado
        //    );
        //}
    }
}
