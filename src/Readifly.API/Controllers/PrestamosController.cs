using MediatR;
using Microsoft.AspNetCore.Mvc;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;
using Readifly.Application.Features.Prestamos.Commands.RealizarPrestamo;
using Readifly.Application.Features.Prestamos.Commands.RegistrarDevolucion;
using Readifly.Application.Features.Prestamos.Queries.ObtenerPrestamos;

namespace Readifly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrestamosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene los préstamos
        /// </summary>
        /// <param name="usuarioId">ID del usuario (opcional)</param>
        /// <param name="soloActivos">Filtrar solo préstamos activos (opcional)</param>
        /// <returns>Lista de préstamos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoDto>>> GetPrestamos(
            [FromQuery] string? usuarioId = null,
            [FromQuery] bool? soloActivos = null)
        {
            var query = new ObtenerPrestamosQuery 
            { 
                UsuarioId = usuarioId,
                SoloActivos = soloActivos 
            };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Realiza un nuevo préstamo
        /// </summary>
        /// <param name="command">Datos del préstamo</param>
        /// <returns>Préstamo creado</returns>
        [HttpPost]
        public async Task<ActionResult<PrestamoDto>> RealizarPrestamo([FromBody] RealizarPrestamoCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetPrestamos), new { prestamoId = result.Value.Id }, result.Value);
        }

        /// <summary>
        /// Registra la devolución de un préstamo
        /// </summary>
        /// <param name="prestamoId">ID del préstamo</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("{prestamoId}/devolucion")]
        public async Task<ActionResult> RegistrarDevolucion(int prestamoId)
        {
            var command = new RegistrarDevolucionCommand { PrestamoId = prestamoId };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(new { message = "Devolución registrada exitosamente" });
        }
    }
}
