using MediatR;
using Microsoft.AspNetCore.Mvc;
using Readifly.Application.Common.Models;
using Readifly.Application.DTOs;
using Readifly.Application.Features.Materiales.Commands.CrearLibro;
using Readifly.Application.Features.Materiales.Commands.CrearRevista;
using Readifly.Application.Features.Materiales.Queries.ObtenerMateriales;
using Readifly.Application.Features.Materiales.Queries.ObtenerMaterialPorIsbn;

namespace Readifly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todos los materiales bibliográficos
        /// </summary>
        /// <param name="soloDisponibles">Filtrar solo materiales disponibles</param>
        /// <returns>Lista de materiales bibliográficos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialBibliograficoDto>>> GetMateriales([FromQuery] bool? soloDisponibles = null)
        {
            var query = new ObtenerMaterialesQuery { SoloDisponibles = soloDisponibles };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Obtiene un material bibliográfico por ISBN
        /// </summary>
        /// <param name="isbn">ISBN del material</param>
        /// <returns>Material bibliográfico</returns>
        [HttpGet("{isbn}")]
        public async Task<ActionResult<MaterialBibliograficoDto>> GetMaterialPorIsbn(string isbn)
        {
            var query = new ObtenerMaterialPorIsbnQuery { ISBN = isbn };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Crea un nuevo libro
        /// </summary>
        /// <param name="command">Datos del libro</param>
        /// <returns>Libro creado</returns>
        [HttpPost("libros")]
        public async Task<ActionResult<LibroDto>> CrearLibro([FromBody] CrearLibroCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetMaterialPorIsbn), new { isbn = result.Value.ISBN }, result.Value);
        }

        /// <summary>
        /// Crea una nueva revista
        /// </summary>
        /// <param name="command">Datos de la revista</param>
        /// <returns>Revista creada</returns>
        [HttpPost("revistas")]
        public async Task<ActionResult<RevistaDto>> CrearRevista([FromBody] CrearRevistaCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetMaterialPorIsbn), new { isbn = result.Value.ISBN }, result.Value);
        }
    }
}
